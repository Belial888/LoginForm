using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        //Connect database
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Aldiano_IMDBSYS\LoginForm\LoginForm\LibraryDB.mdf;Integrated Security=True";
        public SqlConnection con = new SqlConnection(connectionString);
        public SqlCommand cmd;
        public SqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * FROM USERS WHERE userID = '" + txtUser.Text +"'", con);
            cmd.ExecuteNonQuery();

            reader = cmd.ExecuteReader();
            reader.Read();

            string vuserid;
            string vuserpass;

            vuserid = reader["userID"].ToString();
            vuserpass = reader["userPass"].ToString();

            if (vuserid.Equals(txtUser.Text) && vuserpass.Equals(txtPass.Text))
            {
               // MessageBox.Show("Log in Successfully");
               Form2 frm2 = new Form2();
               frm2.Show();
               this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect User ID or Password");

            }

            con.Close();








            //string vuserid;
            //string vpassword;

            //vuserid = txtUser.Text;
            //vpassword = txtPass.Text;

            ////DATABASE

            //string myuserid = "24253437";
            //string mypassword = "dawg";

            //if (myuserid.Equals(vuserid) && mypassword.Equals(vpassword))
            //{
            //    MessageBox.Show("Login Successfully!");
            //}
            //else
            //{
            //    MessageBox.Show("Incorrect User ID or Password");
            //}
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }
    }
}
