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

        // 0Sorghum, 1Xanthum Gum, 2Sweet White Rice, 3Cream of Tartar, 4White Rice, 5Brown Rice, 6Baking Soda, 7Baking Powder,
        // 8Potato Starch, 9Tapioca Starch, 10Garbanzo, 11Millet, 12Salt, 13Buttermilk Powder, 14Flax, 15Almond Meal, 16Blanched Almond Meal, 17Corn Starch

        const int numIngredients = 18;
        private decimal[] amountsHave;
        private decimal[] unitSize;
        private Int32[] unitsHave;

        public decimal[] AmountsHave
        {
            get { return amountsHave; }
            set { amountsHave = value; }
        }        
        public Int32[] UnitsHave
        {
            get { return unitsHave; }
            set { unitsHave = value; }
        }
        public decimal[] UnitSize
        {
            get { return unitSize; }
            set { unitSize = value; }
        }
       
        private void InitializeData()
        {            
            SorghumAmountTextBox.Text = amountsHave[0].ToString();
            XanthumGumAmountTextBox.Text = amountsHave[1].ToString();
            SweetWhiteRiceAmountTextBox.Text = amountsHave[2].ToString();
            CreamOfTartarAmountTextBox.Text = amountsHave[3].ToString();
            WhiteRiceAmountTextBox.Text = amountsHave[4].ToString();
            BrownRiceAmountTextBox.Text = amountsHave[5].ToString();
            BakingSodaAmountTextBox.Text = amountsHave[6].ToString();
            BakingPowderAmountTextBox.Text = amountsHave[7].ToString();
            PotatoStarchAmountTextBox.Text = amountsHave[8].ToString();
            TapiocaStarchAmountTextBox.Text = amountsHave[9].ToString();
            GarbanzoAmountTextBox.Text = amountsHave[10].ToString();
            MilletAmountTextBox.Text = amountsHave[11].ToString();
            SaltAmountTextBox.Text = amountsHave[12].ToString();
            ButtermilkPowderAmountTextBox.Text = amountsHave[13].ToString();
            FlaxAmountTextBox.Text = amountsHave[14].ToString();
            AlmondMealAmountTextBox.Text = amountsHave[15].ToString();
            BlanchedAlmondMealAmountTextBox.Text = amountsHave[16].ToString();
            CornStarchAmountTextBox.Text = amountsHave[17].ToString();

            SorghumUnitTextBox.Text = unitSize[0].ToString();
            XanthumGumUnitTextBox.Text = unitSize[1].ToString();
            SweetWhiteRiceUnitTextBox.Text = unitSize[2].ToString();
            CreamOfTartarUnitTextBox.Text = unitSize[3].ToString();
            WhiteRiceUnitTextBox.Text = unitSize[4].ToString();
            BrownRiceUnitTextBox.Text = unitSize[5].ToString();
            BakingSodaUnitTextBox.Text = unitSize[6].ToString();
            BakingPowderUnitTextBox.Text = unitSize[7].ToString();
            PotatoStarchUnitTextBox.Text = unitSize[8].ToString();
            TapiocaStarchUnitTextBox.Text = unitSize[9].ToString();
            GarbanzoUnitTextBox.Text = unitSize[10].ToString();
            MilletUnitTextBox.Text = unitSize[11].ToString();
            SaltUnitTextBox.Text = unitSize[12].ToString();
            ButtermilkPowderUnitTextBox.Text = unitSize[13].ToString();
            FlaxUnitTextBox.Text = unitSize[14].ToString();
            AlmondMealUnitTextBox.Text = unitSize[15].ToString();
            BlanchedAlmondMealUnitTextBox.Text = unitSize[16].ToString();
            CornStarchUnitTextBox.Text = unitSize[17].ToString();

            SorghumComboBox.SelectedIndex = unitsHave[0];
            XanthumGumComboBox.SelectedIndex = unitsHave[1];
            SweetWhiteRiceComboBox.SelectedIndex = unitsHave[2];
            CreamOfTartarComboBox.SelectedIndex = unitsHave[3];
            WhiteRiceComboBox.SelectedIndex = unitsHave[4];
            BrownRiceComboBox.SelectedIndex = unitsHave[5];
            BakingSodaComboBox.SelectedIndex = unitsHave[6];
            BakingPowderComboBox.SelectedIndex = unitsHave[7];
            PotatoStarchComboBox.SelectedIndex = unitsHave[8];
            TapiocaStarchComboBox.SelectedIndex = unitsHave[9];
            GarbanzoComboBox.SelectedIndex = unitsHave[10];
            MilletComboBox.SelectedIndex = unitsHave[11];
            SaltComboBox.SelectedIndex = unitsHave[12];
            ButtermilkPowderComboBox.SelectedIndex = unitsHave[13];
            FlaxComboBox.SelectedIndex = unitsHave[14];
            AlmondMealComboBox.SelectedIndex = unitsHave[15];
            BlanchedAlmondMealComboBox.SelectedIndex = unitsHave[16];
            CornStarchComboBox.SelectedIndex = unitsHave[17];
        }  
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            unitsHave[0] = SorghumComboBox.SelectedIndex;
            unitsHave[1] = XanthumGumComboBox.SelectedIndex;
            unitsHave[2] = SweetWhiteRiceComboBox.SelectedIndex;
            unitsHave[3] = CreamOfTartarComboBox.SelectedIndex;
            unitsHave[4] = WhiteRiceComboBox.SelectedIndex;
            unitsHave[5] = BrownRiceComboBox.SelectedIndex;
            unitsHave[6] = BakingSodaComboBox.SelectedIndex;
            unitsHave[7] = BakingPowderComboBox.SelectedIndex;
            unitsHave[8] = PotatoStarchComboBox.SelectedIndex;
            unitsHave[9] = TapiocaStarchComboBox.SelectedIndex;
            unitsHave[10] = GarbanzoComboBox.SelectedIndex;
            unitsHave[11] = MilletComboBox.SelectedIndex;
            unitsHave[12] = SaltComboBox.SelectedIndex;
            unitsHave[13] = ButtermilkPowderComboBox.SelectedIndex;
            unitsHave[14] = FlaxComboBox.SelectedIndex;
            unitsHave[15] = AlmondMealComboBox.SelectedIndex;
            unitsHave[16] = BlanchedAlmondMealComboBox.SelectedIndex;
            unitsHave[17] = CornStarchComboBox.SelectedIndex;

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
            || (Decimal.TryParse(CornStarchAmountTextBox.Text, out amountsHave[17]) == false)
            || (Decimal.TryParse(SorghumUnitTextBox.Text, out unitSize[0]) == false) // Start Over! UGH
            || (Decimal.TryParse(XanthumGumUnitTextBox.Text, out unitSize[1]) == false)
            || (Decimal.TryParse(SweetWhiteRiceUnitTextBox.Text, out unitSize[2]) == false)
            || (Decimal.TryParse(CreamOfTartarUnitTextBox.Text, out unitSize[3]) == false)
            || (Decimal.TryParse(WhiteRiceUnitTextBox.Text, out unitSize[4]) == false)
            || (Decimal.TryParse(BrownRiceUnitTextBox.Text, out unitSize[5]) == false)
            || (Decimal.TryParse(BakingSodaUnitTextBox.Text, out unitSize[6]) == false)
            || (Decimal.TryParse(BakingPowderUnitTextBox.Text, out unitSize[7]) == false)
            || (Decimal.TryParse(PotatoStarchUnitTextBox.Text, out unitSize[8]) == false)
            || (Decimal.TryParse(TapiocaStarchUnitTextBox.Text, out unitSize[9]) == false)
            || (Decimal.TryParse(GarbanzoUnitTextBox.Text, out unitSize[10]) == false)
            || (Decimal.TryParse(MilletUnitTextBox.Text, out unitSize[11]) == false)
            || (Decimal.TryParse(SaltUnitTextBox.Text, out unitSize[12]) == false)
            || (Decimal.TryParse(ButtermilkPowderUnitTextBox.Text, out unitSize[13]) == false)
            || (Decimal.TryParse(FlaxUnitTextBox.Text, out unitSize[14]) == false)
            || (Decimal.TryParse(AlmondMealUnitTextBox.Text, out unitSize[15]) == false)
            || (Decimal.TryParse(BlanchedAlmondMealUnitTextBox.Text, out unitSize[16]) == false)
            || (Decimal.TryParse(CornStarchUnitTextBox.Text, out unitSize[17]) == false))
            {
                MessageBox.Show("One or more of your inputs is not a valid number!", "Invalid Input");
                return;
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
                        return;
                    }
                    else if ((amountsHave[i] > 1000000) || (unitSize[i] > 1000000))
                    {
                        MessageBox.Show("One or more of your inputs is too large.  Please do not enter anything larger than 1 million!", "Invalid Input");
                        return;
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
            MessageBox.Show("Please select the unit size of each bag/container in the far right, drop-down lists. \n" +
                " In the middle text boxes, please input the size of the bag/container. \n" +
                " In the far left text boxes, please input the number of each bag/container that you have. \n" +
                " When you are done, make sure to press 'Save' - then 'Go Back'", "Instructions");
        }

        private void FlourPossessedForm_Load(object sender, EventArgs e)
        {
            InitializeData();
        }
    }
}
