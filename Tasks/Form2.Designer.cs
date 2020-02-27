namespace Tasks
{
    partial class Form2
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
            this.tNewTask = new System.Windows.Forms.TextBox();
            this.lNewTask = new System.Windows.Forms.Label();
            this.bAddNewTask = new System.Windows.Forms.Button();
            this.lImportance1 = new System.Windows.Forms.Label();
            this.cBoxImportance1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tNewTask
            // 
            this.tNewTask.Location = new System.Drawing.Point(172, 39);
            this.tNewTask.Name = "tNewTask";
            this.tNewTask.Size = new System.Drawing.Size(370, 20);
            this.tNewTask.TabIndex = 0;
            // 
            // lNewTask
            // 
            this.lNewTask.AutoSize = true;
            this.lNewTask.Location = new System.Drawing.Point(44, 38);
            this.lNewTask.Name = "lNewTask";
            this.lNewTask.Size = new System.Drawing.Size(104, 13);
            this.lNewTask.TabIndex = 1;
            this.lNewTask.Text = "ახალი დავალება";
            // 
            // bAddNewTask
            // 
            this.bAddNewTask.Location = new System.Drawing.Point(467, 83);
            this.bAddNewTask.Name = "bAddNewTask";
            this.bAddNewTask.Size = new System.Drawing.Size(75, 23);
            this.bAddNewTask.TabIndex = 2;
            this.bAddNewTask.Text = "OK";
            this.bAddNewTask.UseVisualStyleBackColor = true;
            this.bAddNewTask.Click += new System.EventHandler(this.BAddNewTask_Click);
            // 
            // lImportance1
            // 
            this.lImportance1.AutoSize = true;
            this.lImportance1.Location = new System.Drawing.Point(44, 91);
            this.lImportance1.Name = "lImportance1";
            this.lImportance1.Size = new System.Drawing.Size(76, 13);
            this.lImportance1.TabIndex = 3;
            this.lImportance1.Text = "პრიორიტეტი";
            this.lImportance1.Click += new System.EventHandler(this.lImportance1_Click);
            // 
            // cBoxImportance1
            // 
            this.cBoxImportance1.FormattingEnabled = true;
            this.cBoxImportance1.Location = new System.Drawing.Point(172, 83);
            this.cBoxImportance1.Name = "cBoxImportance1";
            this.cBoxImportance1.Size = new System.Drawing.Size(121, 21);
            this.cBoxImportance1.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 130);
            this.Controls.Add(this.cBoxImportance1);
            this.Controls.Add(this.lImportance1);
            this.Controls.Add(this.bAddNewTask);
            this.Controls.Add(this.lNewTask);
            this.Controls.Add(this.tNewTask);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tNewTask;
        private System.Windows.Forms.Label lNewTask;
        private System.Windows.Forms.Button bAddNewTask;
        private System.Windows.Forms.Label lImportance1;
        private System.Windows.Forms.ComboBox cBoxImportance1;
    }
}