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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cBoxImportance1.DataSource = Enum.GetValues(typeof(Importance));
        }

        private void BAddNewTask_Click(object sender, EventArgs e)
        {
            var db = new DatabaseOperations();
            db.InsertData(tNewTask.ToString(), cBoxImportance1.Text);
            
        }

        private void lImportance1_Click(object sender, EventArgs e)
        {

        }
    }
}
