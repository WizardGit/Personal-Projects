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
    public partial class FlourPossessedForm : Form
    {
        public FlourPossessedForm()
        {
            InitializeComponent();
        }

        // The amounts array holds the decimal number of the following ingredients in that order - with their units specified in the units array
        // Sorghum, Xanthum Gum, Sweet White Rice, Cream of Tartar, White Rice, Brown Rice, Baking Soda, Baking Powder,
        // Potato Starch, Tapioca Starch, Garbanzo, Millet, Salt, Buttermilk Powder, Flax, Almond Meal, Blanched Almond Meal
        private decimal[] amountsHave;
        private decimal[] unitSize;
        private string[] unitsHave;
        const int numIngredients = 17;

        public decimal[] GetAmountsHave
        {
            get
            {
                return amountsHave;
            }
        }
        public string[] GetUnitsHave
        {
            get
            {
                return unitsHave;
            }
        }

        private bool InputData()
        {
            unitsHave[0] = SorghumComboBox.Text;
            unitsHave[1] = XanthumGumComboBox.Text;
            unitsHave[2] = SweetWhiteRiceComboBox.Text;
            unitsHave[3] = CreamOfTartarComboBox.Text;
            unitsHave[4] = WhiteRiceComboBox.Text;
            unitsHave[5] = BrownRiceComboBox.Text;
            unitsHave[6] = BakingSodaComboBox.Text;
            unitsHave[7] = BakingPowderComboBox.Text;
            unitsHave[8] = PotatoStarchComboBox.Text;
            unitsHave[9] = TapiocaStarchComboBox.Text;
            unitsHave[10] = GarbanzoComboBox.Text;
            unitsHave[11] = MilletComboBox.Text;
            unitsHave[12] = SaltComboBox.Text;
            unitsHave[13] = ButtermilkPowderComboBox.Text;
            unitsHave[14] = FlaxComboBox.Text;
            unitsHave[15] = AlmondMealComboBox.Text;
            unitsHave[16] = BlanchedAlmondMealComboBox.Text;

            // Actually validate the data!
            if (
               (Decimal.TryParse(SorghumAmountTextBox.Text, out amountsHave[0]) == false)
            || (Decimal.TryParse(XanthumGumAmountTextBox.Text, out amountsHave[1]) == false)
            || (Decimal.TryParse(SweetWhiteRiceAmountTextBox.Text, out amountsHave[2]) == false)
            || (Decimal.TryParse(CreamOfTartarAmountTextBox.Text, out amountsHave[3]) == false)
            || (Decimal.TryParse(WhiteRiceAmountTextBox.Text, out amountsHave[4]) == false)
            || (Decimal.TryParse(BrownRiceAmountTextBox.Text, out amountsHave[5]) == false)
            || (Decimal.TryParse(BakingSodaAmountTextBox.Text, out amountsHave[6]) == false)
            || (Decimal.TryParse(BakingPowderAmountTextBox.Text, out amountsHave[7]) == false)
            || (Decimal.TryParse(PotatoStarchAmountTextBox.Text, out amountsHave[8]) == false)
            || (Decimal.TryParse(TapiocaStarchAmountTextBox.Text, out amountsHave[9]) == false)
            || (Decimal.TryParse(GarbanzoAmountTextBox.Text, out amountsHave[10]) == false)
            || (Decimal.TryParse(MilletAmountTextBox.Text, out amountsHave[11]) == false)
            || (Decimal.TryParse(SaltAmountTextBox.Text, out amountsHave[12]) == false)
            || (Decimal.TryParse(ButtermilkPowderAmountTextBox.Text, out amountsHave[13]) == false)
            || (Decimal.TryParse(FlaxAmountTextBox.Text, out amountsHave[14]) == false)
            || (Decimal.TryParse(AlmondMealAmountTextBox.Text, out amountsHave[15]) == false)
            || (Decimal.TryParse(BlanchedAlmondMealAmountTextBox.Text, out amountsHave[16]) == false)
            || (Decimal.TryParse(SorghumAmountTextBox.Text, out unitSize[0]) == false) // Start Over! UGH
            || (Decimal.TryParse(XanthumGumAmountTextBox.Text, out unitSize[1]) == false)
            || (Decimal.TryParse(SweetWhiteRiceAmountTextBox.Text, out unitSize[2]) == false)
            || (Decimal.TryParse(CreamOfTartarAmountTextBox.Text, out unitSize[3]) == false)
            || (Decimal.TryParse(WhiteRiceAmountTextBox.Text, out unitSize[4]) == false)
            || (Decimal.TryParse(BrownRiceAmountTextBox.Text, out unitSize[5]) == false)
            || (Decimal.TryParse(BakingSodaAmountTextBox.Text, out unitSize[6]) == false)
            || (Decimal.TryParse(BakingPowderAmountTextBox.Text, out unitSize[7]) == false)
            || (Decimal.TryParse(PotatoStarchAmountTextBox.Text, out unitSize[8]) == false)
            || (Decimal.TryParse(TapiocaStarchAmountTextBox.Text, out unitSize[9]) == false)
            || (Decimal.TryParse(GarbanzoAmountTextBox.Text, out unitSize[10]) == false)
            || (Decimal.TryParse(MilletAmountTextBox.Text, out unitSize[11]) == false)
            || (Decimal.TryParse(SaltAmountTextBox.Text, out unitSize[12]) == false)
            || (Decimal.TryParse(ButtermilkPowderAmountTextBox.Text, out unitSize[13]) == false)
            || (Decimal.TryParse(FlaxAmountTextBox.Text, out unitSize[14]) == false)
            || (Decimal.TryParse(AlmondMealAmountTextBox.Text, out unitSize[15]) == false)
            || (Decimal.TryParse(BlanchedAlmondMealAmountTextBox.Text, out unitSize[16]) == false))
            {
                MessageBox.Show("One or more of your inputs is not a valid number!", "Invalid Input");
                return false;
            }
            else
            {
                // If we are here, we have at least valid values!
                // Check for negative or too large numbers!
                for (int i = 0; i < numIngredients; i++)
                {
                    if ((amountsHave[i] < 0) || (unitSize[i] < 0))
                    {
                        MessageBox.Show("One ore more of your inputs is too small.  Please make sure to enter in no less than '0' into each input box!", "Invalid Input");
                        return false;
                    }
                    else if ((amountsHave[i] > 1000000) || (unitSize[i] > 1000000))
                    {
                        MessageBox.Show("One or more of your inputs is too large.  Please do not enter anything larger than 1 million!", "Invalid Input");
                        return false;
                    }
                }
            }
            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (InputData() == true)
            {
                //Convert To Grams
                for (int i = 0; i < numIngredients; i++)
                {
                    amountsHave[i] *= unitSize[i];
                }
            }
        }             

        // Initilizes the text boxes and arrays with default values
        private void InitializeData()
        {
            SorghumAmountTextBox.Text = "0";
            XanthumGumAmountTextBox.Text = "0";
            SweetWhiteRiceAmountTextBox.Text = "0";
            CreamOfTartarAmountTextBox.Text = "0";
            WhiteRiceAmountTextBox.Text = "0";
            BrownRiceAmountTextBox.Text = "0";
            BakingSodaAmountTextBox.Text = "0";
            BakingPowderAmountTextBox.Text = "0";
            PotatoStarchAmountTextBox.Text = "0";
            TapiocaStarchAmountTextBox.Text = "0";
            GarbanzoAmountTextBox.Text = "0";
            MilletAmountTextBox.Text = "0";
            SaltAmountTextBox.Text = "0";
            ButtermilkPowderAmountTextBox.Text = "0";
            FlaxAmountTextBox.Text = "0";
            AlmondMealAmountTextBox.Text = "0";
            BlanchedAlmondMealAmountTextBox.Text = "0";

            SorghumUnitTextBox.Text = "25";
            XanthumGumUnitTextBox.Text = "25";
            SweetWhiteRiceUnitTextBox.Text = "25";
            CreamOfTartarUnitTextBox.Text = "25";
            WhiteRiceUnitTextBox.Text = "25";
            BrownRiceUnitTextBox.Text = "25";
            BakingSodaUnitTextBox.Text = "25";
            BakingPowderUnitTextBox.Text = "25";
            PotatoStarchUnitTextBox.Text = "25";
            TapiocaStarchUnitTextBox.Text = "25";
            GarbanzoUnitTextBox.Text = "25";
            MilletUnitTextBox.Text = "25";
            SaltUnitTextBox.Text = "25";
            ButtermilkPowderUnitTextBox.Text = "25";
            FlaxUnitTextBox.Text = "25";
            AlmondMealUnitTextBox.Text = "25";
            BlanchedAlmondMealUnitTextBox.Text = "25";

            SorghumComboBox.SelectedIndex = 2;
            XanthumGumComboBox.SelectedIndex = 2;
            SweetWhiteRiceComboBox.SelectedIndex = 2;
            CreamOfTartarComboBox.SelectedIndex = 2;
            WhiteRiceComboBox.SelectedIndex = 2;
            BrownRiceComboBox.SelectedIndex = 2;
            BakingSodaComboBox.SelectedIndex = 2;
            BakingPowderComboBox.SelectedIndex = 2;
            PotatoStarchComboBox.SelectedIndex = 2;
            TapiocaStarchComboBox.SelectedIndex = 2;
            GarbanzoComboBox.SelectedIndex = 2;
            MilletComboBox.SelectedIndex = 2;
            SaltComboBox.SelectedIndex = 2;
            ButtermilkPowderComboBox.SelectedIndex = 2;
            FlaxComboBox.SelectedIndex = 2;
            AlmondMealComboBox.SelectedIndex = 2;
            BlanchedAlmondMealComboBox.SelectedIndex = 2;

            for (int i = 0; i < numIngredients; i++)
            {
                unitsHave[i] = "pound";
                amountsHave[i] = 0;
                unitSize[i] = 25;
            }
        }
  
        private void FlourPossessedForm_Load(object sender, EventArgs e)
        {          
            
            amountsHave = new decimal[numIngredients];
            unitsHave = new string[numIngredients];
            unitSize = new decimal[numIngredients];
            InitializeData();
        }      

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to go back?  Any unsaved data will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Display Instructions
        }
    }
}
