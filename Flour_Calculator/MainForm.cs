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
        public MainForm()
        {
            InitializeComponent();
        }

        // The amounts array holds the decimal number of the following ingredients in that order - with their units specified in the units array
        // 0Sorghum, 1Xanthum Gum, 2Sweet White Rice, 3Cream of Tartar, 4White Rice, 5Brown Rice, 6Baking Soda, 7Baking Powder,
        // 8Potato Starch, 9Tapioca Starch, 10Garbanzo, 11Millet, 12Salt, 13Buttermilk Powder, 14Flax, 15Almond Meal, 16Blanched Almond Meal, 17Corn Starch
        // The possible units are: grams, kilograms, ounces, pounds

        const int numIngredients = 18;
        // Contains numbers of each ingredient that we already have
        private decimal[] amountsHave;
        // Contains the units of each ingredient that we already have
        private Int32[] unitsHave;
        // Contains the size of the bags that we want our answer in
        private decimal[] amountsWant;
        // Contains the units of the bags that we want our answer in
        private Int32[] unitsWant;
        // Contains the amount of each ingredient that is requested/needed
        private decimal[] amountsNeed;        
        // Contains the units of each ingredient that is requested/needed
        private Int32[] unitsNeed;
        // Units Size for flour possessed
        private decimal[] unitSize;
        // Amount of each round of flour requested/needed
        private Int32[] amountsFlour;       

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
                    if (unitsNeed[i] == 2)
                        amountsNeed[i] *= 453.59237m;
                    if (unitsNeed[i] == 1)
                        amountsNeed[i] *= 1000.0m;
                    if (unitsNeed[i] == 3)
                        amountsNeed[i] *= 28.34952m;
                    unitsNeed[i] = 0;

                    if (unitsHave[i] == 2)
                        amountsHave[i] *= 453.59237m;
                    if (unitsHave[i] == 1)
                        amountsHave[i] *= 1000.0m;
                    if (unitsHave[i] == 3)
                        amountsHave[i] *= 28.34952m;
                    unitsHave[i] = 0;
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
                    if (unitsWant[i] == 2)
                        tempArr[i] /= 453.59237m;
                    if (unitsWant[i] == 1)
                        tempArr[i] /= 1000.0m;
                    if (unitsWant[i] == 3)
                        tempArr[i] /= 28.34952m;
                    // Convert to correct amount of unit
                    if (amountsWant[i] > 0)
                        tempArr[i] /= amountsWant[i];
                    else
                    {
                        tempArr[i] = 0;
                        MessageBox.Show("Invalid units for the size of bags that you want your ingredients in!", "Error!");
                        return;
                    }
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
        private void InstructionsButton_Click(object sender, EventArgs e)
        {
            // Display Instructions
            MessageBox.Show(" To input the number of rounds of each type of flour you want, press 'Flour Needed' \n" +
                " To input the amount of each type of ingredient that you already have, press 'Flour Ingredients already possessed' \n" +
                " To input the size and units of the bags/containers of ingredients that you will be purchasing, press 'Bag Sizes' \n" +
                " To calculate how many bags/containers that you need to purchase, press 'Calculate' \n" +
                " To view the credits, press 'Credits'");
        }
        private void CreditsButton_Click(object sender, EventArgs e)
        {
            // Display Credits
            MessageBox.Show("All rights are reserved by Elegant Elephant Baking Co.  No copies/versions/pictures/video of this software may be created or distributed in any form. \n" +
                "Programmer: Kaiser Slocum \n" +
                "Software Lead: Kaiser Slocum \n" +
                "Head of Distribution: Kaiser Slocum \n" +
                "CEO of Elegant Elephant Baking Co.: Jessie Scarola \n" +
                "Bake On!", "Credits");
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult button = MessageBox.Show("Are you sure you want to close this application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (button == DialogResult.Yes)
                this.Close();
        }

        private void FlourNeededButton_Click(object sender, EventArgs e)
        {
            using (FlourNeededForm frm = new FlourNeededForm())
            {
                frm.AmountsNeed = amountsNeed;
                frm.UnitsNeed = unitsNeed;
                frm.AmountsFlour = amountsFlour;
                frm.ShowDialog();
                amountsNeed = frm.AmountsNeed;
                unitsNeed = frm.UnitsNeed;
                amountsFlour = frm.AmountsFlour;
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }        
        private void PossessedIngredientsButton_Click(object sender, EventArgs e)
        {
            using (FlourPossessedForm frm = new FlourPossessedForm())
            {
                frm.AmountsHave = amountsHave;
                frm.UnitsHave = unitsHave;
                frm.UnitSize = unitSize;
                frm.ShowDialog();
                unitSize = frm.UnitSize;
                amountsHave = frm.AmountsHave;
                unitsHave = frm.UnitsHave;
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }
        private void UnitsButton_Click(object sender, EventArgs e)
        {
            using (FlourUnitNeededForm frm = new FlourUnitNeededForm())
            {
                frm.AmountsWant = amountsWant;
                frm.UnitsWant = unitsWant;
                frm.ShowDialog();
                amountsWant = frm.AmountsWant;
                unitsWant = frm.UnitsWant;
            }
            //MessageBox.Show(OnHandGrams[1].ToString());
        }

        private void InitializeData()
        {
            decimal[] final = new decimal[numIngredients];

            // Initialize arrays
            for (int i = 0; i < numIngredients; i++)
            {
                unitsHave[i] = 0;
                unitsWant[i] = 0;
                unitsNeed[i] = 0;
                amountsHave[i] = 0;
                amountsWant[i] = 0;
                amountsNeed[i] = 0;
                unitSize[i] = 0;
                final[i] = 0;
            }
            for (int i = 0; i < 5; i++)
            {
                amountsFlour[i] = 0;
            }
            DisplayData(final);           
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
                    MessageBox.Show("One or more of your numbers for the amount of ingredients you already have is invalid!", "Invalid Input");
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
                tempArr[i] = final[i].ToString() + " -" + amountsWant[i].ToString() + " " + unitsWant[i] + "- bags";
            }

            SorghumTextBox.Text             = tempArr[0];
            XanthumGumTextBox.Text          = tempArr[1];
            SweetWhiteRiceTextBox.Text      = tempArr[2];
            CreamOfTartarTextBox.Text       = tempArr[3];
            WhiteRiceTextBox.Text           = tempArr[4];
            BrownRiceTextBox.Text           = tempArr[5];
            BakingSodaTextBox.Text          = tempArr[6];
            BakingPowderTextBox.Text        = tempArr[7];
            PotatoStarchTextBox.Text        = tempArr[8];
            TapiocaStarchTextBox.Text       = tempArr[9];
            GarbanzoTextBox.Text            = tempArr[10];
            MilletTextBox.Text              = tempArr[11];
            SaltTextBox.Text                = tempArr[12];
            ButtermilkPowderTextBox.Text    = tempArr[13];
            FlaxTextBox.Text                = tempArr[14];
            AlmondMealTextBox.Text          = tempArr[15];
            BlanchedAlmondMealTextBox.Text  = tempArr[16];
            CornStarchTextBox.Text          = tempArr[17];
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

            // Declare the sizes of the arrays
            amountsHave = new decimal[numIngredients];
            amountsWant = new decimal[numIngredients];
            amountsNeed = new decimal[numIngredients];
            unitSize = new decimal[numIngredients];
            unitsHave = new Int32[numIngredients];
            unitsWant = new Int32[numIngredients];
            unitsNeed = new Int32[numIngredients];
            amountsFlour = new Int32[5];
            InitializeData();

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
