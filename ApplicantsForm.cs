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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DataGridStarostin
{
    public partial class ApplicantsForm : Form
    {
        private Applicant applicant;
        public ApplicantsForm(Applicant applicant = null)
        {
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

            InitializeComponent();

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
                comboBox1.Items.Add(item);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            textBox1.AddBinding(x => x.Text, this.applicant, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, this.applicant, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, this.applicant, x => x.Birthday, errorProvider1);
            comboBox2.AddBinding(x => x.SelectedItem, this.applicant, x => x.Education, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, this.applicant, x => x.Math, errorProvider1);
            numericUpDown2.AddBinding(x => x.Value, this.applicant, x => x.Russian, errorProvider1);
            numericUpDown3.AddBinding(x => x.Value, this.applicant, x => x.ComputerScience, errorProvider1);
            textBox2.AddBinding(x => x.Text, this.applicant, x => x.TotalScore, errorProvider1);
        }

        public Applicant Applicant => applicant;
    }
}
