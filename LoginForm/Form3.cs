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
    public partial class Form3 : Form
    {
        static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Aldiano_IMDBSYS\LoginForm\LoginForm\LibraryDB.mdf;Integrated Security=True";
        public SqlConnection con = new SqlConnection(connectionString);
        public SqlCommand cmd;
        public SqlDataReader reader;
        public Form3()
        {
            InitializeComponent();
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void txtUserRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassRegister_TextChanged(object sender, EventArgs e)
        {
            txtPassRegister.PasswordChar = '*';
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Check if the passwords are matched
            if (txtPassRegister.Text.Equals(txtConfirmPassword.Text))
            {
                string vuserid;
                string vpassword;

                con.Open();
                vuserid = txtUserRegister.Text;
                vpassword = txtConfirmPassword.Text;

                cmd = new SqlCommand("INSERT INTO USERS VALUES('" + vuserid + "','" + vpassword +"')", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully created an account");

                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password Mismatched");
                txtPassRegister.Text = "";
                txtConfirmPassword.Text = "";
            }
        }
    }
}
