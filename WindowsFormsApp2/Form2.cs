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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = 
                "INSERT INTO opiskelija" +
                "(etunimi, sukunimi)" +
                "VALUES ('" + etunimi.Text + "', '" + sukunimi.Text + "'); ";
            string connectstring = @"Data Source=.;Initial Catalog=test;Integrated Security=true;";
            SqlConnection sc = new SqlConnection(connectstring);
            sc.Open();
            SqlCommand scmd = sc.CreateCommand();
            scmd.CommandText = s;
            scmd.Connection = sc;
            scmd.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show("Kohde lisätty.");
        }

        private void etunimi_TextChanged(object sender, EventArgs e)
        {

        }

        private void sukunimi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
