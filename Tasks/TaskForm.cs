using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasks
{
    public partial class TaskForm : Form
    {
        private Task _task;
        public TaskForm()
        {
            InitializeComponent();
            cBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
            cBoxStatus.DataSource = Enum.GetValues(typeof(Status));
            //cBoxImportance.DisplayMember = "Value";
            //cBoxImportance.ValueMember = "Id";
        }
        public TaskForm(Task selectedTask) : this()
        {
            _task = selectedTask;
            textBox1.Text = selectedTask.Name;
            cBoxImportance.DataSource = Enum.GetValues(typeof(Importance));
            cBoxImportance.DisplayMember = "Value";
            cBoxImportance.Text = selectedTask.Importance.ToString();

            cBoxStatus.DataSource = new List<TaskStatus> { 
                new TaskStatus { Id = -1, Name = Status.Deleted.ToString() },
                new TaskStatus { Id = 0, Name = Status.ToDo.ToString() },
                new TaskStatus { Id = 1, Name = Status.Done.ToString() }                
            };
            cBoxStatus.DisplayMember = "Name";
            cBoxStatus.ValueMember = "Id";
            cBoxStatus.Text = selectedTask.Status.ToString();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if(_task == null)
            {
                var db = new DatabaseOperations();
                db.InsertData(textBox1.Text, cBoxImportance.Text);
                MessageBox.Show("დაემატა წარმატებით", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var db = new DatabaseOperations();
                db.UpdateData(_task.Id, textBox1.Text, cBoxImportance.Text, (int)cBoxStatus.SelectedValue);
                MessageBox.Show("შეიცვალა წარმატებით", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }
    }
}
