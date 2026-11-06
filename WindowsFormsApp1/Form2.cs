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

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0J6K7F9;Initial Catalog=Northwind;Integrated Security=True");
        private ComboBox cboPais;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlDataAdapter daPaises = new SqlDataAdapter("select distinct country from Customers", conn);
            DataTable dtpaises = new DataTable();
            try
            {
                daPaises.Fill(dtpaises);
                this.cboPais.DataSource = dtpaises;
                this.cboPais.DisplayMember = "country";

            }
            catch (SqlException exe)
            {
                MessageBox.Show(exe.Message, "Error");
            }
        }
    }
}
