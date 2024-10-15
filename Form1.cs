using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridStarostin.Framework.Contracts;
using DataGridStarostin.Models;

namespace DataGridStarostin
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        private IApplicantManager applicantManager;
        private BindingSource bindingSource;
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="Form1" />
        /// </summary>
        /// <param name="applicantManager"></param>
        public Form1(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
            bindingSource = new BindingSource();

            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        private async void toolStripAdd_Click(object sender, System.EventArgs e)
        {
            var applicantsForm = new ApplicantsForm();
            if (applicantsForm.ShowDialog(this) == DialogResult.OK)
            {
                await applicantManager.AddAsync(applicantsForm.Applicant);
                bindingSource.ResetBindings(false);
                await SetStatus();
            }
        }

        private async void toolStripEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Applicant)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                var applicantsForm = new ApplicantsForm(data);
                if (applicantsForm.ShowDialog(this) == DialogResult.OK)
                {
                    await applicantManager.EditAsync(applicantsForm.Applicant);
                    bindingSource.ResetBindings(false);
                    await SetStatus();
                }
            }
        }

        private async void toolStripDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                var data = (Applicant)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
                if (MessageBox.Show($"Вы действительно хотите удалить {data.Name}?", "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await applicantManager.DeleteAsync(data.Id);
                    bindingSource.ResetBindings(false);
                    await SetStatus();
                }
            }
        }

        public async Task SetStatus()
        {
            var result = await applicantManager.GetStatsAsync();
            toolStripStatusLabel1.Text = $"Всего: {result.Count}";
            toolStripStatusLabel2.Text = $"{result.FemaleCount} Ж/{result.MaleCount} М";
            toolStripStatusLabel3.Text = $"Студенты, набравшие больше 150 баллов в сумме: {result.TotalScoreCount}";
            toolStripStatusLabel4.Text = $"Очный {result.FullTimeCount} / Oчно-Заочный {result.FTPTCount} / Заочный {result.СorrespondenceCount}";
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "TotalScoreColumn")
            {
                var data = (Applicant)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                data.TotalScore = data.Math + data.Russian + data.ComputerScience;
                e.Value = data.TotalScore;
                SetStatus();
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = await applicantManager.GetAllAsync();
            await SetStatus();
        }
    }
}
