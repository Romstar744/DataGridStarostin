using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridStarostin.Models;

namespace DataGridStarostin
{
    public partial class Form1 : Form
    {
        private List<Applicant> people;
        private BindingSource bindingSource;
        public Form1()
        {
            bindingSource = new BindingSource();
            people = new List<Applicant>();
            bindingSource.DataSource = people;

            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        private void toolStripAdd_Click(object sender, EventArgs e)
        {
            var applicantsForm = new ApplicantsForm();
            if (applicantsForm.ShowDialog() == DialogResult.OK)
            {
               
            }
        }
    }
}
