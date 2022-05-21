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
    public partial class FormQry : Form
    {

        private Form1 form1;

        public FormQry()
        {
            InitializeComponent();
        }

        public FormQry(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void FormQry_Load(object sender, EventArgs e)
        {
            consulta();
        }

        public void consulta()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT idtiempo ID, " +
                "FORMAT(fecha, 'dd/MM/yyyy') FECHA, " +
                "CONVERT(CHAR(8), hora, 108) HORA, " +
                "FORMAT(fechahora, 'dd/MM/yyyy hh:mm:ss') 'FECHA Y HORA' FROM tiempos", form1.cn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }

        public void RetirarFila()
        {
            DataGridViewSelectedRowCollection selectedRowCollection = dataGridView1.SelectedRows;

            if (selectedRowCollection.Count > 0)
            {
                var confirmResult = MessageBox.Show("¿Está seguro de retirar este registro?", "Confirmar Retiro", MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    int idtiempo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                    SqlCommand cm = new SqlCommand();

                    cm.Connection = form1.cn;
                    cm.CommandText = "DELETE FROM tiempos WHERE idtiempo = " + idtiempo;
                    form1.cn.Open();
                    cm.ExecuteNonQuery();
                    form1.cn.Close();

                    consulta();
                }
            }
            else
            {
                MessageBox.Show("Seleccione fila a retirar");
            }
        }
    }
}
