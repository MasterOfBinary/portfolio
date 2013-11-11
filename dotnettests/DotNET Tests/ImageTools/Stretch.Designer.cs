namespace DotNET_Tests.ImageTools
{
    partial class Stretch
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
            this.labelCurrentSize = new System.Windows.Forms.Label();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.groupBoxNewSize = new System.Windows.Forms.GroupBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxLockAspectRatio = new System.Windows.Forms.CheckBox();
            this.groupBoxNewSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCurrentSize
            // 
            this.labelCurrentSize.AutoSize = true;
            this.labelCurrentSize.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentSize.Name = "labelCurrentSize";
            this.labelCurrentSize.Size = new System.Drawing.Size(35, 13);
            this.labelCurrentSize.TabIndex = 1;
            this.labelCurrentSize.Text = "label2";
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(86, 17);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(69, 20);
            this.textBoxWidth.TabIndex = 3;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(86, 43);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(69, 20);
            this.textBoxHeight.TabIndex = 4;
            // 
            // groupBoxNewSize
            // 
            this.groupBoxNewSize.Controls.Add(this.checkBoxLockAspectRatio);
            this.groupBoxNewSize.Controls.Add(this.labelHeight);
            this.groupBoxNewSize.Controls.Add(this.labelWidth);
            this.groupBoxNewSize.Controls.Add(this.textBoxWidth);
            this.groupBoxNewSize.Controls.Add(this.textBoxHeight);
            this.groupBoxNewSize.Location = new System.Drawing.Point(13, 26);
            this.groupBoxNewSize.Name = "groupBoxNewSize";
            this.groupBoxNewSize.Size = new System.Drawing.Size(161, 91);
            this.groupBoxNewSize.TabIndex = 5;
            this.groupBoxNewSize.TabStop = false;
            this.groupBoxNewSize.Text = "New Size";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(7, 20);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Width";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(7, 46);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "Height";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 123);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(99, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxLockAspectRatio
            // 
            this.checkBoxLockAspectRatio.AutoSize = true;
            this.checkBoxLockAspectRatio.Checked = true;
            this.checkBoxLockAspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLockAspectRatio.Location = new System.Drawing.Point(10, 69);
            this.checkBoxLockAspectRatio.Name = "checkBoxLockAspectRatio";
            this.checkBoxLockAspectRatio.Size = new System.Drawing.Size(108, 17);
            this.checkBoxLockAspectRatio.TabIndex = 7;
            this.checkBoxLockAspectRatio.Text = "Lock aspect ratio";
            this.checkBoxLockAspectRatio.UseVisualStyleBackColor = true;
            // 
            // Stretch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 154);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxNewSize);
            this.Controls.Add(this.labelCurrentSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stretch";
            this.ShowInTaskbar = false;
            this.Text = "Stretch";
            this.Load += new System.EventHandler(this.Stretch_Load);
            this.groupBoxNewSize.ResumeLayout(false);
            this.groupBoxNewSize.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentSize;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.GroupBox groupBoxNewSize;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxLockAspectRatio;
    }
}