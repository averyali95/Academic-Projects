namespace final_database_question
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Names = new System.Windows.Forms.ComboBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Student ";
            // 
            // cmb_Names
            // 
            this.cmb_Names.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmb_Names.FormattingEnabled = true;
            this.cmb_Names.Location = new System.Drawing.Point(36, 77);
            this.cmb_Names.Name = "cmb_Names";
            this.cmb_Names.Size = new System.Drawing.Size(226, 21);
            this.cmb_Names.TabIndex = 1;
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(36, 141);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(87, 33);
            this.btn_Select.TabIndex = 2;
            this.btn_Select.Text = "Select";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(175, 141);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(87, 33);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 458);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.cmb_Names);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Avery Ali Final";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Names;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Close;
    }
}

