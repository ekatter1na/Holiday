using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Event = new System.Windows.Forms.Button();
            this.Documents = new System.Windows.Forms.Button();
            this.Client = new System.Windows.Forms.Button();
            this.Staff = new System.Windows.Forms.Button();
            this.Analysis = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.holidayDataSet = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet();
            this.предстоящиеМероприятияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.предстоящиеМероприятияTableAdapter = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSetTableAdapters.ПредстоящиеМероприятияTableAdapter();
            this.holidayDataSet1 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet1();
            this.предстоящиеМероприятияBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.предстоящиеМероприятияTableAdapter1 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet1TableAdapters.ПредстоящиеМероприятияTableAdapter();
            this.holidayDataSet2 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet2();
            this.предстоящиеМероприятияBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.предстоящиеМероприятияTableAdapter2 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet2TableAdapters.ПредстоящиеМероприятияTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.предстоящиеМероприятияBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.holidayDataSet3 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet3();
            this.предстоящиеМероприятияTableAdapter3 = new Курсовая_Жирнова_Е.А._Holiday.HolidayDataSet3TableAdapters.ПредстоящиеМероприятияTableAdapter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonFilters = new System.Windows.Forms.Button();
            this.DatePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet3)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Event
            // 
            this.Event.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Event.FlatAppearance.BorderSize = 0;
            this.Event.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Event.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Event.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Event.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Event.Location = new System.Drawing.Point(9, 7);
            this.Event.Name = "Event";
            this.Event.Size = new System.Drawing.Size(220, 81);
            this.Event.TabIndex = 0;
            this.Event.Text = "Мероприятия";
            this.Event.UseVisualStyleBackColor = false;
            this.Event.Click += new System.EventHandler(this.Event_Click);
            // 
            // Documents
            // 
            this.Documents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Documents.FlatAppearance.BorderSize = 0;
            this.Documents.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Documents.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Documents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Documents.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Documents.Location = new System.Drawing.Point(240, 7);
            this.Documents.Name = "Documents";
            this.Documents.Size = new System.Drawing.Size(220, 81);
            this.Documents.TabIndex = 1;
            this.Documents.Text = "Справочники";
            this.Documents.UseVisualStyleBackColor = false;
            this.Documents.Click += new System.EventHandler(this.Documents_Click);
            // 
            // Client
            // 
            this.Client.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Client.FlatAppearance.BorderSize = 0;
            this.Client.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Client.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Client.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Client.Location = new System.Drawing.Point(472, 7);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(220, 81);
            this.Client.TabIndex = 2;
            this.Client.Text = "Заказчики";
            this.Client.UseVisualStyleBackColor = false;
            this.Client.Click += new System.EventHandler(this.Client_Click);
            // 
            // Staff
            // 
            this.Staff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Staff.FlatAppearance.BorderSize = 0;
            this.Staff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Staff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Staff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Staff.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Staff.Location = new System.Drawing.Point(705, 7);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(220, 81);
            this.Staff.TabIndex = 3;
            this.Staff.Text = "Сотрудники";
            this.Staff.UseVisualStyleBackColor = false;
            this.Staff.Click += new System.EventHandler(this.Staff_Click);
            // 
            // Analysis
            // 
            this.Analysis.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Analysis.FlatAppearance.BorderSize = 0;
            this.Analysis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Analysis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Analysis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Analysis.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Analysis.Location = new System.Drawing.Point(937, 7);
            this.Analysis.Name = "Analysis";
            this.Analysis.Size = new System.Drawing.Size(220, 81);
            this.Analysis.TabIndex = 4;
            this.Analysis.Text = "Аналитика";
            this.Analysis.UseVisualStyleBackColor = false;
            this.Analysis.Click += new System.EventHandler(this.Analysis_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Close.Location = new System.Drawing.Point(1486, 7);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(220, 81);
            this.Close.TabIndex = 6;
            this.Close.Text = "Выход";
            this.Close.UseVisualStyleBackColor = false;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 120);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "ХХХХХХ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Всего мероприятий";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(426, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 120);
            this.panel2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 45);
            this.label3.TabIndex = 3;
            this.label3.Text = "ХХХХХХ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(20, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 52);
            this.label4.TabIndex = 2;
            this.label4.Text = "Общая выручка";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(826, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(391, 120);
            this.panel3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(20, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 45);
            this.label5.TabIndex = 5;
            this.label5.Text = "ХХХХХХ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(20, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 52);
            this.label6.TabIndex = 4;
            this.label6.Text = "Предстоящие";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(1223, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(385, 120);
            this.panel4.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 13.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(20, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 45);
            this.label7.TabIndex = 7;
            this.label7.Text = "ХХХХХХ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(20, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 52);
            this.label8.TabIndex = 6;
            this.label8.Text = "Заказчиков";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.Font = new System.Drawing.Font("Monotype Corsiva", 19.875F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(622, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(435, 64);
            this.label9.TabIndex = 10;
            this.label9.Text = "DD.mm.yy HH:MM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label10.Font = new System.Drawing.Font("Monotype Corsiva", 16.125F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(0, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(425, 52);
            this.label10.TabIndex = 11;
            this.label10.Text = "Предстоящие события:";
            // 
            // holidayDataSet
            // 
            this.holidayDataSet.DataSetName = "HolidayDataSet";
            this.holidayDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // предстоящиеМероприятияBindingSource
            // 
            this.предстоящиеМероприятияBindingSource.DataMember = "ПредстоящиеМероприятия";
            this.предстоящиеМероприятияBindingSource.DataSource = this.holidayDataSet;
            // 
            // предстоящиеМероприятияTableAdapter
            // 
            this.предстоящиеМероприятияTableAdapter.ClearBeforeFill = true;
            // 
            // holidayDataSet1
            // 
            this.holidayDataSet1.DataSetName = "HolidayDataSet1";
            this.holidayDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // предстоящиеМероприятияBindingSource1
            // 
            this.предстоящиеМероприятияBindingSource1.DataMember = "ПредстоящиеМероприятия";
            this.предстоящиеМероприятияBindingSource1.DataSource = this.holidayDataSet1;
            // 
            // предстоящиеМероприятияTableAdapter1
            // 
            this.предстоящиеМероприятияTableAdapter1.ClearBeforeFill = true;
            // 
            // holidayDataSet2
            // 
            this.holidayDataSet2.DataSetName = "HolidayDataSet2";
            this.holidayDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // предстоящиеМероприятияBindingSource2
            // 
            this.предстоящиеМероприятияBindingSource2.DataMember = "ПредстоящиеМероприятия";
            this.предстоящиеМероприятияBindingSource2.DataSource = this.holidayDataSet2;
            // 
            // предстоящиеМероприятияTableAdapter2
            // 
            this.предстоящиеМероприятияTableAdapter2.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 60;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.прибыльDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.предстоящиеМероприятияBindingSource3;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1722, 454);
            this.dataGridView1.TabIndex = 12;
            // 
            // фИОЗаказчикаDataGridViewTextBoxColumn
            // 
            this.фИОЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "ФИО заказчика";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.HeaderText = "ФИО заказчика";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.фИОЗаказчикаDataGridViewTextBoxColumn.Name = "фИОЗаказчикаDataGridViewTextBoxColumn";
            this.фИОЗаказчикаDataGridViewTextBoxColumn.ReadOnly = true;
            this.фИОЗаказчикаDataGridViewTextBoxColumn.Width = 150;
            // 
            // телефонЗаказчикаDataGridViewTextBoxColumn
            // 
            this.телефонЗаказчикаDataGridViewTextBoxColumn.DataPropertyName = "Телефон заказчика";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.HeaderText = "Телефон заказчика";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.телефонЗаказчикаDataGridViewTextBoxColumn.Name = "телефонЗаказчикаDataGridViewTextBoxColumn";
            this.телефонЗаказчикаDataGridViewTextBoxColumn.ReadOnly = true;
            this.телефонЗаказчикаDataGridViewTextBoxColumn.Width = 130;
            // 
            // категорияDataGridViewTextBoxColumn
            // 
            this.категорияDataGridViewTextBoxColumn.DataPropertyName = "Категория";
            this.категорияDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.категорияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.категорияDataGridViewTextBoxColumn.Name = "категорияDataGridViewTextBoxColumn";
            this.категорияDataGridViewTextBoxColumn.ReadOnly = true;
            this.категорияDataGridViewTextBoxColumn.Width = 120;
            // 
            // местоПроведенияDataGridViewTextBoxColumn
            // 
            this.местоПроведенияDataGridViewTextBoxColumn.DataPropertyName = "Место проведения";
            this.местоПроведенияDataGridViewTextBoxColumn.HeaderText = "Место проведения";
            this.местоПроведенияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.местоПроведенияDataGridViewTextBoxColumn.Name = "местоПроведенияDataGridViewTextBoxColumn";
            this.местоПроведенияDataGridViewTextBoxColumn.ReadOnly = true;
            this.местоПроведенияDataGridViewTextBoxColumn.Width = 130;
            // 
            // адресDataGridViewTextBoxColumn
            // 
            this.адресDataGridViewTextBoxColumn.DataPropertyName = "Адрес";
            this.адресDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.адресDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.адресDataGridViewTextBoxColumn.Name = "адресDataGridViewTextBoxColumn";
            this.адресDataGridViewTextBoxColumn.ReadOnly = true;
            this.адресDataGridViewTextBoxColumn.Width = 150;
            // 
            // стоимостьАрендыDataGridViewTextBoxColumn
            // 
            this.стоимостьАрендыDataGridViewTextBoxColumn.DataPropertyName = "Стоимость аренды";
            this.стоимостьАрендыDataGridViewTextBoxColumn.HeaderText = "Стоимость аренды";
            this.стоимостьАрендыDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.стоимостьАрендыDataGridViewTextBoxColumn.Name = "стоимостьАрендыDataGridViewTextBoxColumn";
            this.стоимостьАрендыDataGridViewTextBoxColumn.ReadOnly = true;
            this.стоимостьАрендыDataGridViewTextBoxColumn.Width = 130;
            // 
            // дополнительнаяУслугаDataGridViewTextBoxColumn
            // 
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.DataPropertyName = "Дополнительная услуга";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.HeaderText = "Дополнительная услуга";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.Name = "дополнительнаяУслугаDataGridViewTextBoxColumn";
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.ReadOnly = true;
            this.дополнительнаяУслугаDataGridViewTextBoxColumn.Width = 150;
            // 
            // стоимостьУслугиDataGridViewTextBoxColumn
            // 
            this.стоимостьУслугиDataGridViewTextBoxColumn.DataPropertyName = "Стоимость услуги";
            this.стоимостьУслугиDataGridViewTextBoxColumn.HeaderText = "Стоимость услуги";
            this.стоимостьУслугиDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.стоимостьУслугиDataGridViewTextBoxColumn.Name = "стоимостьУслугиDataGridViewTextBoxColumn";
            this.стоимостьУслугиDataGridViewTextBoxColumn.ReadOnly = true;
            this.стоимостьУслугиDataGridViewTextBoxColumn.Width = 130;
            // 
            // датаЗаказаDataGridViewTextBoxColumn
            // 
            this.датаЗаказаDataGridViewTextBoxColumn.DataPropertyName = "Дата заказа";
            this.датаЗаказаDataGridViewTextBoxColumn.HeaderText = "Дата заказа";
            this.датаЗаказаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.датаЗаказаDataGridViewTextBoxColumn.Name = "датаЗаказаDataGridViewTextBoxColumn";
            this.датаЗаказаDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаЗаказаDataGridViewTextBoxColumn.Width = 110;
            // 
            // датаПроведенияDataGridViewTextBoxColumn
            // 
            this.датаПроведенияDataGridViewTextBoxColumn.DataPropertyName = "Дата проведения";
            this.датаПроведенияDataGridViewTextBoxColumn.HeaderText = "Дата проведения";
            this.датаПроведенияDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.датаПроведенияDataGridViewTextBoxColumn.Name = "датаПроведенияDataGridViewTextBoxColumn";
            this.датаПроведенияDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаПроведенияDataGridViewTextBoxColumn.Width = 110;
            // 
            // времяНачалаDataGridViewTextBoxColumn
            // 
            this.времяНачалаDataGridViewTextBoxColumn.DataPropertyName = "Время начала";
            this.времяНачалаDataGridViewTextBoxColumn.HeaderText = "Время начала";
            this.времяНачалаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.времяНачалаDataGridViewTextBoxColumn.Name = "времяНачалаDataGridViewTextBoxColumn";
            this.времяНачалаDataGridViewTextBoxColumn.ReadOnly = true;
            this.времяНачалаDataGridViewTextBoxColumn.Width = 90;
            // 
            // длительностьчасовDataGridViewTextBoxColumn
            // 
            this.длительностьчасовDataGridViewTextBoxColumn.DataPropertyName = "Длительность (часов)";
            this.длительностьчасовDataGridViewTextBoxColumn.HeaderText = "Длительность (часов)";
            this.длительностьчасовDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.длительностьчасовDataGridViewTextBoxColumn.Name = "длительностьчасовDataGridViewTextBoxColumn";
            this.длительностьчасовDataGridViewTextBoxColumn.ReadOnly = true;
            this.длительностьчасовDataGridViewTextBoxColumn.Width = 120;
            // 
            // количествоУчастниковDataGridViewTextBoxColumn
            // 
            this.количествоУчастниковDataGridViewTextBoxColumn.DataPropertyName = "Количество участников";
            this.количествоУчастниковDataGridViewTextBoxColumn.HeaderText = "Количество участников";
            this.количествоУчастниковDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.количествоУчастниковDataGridViewTextBoxColumn.Name = "количествоУчастниковDataGridViewTextBoxColumn";
            this.количествоУчастниковDataGridViewTextBoxColumn.ReadOnly = true;
            this.количествоУчастниковDataGridViewTextBoxColumn.Width = 130;
            // 
            // ответственныйСотрудникDataGridViewTextBoxColumn
            // 
            this.ответственныйСотрудникDataGridViewTextBoxColumn.DataPropertyName = "Ответственный сотрудник";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.HeaderText = "Ответственный сотрудник";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.ответственныйСотрудникDataGridViewTextBoxColumn.Name = "ответственныйСотрудникDataGridViewTextBoxColumn";
            this.ответственныйСотрудникDataGridViewTextBoxColumn.ReadOnly = true;
            this.ответственныйСотрудникDataGridViewTextBoxColumn.Width = 150;
            // 
            // телефонСотрудникаDataGridViewTextBoxColumn
            // 
            this.телефонСотрудникаDataGridViewTextBoxColumn.DataPropertyName = "Телефон сотрудника";
            this.телефонСотрудникаDataGridViewTextBoxColumn.HeaderText = "Телефон сотрудника";
            this.телефонСотрудникаDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.телефонСотрудникаDataGridViewTextBoxColumn.Name = "телефонСотрудникаDataGridViewTextBoxColumn";
            this.телефонСотрудникаDataGridViewTextBoxColumn.ReadOnly = true;
            this.телефонСотрудникаDataGridViewTextBoxColumn.Width = 130;
            // 
            // общаяСтоимостьDataGridViewTextBoxColumn
            // 
            this.общаяСтоимостьDataGridViewTextBoxColumn.DataPropertyName = "Общая стоимость";
            this.общаяСтоимостьDataGridViewTextBoxColumn.HeaderText = "Общая стоимость";
            this.общаяСтоимостьDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.общаяСтоимостьDataGridViewTextBoxColumn.Name = "общаяСтоимостьDataGridViewTextBoxColumn";
            this.общаяСтоимостьDataGridViewTextBoxColumn.ReadOnly = true;
            this.общаяСтоимостьDataGridViewTextBoxColumn.Width = 130;
            // 
            // прибыльDataGridViewTextBoxColumn
            // 
            this.прибыльDataGridViewTextBoxColumn.DataPropertyName = "Прибыль";
            this.прибыльDataGridViewTextBoxColumn.HeaderText = "Прибыль";
            this.прибыльDataGridViewTextBoxColumn.MinimumWidth = 10;
            this.прибыльDataGridViewTextBoxColumn.Name = "прибыльDataGridViewTextBoxColumn";
            this.прибыльDataGridViewTextBoxColumn.ReadOnly = true;
            this.прибыльDataGridViewTextBoxColumn.Width = 200;
            // 
            // предстоящиеМероприятияBindingSource3
            // 
            this.предстоящиеМероприятияBindingSource3.DataMember = "ПредстоящиеМероприятия";
            this.предстоящиеМероприятияBindingSource3.DataSource = this.holidayDataSet3;
            // 
            // holidayDataSet3
            // 
            this.holidayDataSet3.DataSetName = "HolidayDataSet3";
            this.holidayDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // предстоящиеМероприятияTableAdapter3
            // 
            this.предстоящиеМероприятияTableAdapter3.ClearBeforeFill = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.buttonFilters);
            this.panel5.Controls.Add(this.DatePicker);
            this.panel5.Controls.Add(this.buttonSearch);
            this.panel5.Controls.Add(this.comboBox1);
            this.panel5.Controls.Add(this.textBox1);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1722, 360);
            this.panel5.TabIndex = 13;
            // 
            // buttonFilters
            // 
            this.buttonFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFilters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFilters.FlatAppearance.BorderSize = 0;
            this.buttonFilters.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonFilters.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilters.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFilters.Location = new System.Drawing.Point(1533, 230);
            this.buttonFilters.Name = "buttonFilters";
            this.buttonFilters.Size = new System.Drawing.Size(155, 50);
            this.buttonFilters.TabIndex = 39;
            this.buttonFilters.Text = "Сбросить";
            this.buttonFilters.UseVisualStyleBackColor = false;
            // 
            // DatePicker
            // 
            this.DatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DatePicker.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DatePicker.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DatePicker.Location = new System.Drawing.Point(1209, 232);
            this.DatePicker.Name = "DatePicker";
            this.DatePicker.Size = new System.Drawing.Size(288, 43);
            this.DatePicker.TabIndex = 38;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.buttonSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(617, 230);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(155, 52);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Место проведения",
            "Доп. услуга",
            "Категория",
            "Заказчик",
            "Сотрудник"});
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Места проведения",
            "Доп услуга",
            "Категория",
            "Сотрудники",
            "Заказчик"});
            this.comboBox1.Location = new System.Drawing.Point(20, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 47);
            this.comboBox1.TabIndex = 14;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(20, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(562, 43);
            this.textBox1.TabIndex = 12;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.Event);
            this.panel6.Controls.Add(this.Documents);
            this.panel6.Controls.Add(this.Client);
            this.panel6.Controls.Add(this.Staff);
            this.panel6.Controls.Add(this.Analysis);
            this.panel6.Controls.Add(this.Close);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1722, 98);
            this.panel6.TabIndex = 14;
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.topPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.centerPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.bottomPanel, 0, 2);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 366F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1728, 930);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.topPanel.Controls.Add(this.panel5);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1722, 360);
            this.topPanel.TabIndex = 0;
            // 
            // centerPanel
            // 
            this.centerPanel.BackColor = System.Drawing.Color.Silver;
            this.centerPanel.Controls.Add(this.dataGridView1);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(3, 369);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(1722, 454);
            this.centerPanel.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.bottomPanel.Controls.Add(this.panel6);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 829);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1722, 98);
            this.bottomPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1728, 930);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Дашборд";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.предстоящиеМероприятияBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holidayDataSet3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // Основные элементы интерфейса
        private System.Windows.Forms.Button Event;
        private System.Windows.Forms.Button Documents;
        private System.Windows.Forms.Button Client;
        private System.Windows.Forms.Button Staff;
        private System.Windows.Forms.Button Analysis;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;

        // DataSet и связанные компоненты
        private HolidayDataSet holidayDataSet;
        private System.Windows.Forms.BindingSource предстоящиеМероприятияBindingSource;
        private HolidayDataSetTableAdapters.ПредстоящиеМероприятияTableAdapter предстоящиеМероприятияTableAdapter;
        private HolidayDataSet1 holidayDataSet1;
        private System.Windows.Forms.BindingSource предстоящиеМероприятияBindingSource1;
        private HolidayDataSet1TableAdapters.ПредстоящиеМероприятияTableAdapter предстоящиеМероприятияTableAdapter1;
        private HolidayDataSet2 holidayDataSet2;
        private System.Windows.Forms.BindingSource предстоящиеМероприятияBindingSource2;
        private HolidayDataSet2TableAdapters.ПредстоящиеМероприятияTableAdapter предстоящиеМероприятияTableAdapter2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private HolidayDataSet3 holidayDataSet3;
        private System.Windows.Forms.BindingSource предстоящиеМероприятияBindingSource3;
        private HolidayDataSet3TableAdapters.ПредстоящиеМероприятияTableAdapter предстоящиеМероприятияTableAdapter3;

        // Панели
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;

        // Новые элементы для масштабирования
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button buttonSearch;
        private DateTimePicker DatePicker;
        private Button buttonFilters;
        private DataGridViewTextBoxColumn фИОЗаказчикаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn телефонЗаказчикаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn категорияDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn местоПроведенияDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn адресDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn стоимостьАрендыDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn дополнительнаяУслугаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn стоимостьУслугиDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn датаЗаказаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn датаПроведенияDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn времяНачалаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn длительностьчасовDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn количествоУчастниковDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ответственныйСотрудникDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn телефонСотрудникаDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn общаяСтоимостьDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn прибыльDataGridViewTextBoxColumn;
    }
}