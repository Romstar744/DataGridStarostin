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
			this.AvgGradeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ExpelledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DeptColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.toolStrip1.Size = new System.Drawing.Size(705, 25);
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
			this.statusStrip1.Size = new System.Drawing.Size(705, 22);
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
			this.menuStrip1.Size = new System.Drawing.Size(705, 24);
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
            this.AvgGradeColumn,
            this.ExpelledColumn,
            this.DeptColumn});
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 49);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(705, 379);
			this.dataGridView1.TabIndex = 7;
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
			// AvgGradeColumn
			// 
			this.AvgGradeColumn.DataPropertyName = "AvgGrade";
			this.AvgGradeColumn.HeaderText = "Ср. оценка";
			this.AvgGradeColumn.Name = "AvgGradeColumn";
			this.AvgGradeColumn.ReadOnly = true;
			this.AvgGradeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.AvgGradeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ExpelledColumn
			// 
			this.ExpelledColumn.DataPropertyName = "Expelled";
			this.ExpelledColumn.HeaderText = "Отчислен";
			this.ExpelledColumn.Name = "ExpelledColumn";
			this.ExpelledColumn.ReadOnly = true;
			this.ExpelledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.ExpelledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// DeptColumn
			// 
			this.DeptColumn.DataPropertyName = "Dept";
			this.DeptColumn.HeaderText = "Задолженность";
			this.DeptColumn.Name = "DeptColumn";
			this.DeptColumn.ReadOnly = true;
			this.DeptColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.DeptColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(705, 450);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Name = "Form1";
			this.Text = "Form1";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgGradeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpelledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeptColumn;
    }
}

