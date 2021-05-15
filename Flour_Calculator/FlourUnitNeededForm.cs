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
    public partial class FlourUnitNeededForm : Form
    {
        public FlourUnitNeededForm()
        {
            InitializeComponent();
        }

        // 0Sorghum, 1Xanthum Gum, 2Sweet White Rice, 3Cream of Tartar, 4White Rice, 5Brown Rice, 6Baking Soda, 7Baking Powder,
        // 8Potato Starch, 9Tapioca Starch, 10Garbanzo, 11Millet, 12Salt, 13Buttermilk Powder, 14Flax, 15Almond Meal, 16Blanched Almond Meal, 17Corn Starch

        const int numIngredients = 18;
        private decimal[] amountsWant;
        private Int32[] unitsWant;

        public decimal[] AmountsWant
        {
            get { return amountsWant; }
            set { amountsWant = value; }
        }
        public Int32[] UnitsWant
        {
            get { return unitsWant; }
            set { unitsWant = value; }
        }

        private void InitializeData()
        {
            SorghumAmountTextBox.Text = amountsWant[0].ToString();
            XanthumGumAmountTextBox.Text = amountsWant[1].ToString();
            SweetWhiteRiceAmountTextBox.Text = amountsWant[2].ToString();
            CreamOfTartarAmountTextBox.Text = amountsWant[3].ToString();
            WhiteRiceAmountTextBox.Text = amountsWant[4].ToString();
            BrownRiceAmountTextBox.Text = amountsWant[5].ToString();
            BakingSodaAmountTextBox.Text = amountsWant[6].ToString();
            BakingPowderAmountTextBox.Text = amountsWant[7].ToString();
            PotatoStarchAmountTextBox.Text = amountsWant[8].ToString();
            TapiocaStarchAmountTextBox.Text = amountsWant[9].ToString();
            GarbanzoAmountTextBox.Text = amountsWant[10].ToString();
            MilletAmountTextBox.Text = amountsWant[11].ToString();
            SaltAmountTextBox.Text = amountsWant[12].ToString();
            ButtermilkPowderAmountTextBox.Text = amountsWant[13].ToString();
            FlaxAmountTextBox.Text = amountsWant[14].ToString();
            AlmondMealAmountTextBox.Text = amountsWant[15].ToString();
            BlanchedAlmondMealAmountTextBox.Text = amountsWant[16].ToString();
            CornStarchAmountTextBox.Text = amountsWant[17].ToString();

            SorghumComboBox.SelectedIndex = unitsWant[0];
            XanthumGumComboBox.SelectedIndex = unitsWant[1];
            SweetWhiteRiceComboBox.SelectedIndex = unitsWant[2];
            CreamOfTartarComboBox.SelectedIndex = unitsWant[3];
            WhiteRiceComboBox.SelectedIndex = unitsWant[4];
            BrownRiceComboBox.SelectedIndex = unitsWant[5];
            BakingSodaComboBox.SelectedIndex = unitsWant[6];
            BakingPowderComboBox.SelectedIndex = unitsWant[7];
            PotatoStarchComboBox.SelectedIndex = unitsWant[8];
            TapiocaStarchComboBox.SelectedIndex = unitsWant[9];
            GarbanzoComboBox.SelectedIndex = unitsWant[10];
            MilletComboBox.SelectedIndex = unitsWant[11];
            SaltComboBox.SelectedIndex = unitsWant[12];
            ButtermilkPowderComboBox.SelectedIndex = unitsWant[13];
            FlaxComboBox.SelectedIndex = unitsWant[14];
            AlmondMealComboBox.SelectedIndex = unitsWant[15];
            BlanchedAlmondMealComboBox.SelectedIndex = unitsWant[16];
            CornStarchComboBox.SelectedIndex = unitsWant[17];
        }        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            unitsWant[0] = SorghumComboBox.SelectedIndex;
            unitsWant[1] = XanthumGumComboBox.SelectedIndex;
            unitsWant[2] = SweetWhiteRiceComboBox.SelectedIndex;
            unitsWant[3] = CreamOfTartarComboBox.SelectedIndex;
            unitsWant[4] = WhiteRiceComboBox.SelectedIndex;
            unitsWant[5] = BrownRiceComboBox.SelectedIndex;
            unitsWant[6] = BakingSodaComboBox.SelectedIndex;
            unitsWant[7] = BakingPowderComboBox.SelectedIndex;
            unitsWant[8] = PotatoStarchComboBox.SelectedIndex;
            unitsWant[9] = TapiocaStarchComboBox.SelectedIndex;
            unitsWant[10] = GarbanzoComboBox.SelectedIndex;
            unitsWant[11] = MilletComboBox.SelectedIndex;
            unitsWant[12] = SaltComboBox.SelectedIndex;
            unitsWant[13] = ButtermilkPowderComboBox.SelectedIndex;
            unitsWant[14] = FlaxComboBox.SelectedIndex;
            unitsWant[15] = AlmondMealComboBox.SelectedIndex;
            unitsWant[16] = BlanchedAlmondMealComboBox.SelectedIndex;
            unitsWant[17] = CornStarchComboBox.SelectedIndex;

            // Actually validate the data!
            if (
               (Decimal.TryParse(SorghumAmountTextBox.Text, out amountsWant[0]) == false)
            || (Decimal.TryParse(XanthumGumAmountTextBox.Text, out amountsWant[1]) == false)
            || (Decimal.TryParse(SweetWhiteRiceAmountTextBox.Text, out amountsWant[2]) == false)
            || (Decimal.TryParse(CreamOfTartarAmountTextBox.Text, out amountsWant[3]) == false)
            || (Decimal.TryParse(WhiteRiceAmountTextBox.Text, out amountsWant[4]) == false)
            || (Decimal.TryParse(BrownRiceAmountTextBox.Text, out amountsWant[5]) == false)
            || (Decimal.TryParse(BakingSodaAmountTextBox.Text, out amountsWant[6]) == false)
            || (Decimal.TryParse(BakingPowderAmountTextBox.Text, out amountsWant[7]) == false)
            || (Decimal.TryParse(PotatoStarchAmountTextBox.Text, out amountsWant[8]) == false)
            || (Decimal.TryParse(TapiocaStarchAmountTextBox.Text, out amountsWant[9]) == false)
            || (Decimal.TryParse(GarbanzoAmountTextBox.Text, out amountsWant[10]) == false)
            || (Decimal.TryParse(MilletAmountTextBox.Text, out amountsWant[11]) == false)
            || (Decimal.TryParse(SaltAmountTextBox.Text, out amountsWant[12]) == false)
            || (Decimal.TryParse(ButtermilkPowderAmountTextBox.Text, out amountsWant[13]) == false)
            || (Decimal.TryParse(FlaxAmountTextBox.Text, out amountsWant[14]) == false)
            || (Decimal.TryParse(AlmondMealAmountTextBox.Text, out amountsWant[15]) == false)
            || (Decimal.TryParse(BlanchedAlmondMealAmountTextBox.Text, out amountsWant[16]) == false)
            || (Decimal.TryParse(CornStarchAmountTextBox.Text, out amountsWant[17]) == false))
            {
                MessageBox.Show("One or more of your inputs is not a valid number!", "Invalid Input");
            }
            else
            {
                // If we are here, we have at least valid values!
                // Check for negative or too large numbers!
                for (int i = 0; i < numIngredients; i++)
                {
                    if (amountsWant[i] < 0)
                    {
                        MessageBox.Show("One of your inputs is too small.  Please make sure to enter in no less than '0' into each input box!", "Invalid Input");
                        break;
                    }
                    else if (amountsWant[i] > 1000000)
                    {
                        MessageBox.Show("One of your inputs is too large.  Please do not enter anything larger than 1 million!", "Invalid Input");
                        break;
                    }
                }
            }

            MessageBox.Show("Data Saved!", "Save Successful");
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
            MessageBox.Show("Please select the unit size of each bag/container in the right, drop-down lists. \n" +
                "In the left text boxes, please input the size of the bag/container. \n" +
                "When you are done, make sure to press 'Save' - then 'Go Back'", "Instructions");
        }

        private void FlourUnitNeededForm_Load(object sender, EventArgs e)
        {
            InitializeData();
        }
    }
}
