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
    public partial class FormIns : Form
    {
        private Form1 form1;
        private FormQry formQry;

        public FormIns()
        {
            InitializeComponent();
        }

        public FormIns(Form1 form1, FormQry formQry)
        {
            InitializeComponent();
            this.form1 = form1;
            this.formQry = formQry;
        }

        private void FormIns_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "HH:mm:ss";
            dateTimePicker3.CustomFormat = "dd/MM/yyyy HH:mm:ss";

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;

            // LOS QUE TIENEN HORA
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker3.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            DateTime dt3 = dateTimePicker3.Value;

            string s1 = dt1.Day + "-" + dt1.Month + "-" + dt1.Year;
            string s2 = dt2.Hour + ":" + dt2.Minute + ":" + dt2.Second;
            string s3 = dt3.Day + "-" + dt3.Month + "-" + dt3.Year + " " + dt3.Hour + ":" + dt3.Minute + ":" + dt3.Second;

            SqlCommand cm = new SqlCommand();
            cm.Connection = form1.cn;
            cm.CommandText = "set dateformat 'dmy' INSERT INTO tiempos VALUES('" + s1 + "', '" + s2 + "', '" + s3 + "')";
            //MessageBox.Show(cm.CommandText); // PARA SABER LOS POSIBLES ERRORES AL HACER LA CONSULTA
            form1.cn.Open();
            cm.ExecuteNonQuery();
            form1.cn.Close();

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormQry))
                {
                    ((FormQry)form).consulta();
                    form.Activate();
                    form.BringToFront();
                }
            }

            this.Dispose();
        }
    }
}
