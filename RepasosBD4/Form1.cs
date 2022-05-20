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
    public partial class Form1 : Form
    {

        public SqlConnection cn;
        private FormQry formQry;

        public Form1()
        {
            InitializeComponent();
            cn = new SqlConnection("Data Source=(local);Initial Catalog=parainfo;Integrated Security=SSPI;");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormQry))
                {
                    form.Activate();
                    return;
                }
            }

            formQry = new FormQry(this);
            formQry.MdiParent = this;
            formQry.Show();
            formQry.BringToFront();
        }

        private void retirarRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool msg = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FormQry))
                {
                    formQry = (FormQry)form;
                    formQry.Activate();
                    formQry.RetirarFila();

                    msg = false;
                    break;
                }
                else
                {
                    msg = true;
                }
            }

            if (msg)
            {
                MessageBox.Show("Para retirar active el formulario");
            }
        }

        private void nuevoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIns formIns = new FormIns(this, formQry);

            formIns.MdiParent = this;
            formIns.Show();
        }

        private void entreRangoDeFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(FechasReport))
                {
                    form.Activate();
                    return;
                }
            }

            FechasReport fechasReport = new FechasReport(this);          
            fechasReport.MdiParent = this;
            fechasReport.Show();
            fechasReport.BringToFront();
        }

        private void entreRangoDeHorasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
