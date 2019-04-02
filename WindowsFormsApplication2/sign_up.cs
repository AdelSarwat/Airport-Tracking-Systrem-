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

namespace WindowsFormsApplication2
{
    public partial class sign_up : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NR3KBL6\\ADELSQL;Initial Catalog=airport;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader Rd;
        public sign_up()
        {
            InitializeComponent();
        }
        private void textboxname_Enter(object sender, EventArgs e)
        {
            if (txt_name.Text == "Name")
            {
                txt_name.Text = "";
            }
        }

        private void textboxname_Leave(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                txt_name.Text = "Name";
            }
        }

        private void textboxusername1_Enter(object sender, EventArgs e)
        {
            if (txt_username.Text == "UserName")
            {
                txt_username.Text = "";
            }
        }

        private void textboxusername1_Leave(object sender, EventArgs e)
        {
            if (txt_username.Text == "")
            {
                txt_username.Text = "UserName";
            }
        }

        private void textboxpassword1_Enter(object sender, EventArgs e)
        {
            if (txt_pass.Text == "Password")
            {
                txt_pass.Text = "";
                txt_pass.PasswordChar = '*';
            }
        }

        private void textboxpassword1_Leave(object sender, EventArgs e)
        {
            if (txt_pass.Text == "")
            {
                txt_pass.PasswordChar = '\0';
                txt_pass.Text = "Password";
            }
        }

        private void textboxconfirmpassword_Enter(object sender, EventArgs e)
        {
            if (txt_con_pass.Text == "Confirm Password")
            {
                txt_con_pass.Text = "";
                txt_con_pass.PasswordChar = '*';
            }
        }

        private void textboxconfirmpassword_Leave(object sender, EventArgs e)
        {
            if (txt_con_pass.Text == "")
            {
                txt_con_pass.Text = "Confirm Password";
                txt_con_pass.Text = "Password";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(" select * from passenger where username = '" + txt_username.Text + "'", con);

            //  cmd.CommandType = CommandType.Text;

            SqlDataReader Rd = cmd.ExecuteReader();

            bool found_username = false;
            while (Rd.Read())
            {
                found_username = true;
            }
            Rd.Close();
            cmd = new SqlCommand(" select * from passenger where passport = '" + txt_passport_num.Text + "'", con);

            Rd = cmd.ExecuteReader();

            bool found_passport = false;
            while (Rd.Read())
            {
                found_passport = true;
            }
            Rd.Close();

            if (txt_con_pass.Text != txt_pass.Text)
                MessageBox.Show("incorrect password !", "an error occured", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else if (txt_name.Text == "" || txt_pass.Text == "" || txt_name.Text == "" || txt_con_pass.Text == "" || txt_passport_num.Text == "" || txt_gmail.Text =="" || txt_gmail_pass.Text =="")
                MessageBox.Show("  Please Enter Full Information  ");
            else if (found_username)
                MessageBox.Show("this username is already exist try another username");
            else if (found_passport)
                MessageBox.Show("this passport is already exist");
            else
            {
                cmd = new SqlCommand(" exec p_signup '" + txt_username.Text + "' ,'" + txt_pass.Text + "','" + txt_name.Text + "','" + txt_passport_num.Text + "','"+txt_gmail.Text+"','"+txt_gmail_pass.Text+ "'", con);
                cmd.ExecuteNonQuery();
                // cmd.CommandType = CommandType.StoredProcedure;
                MessageBox.Show("Done ");
                p_login f = new p_login();
                f.Show();
                this.Hide();
            }
            con.Close();

        }
        
        

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        private void txt_passport_num_Enter(object sender, EventArgs e)
        {
            if (txt_passport_num.Text == "Passport number")
            {
                txt_passport_num.Text = "";
            }
        }

        private void txt_passport_num_Leave(object sender, EventArgs e)
        {
            if (txt_passport_num.Text == "")
            {
                txt_passport_num.Text = "Passport number";
            }
        }

        private void txt_gmail_Enter(object sender, EventArgs e)
        {
            if (txt_gmail.Text == "gmail")
            {
                txt_gmail.Text = "";
            }
        }

        private void txt_gmail_Leave(object sender, EventArgs e)
        {
            if (txt_gmail.Text == "")
            {
                txt_gmail.Text = "gmail";
            }
        }

        private void txt_gmail_pass_Enter(object sender, EventArgs e)
        {
            if (txt_gmail_pass.Text == "gmail password")
            {
                txt_gmail_pass.Text = "";
            }
        }

        private void txt_gmail_pass_Leave(object sender, EventArgs e)
        {
            if (txt_gmail_pass.Text == "")
            {
                txt_gmail_pass.Text = "gmail password";
            }
        }

        private void txt_passport_num_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_passport_num.Text, "[^0-9]"))
            {
                MessageBox.Show("please enter only numbers.");
                txt_passport_num.Text = txt_passport_num.Text.Remove(txt_passport_num.Text.Length - 1);
            }
        }
    }

}
