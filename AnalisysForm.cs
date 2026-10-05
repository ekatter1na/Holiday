using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_Жирнова_Е.А._Holiday
{
    public partial class AnalisysForm : Form
    {
        public AnalisysForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        public AnalisysForm(Size size, Point location, FormWindowState state)
        {
            InitializeComponent();

            if (state == FormWindowState.Normal)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = location;
                this.Size = size;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.Size = size;
                this.Location = location;
            }
        }
        private void SetupColumnAlignment()
        {
            
            string[] numericColumns = {
        "общаяВыручкаDataGridViewTextBoxColumn",
        "средняяСтоимостьDataGridViewTextBoxColumn",
        "максимальнаяСтоимостьDataGridViewTextBoxColumn",
        "минимальнаяСтоимостьDataGridViewTextBoxColumn",
        "всегоУчастниковDataGridViewTextBoxColumn",
        "среднееКоличествоУчастниковDataGridViewTextBoxColumn",
        "базоваяСтоимостьDataGridViewTextBoxColumn",
        "количествоЗаказовDataGridViewTextBoxColumn",
        "общаяВыручкаDataGridViewTextBoxColumn1",
        "средняяСтоимостьМероприятияDataGridViewTextBoxColumn",
        "средняяПрибыльСверхУслугиDataGridViewTextBoxColumn",
        "доляОтВсехМероприятийDataGridViewTextBoxColumn",
        "доляОтВсехМероприятийDataGridViewTextBoxColumn1",
        "общаяВыручкаDataGridViewTextBoxColumn2",
        "общаяВыручкаDataGridViewTextBoxColumn3",
        "средняяСтоимостьDataGridViewTextBoxColumn1",
        "максимальнаяСтоимостьDataGridViewTextBoxColumn1",
        "минимальнаяСтоимостьDataGridViewTextBoxColumn1"
    };

            foreach (string colName in numericColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dataGridView2.Columns[colName] != null)
                    dataGridView2.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dataGridView3.Columns[colName] != null)
                    dataGridView3.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (dataGridView4.Columns[colName] != null)
                    dataGridView4.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

           
            string[] centerColumns = {
        "датаЗаказаDataGridViewTextBoxColumn",
        "датаПроведенияDataGridViewTextBoxColumn",
        "телефонЗаказчикаDataGridViewTextBoxColumn",
        "телефонСотрудникаDataGridViewTextBoxColumn"
    };

            foreach (string colName in centerColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            
            string[] leftColumns = {
        "категорияDataGridViewTextBoxColumn",
        "услугаDataGridViewTextBoxColumn",
        "местоПроведенияDataGridViewTextBoxColumn",
        "адресDataGridViewTextBoxColumn",
        "показательDataGridViewTextBoxColumn"
    };

            foreach (string colName in leftColumns)
            {
                if (dataGridView1.Columns[colName] != null)
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (dataGridView2.Columns[colName] != null)
                    dataGridView2.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (dataGridView3.Columns[colName] != null)
                    dataGridView3.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (dataGridView4.Columns[colName] != null)
                    dataGridView4.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Size sizeToPass = this.WindowState == FormWindowState.Normal ? this.Size : this.RestoreBounds.Size;
            Point locationToPass = this.WindowState == FormWindowState.Normal ? this.Location : this.RestoreBounds.Location;
            FormWindowState stateToPass = this.WindowState;

            MainForm f = new MainForm(sizeToPass, locationToPass, stateToPass);
            f.Show();
            this.Close();
        }

        private void AnalisysForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet20.ЗагруженностьМест". При необходимости она может быть перемещена или удалена.
            this.загруженностьМестTableAdapter1.Fill(this.holidayDataSet20.ЗагруженностьМест);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet19.ЗагруженностьУслуг_Расширенная". При необходимости она может быть перемещена или удалена.
            this.загруженностьУслуг_РасширеннаяTableAdapter1.Fill(this.holidayDataSet19.ЗагруженностьУслуг_Расширенная);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet18.АгрегированнаяСтатистика". При необходимости она может быть перемещена или удалена.
            this.агрегированнаяСтатистикаTableAdapter1.Fill(this.holidayDataSet18.АгрегированнаяСтатистика);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet17.АгрегированнаяСтатистика". При необходимости она может быть перемещена или удалена.
            this.агрегированнаяСтатистикаTableAdapter.Fill(this.holidayDataSet17.АгрегированнаяСтатистика);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet16.ЗагруженностьМест". При необходимости она может быть перемещена или удалена.
            this.загруженностьМестTableAdapter.Fill(this.holidayDataSet16.ЗагруженностьМест);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet15.ЗагруженностьУслуг_Расширенная". При необходимости она может быть перемещена или удалена.
            this.загруженностьУслуг_РасширеннаяTableAdapter.Fill(this.holidayDataSet15.ЗагруженностьУслуг_Расширенная);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet14.ЗагруженностьКатегорий_Расширенная". При необходимости она может быть перемещена или удалена.
            this.загруженностьКатегорий_РасширеннаяTableAdapter.Fill(this.holidayDataSet14.ЗагруженностьКатегорий_Расширенная);
            SetupColumnAlignment();

        }

        private void Restart_Click(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet17.АгрегированнаяСтатистика". При необходимости она может быть перемещена или удалена.
            this.агрегированнаяСтатистикаTableAdapter.Fill(this.holidayDataSet17.АгрегированнаяСтатистика);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet16.ЗагруженностьМест". При необходимости она может быть перемещена или удалена.
            this.загруженностьМестTableAdapter.Fill(this.holidayDataSet16.ЗагруженностьМест);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet15.ЗагруженностьУслуг_Расширенная". При необходимости она может быть перемещена или удалена.
            this.загруженностьУслуг_РасширеннаяTableAdapter.Fill(this.holidayDataSet15.ЗагруженностьУслуг_Расширенная);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "holidayDataSet14.ЗагруженностьКатегорий_Расширенная". При необходимости она может быть перемещена или удалена.
            this.загруженностьКатегорий_РасширеннаяTableAdapter.Fill(this.holidayDataSet14.ЗагруженностьКатегорий_Расширенная);
            SetupColumnAlignment();

        }
    }
}
