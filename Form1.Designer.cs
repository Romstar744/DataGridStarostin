namespace DataGridStarostin
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.BirthdayColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EducationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RussianColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ComputerScienceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalScoreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// toolStripDelete
			// 
			this.toolStripDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDelete.Image")));
			this.toolStripDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDelete.Name = "toolStripDelete";
			this.toolStripDelete.Size = new System.Drawing.Size(23, 22);
			this.toolStripDelete.Text = "toolStripButton3";
			this.toolStripDelete.Click += new System.EventHandler(this.toolStripDelete_Click);
			// 
			// toolStripEdit
			// 
			this.toolStripEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripEdit.Image")));
			this.toolStripEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripEdit.Name = "toolStripEdit";
			this.toolStripEdit.Size = new System.Drawing.Size(23, 22);
			this.toolStripEdit.Text = "toolStripButton2";
			this.toolStripEdit.Click += new System.EventHandler(this.toolStripEdit_Click);
			// 
			// toolStripAdd
			// 
			this.toolStripAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripAdd.Image")));
			this.toolStripAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripAdd.Name = "toolStripAdd";
			this.toolStripAdd.Size = new System.Drawing.Size(23, 22);
			this.toolStripAdd.Text = "toolStripButton1";
			this.toolStripAdd.Click += new System.EventHandler(this.toolStripAdd_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripAdd,
            this.toolStripEdit,
            this.toolStripDelete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(841, 25);
			this.toolStrip1.TabIndex = 5;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.справкаToolStripMenuItem.Text = "Справка";
			// 
			// правкаToolStripMenuItem
			// 
			this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
			this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.правкаToolStripMenuItem.Text = "Правка";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(841, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.справкаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(841, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.GenderColumn,
            this.BirthdayColumn,
            this.EducationColumn,
            this.MathColumn,
            this.RussianColumn,
            this.ComputerScienceColumn,
            this.TotalScoreColumn});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 49);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(841, 379);
			this.dataGridView1.TabIndex = 7;
			this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
			// 
			// NameColumn
			// 
			this.NameColumn.DataPropertyName = "Name";
			this.NameColumn.HeaderText = "ФИО";
			this.NameColumn.Name = "NameColumn";
			this.NameColumn.ReadOnly = true;
			// 
			// GenderColumn
			// 
			this.GenderColumn.DataPropertyName = "Gender";
			this.GenderColumn.HeaderText = "Пол";
			this.GenderColumn.Name = "GenderColumn";
			this.GenderColumn.ReadOnly = true;
			// 
			// BirthdayColumn
			// 
			this.BirthdayColumn.DataPropertyName = "Birthday";
			this.BirthdayColumn.HeaderText = "Дата рождения";
			this.BirthdayColumn.Name = "BirthdayColumn";
			this.BirthdayColumn.ReadOnly = true;
			// 
			// EducationColumn
			// 
			this.EducationColumn.DataPropertyName = "Education";
			this.EducationColumn.HeaderText = "Форма обучения";
			this.EducationColumn.Name = "EducationColumn";
			this.EducationColumn.ReadOnly = true;
			this.EducationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.EducationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// MathColumn
			// 
			this.MathColumn.DataPropertyName = "Math";
			this.MathColumn.HeaderText = "Математика";
			this.MathColumn.Name = "MathColumn";
			this.MathColumn.ReadOnly = true;
			this.MathColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.MathColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// RussianColumn
			// 
			this.RussianColumn.DataPropertyName = "Russian";
			this.RussianColumn.HeaderText = "Русский";
			this.RussianColumn.Name = "RussianColumn";
			this.RussianColumn.ReadOnly = true;
			this.RussianColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.RussianColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ComputerScienceColumn
			// 
			this.ComputerScienceColumn.DataPropertyName = "ComputerScience";
			this.ComputerScienceColumn.HeaderText = "Информатика";
			this.ComputerScienceColumn.Name = "ComputerScienceColumn";
			this.ComputerScienceColumn.ReadOnly = true;
			this.ComputerScienceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// TotalScoreColumn
			// 
			this.TotalScoreColumn.DataPropertyName = "TotalScore";
			this.TotalScoreColumn.HeaderText = "Сумма баллов";
			this.TotalScoreColumn.Name = "TotalScoreColumn";
			this.TotalScoreColumn.ReadOnly = true;
			this.TotalScoreColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(841, 450);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Form1";
			this.Text = "Данные абитуриентов";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton toolStripDelete;
        private System.Windows.Forms.ToolStripButton toolStripEdit;
        private System.Windows.Forms.ToolStripButton toolStripAdd;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthdayColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EducationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RussianColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComputerScienceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalScoreColumn;
    }
}

