namespace DataConnectionString
{
    partial class AddMessage
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
            this.btn_close = new System.Windows.Forms.Button();
            this.AddMessages = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cmb_service = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addNotes = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(174, 240);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(109, 33);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Close Form";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // AddMessages
            // 
            this.AddMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AddMessages.Location = new System.Drawing.Point(39, 29);
            this.AddMessages.Name = "AddMessages";
            this.AddMessages.Size = new System.Drawing.Size(197, 39);
            this.AddMessages.TabIndex = 1;
            this.AddMessages.Text = "Add Messages";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(44, 71);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // cmb_service
            // 
            this.cmb_service.FormattingEnabled = true;
            this.cmb_service.Items.AddRange(new object[] {
            "Service Issue",
            "General Communication",
            "Account Management"});
            this.cmb_service.Location = new System.Drawing.Point(44, 97);
            this.cmb_service.Name = "cmb_service";
            this.cmb_service.Size = new System.Drawing.Size(200, 21);
            this.cmb_service.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(39, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 39);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Notes";
            // 
            // addNotes
            // 
            this.addNotes.Location = new System.Drawing.Point(44, 176);
            this.addNotes.Name = "addNotes";
            this.addNotes.Size = new System.Drawing.Size(462, 20);
            this.addNotes.TabIndex = 5;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(44, 240);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(109, 33);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Save and Close";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // AddMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 501);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.addNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_service);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.AddMessages);
            this.Controls.Add(this.btn_close);
            this.Name = "AddMessage";
            this.Text = "AddMessage";
            this.Load += new System.EventHandler(this.AddMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label AddMessages;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox cmb_service;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox addNotes;
        private System.Windows.Forms.Button btn_save;
    }
}