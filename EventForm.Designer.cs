using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    partial class EventForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventForm));
            this.close = new System.Windows.Forms.Button();
            this.Insert = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.holidayDataSet4 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet4();
            this.полнаяИнформацияОМероприятияхBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.полнаяИнформацияОМероприятияхTableAdapter = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet4TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter();
            this.holidayDataSet5 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet5();
            this.полнаяИнформацияОМероприятияхBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.полнаяИнформацияОМероприятияхTableAdapter1 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet5TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter();
            this.полнаяИнформацияОМероприятияхBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet6 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet6();
            this.полнаяИнформацияОМероприятияхTableAdapter2 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet6TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter();
            this.полнаяИнформацияОМероприятияхBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet23 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet23();
            this.полнаяИнформацияОМероприятияхTableAdapter3 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet23TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.lblSearchStatus = new System.Windows.Forms.Label();
            this.btnResetFilters = new System.Windows.Forms.Button();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.comboBoxSearchType = new System.Windows.Forms.ComboBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.dataGridViewEvents = new System.Windows.Forms.DataGridView();
            this.номерМероприятияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фИОЗаказчикаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.телефонЗаказчикаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.категорияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.местоПроведенияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.адресDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.стоимостьАрендыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.дополнительнаяУслугаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.стоимостьУслугиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаЗаказаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаПроведенияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.времяНачалаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.длительностьчасовDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоУчастниковDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ответственныйСотрудникDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.телефонСотрудникаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.общаяСтоимостьDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.прибыльDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bottomPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet23)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.close.Location = new System.Drawing.Point(1737, 7);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(220, 81);
            this.close.TabIndex = 0;
            this.close.Text = "Назад";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Insert
            // 
            this.Insert.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Insert.FlatAppearance.BorderSize = 0;
            this.Insert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Insert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Insert.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.Insert.Location = new System.Drawing.Point(14, 7);
            this.Insert.Name = "Insert";
            this.Insert.Size = new System.Drawing.Size(220, 81);
            this.Insert.TabIndex = 2;
            this.Insert.Text = "Добавить";
            this.Insert.UseVisualStyleBackColor = false;
            this.Insert.Click += new System.EventHandler(this.Insert_Click);
            // 
            // Update
            // 
            this.Update.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Update.FlatAppearance.BorderSize = 0;
            this.Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.Update.Location = new System.Drawing.Point(250, 7);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(220, 81);
            this.Update.TabIndex = 3;
            this.Update.Text = "Редактировать";
            this.Update.UseVisualStyleBackColor = false;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Restart
            // 
            this.Restart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Restart.FlatAppearance.BorderSize = 0;
            this.Restart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Restart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Restart.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic);
            this.Restart.Location = new System.Drawing.Point(487, 7);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(220, 81);
            this.Restart.TabIndex = 6;
            this.Restart.Text = "Обновить";
            this.Restart.UseVisualStyleBackColor = false;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // holidayDataSet4
            // 
            this.holidayDataSet4.DataSetName = "HolidayDataSet4";
            this.holidayDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // полнаяИнформацияОМероприятияхBindingSource
            // 
            this.полнаяИнформацияОМероприятияхBindingSource.DataMember = "ПолнаяИнформацияОМероприятиях";
            this.полнаяИнформацияОМероприятияхBindingSource.DataSource = this.holidayDataSet4;
            // 
            // полнаяИнформацияОМероприятияхTableAdapter
            // 
            this.полнаяИнформацияОМероприятияхTableAdapter.ClearBeforeFill = true;
            // 
            // holidayDataSet5
            // 
            this.holidayDataSet5.DataSetName = "HolidayDataSet5";
            this.holidayDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // полнаяИнформацияОМероприятияхBindingSource1
            // 
            this.полнаяИнформацияОМероприятияхBindingSource1.DataMember = "ПолнаяИнформацияОМероприятиях";
            this.полнаяИнформацияОМероприятияхBindingSource1.DataSource = this.holidayDataSet5;
            // 
            // полнаяИнформацияОМероприятияхTableAdapter1
            // 
            this.полнаяИнформацияОМероприятияхTableAdapter1.ClearBeforeFill = true;
            // 
            // полнаяИнформацияОМероприятияхBindingSource2
            // 
            this.полнаяИнформацияОМероприятияхBindingSource2.DataMember = "ПолнаяИнформацияОМероприятиях";
            this.полнаяИнформацияОМероприятияхBindingSource2.DataSource = this.holidayDataSet6;
            // 
            // holidayDataSet6
            // 
            this.holidayDataSet6.DataSetName = "HolidayDataSet6";
            this.holidayDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // полнаяИнформацияОМероприятияхTableAdapter2
            // 
            this.полнаяИнформацияОМероприятияхTableAdapter2.ClearBeforeFill = true;
            // 
            // полнаяИнформацияОМероприятияхBindingSource3
            // 
            this.полнаяИнформацияОМероприятияхBindingSource3.DataMember = "ПолнаяИнформацияОМероприятиях";
            this.полнаяИнформацияОМероприятияхBindingSource3.DataSource = this.holidayDataSet23;
            // 
            // holidayDataSet23
            // 
            this.holidayDataSet23.DataSetName = "HolidayDataSet23";
            this.holidayDataSet23.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // полнаяИнформацияОМероприятияхTableAdapter3
            // 
            this.полнаяИнформацияОМероприятияхTableAdapter3.ClearBeforeFill = true;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.searchPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.topPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.bottomPanel, 0, 2);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1983, 1149);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.searchPanel.Controls.Add(this.comboBoxStatus);
            this.searchPanel.Controls.Add(this.lblSearchStatus);
            this.searchPanel.Controls.Add(this.btnResetFilters);
            this.searchPanel.Controls.Add(this.dtpFilterDate);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Controls.Add(this.comboBoxSearchType);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(3, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(10);
            this.searchPanel.Size = new System.Drawing.Size(1977, 110);
            this.searchPanel.TabIndex = 0;
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxStatus.Items.AddRange(new object[] {
            "Все",
            "Выполнено",
            "Сегодня",
            "Предстоящее"});
            this.comboBoxStatus.Location = new System.Drawing.Point(1030, 14);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(310, 47);
            this.comboBoxStatus.TabIndex = 5;
            this.comboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // lblSearchStatus
            // 
            this.lblSearchStatus.AutoSize = true;
            this.lblSearchStatus.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearchStatus.Location = new System.Drawing.Point(7, 64);
            this.lblSearchStatus.Name = "lblSearchStatus";
            this.lblSearchStatus.Size = new System.Drawing.Size(354, 39);
            this.lblSearchStatus.TabIndex = 0;
            this.lblSearchStatus.Text = "Показаны все мероприятия";
            // 
            // btnResetFilters
            // 
            this.btnResetFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnResetFilters.FlatAppearance.BorderSize = 0;
            this.btnResetFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFilters.Font = new System.Drawing.Font("Monotype Corsiva", 11F, System.Drawing.FontStyle.Italic);
            this.btnResetFilters.Location = new System.Drawing.Point(1786, 10);
            this.btnResetFilters.Name = "btnResetFilters";
            this.btnResetFilters.Size = new System.Drawing.Size(171, 53);
            this.btnResetFilters.TabIndex = 4;
            this.btnResetFilters.Text = "Сбросить";
            this.btnResetFilters.UseVisualStyleBackColor = false;
            this.btnResetFilters.Click += new System.EventHandler(this.BtnResetFilters_Click);
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFilterDate.Checked = false;
            this.dtpFilterDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Location = new System.Drawing.Point(1497, 14);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.ShowCheckBox = true;
            this.dtpFilterDate.Size = new System.Drawing.Size(266, 43);
            this.dtpFilterDate.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Monotype Corsiva", 11F, System.Drawing.FontStyle.Italic);
            this.btnSearch.Location = new System.Drawing.Point(808, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(171, 53);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(280, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(502, 43);
            this.txtSearch.TabIndex = 1;
            // 
            // comboBoxSearchType
            // 
            this.comboBoxSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchType.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxSearchType.Items.AddRange(new object[] {
            "Заказчик",
            "Категория",
            "Место проведения",
            "Дополнительная услуга",
            "Сотрудник"});
            this.comboBoxSearchType.Location = new System.Drawing.Point(12, 12);
            this.comboBoxSearchType.Name = "comboBoxSearchType";
            this.comboBoxSearchType.Size = new System.Drawing.Size(245, 47);
            this.comboBoxSearchType.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.dataGridViewEvents);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 119);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(10);
            this.topPanel.Size = new System.Drawing.Size(1977, 923);
            this.topPanel.TabIndex = 1;
            // 
            // dataGridViewEvents
            // 
            this.dataGridViewEvents.AllowUserToAddRows = false;
            this.dataGridViewEvents.AllowUserToDeleteRows = false;
            this.dataGridViewEvents.AutoGenerateColumns = false;
            this.dataGridViewEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewEvents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEvents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewEvents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEvents.ColumnHeadersHeight = 50;
            this.dataGridViewEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерМероприятияDataGridViewTextBoxColumn,
            this.фИОЗаказчикаDataGridViewTextBoxColumn,
            this.телефонЗаказчикаDataGridViewTextBoxColumn,
            this.категорияDataGridViewTextBoxColumn,
            this.местоПроведенияDataGridViewTextBoxColumn,
            this.адресDataGridViewTextBoxColumn,
            this.стоимостьАрендыDataGridViewTextBoxColumn,
            this.дополнительнаяУслугаDataGridViewTextBoxColumn,
            this.стоимостьУслугиDataGridViewTextBoxColumn,
            this.датаЗаказаDataGridViewTextBoxColumn,
            this.датаПроведенияDataGridViewTextBoxColumn,
            this.времяНачалаDataGridViewTextBoxColumn,
            this.длительностьчасовDataGridViewTextBoxColumn,
            this.количествоУчастниковDataGridViewTextBoxColumn,
            this.ответственныйСотрудникDataGridViewTextBoxColumn,
            this.телефонСотрудникаDataGridViewTextBoxColumn,
            this.общаяСтоимостьDataGridViewTextBoxColumn,
            this.прибыльDataGridViewTextBoxColumn,
            this.статусDataGridViewTextBoxColumn});
            this.dataGridViewEvents.DataSource = this.полнаяИнформацияОМероприятияхBindingSource3;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEvents.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEvents.EnableHeadersVisualStyles = false;
            this.dataGridViewEvents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataGridViewEvents.Location = new System.Drawing.Point(10, 10);
            this.dataGridViewEvents.MultiSelect = false;
            this.dataGridViewEvents.Name = "dataGridViewEvents";
            this.dataGridViewEvents.ReadOnly = true;
            this.dataGridViewEvents.RowHeadersVisible = false;
            this.dataGridViewEvents.RowHeadersWidth = 82;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridViewEvents.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewEvents.RowTemplate.Height = 35;
            this.dataGridViewEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvents.Size = new System.Drawing.Size(1957, 903);
            this.dataGridViewEvents.TabIndex = 0;
            // 
            // номерМероприятияDataGridViewTextBoxColumn
            // 
            this.номерМероприятияDataGridViewTextBoxColumn.DataPropertyName = "Номер мероприятия";
            this.номерМероприятияDataGridViewTextBoxColumn.HeaderText = "Номер мероприятия";
            this.номерМероприятияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.номерМероприятияDataGridViewTextBoxColumn.Name = "номерМероприятияDataGridViewTextBoxColumn";
            this.номерМероприятияDataGridViewTextBoxColumn.ReadOnly = true;
            this.номерМероприятияDataGridViewTextBoxColumn.Visible = false;
            this.номерМероприятияDataGridViewTextBoxColumn.Width = 349;
            // 
            // фИОЗаказчикаDataGridViewTextBoxColumn
            // 
            this.фИОЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "ФИО заказчика";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.HeaderText = "ФИО заказчика";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.фИОЗаказчикаDataGridViewTextBoxColumn.Name = "фИОЗаказчикаDataGridViewTextBoxColumn";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.ReadOnly = true;
            this.фИОЗаказчикаDataGridViewTextBoxColumn.Width = 283;
            // 
            // телефонЗаказчикаDataGridViewTextBoxColumn
            // 
            this.телефонЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "Телефон заказчика";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.HeaderText = "Телефон заказчика";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.телефонЗаказчикаDataGridViewTextBoxColumn.Name = "телефонЗаказчикаDataGridViewTextBoxColumn";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.ReadOnly = true;
            this.телефонЗаказчикаDataGridViewTextBoxColumn.Width = 336;
            // 
            // категорияDataGridViewTextBoxColumn
            // 
            this.категорияDataGridViewTextBoxColumn.DataPropertyName = "Категория";
            this.категорияDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.категорияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.категорияDataGridViewTextBoxColumn.Name = "категорияDataGridViewTextBoxColumn";
            this.категорияDataGridViewTextBoxColumn.ReadOnly = true;
            this.категорияDataGridViewTextBoxColumn.Width = 212;
            // 
            // местоПроведенияDataGridViewTextBoxColumn
            // 
            this.местоПроведенияDataGridViewTextBoxColumn.DataPropertyName = "Место проведения";
            this.местоПроведенияDataGridViewTextBoxColumn.HeaderText = "Место проведения";
            this.местоПроведенияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.местоПроведенияDataGridViewTextBoxColumn.Name = "местоПроведенияDataGridViewTextBoxColumn";
            this.местоПроведенияDataGridViewTextBoxColumn.ReadOnly = true;
            this.местоПроведенияDataGridViewTextBoxColumn.Width = 334;
            // 
            // адресDataGridViewTextBoxColumn
            // 
            this.адресDataGridViewTextBoxColumn.DataPropertyName = "Адрес";
            this.адресDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.адресDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.адресDataGridViewTextBoxColumn.Name = "адресDataGridViewTextBoxColumn";
            this.адресDataGridViewTextBoxColumn.ReadOnly = true;
            this.адресDataGridViewTextBoxColumn.Width = 156;
            // 
            // стоимостьАрендыDataGridViewTextBoxColumn
            // 
            this.стоимостьАрендыDataGridViewTextBoxColumn.DataPropertyName = "Стоимость аренды";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.стоимостьАрендыDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.стоимостьАрендыDataGridViewTextBoxColumn.HeaderText = "Стоимость аренды";
            this.стоимостьАрендыDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.стоимостьАрендыDataGridViewTextBoxColumn.Name = "стоимостьАрендыDataGridViewTextBoxColumn";
            this.стоимостьАрендыDataGridViewTextBoxColumn.ReadOnly = true;
            this.стоимостьАрендыDataGridViewTextBoxColumn.Width = 330;
            // 
            // дополнительнаяУслугаDataGridViewTextBoxColumn
            // 
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.DataPropertyName = "Дополнительная услуга";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.HeaderText = "Дополнительная услуга";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.Name = "дополнительнаяУслугаDataGridViewTextBoxColumn";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.ReadOnly = true;
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.Width = 397;
            // 
            // стоимостьУслугиDataGridViewTextBoxColumn
            // 
            this.стоимостьУслугиDataGridViewTextBoxColumn.DataPropertyName = "Стоимость услуги";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.стоимостьУслугиDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.стоимостьУслугиDataGridViewTextBoxColumn.HeaderText = "Стоимость услуги";
            this.стоимостьУслугиDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.стоимостьУслугиDataGridViewTextBoxColumn.Name = "стоимостьУслугиDataGridViewTextBoxColumn";
            this.стоимостьУслугиDataGridViewTextBoxColumn.ReadOnly = true;
            this.стоимостьУслугиDataGridViewTextBoxColumn.Width = 315;
            // 
            // датаЗаказаDataGridViewTextBoxColumn
            // 
            this.датаЗаказаDataGridViewTextBoxColumn.DataPropertyName = "Дата заказа";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.датаЗаказаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.датаЗаказаDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.датаЗаказаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.датаЗаказаDataGridViewTextBoxColumn.Name = "датаЗаказаDataGridViewTextBoxColumn";
            this.датаЗаказаDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаЗаказаDataGridViewTextBoxColumn.Width = 230;
            // 
            // датаПроведенияDataGridViewTextBoxColumn
            // 
            this.датаПроведенияDataGridViewTextBoxColumn.DataPropertyName = "Дата проведения";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.датаПроведенияDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.датаПроведенияDataGridViewTextBoxColumn.HeaderText = "Дата проведения";
            this.датаПроведенияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.датаПроведенияDataGridViewTextBoxColumn.Name = "датаПроведенияDataGridViewTextBoxColumn";
            this.датаПроведенияDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаПроведенияDataGridViewTextBoxColumn.Width = 310;
            // 
            // времяНачалаDataGridViewTextBoxColumn
            // 
            this.времяНачалаDataGridViewTextBoxColumn.DataPropertyName = "Время начала";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.времяНачалаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.времяНачалаDataGridViewTextBoxColumn.HeaderText = "Время начала";
            this.времяНачалаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.времяНачалаDataGridViewTextBoxColumn.Name = "времяНачалаDataGridViewTextBoxColumn";
            this.времяНачалаDataGridViewTextBoxColumn.ReadOnly = true;
            this.времяНачалаDataGridViewTextBoxColumn.Width = 263;
            // 
            // длительностьчасовDataGridViewTextBoxColumn
            // 
            this.длительностьчасовDataGridViewTextBoxColumn.DataPropertyName = "Длительность (часов)";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.длительностьчасовDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.длительностьчасовDataGridViewTextBoxColumn.HeaderText = "Длительность (часов)";
            this.длительностьчасовDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.длительностьчасовDataGridViewTextBoxColumn.Name = "длительностьчасовDataGridViewTextBoxColumn";
            this.длительностьчасовDataGridViewTextBoxColumn.ReadOnly = true;
            this.длительностьчасовDataGridViewTextBoxColumn.Width = 368;
            // 
            // количествоУчастниковDataGridViewTextBoxColumn
            // 
            this.количествоУчастниковDataGridViewTextBoxColumn.DataPropertyName = "Количество участников";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.количествоУчастниковDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.количествоУчастниковDataGridViewTextBoxColumn.HeaderText = "Количество участников";
            this.количествоУчастниковDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.количествоУчастниковDataGridViewTextBoxColumn.Name = "количествоУчастниковDataGridViewTextBoxColumn";
            this.количествоУчастниковDataGridViewTextBoxColumn.ReadOnly = true;
            this.количествоУчастниковDataGridViewTextBoxColumn.Width = 398;
            // 
            // ответственныйСотрудникDataGridViewTextBoxColumn
            // 
            this.ответственныйСотрудникDataGridViewTextBoxColumn.DataPropertyName = "Ответственный сотрудник";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.HeaderText = "Ответственный сотрудник";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.ответственныйСотрудникDataGridViewTextBoxColumn.Name = "ответственныйСотрудникDataGridViewTextBoxColumn";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.ReadOnly = true;
            this.ответственныйСотрудникDataGridViewTextBoxColumn.Width = 432;
            // 
            // телефонСотрудникаDataGridViewTextBoxColumn
            // 
            this.телефонСотрудникаDataGridViewTextBoxColumn.DataPropertyName = "Телефон сотрудника";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.телефонСотрудникаDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.телефонСотрудникаDataGridViewTextBoxColumn.HeaderText = "Телефон сотрудника";
            this.телефонСотрудникаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.телефонСотрудникаDataGridViewTextBoxColumn.Name = "телефонСотрудникаDataGridViewTextBoxColumn";
            this.телефонСотрудникаDataGridViewTextBoxColumn.ReadOnly = true;
            this.телефонСотрудникаDataGridViewTextBoxColumn.Width = 358;
            // 
            // общаяСтоимостьDataGridViewTextBoxColumn
            // 
            this.общаяСтоимостьDataGridViewTextBoxColumn.DataPropertyName = "Общая стоимость";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            this.общаяСтоимостьDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.общаяСтоимостьDataGridViewTextBoxColumn.HeaderText = "Общая стоимость";
            this.общаяСтоимостьDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.общаяСтоимостьDataGridViewTextBoxColumn.Name = "общаяСтоимостьDataGridViewTextBoxColumn";
            this.общаяСтоимостьDataGridViewTextBoxColumn.ReadOnly = true;
            this.общаяСтоимостьDataGridViewTextBoxColumn.Width = 317;
            // 
            // прибыльDataGridViewTextBoxColumn
            // 
            this.прибыльDataGridViewTextBoxColumn.DataPropertyName = "Прибыль";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            this.прибыльDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.прибыльDataGridViewTextBoxColumn.HeaderText = "Прибыль";
            this.прибыльDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.прибыльDataGridViewTextBoxColumn.Name = "прибыльDataGridViewTextBoxColumn";
            this.прибыльDataGridViewTextBoxColumn.ReadOnly = true;
            this.прибыльDataGridViewTextBoxColumn.Width = 198;
            // 
            // статусDataGridViewTextBoxColumn
            // 
            this.статусDataGridViewTextBoxColumn.DataPropertyName = "Статус";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.статусDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            this.статусDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.статусDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.статусDataGridViewTextBoxColumn.Name = "статусDataGridViewTextBoxColumn";
            this.статусDataGridViewTextBoxColumn.ReadOnly = true;
            this.статусDataGridViewTextBoxColumn.Width = 160;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomPanel.Controls.Add(this.Insert);
            this.bottomPanel.Controls.Add(this.Update);
            this.bottomPanel.Controls.Add(this.Restart);
            this.bottomPanel.Controls.Add(this.close);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 1048);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1977, 98);
            this.bottomPanel.TabIndex = 2;
            // 
            // EventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1983, 1149);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "EventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление мероприятиями";
            this.Load += new System.EventHandler(this.EventForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.полнаяИнформацияОМероприятияхBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet23)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.topPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvents)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Все элементы управления
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button Insert;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Restart;
        private HolidayDataSet4 holidayDataSet4;
        private System.Windows.Forms.BindingSource полнаяИнформацияОМероприятияхBindingSource;
        private HolidayDataSet4TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter полнаяИнформацияОМероприятияхTableAdapter;
        private HolidayDataSet5 holidayDataSet5;
        private System.Windows.Forms.BindingSource полнаяИнформацияОМероприятияхBindingSource1;
        private HolidayDataSet5TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter полнаяИнформацияОМероприятияхTableAdapter1;
        private HolidayDataSet6 holidayDataSet6;
        private System.Windows.Forms.BindingSource полнаяИнформацияОМероприятияхBindingSource2;
        private HolidayDataSet6TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter полнаяИнформацияОМероприятияхTableAdapter2;
        private System.Windows.Forms.BindingSource полнаяИнформацияОМероприятияхBindingSource3;
        private HolidayDataSet23 holidayDataSet23;
        private HolidayDataSet23TableAdapters.ПолнаяИнформацияОМероприятияхTableAdapter полнаяИнформацияОМероприятияхTableAdapter3;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.DataGridView dataGridViewEvents;
        private System.Windows.Forms.ComboBox comboBoxSearchType;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Button btnResetFilters;
        private System.Windows.Forms.Label lblSearchStatus;

        // Колонки DataGridView
        private System.Windows.Forms.DataGridViewTextBoxColumn номерМероприятияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОЗаказчикаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонЗаказчикаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn категорияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn местоПроведенияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn адресDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn стоимостьАрендыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn дополнительнаяУслугаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn стоимостьУслугиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаЗаказаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаПроведенияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn времяНачалаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn длительностьчасовDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоУчастниковDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ответственныйСотрудникDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn телефонСотрудникаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn общаяСтоимостьDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn прибыльDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        
    }
}