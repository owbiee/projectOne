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
//using Microsoft.VisualBasic;

namespace ContainerBase
{
    public partial class Form1 : Form
    {
        SqlCommand command;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9DG3HKT\SQLEXPRESS;Initial Catalog=ConsignmentData;Integrated Security=True");
        DataTable table;

        public Form1()
        {
            InitializeComponent();
            //Starts the Timer===============
            timer1.Start();
        }

        //Search From Database Button========================
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter C Number!");
                }
                else
                {
                    SqlDataAdapter data = new SqlDataAdapter("SELECT * FROM DataOne where CNumber = '" + textBox2.Text + "'", connection);

                    table = new DataTable();
                    data.Fill(table);

                    textBox2.Text = table.Rows[0][0].ToString();
                    textBox3.Text = table.Rows[0][1].ToString();
                    textBox4.Text = table.Rows[0][2].ToString();
                    textBox5.Text = table.Rows[0][3].ToString();
                    textBox6.Text = table.Rows[0][4].ToString();
                    textBox7.Text = table.Rows[0][5].ToString();
                    textBox8.Text = table.Rows[0][6].ToString();
                    textBox9.Text = table.Rows[0][7].ToString();
                    textBox10.Text = table.Rows[0][8].ToString();
                    textBox11.Text = table.Rows[0][9].ToString();
                    textBox13.Text = table.Rows[0][10].ToString();

                    textBox2.BackColor = Color.LightYellow;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Invalid Action");
            }
        }

        //Save To Database Button
        private void Button2_Click(object sender, EventArgs e)
        {
            
                try
                {

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter C Number!");
                }

                else
                {

                    //Opens an SQL connection
                    connection.Open();

                    //code to insert data into DataBase====================================================================================
                    command = new SqlCommand("INSERT INTO DataOne (CNumber, ANumber, BLNumber, ContainerNumber, Office, Consignee, Declarant, AssessmentDate, Vessel, Manifest, AssessedBy) VALUES " +
                        "(@CNumber, @ANumber, @BLNumber, @ContainerNumber, @Office, @Consignee, @Declarant, @AssessmentDate, @Vessel, @Manifest, @AssessedBy)", connection);

                    command.Parameters.AddWithValue("@CNumber", textBox2.Text);
                    command.Parameters.AddWithValue("@ANumber", textBox3.Text);
                    command.Parameters.AddWithValue("@BLNumber", textBox4.Text);
                    command.Parameters.AddWithValue("@ContainerNumber", textBox5.Text);
                    command.Parameters.AddWithValue("@Office", textBox6.Text);
                    command.Parameters.AddWithValue("@Consignee", textBox7.Text);
                    command.Parameters.AddWithValue("@Declarant", textBox8.Text);
                    command.Parameters.AddWithValue("@AssessmentDate", textBox9.Text);
                    command.Parameters.AddWithValue("@Vessel", textBox10.Text);
                    command.Parameters.AddWithValue("@Manifest", textBox11.Text);
                    command.Parameters.AddWithValue("@AssessedBy", textBox13.Text);

                    command.ExecuteNonQuery();

                    //Confirms that the input was successful

                    MessageBox.Show("Data has been Saved!");
                }

            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured!");
            }
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //==============This Function takes the user back to the Login Form===========
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.ShowDialog();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Timer Function====================================
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label12.Text = dateTime.ToLongTimeString();
        }

        //DELETES DATA FROM DATABASE
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("Enter C Number!");
           
            }
            else
            {
                connection.Open();
                command = new SqlCommand("DELETE FROM DataOne WHERE (CNumber = '" + textBox2.Text + "')", connection);

                // command.Parameters.Remove("@CNumber",textBox2.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Data Deleted!");

                textBox2.Text = "";               
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox13.Text = "";

            }
        }

        //This Function Updates Data  in DataBase===============
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text=="")
                {
                    MessageBox.Show("Enter C Number!");
                }
                else {
                    connection.Open();

                    command = new SqlCommand("UPDATE DataOne SET ANumber=@ANumber, BLNumber=@BLNumber, ContainerNumber=@ContainerNumber, Office=@Office, Consignee=@Consignee, Declarant=@Declarant, AssessmentDate=@AssessmentDate, Vessel=@Vessel, Manifest=@Manifest, AssessedBy=@AssessedBy WHERE  CNumber=@CNumber", connection);

                    command.Parameters.AddWithValue("@ANumber", textBox3.Text);
                    command.Parameters.AddWithValue("@BLNumber", textBox4.Text);
                    command.Parameters.AddWithValue("@ContainerNumber", textBox5.Text);
                    command.Parameters.AddWithValue("@Office", textBox6.Text);
                    command.Parameters.AddWithValue("@Consignee", textBox7.Text);
                    command.Parameters.AddWithValue("@Declarant", textBox8.Text);
                    command.Parameters.AddWithValue("@AssessmentDate", textBox9.Text);
                    command.Parameters.AddWithValue("@Vessel", textBox10.Text);
                    command.Parameters.AddWithValue("@Manifest", textBox11.Text);
                    command.Parameters.AddWithValue("@AssessedBy", textBox13.Text);
                    command.Parameters.AddWithValue("@CNumber", textBox2.Text);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Data has been Updated!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("An Error Occured!");
            }
        }
    }
}
