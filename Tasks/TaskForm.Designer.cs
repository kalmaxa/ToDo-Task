namespace Tasks
{
    partial class TaskForm
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
            this.bSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lImportance = new System.Windows.Forms.Label();
            this.cBoxImportance = new System.Windows.Forms.ComboBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.cBoxStatus = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(339, 84);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 0;
            this.bSave.Text = "save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "დავალება";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(320, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "test";
            // 
            // lImportance
            // 
            this.lImportance.AutoSize = true;
            this.lImportance.Location = new System.Drawing.Point(16, 52);
            this.lImportance.Name = "lImportance";
            this.lImportance.Size = new System.Drawing.Size(76, 13);
            this.lImportance.TabIndex = 4;
            this.lImportance.Text = "პრიორიტეტი";
            // 
            // cBoxImportance
            // 
            this.cBoxImportance.FormattingEnabled = true;
            this.cBoxImportance.Location = new System.Drawing.Point(103, 49);
            this.cBoxImportance.Name = "cBoxImportance";
            this.cBoxImportance.Size = new System.Drawing.Size(153, 21);
            this.cBoxImportance.TabIndex = 6;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(16, 89);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(55, 13);
            this.lStatus.TabIndex = 4;
            this.lStatus.Text = "სტატუსი";
            // 
            // cBoxStatus
            // 
            this.cBoxStatus.FormattingEnabled = true;
            this.cBoxStatus.Location = new System.Drawing.Point(103, 86);
            this.cBoxStatus.Name = "cBoxStatus";
            this.cBoxStatus.Size = new System.Drawing.Size(153, 21);
            this.cBoxStatus.TabIndex = 6;
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 149);
            this.Controls.Add(this.cBoxStatus);
            this.Controls.Add(this.lStatus);
            this.Controls.Add(this.cBoxImportance);
            this.Controls.Add(this.lImportance);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSave);
            this.Name = "TaskForm";
            this.Text = "TaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lImportance;
        private System.Windows.Forms.ComboBox cBoxImportance;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.ComboBox cBoxStatus;
    }
}