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
    public partial class Form1 : Form
    {
    
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=test;Integrated Security=true;");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adapt;
        SqlDataReader dr;

        int ID = 0;
        public Form1()
        {

            InitializeComponent();
            DisplayData();
            DisplayValue();
        }
 
        public void DisplayValue()
        {
            con.Open();
            adapt = new SqlDataAdapter("select * from opiskelija left join Opiskelijaryhma on opiskelija.groupid=Opiskelijaryhma.id", con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchData(textBox1.Text);
        }
        public void SearchData(string search)
        {
            con.Open();
            string query = "select * from opiskelija left join Opiskelijaryhma on opiskelija.groupid=Opiskelijaryhma.id where Etunimi like '%" + search + "%'";
            adapt = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
      

        //Insert Data  
        private void btn_Insert_Click_1(object sender, EventArgs e)
        {
            if (txt_Etunimi.Text != "" && txt_Sukunimi.Text != "")
            {
                cmd = new SqlCommand("insert into opiskelija (Etunimi,Sukunimi,groupid) values(@Etunimi,@Sukunimi,@groupid)", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Etunimi", txt_Etunimi.Text);
                cmd.Parameters.AddWithValue("@Sukunimi", txt_Sukunimi.Text);
                cmd.Parameters.AddWithValue("@groupid", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kohde lisätty.");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Tarkista tiedot.");
            }
        }
        private void btn_Update_Click_1(object sender, EventArgs e)
        {
            if (txt_Etunimi.Text != "" && txt_Sukunimi.Text != "")
            {
                cmd = new SqlCommand("update opiskelija set Etunimi=@etunimi,Sukunimi=@sukunimi, groupid=@groupid where ID=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@etunimi", txt_Etunimi.Text);
                cmd.Parameters.AddWithValue("@sukunimi", txt_Sukunimi.Text);
                cmd.Parameters.AddWithValue("@groupid", comboBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kohteen tiedot päivitetty.");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Valitse kohde päivitettäväksi.");
            }
        }
        private void btn_Delete_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                if (index != dataGridView1.Rows.Count)
                {
                    string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    con.Open();
                    SqlCommand delcmd = con.CreateCommand();
                    delcmd.CommandText = "DELETE from opiskelija WHERE ID = " + id;
                    delcmd.Connection = con;
                    delcmd.ExecuteNonQuery();
                    con.Close();
                }
                dataGridView1.Rows.RemoveAt(index);
                dataGridView1.Update();
            }

            else
            {
                MessageBox.Show("Valitse poistettava kohde.");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Etunimi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Sukunimi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        //Display Data in DataGridView  
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from opiskelija", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Data  
        private void ClearData()
        {
            txt_Etunimi.Text = "";
            txt_Sukunimi.Text = "";
            ID = 0;
            group.Text = "";
        }
        private void txt_Etunimi_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_Sukunimi_TextChanged(object sender, EventArgs e)
        {

        }
        private void txt_group_TextChanged(object sender, EventArgs e)
        {

        }

        Form2 secondForm = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            secondForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string namestr = group.Text;
            comboBox1.Items.Add(namestr);
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            ClearData();
            SqlConnection sc;
            string Query = "Select ID, groupid from Opiskelijaryhma;";

            try
            {
                // 
                sc = new SqlConnection(@"Data Source=.;Initial Catalog=test;Integrated Security=true;");
                sc.Open();
                SqlCommand scmd = sc.CreateCommand();
                scmd.CommandText = Query;
                scmd.Connection = sc;
                // create a datatable
                DataTable table = new DataTable();
                table.Load(scmd.ExecuteReader());
                sc.Close();
              // add columns to datatable
                table.Columns.Add("id");
                table.Columns.Add("name");
                // add rows to datatable
                table.Rows.Add("1", "opiskelija");
                table.Rows.Add("2", "opiskelijaryhmä");
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "groupid";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
   /*     private void Form1_Load(object sender, EventArgs e)
        {
            // create a datatable
            DataTable table = new DataTable();

            // add columns to datatable
            table.Columns.Add("id");
            table.Columns.Add("username");

            // add rows to datatable
            table.Rows.Add("1", "PHP");
            table.Rows.Add("2", "C#");
            table.Rows.Add("3", "Java");
            table.Rows.Add("4", "Javascript");
            table.Rows.Add("5", "C++");

            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "id";
        }*/
    }
}