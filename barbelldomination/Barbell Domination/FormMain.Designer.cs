namespace Barbell_Domination
{
    partial class FormMain
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
            this.labelAvailableWeights = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownAmt = new System.Windows.Forms.NumericUpDown();
            this.labelUse = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmt)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAvailableWeights
            // 
            this.labelAvailableWeights.AutoSize = true;
            this.labelAvailableWeights.Location = new System.Drawing.Point(12, 9);
            this.labelAvailableWeights.Name = "labelAvailableWeights";
            this.labelAvailableWeights.Size = new System.Drawing.Size(89, 13);
            this.labelAvailableWeights.TabIndex = 0;
            this.labelAvailableWeights.Text = "Available weights";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total amt req\'d";
            // 
            // numericUpDownAmt
            // 
            this.numericUpDownAmt.Location = new System.Drawing.Point(95, 25);
            this.numericUpDownAmt.Maximum = new decimal(new int[] {
            350,
            0,
            0,
            0});
            this.numericUpDownAmt.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAmt.Name = "numericUpDownAmt";
            this.numericUpDownAmt.Size = new System.Drawing.Size(59, 20);
            this.numericUpDownAmt.TabIndex = 2;
            this.numericUpDownAmt.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelUse
            // 
            this.labelUse.AutoSize = true;
            this.labelUse.Location = new System.Drawing.Point(12, 48);
            this.labelUse.Name = "labelUse";
            this.labelUse.Size = new System.Drawing.Size(94, 13);
            this.labelUse.TabIndex = 3;
            this.labelUse.Text = "Use these weights";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(247, 25);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(73, 20);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 73);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelUse);
            this.Controls.Add(this.numericUpDownAmt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAvailableWeights);
            this.Name = "FormMain";
            this.Text = "Barbell domination";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAvailableWeights;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownAmt;
        private System.Windows.Forms.Label labelUse;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

