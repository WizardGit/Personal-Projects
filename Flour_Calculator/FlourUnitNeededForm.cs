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

        const int numIngredients = 17;
        private decimal[] amountsWant;
        private string[] unitsWant;
        public decimal[] GetAmountsWant
        {
            get
            {
                return amountsWant;
            }
        }
        public string[] GetUnitsWant
        {
            get
            {
                return unitsWant;
            }
        }

        private void InitializeData()
        {
            SorghumAmountTextBox.Text = "25";
            XanthumGumAmountTextBox.Text = "25";
            SweetWhiteRiceAmountTextBox.Text = "25";
            CreamOfTartarAmountTextBox.Text = "25";
            WhiteRiceAmountTextBox.Text = "25";
            BrownRiceAmountTextBox.Text = "25";
            BakingSodaAmountTextBox.Text = "25";
            BakingPowderAmountTextBox.Text = "25";
            PotatoStarchAmountTextBox.Text = "25";
            TapiocaStarchAmountTextBox.Text = "25";
            GarbanzoAmountTextBox.Text = "25";
            MilletAmountTextBox.Text = "25";
            SaltAmountTextBox.Text = "25";
            ButtermilkPowderAmountTextBox.Text = "25";
            FlaxAmountTextBox.Text = "25";
            AlmondMealAmountTextBox.Text = "25";
            BlanchedAlmondMealAmountTextBox.Text = "25";

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
                unitsWant[i] = "pound";
                amountsWant[i] = 25;
            }
        }
        private void FlourUnitNeededForm_Load(object sender, EventArgs e)
        {
            amountsWant = new decimal[numIngredients];
            unitsWant = new string[numIngredients];
            InitializeData();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            unitsWant[0] = SorghumComboBox.Text;
            unitsWant[1] = XanthumGumComboBox.Text;
            unitsWant[2] = SweetWhiteRiceComboBox.Text;
            unitsWant[3] = CreamOfTartarComboBox.Text;
            unitsWant[4] = WhiteRiceComboBox.Text;
            unitsWant[5] = BrownRiceComboBox.Text;
            unitsWant[6] = BakingSodaComboBox.Text;
            unitsWant[7] = BakingPowderComboBox.Text;
            unitsWant[8] = PotatoStarchComboBox.Text;
            unitsWant[9] = TapiocaStarchComboBox.Text;
            unitsWant[10] = GarbanzoComboBox.Text;
            unitsWant[11] = MilletComboBox.Text;
            unitsWant[12] = SaltComboBox.Text;
            unitsWant[13] = ButtermilkPowderComboBox.Text;
            unitsWant[14] = FlaxComboBox.Text;
            unitsWant[15] = AlmondMealComboBox.Text;
            unitsWant[16] = BlanchedAlmondMealComboBox.Text;

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
            || (Decimal.TryParse(BlanchedAlmondMealAmountTextBox.Text, out amountsWant[16]) == false))
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
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to go back?  Any unsaved data will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Show Instructions Form
        }
    }
}
