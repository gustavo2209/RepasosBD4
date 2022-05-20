using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace RepasosBD4
{
    public partial class FechasReport : Form
    {
        private Form1 form1;

        public FechasReport()
        {
            InitializeComponent();
        }

        public FechasReport(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void FechasReport_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            Consulta();
        }

        public void Consulta()
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;

            //yyyyMMdd
            string s1 = dt1.Year + String.Format("{0:00}", dt1.Month) + String.Format("{0:00}", dt1.Day);
            string s2 = dt2.Year + String.Format("{0:00}", dt2.Month) + String.Format("{0:00}", dt2.Day);

            SqlDataAdapter da = new SqlDataAdapter("SELECT idtiempo ID, " +
                "FORMAT(fecha, 'dd/MM/yyyy') FECHA, " +
                "CONVERT(CHAR(8), hora, 108) HORA, " +
                "FORMAT(fechahora, 'dd/MM/yyyy hh:mm:ss') 'FECHA Y HORA' FROM tiempos " +
                "WHERE FORMAT(fecha, 'yyyyMMdd') >= '" + s1 + "' " +
                "AND FORMAT(fecha, 'yyyyMMdd') <= '" + s2 + "'", form1.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta();
        }
    }
}
