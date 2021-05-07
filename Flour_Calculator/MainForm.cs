using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flour_Calculator
{
    public partial class MainForm : Form
    {
        /*
            units[0] = SorghumComboBox.Text;
            units[1] = XanthumGumComboBox.Text;
            units[2] = SweetWhiteRiceComboBox.Text;
            units[3] = CreamOfTartarComboBox.Text;
            units[4] = WhiteRiceComboBox.Text;
            units[5] = BrownRiceComboBox.Text;
            units[6] = BakingSodaComboBox.Text;
            units[7] = BakingPowderComboBox.Text;
            units[8] = PotatoStarchComboBox.Text;
            units[9] = TapiocaStarchComboBox.Text;
            units[10] = GarbanzoComboBox.Text;
            units[11] = MilletComboBox.Text;
            units[12] = SaltComboBox.Text;
            units[13] = ButtermilkPowderComboBox.Text;
            units[14] = FlaxComboBox.Text;

            // Actually validate the data!
            if (
               (Decimal.TryParse(SorghumTextBox.Text, out amounts[0]) == false)
            || (Decimal.TryParse(XanthumGumTextBox.Text, out amounts[1]) == false)
            || (Decimal.TryParse(SweetWhiteRiceTextBox.Text, out amounts[2]) == false)
            || (Decimal.TryParse(CreamOfTartarTextBox.Text, out amounts[3]) == false)
            || (Decimal.TryParse(WhiteRiceTextBox.Text, out amounts[4]) == false)
            || (Decimal.TryParse(BrownRiceTextBox.Text, out amounts[5]) == false)
            || (Decimal.TryParse(BakingSodaTextBox.Text, out amounts[6]) == false)
            || (Decimal.TryParse(BakingPowderTextBox.Text, out amounts[7]) == false)
            || (Decimal.TryParse(AlmondMealTextBox.Text, out amounts[8]) == false)
            || (Decimal.TryParse(TapiocaStarchTextBox.Text, out amounts[9]) == false)
            || (Decimal.TryParse(GarbanzoTextBox.Text, out amounts[10]) == false)
            || (Decimal.TryParse(MilletTextBox.Text, out amounts[11]) == false)
            || (Decimal.TryParse(SaltTextBox.Text, out amounts[12]) == false)
            || (Decimal.TryParse(ButtermilkPowderTextBox.Text, out amounts[13]) == false)
            || (Decimal.TryParse(FlaxTextBox.Text, out amounts[14]) == false))
            {
                MessageBox.Show("One or more of your inputs is not a valid number!", "Invalid Input");
            }
            else
            {
                // If we are here, we have at least valid values!
                // Check for negative or too large numbers!
                for (int i = 0; i < 15; i++)
                {
                    if (amounts[i] < 0)
                    {
                        MessageBox.Show("One of your inputs is too small.  Please make sure to enter in no less than '0' into each input box!", "Invalid Input");
                        break;
                    }
                    else if (amounts[i] > 1000000)
                    {
                        MessageBox.Show("One of your inputs is too large.  Please do not enter anything larger than 1 million!", "Invalid Input");
                        break;
                    }
                }
            }

            Convert();

            //ExitButton.Enabled = true;
            //calculateButton.Enabled = true;
            //FlourOnHandButton.Enabled = true;

            //Form needFlour = new NeedFlour();

            //this.Close();
            //needFlour.ShowDialog();
            */



        // The amounts array holds the decimal number of the following ingredients in that order - with their units specified in the units array
        // Sorghum, Xanthum Gum, Sweet White Rice, Cream of Tartar, White Rice, Brown Rice, Baking Soda, Baking Powder,
        // Potato Starch, Tapioca Starch, Garbanzo, Millet, Salt, Buttermilk Powder, Flax, Almond Meal, Blanched Almond Meal
        // The possible units are: grams, kilograms, ounces, pounds
        // Contains numbers of each ingredient that we already have
        private decimal[] amountsHave;
        // Contains the size of the bags that we want our answer in
        private decimal[] amountsWant;
        // Contains the amount of each ingredient that is requested/needed
        private decimal[] amountsNeed;
        // Contains the units of each ingredient that we already have
        private string[] unitsHave;
        // Contains the units of the bags that we want our answer in
        private string[] unitsWant;
        // Contains the units of each ingredient that is requested/needed
        private readonly string[] unitsNeed; 
        
        const int numIngredients = 17;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to close this application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }       
        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Display Instructions Form
        }
        private void CreditsButton_Click(object sender, EventArgs e)
        {
            // Display Credits Form
        }
        
        private void UnitsButton_Click(object sender, EventArgs e)
        {
            using (FlourUnitNeededForm frm = new FlourUnitNeededForm())
            {
                frm.ShowDialog();

                amountsWant = frm.GetAmountsWant;
                unitsWant = frm.GetUnitsWant;
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }
        private void PossessedIngredientsButton_Click(object sender, EventArgs e)
        {
            using (FlourPossessedForm frm = new FlourPossessedForm())
            {
                frm.ShowDialog();

                amountsHave = frm.GetAmountsHave;
                unitsHave = frm.GetUnitsHave;
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }
        private void FlourNeededButton_Click(object sender, EventArgs e)
        {
            using (FlourNeededForm frm = new FlourNeededForm())
            {
                frm.ShowDialog();
                
                amountsNeed = frm.GetAmountsNeed;                
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            // We don't want the user to be able to push anything while we are calculating everything!
            UnitsButton.Enabled = false;
            PossessedIngredientsButton.Enabled = false;
            FlourNeededButton.Enabled = false;
            ExitButton.Enabled = false;
            InstructionsButton.Enabled = false;
            CreditsButton.Enabled = false;

            if (ValidateData() == true)
            {
                decimal[] tempArr = new decimal[numIngredients];

                //Convert To Grams
                for (int i = 0; i < numIngredients; i++)
                {
                    if (unitsNeed[i] == "pound")
                        amountsNeed[i] *= 453.59237m;
                    if (unitsNeed[i] == "kilogram")
                        amountsNeed[i] *= 1000.0m;
                    if (unitsNeed[i] == "ounce")
                        amountsNeed[i] *= 28.34952m;
                    unitsNeed[i] = "gram";

                    if (unitsHave[i] == "pound")
                        amountsHave[i] *= 453.59237m;
                    if (unitsHave[i] == "kilogram")
                        amountsHave[i] *= 1000.0m;
                    if (unitsHave[i] == "ounce")
                        amountsHave[i] *= 28.34952m;
                    unitsHave[i] = "gram";
                }
                
                decimal tempNum;
                for (int i = 0; i < numIngredients; i++)
                {
                    tempNum = amountsNeed[i] - amountsHave[i];
                    if (tempNum <= 0)
                        tempArr[i] = 0.0m;
                    else
                        tempArr[i] = tempNum;
                }
                
                // Now convert back to correct units
                for (int i = 0; i < numIngredients; i++)
                {
                    if (unitsWant[i] == "pound")
                        tempArr[i] /= 453.59237m;
                    if (unitsWant[i] == "kilogram")
                        tempArr[i] /= 1000.0m;
                    if (unitsWant[i] == "ounce")
                        tempArr[i] /= 28.34952m;
                    // Convert to correct amount of unit
                    tempArr[i] /= amountsWant[i];
                    // Round up
                   tempArr[i] = Math.Ceiling(tempArr[i]);
                }
                DisplayData(tempArr);
            }

            // Now we can enable all the buttons
            UnitsButton.Enabled = true;
            PossessedIngredientsButton.Enabled = true;
            FlourNeededButton.Enabled = true;
            ExitButton.Enabled = true;
            InstructionsButton.Enabled = true;
            CreditsButton.Enabled = true;
        }

        private bool ValidateData()
        {
            for (int i = 0; i < numIngredients; i++)
            {
                if ((amountsWant[i] == -1) || (amountsWant[i] > 1000000))
                {
                    MessageBox.Show("One or more of your numbers for the size of bag you want is invalid!", "Invalid Input");
                    return false;
                }
            }
            for (int i = 0; i < numIngredients; i++)
            {
                if ((amountsHave[i] == -1) || (amountsHave[i] > 1000000))
                {
                    MessageBox.Show("One or more of your numbers for the amount of ingriends you already have is invalid!", "Invalid Input");
                    return false;
                }
            }
            return true;
        }
        private void DisplayData(decimal[] final)
        {
            string[] tempArr = new string[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                tempArr[i] = final[i].ToString() + amountsWant[i].ToString() + "-" + unitsWant[i] + "units";
            }

            SorghumTextBox.Text             = tempArr[0];
            XanthumGumTextBox.Text          = tempArr[1];
            SweetWhiteRiceTextBox.Text      = tempArr[2];
            CreamOfTartarTextBox.Text       = tempArr[3];
            WhiteRiceTextBox.Text           = tempArr[4];
            BrownRiceTextBox.Text           = tempArr[5];
            BakingSodaTextBox.Text          = tempArr[6];
            BakingPowderTextBox.Text        = tempArr[7];
            AlmondMealTextBox.Text          = tempArr[8];
            TapiocaStarchTextBox.Text       = tempArr[9];
            GarbanzoTextBox.Text            = tempArr[10];
            MilletTextBox.Text              = tempArr[11];
            SaltTextBox.Text                = tempArr[12];
            ButtermilkPowderTextBox.Text    = tempArr[13];
            FlaxTextBox.Text                = tempArr[14];
            AlmondMealTextBox.Text          = tempArr[15];
            BlanchedAlmondMealTextBox.Text  = tempArr[16];
        }        

        private void MainForm_Load(object sender, EventArgs e)
        {
            // We don't want the user to be able to push anything while we are loading everything!
            UnitsButton.Enabled = false;
            PossessedIngredientsButton.Enabled = false;
            FlourNeededButton.Enabled = false;
            ExitButton.Enabled = false;
            InstructionsButton.Enabled = false;
            CreditsButton.Enabled = false;

            // Initialize arrays
            for (int i = 0; i < numIngredients; i++)
            {
                unitsHave[i] = "grams";
                unitsWant[i] = "grams";
                amountsHave[i] = -1;
                amountsWant[i] = -1;
            }
            
            // Declare the sizes of the arrays
            amountsHave = new decimal[numIngredients];
            amountsWant = new decimal[numIngredients];
            unitsHave = new string[numIngredients];           
            unitsWant = new string[numIngredients];

            // Now we can enable all the buttons
            UnitsButton.Enabled = true;
            PossessedIngredientsButton.Enabled = true;
            FlourNeededButton.Enabled = true;
            ExitButton.Enabled = true;
            InstructionsButton.Enabled = true;
            CreditsButton.Enabled = true;
        }        
    }
}
