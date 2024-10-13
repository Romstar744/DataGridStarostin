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
                people.Add(applicantsForm.Applicant);
                bindingSource.ResetBindings(false);
            }
        }

        private void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Applicant)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var personForm = new ApplicantsForm(data);
                if (personForm.ShowDialog(this) == DialogResult.OK)
                {
                    data.Name = personForm.Applicant.Name;
                    data.Gender = personForm.Applicant.Gender;
                    data.Birthday = personForm.Applicant.Birthday;
                    data.Education = personForm.Applicant.Education;
                    data.Math = personForm.Applicant.Math;
                    data.Russian = personForm.Applicant.Russian;
                    data.ComputerScience = personForm.Applicant.ComputerScience;
                    data.TotalScore = personForm.Applicant.TotalScore;
                    bindingSource.ResetBindings(false);
                    SetStatus();
                }
            }
        }

        private void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Applicant)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    people.Remove(data);
                    bindingSource.ResetBindings(false);
                    SetStatus();
                }
            }
        }

        public void SetStatus()
        {
            toolStripStatusLabel1.Text = $"Всего: {people.Count}";
            toolStripStatusLabel2.Text = $"{people.Where(x => x.Gender == Gender.Female).Count()} Ж/{people.Where(x => x.Gender == Gender.Male).Count()} М";
            toolStripStatusLabel5.Text = $"Студенты, набравшие больше 150 баллов в сумме: {people.Count}";
        }
    }
}
