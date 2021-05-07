
namespace Flour_Calculator
{
    partial class FlourNeededForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RoundsNeededGroupBox = new System.Windows.Forms.GroupBox();
            this.BBETextBox = new System.Windows.Forms.TextBox();
            this.PotatoTextBox = new System.Windows.Forms.TextBox();
            this.CakeTextBox = new System.Windows.Forms.TextBox();
            this.SconeTextBox = new System.Windows.Forms.TextBox();
            this.PieTextBox = new System.Windows.Forms.TextBox();
            this.CakeLabel = new System.Windows.Forms.Label();
            this.BBELabel = new System.Windows.Forms.Label();
            this.PotatoLabel = new System.Windows.Forms.Label();
            this.PieLabel = new System.Windows.Forms.Label();
            this.SconeLabel = new System.Windows.Forms.Label();
            this.InstructionsButton = new System.Windows.Forms.Button();
            this.RoundsNeededGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(271, 65);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(98, 46);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Go Back";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(271, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(98, 46);
            this.SaveButton.TabIndex = 46;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RoundsNeededGroupBox
            // 
            this.RoundsNeededGroupBox.Controls.Add(this.BBETextBox);
            this.RoundsNeededGroupBox.Controls.Add(this.PotatoTextBox);
            this.RoundsNeededGroupBox.Controls.Add(this.CakeTextBox);
            this.RoundsNeededGroupBox.Controls.Add(this.SconeTextBox);
            this.RoundsNeededGroupBox.Controls.Add(this.PieTextBox);
            this.RoundsNeededGroupBox.Controls.Add(this.CakeLabel);
            this.RoundsNeededGroupBox.Controls.Add(this.BBELabel);
            this.RoundsNeededGroupBox.Controls.Add(this.PotatoLabel);
            this.RoundsNeededGroupBox.Controls.Add(this.PieLabel);
            this.RoundsNeededGroupBox.Controls.Add(this.SconeLabel);
            this.RoundsNeededGroupBox.Location = new System.Drawing.Point(12, 12);
            this.RoundsNeededGroupBox.Name = "RoundsNeededGroupBox";
            this.RoundsNeededGroupBox.Size = new System.Drawing.Size(253, 160);
            this.RoundsNeededGroupBox.TabIndex = 47;
            this.RoundsNeededGroupBox.TabStop = false;
            this.RoundsNeededGroupBox.Text = "Rounds Needed:";
            // 
            // BBETextBox
            // 
            this.BBETextBox.Location = new System.Drawing.Point(141, 24);
            this.BBETextBox.Name = "BBETextBox";
            this.BBETextBox.Size = new System.Drawing.Size(100, 20);
            this.BBETextBox.TabIndex = 9;
            // 
            // PotatoTextBox
            // 
            this.PotatoTextBox.Location = new System.Drawing.Point(141, 50);
            this.PotatoTextBox.Name = "PotatoTextBox";
            this.PotatoTextBox.Size = new System.Drawing.Size(100, 20);
            this.PotatoTextBox.TabIndex = 8;
            // 
            // CakeTextBox
            // 
            this.CakeTextBox.Location = new System.Drawing.Point(141, 76);
            this.CakeTextBox.Name = "CakeTextBox";
            this.CakeTextBox.Size = new System.Drawing.Size(100, 20);
            this.CakeTextBox.TabIndex = 7;
            // 
            // SconeTextBox
            // 
            this.SconeTextBox.Location = new System.Drawing.Point(141, 102);
            this.SconeTextBox.Name = "SconeTextBox";
            this.SconeTextBox.Size = new System.Drawing.Size(100, 20);
            this.SconeTextBox.TabIndex = 6;
            // 
            // PieTextBox
            // 
            this.PieTextBox.Location = new System.Drawing.Point(141, 128);
            this.PieTextBox.Name = "PieTextBox";
            this.PieTextBox.Size = new System.Drawing.Size(100, 20);
            this.PieTextBox.TabIndex = 5;
            // 
            // CakeLabel
            // 
            this.CakeLabel.AutoSize = true;
            this.CakeLabel.Location = new System.Drawing.Point(77, 79);
            this.CakeLabel.Name = "CakeLabel";
            this.CakeLabel.Size = new System.Drawing.Size(58, 13);
            this.CakeLabel.TabIndex = 4;
            this.CakeLabel.Text = "Cake Flour";
            // 
            // BBELabel
            // 
            this.BBELabel.AutoSize = true;
            this.BBELabel.Location = new System.Drawing.Point(6, 27);
            this.BBELabel.Name = "BBELabel";
            this.BBELabel.Size = new System.Drawing.Size(129, 13);
            this.BBELabel.TabIndex = 3;
            this.BBELabel.Text = "Almond Bread (BBE) Flour";
            // 
            // PotatoLabel
            // 
            this.PotatoLabel.AutoSize = true;
            this.PotatoLabel.Location = new System.Drawing.Point(27, 53);
            this.PotatoLabel.Name = "PotatoLabel";
            this.PotatoLabel.Size = new System.Drawing.Size(108, 13);
            this.PotatoLabel.TabIndex = 2;
            this.PotatoLabel.Text = "Nut Free Potato Flour";
            // 
            // PieLabel
            // 
            this.PieLabel.AutoSize = true;
            this.PieLabel.Location = new System.Drawing.Point(87, 131);
            this.PieLabel.Name = "PieLabel";
            this.PieLabel.Size = new System.Drawing.Size(48, 13);
            this.PieLabel.TabIndex = 1;
            this.PieLabel.Text = "Pie Flour";
            // 
            // SconeLabel
            // 
            this.SconeLabel.AutoSize = true;
            this.SconeLabel.Location = new System.Drawing.Point(71, 105);
            this.SconeLabel.Name = "SconeLabel";
            this.SconeLabel.Size = new System.Drawing.Size(64, 13);
            this.SconeLabel.TabIndex = 0;
            this.SconeLabel.Text = "Scone Flour";
            // 
            // InstructionsButton
            // 
            this.InstructionsButton.Location = new System.Drawing.Point(271, 114);
            this.InstructionsButton.Name = "InstructionsButton";
            this.InstructionsButton.Size = new System.Drawing.Size(98, 46);
            this.InstructionsButton.TabIndex = 54;
            this.InstructionsButton.Text = "Instructions";
            this.InstructionsButton.UseVisualStyleBackColor = true;
            this.InstructionsButton.Click += new System.EventHandler(this.InstructionsButton_Click);
            // 
            // FlourNeededForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 182);
            this.Controls.Add(this.InstructionsButton);
            this.Controls.Add(this.RoundsNeededGroupBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ExitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FlourNeededForm";
            this.Text = "How many rounds of each flour do you need?";
            this.Load += new System.EventHandler(this.NeedFlour_Load);
            this.RoundsNeededGroupBox.ResumeLayout(false);
            this.RoundsNeededGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox RoundsNeededGroupBox;
        private System.Windows.Forms.TextBox BBETextBox;
        private System.Windows.Forms.TextBox PotatoTextBox;
        private System.Windows.Forms.TextBox CakeTextBox;
        private System.Windows.Forms.TextBox SconeTextBox;
        private System.Windows.Forms.TextBox PieTextBox;
        private System.Windows.Forms.Label CakeLabel;
        private System.Windows.Forms.Label BBELabel;
        private System.Windows.Forms.Label PotatoLabel;
        private System.Windows.Forms.Label PieLabel;
        private System.Windows.Forms.Label SconeLabel;
        private System.Windows.Forms.Button InstructionsButton;
    }
}