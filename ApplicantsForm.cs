using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridStarostin.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DataGridStarostin
{
    public partial class ApplicantsForm : Form
    {
        private Applicant applicant;
        public Applicant Applicant => applicant;
        public ApplicantsForm(Applicant applicant = null)
        {
            InitializeComponent();

            this.applicant = applicant == null
              ? DataGenerator.CreateApplicant(x =>
              {
                  x.Id = Guid.NewGuid();
                  x.Name = "Иванов";
                  x.Gender = Gender.Male;
                  x.Birthday = DateTime.Now.AddYears(-12);
              })
              : new Applicant
              {
                  Id = applicant.Id,
                  Name = applicant.Name,
                  Gender = Gender.Male,
                  Birthday = applicant.Birthday,
                  Education = Education.FullTime,
                  Math = applicant.Math,
                  Russian = applicant.Russian,
                  ComputerScience = applicant.ComputerScience,
                  TotalScore = applicant.TotalScore,
              };

            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                comboBox1.Items.Add(item);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            foreach (var item in Enum.GetValues(typeof(Education)))
            {
                comboBox2.Items.Add(item);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }

            textBox1.AddBinding(x => x.Text, Applicant, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, Applicant, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, Applicant, x => x.Birthday, errorProvider1);
            comboBox2.AddBinding(x => x.SelectedItem, Applicant, x => x.Education, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, Applicant, x => x.Math, errorProvider1);
            numericUpDown2.AddBinding(x => x.Value, Applicant, x => x.Russian, errorProvider1);
            numericUpDown3.AddBinding(x => x.Value, Applicant, x => x.ComputerScience, errorProvider1);
            textBox2.AddBinding(x => x.Text, Applicant, x => x.TotalScore, errorProvider1);

            UpdateData();
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Gender)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValue(value),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
            }
        }

        private string GetDisplayValue(Gender value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }

        private void UpdateData()
        {
            textBox2.Text = (numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value).ToString();
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //decimal value1 = numericUpDown1.Value;
            //decimal value2 = numericUpDown2.Value;
            //decimal value3 = numericUpDown3.Value;

            //Functions function = new Functions();

            //decimal result = function.CalculateResult(value1, value2, value3);

            //textBox2.Text = result.ToString();
            UpdateData();
        }
    }
}
