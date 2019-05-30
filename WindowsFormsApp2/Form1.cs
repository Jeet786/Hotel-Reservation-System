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
using System.Net;
using System.Net.Mail;





namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Name :" + textBox1.Text + Environment.NewLine + "Gender :" + comboBox1.Text + Environment.NewLine + "Email :" + textBox2.Text + Environment.NewLine + "Country :" + comboBox2.Text + "Type of Room :" + comboBox3.Text + Environment.NewLine + "Hotel Name :" + comboBox4.Text + Environment.NewLine + "No. of Room :" + comboBox5.Text + Environment.NewLine + "Check-In :" + dateTimePicker1.Text + Environment.NewLine + "Check-out :" + dateTimePicker2.Text + Environment.NewLine + "Adults :" + textBox3.Text + Environment.NewLine + "Child :" + textBox4.Text + Environment.NewLine + "Phone No. :" + textBox5.Text + Environment.NewLine + "Special Requirements :" + textBox6.Text);
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Emp_Detail;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            String Name = textBox1.Text;
            String Gender = comboBox1.Text;
            String Email = textBox2.Text;
            String Country = comboBox2.Text;
            String Type = comboBox3.Text;
            String Hotel_Name = comboBox4.Text;
            String Room = comboBox5.Text;
            String Check_In = dateTimePicker1.Text;
            String Check_Out = dateTimePicker2.Text;
            String Adults = textBox3.Text;
            String Child = textBox4.Text;
            String Phone = textBox5.Text;
            String Special_Req = textBox6.Text;
            String SQLCommand = "Insert into book values("+"'" + Name + "', '"+ Gender +"' , '" + Email + "','" + Country + "','" + Type + "','" + Hotel_Name + "','" + Room + "','" + Check_In + "','" + Check_Out + "','" + Adults + "','" + Child + "','" + Phone + "','" + Special_Req + "')";
            SqlCommand cmd = new SqlCommand(SQLCommand, cnn);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("value saved successfully");
            }
            catch(Exception exception)
            {
                MessageBox.Show("some error occured" + exception.Message);
            }
           

            cnn.Close();

            //this.bookBindingSource.AddNew();

            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("jeetthakur395@gmail.com");
                msg.To.Add (textBox2.Text);
                msg.Subject = "Regarding Booking";
                msg.Body = "Name :" + textBox1.Text.ToString() + Environment.NewLine + "Gender :" + comboBox1.Text + Environment.NewLine + "Email :" + textBox2.Text.ToString() + Environment.NewLine + "Country :" + comboBox2.Text + Environment.NewLine + "Type of Room :" + comboBox3.Text + Environment.NewLine + "Hotel Name :" + comboBox4.Text + Environment.NewLine + "No. of Room :" + comboBox5.Text + Environment.NewLine + "Check-In :" + dateTimePicker1.Text.ToString() + Environment.NewLine + "Check-out :" + dateTimePicker2.Text.ToString() + Environment.NewLine + "Adults :" + textBox3.Text.ToString() + Environment.NewLine + "Child :" + textBox4.Text.ToString() + Environment.NewLine + "Phone No. :" + textBox5.Text.ToString() + Environment.NewLine + "Special Requirements :" + textBox6.Text.ToString();


                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "jeetthakur395@gmail.com";
                ntcd.Password = "affected";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        
    }


        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
    


   
    
