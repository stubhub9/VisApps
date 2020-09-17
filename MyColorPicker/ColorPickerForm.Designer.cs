namespace MyColorPicker
{
    partial class ColorPickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PickColorButton = new System.Windows.Forms.Button();
            this.AcceptColorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ColorPanel
            // 
            this.ColorPanel.Location = new System.Drawing.Point(25, 15);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(736, 275);
            this.ColorPanel.TabIndex = 0;
            // 
            // PickColorButton
            // 
            this.PickColorButton.Location = new System.Drawing.Point(25, 305);
            this.PickColorButton.Name = "PickColorButton";
            this.PickColorButton.Size = new System.Drawing.Size(736, 64);
            this.PickColorButton.TabIndex = 1;
            this.PickColorButton.Text = "Pick Color";
            this.PickColorButton.UseVisualStyleBackColor = true;
            this.PickColorButton.Click += new System.EventHandler(this.PickColorButton_Click);
            // 
            // AcceptColorButton
            // 
            this.AcceptColorButton.Location = new System.Drawing.Point(25, 380);
            this.AcceptColorButton.Name = "AcceptColorButton";
            this.AcceptColorButton.Size = new System.Drawing.Size(736, 64);
            this.AcceptColorButton.TabIndex = 2;
            this.AcceptColorButton.Text = "Accept Color";
            this.AcceptColorButton.UseVisualStyleBackColor = true;
            this.AcceptColorButton.Click += new System.EventHandler(this.AcceptColorButton_Click);
            // 
            // ColorPickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AcceptColorButton);
            this.Controls.Add(this.PickColorButton);
            this.Controls.Add(this.ColorPanel);
            this.Name = "ColorPickerForm";
            this.Text = "Pick a color!";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button PickColorButton;
        private System.Windows.Forms.Button AcceptColorButton;
        public System.Windows.Forms.Panel ColorPanel;
    }
}

