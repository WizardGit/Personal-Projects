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
    public partial class FlourNeededForm : Form
    {
        public FlourNeededForm()
        {
            InitializeComponent();
        }

        // 0Sorghum, 1Xanthum Gum, 2Sweet White Rice, 3Cream of Tartar, 4White Rice, 5Brown Rice, 6Baking Soda, 7Baking Powder,
        // 8Potato Starch, 9Tapioca Starch, 10Garbanzo, 11Millet, 12Salt, 13Buttermilk Powder, 14Flax, 15Almond Meal, 16Blanched Almond Meal, 17Corn Starch

        const int numIngredients = 18;
        private decimal[] amountsNeed;
        private Int32[] unitsNeed;
        // amountsFlour holds the amount of rounds of each type of flour to be made in this order: BBE, potato, cake, scone, pie
        private Int32[] amountsFlour;

        public decimal[] AmountsNeed
        {
            get { return amountsNeed; }
            set { amountsNeed = value; }
        }
        public Int32[] UnitsNeed
        {
            get { return unitsNeed; }
            set { unitsNeed = value; }
        }
        public Int32[] AmountsFlour
        {
            get { return amountsFlour; }
            set { amountsFlour = value; }
        }

        private bool InputData()
        {
            // Actually validate the data!
            if (
               (Int32.TryParse(BBETextBox.Text, out amountsFlour[0]) == false)
            || (Int32.TryParse(PotatoTextBox.Text, out amountsFlour[1]) == false)
            || (Int32.TryParse(CakeTextBox.Text, out amountsFlour[2]) == false)
            || (Int32.TryParse(SconeTextBox.Text, out amountsFlour[3]) == false)
            || (Int32.TryParse(PieTextBox.Text, out amountsFlour[4]) == false))
            {
                MessageBox.Show("One or more of your inputs is not a valid number!", "Invalid Input");
                return false;
            }
            else
            {
                // If we are here, we have at least valid values!
                // Check for negative or too large numbers!
                for (int i = 0; i < 5; i++)
                {
                    if ((amountsFlour[i] == -1) || (amountsFlour[i] > 1000000))
                    {
                        MessageBox.Show("One or more of your numbers for the rounds of flour you want is invalid!", "Invalid Input");
                        return false;
                    }
                }
            }
            return true;
        }
        private void InitializeData()
        {
            BBETextBox.Text = amountsFlour[0].ToString();
            PotatoTextBox.Text = amountsFlour[1].ToString();
            CakeTextBox.Text = amountsFlour[2].ToString();
            SconeTextBox.Text = amountsFlour[3].ToString();
            PieTextBox.Text = amountsFlour[4].ToString();

            for (int i = 0; i < numIngredients; i++)
            {
                amountsNeed[i] = 0.0m;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // unitsNeed will hold the units for each amount - all of them are in grams EXCEPT for Almond Meal which is in pounds
            for (int i = 0; i < numIngredients; i++)
            {
                if (i == 15)
                    unitsNeed[i] = 2;
                else
                    unitsNeed[i] = 0;
            }

            if (InputData() == true)
            {
                // Add in BBE
                amountsNeed[2] += amountsFlour[0] * 8925.0m;
                amountsNeed[0] += amountsFlour[0] * 2835.0m;
                amountsNeed[9] += amountsFlour[0] * 7035.0m;
                amountsNeed[15] += amountsFlour[0] * 25.0m;
                amountsNeed[17] += amountsFlour[0] * 8505.0m;
                amountsNeed[12] += amountsFlour[0] * 804.0m;
                amountsNeed[3] += amountsFlour[0] * 105.0m;
                amountsNeed[1] += amountsFlour[0] * 945.0m;
                amountsNeed[8] += amountsFlour[0] * 10290.0m;
                // Add in potato
                amountsNeed[2] += amountsFlour[1] * 8925.0m;
                amountsNeed[9] += amountsFlour[1] * 8464.0m;
                amountsNeed[8] += amountsFlour[1] * 16928.0m;
                amountsNeed[0] += amountsFlour[1] * 4805.0m;
                amountsNeed[11] += amountsFlour[1] * 4805.0m;
                amountsNeed[10] += amountsFlour[1] * 4805.0m;
                amountsNeed[14] += amountsFlour[1] * 1507.0m;
                amountsNeed[12] += amountsFlour[1] * 1300.0m;
                amountsNeed[1] += amountsFlour[1] * 950.0m;
                amountsNeed[3] += amountsFlour[1] * 150.0m;
                // Add in cake
                amountsNeed[4] += amountsFlour[2] * 19840.0m;
                amountsNeed[9] += amountsFlour[2] * 2320.0m;
                amountsNeed[8] += amountsFlour[2] * 11520.0m;
                amountsNeed[7] += amountsFlour[2] * 800.0m;
                amountsNeed[6] += amountsFlour[2] * 560.0m;
                amountsNeed[1] += amountsFlour[2] * 400.0m;
                amountsNeed[0] += amountsFlour[2] * 5280.0m;
                amountsNeed[5] += amountsFlour[2] * 2960.0m;
                // Add in scone
                amountsNeed[4] += amountsFlour[3] * 5940.0m;
                amountsNeed[5] += amountsFlour[3] * 5364.0m;
                amountsNeed[16] += amountsFlour[3] * 3492.0m;
                amountsNeed[9] += amountsFlour[3] * 4194.0m;
                amountsNeed[8] += amountsFlour[3] * 5166.0m;
                amountsNeed[12] += amountsFlour[3] * 198.0m;
                amountsNeed[1] += amountsFlour[3] * 252.0m;
                amountsNeed[6] += amountsFlour[3] * 774.0m;
                amountsNeed[7] += amountsFlour[3] * 1098.0m;
                amountsNeed[13] += amountsFlour[3] * 2862.0m;
                amountsNeed[2] += amountsFlour[3] * 5778.0m;
                // Add in pie
                amountsNeed[11] += amountsFlour[4] * 12000.0m;
                amountsNeed[5] += amountsFlour[4] * 8880.0m;
                amountsNeed[8] += amountsFlour[4] * 13920.0m;
                amountsNeed[12] += amountsFlour[4] * 632.0m;
                amountsNeed[0] += amountsFlour[4] * 11760.0m;
                amountsNeed[1] += amountsFlour[4] * 664.0m;
            }

            MessageBox.Show("Data Saved!", "Save Successful");
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to go back? All unsaved data will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }
        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Display Instructions
            MessageBox.Show("Please input the total number of rounds of each flour that you want. \n When you are done, make sure to press 'Save' - then 'Go Back'", "Instructions");
        }

        private void NeedFlour_Load(object sender, EventArgs e)
        {
            InitializeData();
        }
    }
}
