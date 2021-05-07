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

        const int numIngredients = 17;
        private decimal[] amountsNeed;
        // In this order: BBE, potato, cake, scone, pie
        private int[] amountsFlour;
        public decimal[] GetAmountsNeed
        {
            get
            {
                return amountsNeed;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to go back? All unsaved data will be lost.", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }

        private void NeedFlour_Load(object sender, EventArgs e)
        {
            // What we actually need is our two arrays from the main form 
            amountsNeed = new decimal[numIngredients];
            amountsFlour = new int[5];
            for (int i = 0; i < numIngredients; i++)
            {                
                amountsNeed[i] = 0.0m;
            }
            for (int i = 0; i < 5; i++)
            {
                amountsFlour[i] = -1;
            }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (InputData() == true)
            {
                // Add in BBE
                amountsNeed[0] += amountsFlour[0] * 4513.0m;
                // Add in potato
                // Add in cake
                // Add in scone
                // Add in pie
            }
        }

        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Display Instructions Form
        }
    }
}
