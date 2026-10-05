using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    partial class DocumentsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Category = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDEventCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet7 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet7();
            this.Service = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iDAdditionalServicesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameServicesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalServicesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet10 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet10();
            this.tabPageLocation = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.iDLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentalPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet11 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet11();
            this.event_CategoryTableAdapter = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet7TableAdapters.Event_CategoryTableAdapter();
            this.holidayDataSet8 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet8();
            this.additionalServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.additional_ServicesTableAdapter = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet8TableAdapters.Additional_ServicesTableAdapter();
            this.holidayDataSet9 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet9();
            this.additionalServicesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.additional_ServicesTableAdapter1 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet9TableAdapters.Additional_ServicesTableAdapter();
            this.additional_ServicesTableAdapter2 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet10TableAdapters.Additional_ServicesTableAdapter();
            this.locationTableAdapter = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet11TableAdapters.LocationTableAdapter();
            this.Add = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.Category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet7)).BeginInit();
            this.Service.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet10)).BeginInit();
            this.tabPageLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource1)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Category);
            this.tabControl1.Controls.Add(this.Service);
            this.tabControl1.Controls.Add(this.tabPageLocation);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1368, 664);
            this.tabControl1.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.Controls.Add(this.dataGridView1);
            this.Category.Location = new System.Drawing.Point(8, 51);
            this.Category.Name = "Category";
            this.Category.Padding = new System.Windows.Forms.Padding(3);
            this.Category.Size = new System.Drawing.Size(1352, 605);
            this.Category.TabIndex = 0;
            this.Category.Text = "Категории";
            this.Category.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDEventCategoryDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.eventCategoryBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1346, 599);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDEventCategoryDataGridViewTextBoxColumn
            // 
            this.iDEventCategoryDataGridViewTextBoxColumn.DataPropertyName = "ID_Event_Category";
            this.iDEventCategoryDataGridViewTextBoxColumn.HeaderText = "Номер категории";
            this.iDEventCategoryDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.iDEventCategoryDataGridViewTextBoxColumn.Name = "iDEventCategoryDataGridViewTextBoxColumn";
            this.iDEventCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDEventCategoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.titleDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // eventCategoryBindingSource
            // 
            this.eventCategoryBindingSource.DataMember = "Event_Category";
            this.eventCategoryBindingSource.DataSource = this.holidayDataSet7;
            // 
            // holidayDataSet7
            // 
            this.holidayDataSet7.DataSetName = "HolidayDataSet7";
            this.holidayDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Service
            // 
            this.Service.Controls.Add(this.dataGridView2);
            this.Service.Location = new System.Drawing.Point(8, 51);
            this.Service.Name = "Service";
            this.Service.Padding = new System.Windows.Forms.Padding(3);
            this.Service.Size = new System.Drawing.Size(1352, 589);
            this.Service.TabIndex = 1;
            this.Service.Text = "Доп. услуги";
            this.Service.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.ColumnHeadersHeight = 45;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDAdditionalServicesDataGridViewTextBoxColumn,
            this.nameServicesDataGridViewTextBoxColumn,
            this.costDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.additionalServicesBindingSource2;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataGridView2.Location = new System.Drawing.Point(3, 3);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 82;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView2.RowTemplate.Height = 35;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1346, 583);
            this.dataGridView2.TabIndex = 1;
            // 
            // iDAdditionalServicesDataGridViewTextBoxColumn
            // 
            this.iDAdditionalServicesDataGridViewTextBoxColumn.DataPropertyName = "ID_Additional_Services";
            this.iDAdditionalServicesDataGridViewTextBoxColumn.HeaderText = "Номер доп. услуги";
            this.iDAdditionalServicesDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.iDAdditionalServicesDataGridViewTextBoxColumn.Name = "iDAdditionalServicesDataGridViewTextBoxColumn";
            this.iDAdditionalServicesDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDAdditionalServicesDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameServicesDataGridViewTextBoxColumn
            // 
            this.nameServicesDataGridViewTextBoxColumn.DataPropertyName = "Name_Services";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nameServicesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.nameServicesDataGridViewTextBoxColumn.FillWeight = 70F;
            this.nameServicesDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameServicesDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.nameServicesDataGridViewTextBoxColumn.Name = "nameServicesDataGridViewTextBoxColumn";
            // 
            // costDataGridViewTextBoxColumn
            // 
            this.costDataGridViewTextBoxColumn.DataPropertyName = "Cost";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Format = "N2";
            this.costDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.costDataGridViewTextBoxColumn.FillWeight = 30F;
            this.costDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            this.costDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.costDataGridViewTextBoxColumn.Name = "costDataGridViewTextBoxColumn";
            // 
            // additionalServicesBindingSource2
            // 
            this.additionalServicesBindingSource2.DataMember = "Additional_Services";
            this.additionalServicesBindingSource2.DataSource = this.holidayDataSet10;
            // 
            // holidayDataSet10
            // 
            this.holidayDataSet10.DataSetName = "HolidayDataSet10";
            this.holidayDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPageLocation
            // 
            this.tabPageLocation.Controls.Add(this.dataGridView3);
            this.tabPageLocation.Location = new System.Drawing.Point(8, 51);
            this.tabPageLocation.Name = "tabPageLocation";
            this.tabPageLocation.Size = new System.Drawing.Size(1352, 589);
            this.tabPageLocation.TabIndex = 2;
            this.tabPageLocation.Text = "Места проведения";
            this.tabPageLocation.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToOrderColumns = true;
            this.dataGridView3.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView3.ColumnHeadersHeight = 45;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDLocationDataGridViewTextBoxColumn,
            this.nameLocationDataGridViewTextBoxColumn,
            this.addressLocationDataGridViewTextBoxColumn,
            this.rentalPriceDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.locationBindingSource;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.EnableHeadersVisualStyles = false;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowHeadersWidth = 82;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView3.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView3.RowTemplate.Height = 35;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(1352, 589);
            this.dataGridView3.TabIndex = 2;
            // 
            // iDLocationDataGridViewTextBoxColumn
            // 
            this.iDLocationDataGridViewTextBoxColumn.DataPropertyName = "ID_Location";
            this.iDLocationDataGridViewTextBoxColumn.HeaderText = "Номер локации";
            this.iDLocationDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.iDLocationDataGridViewTextBoxColumn.Name = "iDLocationDataGridViewTextBoxColumn";
            this.iDLocationDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDLocationDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameLocationDataGridViewTextBoxColumn
            // 
            this.nameLocationDataGridViewTextBoxColumn.DataPropertyName = "Name_Location";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.nameLocationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.nameLocationDataGridViewTextBoxColumn.FillWeight = 35F;
            this.nameLocationDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameLocationDataGridViewTextBoxColumn.MinimumWidth = 120;
            this.nameLocationDataGridViewTextBoxColumn.Name = "nameLocationDataGridViewTextBoxColumn";
            // 
            // addressLocationDataGridViewTextBoxColumn
            // 
            this.addressLocationDataGridViewTextBoxColumn.DataPropertyName = "Address_Location";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.addressLocationDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.addressLocationDataGridViewTextBoxColumn.FillWeight = 35F;
            this.addressLocationDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.addressLocationDataGridViewTextBoxColumn.MinimumWidth = 170;
            this.addressLocationDataGridViewTextBoxColumn.Name = "addressLocationDataGridViewTextBoxColumn";
            // 
            // rentalPriceDataGridViewTextBoxColumn
            // 
            this.rentalPriceDataGridViewTextBoxColumn.DataPropertyName = "Rental_Price";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.Format = "N2";
            this.rentalPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.rentalPriceDataGridViewTextBoxColumn.FillWeight = 30F;
            this.rentalPriceDataGridViewTextBoxColumn.HeaderText = "Стоимость аренды";
            this.rentalPriceDataGridViewTextBoxColumn.MinimumWidth = 150;
            this.rentalPriceDataGridViewTextBoxColumn.Name = "rentalPriceDataGridViewTextBoxColumn";
            // 
            // locationBindingSource
            // 
            this.locationBindingSource.DataMember = "Location";
            this.locationBindingSource.DataSource = this.holidayDataSet11;
            // 
            // holidayDataSet11
            // 
            this.holidayDataSet11.DataSetName = "HolidayDataSet11";
            this.holidayDataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // event_CategoryTableAdapter
            // 
            this.event_CategoryTableAdapter.ClearBeforeFill = true;
            // 
            // holidayDataSet8
            // 
            this.holidayDataSet8.DataSetName = "HolidayDataSet8";
            this.holidayDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // additional_ServicesTableAdapter
            // 
            this.additional_ServicesTableAdapter.ClearBeforeFill = true;
            // 
            // holidayDataSet9
            // 
            this.holidayDataSet9.DataSetName = "HolidayDataSet9";
            this.holidayDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // additional_ServicesTableAdapter1
            // 
            this.additional_ServicesTableAdapter1.ClearBeforeFill = true;
            // 
            // additional_ServicesTableAdapter2
            // 
            this.additional_ServicesTableAdapter2.ClearBeforeFill = true;
            // 
            // locationTableAdapter
            // 
            this.locationTableAdapter.ClearBeforeFill = true;
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Add.FlatAppearance.BorderSize = 0;
            this.Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Add.Location = new System.Drawing.Point(14, 7);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(220, 81);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Update.FlatAppearance.BorderSize = 0;
            this.Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Update.Location = new System.Drawing.Point(251, 7);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(220, 81);
            this.Update.TabIndex = 2;
            this.Update.Text = "Редактировать";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Delete.FlatAppearance.BorderSize = 0;
            this.Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(487, 7);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(220, 81);
            this.Delete.TabIndex = 3;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Restart.FlatAppearance.BorderSize = 0;
            this.Restart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Restart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restart.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Restart.Location = new System.Drawing.Point(724, 7);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(220, 81);
            this.Restart.TabIndex = 4;
            this.Restart.Text = "Обновить";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.AutoEllipsis = true;
            this.Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.Location = new System.Drawing.Point(1164, 7);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(220, 81);
            this.Close.TabIndex = 5;
            this.Close.Text = "Назад";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.contentPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.bottomPanel, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 2;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1400, 800);
            this.mainTableLayoutPanel.TabIndex = 6;
            // 
            // contentPanel
            // 
            this.contentPanel.Controls.Add(this.tabControl1);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(3, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(10);
            this.contentPanel.Size = new System.Drawing.Size(1394, 690);
            this.contentPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomPanel.Controls.Add(this.Add);
            this.bottomPanel.Controls.Add(this.Update);
            this.bottomPanel.Controls.Add(this.Delete);
            this.bottomPanel.Controls.Add(this.Restart);
            this.bottomPanel.Controls.Add(this.Close);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 699);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1394, 98);
            this.bottomPanel.TabIndex = 1;
            // 
            // DocumentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "DocumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.Load += new System.EventHandler(this.DocumentsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.Category.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet7)).EndInit();
            this.Service.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet10)).EndInit();
            this.tabPageLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.locationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.additionalServicesBindingSource1)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Category;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage Service;
        private System.Windows.Forms.TabPage tabPageLocation;
        private HolidayDataSet7 holidayDataSet7;
        private System.Windows.Forms.BindingSource eventCategoryBindingSource;
        private HolidayDataSet7TableAdapters.Event_CategoryTableAdapter event_CategoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDEventCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private HolidayDataSet8 holidayDataSet8;
        private System.Windows.Forms.BindingSource additionalServicesBindingSource;
        private HolidayDataSet8TableAdapters.Additional_ServicesTableAdapter additional_ServicesTableAdapter;
        private HolidayDataSet9 holidayDataSet9;
        private System.Windows.Forms.BindingSource additionalServicesBindingSource1;
        private HolidayDataSet9TableAdapters.Additional_ServicesTableAdapter additional_ServicesTableAdapter1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private HolidayDataSet10 holidayDataSet10;
        private System.Windows.Forms.BindingSource additionalServicesBindingSource2;
        private HolidayDataSet10TableAdapters.Additional_ServicesTableAdapter additional_ServicesTableAdapter2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private HolidayDataSet11 holidayDataSet11;
        private System.Windows.Forms.BindingSource locationBindingSource;
        private HolidayDataSet11TableAdapters.LocationTableAdapter locationTableAdapter;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDAdditionalServicesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameServicesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rentalPriceDataGridViewTextBoxColumn;

        // Элементы для масштабирования
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel bottomPanel;
    }
}