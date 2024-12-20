﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using DataGridStarostin.Standart.Contracts.Models;
using ComboBox = System.Windows.Forms.ComboBox;

namespace DataGridStarostin
{
    /// <summary>
    /// Форма добавления данных абитуриентов
    /// </summary>
    public partial class ApplicantsForm : Form
    {
        private ValidateApplicant applicant;
        /// <summary>
        /// Конструктор
        /// </summary>
        public ApplicantsForm(ValidateApplicant applicant = null)
        {
            InitializeComponent();
            this.applicant = applicant == null
              ? new ValidateApplicant
              {
                  Id = Guid.NewGuid(),
                  Name = "Старостин Роман Александрович",
                  Gender = Gender.Male,
                  Birthday = DateTime.Now.AddYears(-12),
                  Education = Education.FullTime,
                  Math = 100,
                  Russian = 100,
                  ComputerScience = 100,
              }
              : new ValidateApplicant
              {
                  Id = applicant.Id,
                  Name = applicant.Name,
                  Gender = applicant.Gender,
                  Birthday = applicant.Birthday,
                  Education = applicant.Education,
                  Math = applicant.Math,
                  Russian = applicant.Russian,
                  ComputerScience = applicant.ComputerScience,
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

            textBox1.AddBinding(x => x.Text, this.applicant, x => x.Name, errorProvider1);
            comboBox1.AddBinding(x => x.SelectedItem, this.applicant, x => x.Gender, errorProvider1);
            dateTimePicker1.AddBinding(x => x.Value, this.applicant, x => x.Birthday, errorProvider1);
            comboBox2.AddBinding(x => x.SelectedItem, this.applicant, x => x.Education, errorProvider1);
            numericUpDown1.AddBinding(x => x.Value, this.applicant, x => x.Math, errorProvider1);
            numericUpDown2.AddBinding(x => x.Value, this.applicant, x => x.Russian, errorProvider1);
            numericUpDown3.AddBinding(x => x.Value, this.applicant, x => x.ComputerScience, errorProvider1);
        }

        private void CalculateResult()
        {
            textBox2.Text = (numericUpDown1.Value + numericUpDown2.Value + numericUpDown3.Value).ToString();
        }

        private void CalculateResult(object sender, EventArgs e)
        {
            CalculateResult();
        }

        /// <summary>
        /// Данные абитуриентов, с которыми работает эта форма
        /// </summary>
        public ValidateApplicant ValidateApplicant => applicant;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Red, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Gender)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValueGender(value),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
            }
        }

        private string GetDisplayValueGender(Gender value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Height - 4, e.Bounds.Height - 4));
            if (e.Index > -1)
            {
                var value = (Education)(sender as ComboBox).Items[e.Index];
                e.Graphics.DrawString(GetDisplayValueEducation(value),
                   e.Font,
                   new SolidBrush(e.ForeColor),
                   e.Bounds.X + 20,
                   e.Bounds.Y);
            }
        }
        private string GetDisplayValueEducation(Education value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes<DescriptionAttribute>(false);
            return attributes.FirstOrDefault()?.Description ?? "IDK";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidatableApplicant(applicant))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidatableApplicant(ValidateApplicant applicant)
        {
            var context = new ValidationContext(applicant, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(applicant, context, results, true);
        }
    }
}
