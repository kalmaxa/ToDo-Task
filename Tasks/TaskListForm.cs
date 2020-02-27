using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Microsoft.Office.Interop.Excel;

namespace Tasks
{
    public partial class TaskListForm : Form
    {
        public TaskListForm()
        {
            InitializeComponent();
            cBoxSelectStatus.DataSource = new List<TaskStatus> {
                new TaskStatus { Id = 0, Name = "ToDo"},
                new TaskStatus { Id = 1, Name = "Done"},
                new TaskStatus { Id = -1, Name = "Deleted"},
                new TaskStatus { Id = 10, Name = "All" } };
            cBoxSelectStatus.DisplayMember = "Name";
            cBoxSelectStatus.ValueMember = "Id";

            cBoxSelectStatus.SelectedIndex = 0;
            load();
        }
        private void load()
        {
            var db = new DatabaseOperations();

            var selectedStatus = (TaskStatus)cBoxSelectStatus.SelectedItem;

            var tasks = db.GetTasks(selectedStatus.Id == 10? (int?)null: selectedStatus.Id);
            dataGridView1.DataSource = tasks;

        }

        private void bShowTasks_Click(object sender, EventArgs e)
        {
            
        }


        private void BAddTask_Click(object sender, EventArgs e)
        {
            var addForm = new TaskForm();
            addForm.ShowDialog();
            load();
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if(taskBindingSource.Current is Task task)
            {
                var editForm = new TaskForm(task);
                editForm.ShowDialog();
            }
        }
        private void dataGridView1_CellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Task task)
                {
                    var editForm = new TaskForm(task);
                    editForm.ShowDialog();
                }
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (taskBindingSource.Current is Task task)
            {
                if(MessageBox.Show("ნამდვილად გსურს წაშლა?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var db = new DatabaseOperations();
                    db.DeleteData(task.Id);
                    MessageBox.Show("წაიშალა წარმატებით", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 6:
                    {
                        if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Task selectedTask)
                        {
                            var editForm = new TaskForm(selectedTask);
                            editForm.ShowDialog();
                            //MessageBox.Show("შეიცვალა წარმატებით", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            load();
                        }
                    }
                    break;
                case 7:
                    {
                        if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Task selectedTask)
                        {
                            if (MessageBox.Show("ნამდვილად გსურს წაშლა?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var db = new DatabaseOperations();
                                db.DeleteData(selectedTask.Id);
                                MessageBox.Show("წაიშალა წარმატებით", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                load();
                            }
                        }
                    }
                    break;
            }   
        }
       


       

        private void bOk_Click(object sender, EventArgs e)
        {
            load();
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                //worksheet(1).Cells("A1:E1").Style.Fill.BackgroundColor = ;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            workbook.SaveAs("C:\\Users\\nino.kalmaxelidze\\Desktop\\taskiii", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
            load();
        }
    }
}
