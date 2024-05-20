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




namespace BuncoGame
{
    
    public partial class Form2 : Form
    {
        string connectionstring = "Data Source=DESKTOP-KIH1OI6;Initial Catalog=Rtu;Integrated Security=True";

        public int rnumber = 1;
        public int minbunco = 0;
        public int bunco = 0;
        private System.Timers.Timer timer;
        private int secondsRemaining = 60;
     
        



        public Form2()
        {

            InitializeTimer();

            InitializeComponent();
           






        }
        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 second
            timer.Elapsed += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                MessageBox.Show("Header table reach to  21 !", "Information", MessageBoxButtons.OK);
              
                secondsRemaining = 60; // Reset the timer
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void label11_Click(object sender, EventArgs e)
        {

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            int team1value = int.Parse(label11.Text);
            int newValue = team1value;

            Random rnd = new Random();

            int number = rnd.Next(1, 7);
            int number2 = rnd.Next(1, 7);
            int number3 = rnd.Next(1, 7);

            pictureBox5.Image = GetDiceImage(number);
            pictureBox6.Image = GetDiceImage(number2);
            pictureBox7.Image = GetDiceImage(number3);

            if (number == rnumber)
            {
                newValue++;
            }
            if (number2 == rnumber)
            {
                newValue++;
            }
            if (number3 == rnumber)
            {
                newValue++;
            }

            if (number == number2 && number2 == number3)
            {
                newValue += 5;
                minbunco++;
            }
            if (number == number2 && number2 == number3 && number == rnumber)
            {
                newValue += 21;
                bunco++;
            }

            else if (rnumber != number && rnumber != number2 && rnumber != number3)
            {
                MessageBox.Show("Turn goes to Joe!", "Information", MessageBoxButtons.OK);
                button1.Visible = false;
            }

            label11.Text = newValue.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }
        private void label9_Click(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int team2value = int.Parse(label10.Text);
            int newValue2 = team2value;

            Random rnd = new Random();

            int number = rnd.Next(1, 7);
            int number2 = rnd.Next(1, 7);
            int number3 = rnd.Next(1, 7);

            pictureBox5.Image = GetDiceImage(number);
            pictureBox6.Image = GetDiceImage(number2);
            pictureBox7.Image = GetDiceImage(number3);

            if (number == rnumber)
            {
                newValue2++;
            }
            if (number2 == rnumber)
            {
                newValue2++;
            }
            if (number3 == rnumber)
            {
                newValue2++;
            }

            if (number == number2 && number2 == number3)
            {
                newValue2 += 5;
                minbunco++;
            }
            if (number == number2 && number2 == number3 && number == rnumber)
            {
                newValue2 += 21;
                bunco++;
            }

           else if (rnumber != number && rnumber != number2 && rnumber != number3)
            {
                MessageBox.Show("Turn goes to Hagi!", "Information", MessageBoxButtons.OK);
            }

            label10.Text = newValue2.ToString();
        }


        public void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int team1value = int.Parse(label11.Text);
            int newValue = team1value;

        Random rnd = new Random();

            int number = rnd.Next(1, 7);
            int number2 = rnd.Next(1, 7);
            int number3 = rnd.Next(1, 7);

            pictureBox5.Image = GetDiceImage(number);
            pictureBox6.Image = GetDiceImage(number2);
            pictureBox7.Image = GetDiceImage(number3);

            if (number == rnumber)
            {
                newValue++;
            }
            if (number2 == rnumber)
            {
                newValue++;
            }
            if (number3 == rnumber)
            {
                newValue++;
            }

            else  if (number == number2 && number2 == number3)
            {
                newValue += 5;
                minbunco++;
            }
           else if (number == number2 && number2 == number3 && number == rnumber)
            {
                newValue += 21;
                bunco++;
            }

            else if (rnumber != number && rnumber != number2 && rnumber != number3)
            {
                MessageBox.Show("Turn goes to Alex!", "Information", MessageBoxButtons.OK);
            }

            label11.Text = newValue.ToString();
        }

        private Image GetDiceImage(int number)
        {
            switch (number)
            {
                case 1:
                    return Properties.Resources.dice1;
                case 2:
                    return Properties.Resources.dice2;
                case 3:
                    return Properties.Resources.dice3;
                case 4:
                    return Properties.Resources.dice4;
                case 5:
                    return Properties.Resources.dice5;
                case 6:
                    return Properties.Resources.dice6;
                default:
                    return null;
            }
        }


        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int team2value = int.Parse(label10.Text);
            int newValue2 = team2value;

            Random rnd = new Random();

            int number = rnd.Next(1, 7);
            int number2 = rnd.Next(1, 7);
            int number3 = rnd.Next(1, 7);

            pictureBox5.Image = GetDiceImage(number);
            pictureBox6.Image = GetDiceImage(number2);
            pictureBox7.Image = GetDiceImage(number3);

            if (number == rnumber)
            {
                newValue2++;
            }
            if (number2 == rnumber)
            {
                newValue2++;
            }
            if (number3 == rnumber)
            {
                newValue2++;
            }

           else  if (number == number2 && number2 == number3)
            {
                newValue2 += 5;
                minbunco++;
            }
           else if (number == number2 && number2 == number3 && number == rnumber)
            {
                newValue2 += 21;
                bunco++;
            }

            else if (rnumber != number && rnumber != number2 && rnumber != number3)
            {
                MessageBox.Show("Turn goes to you!", "Information", MessageBoxButtons.OK);
                button1.Visible = true;

            }

            label10.Text = newValue2.ToString();
        }
       
      

       
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            timer.Start();
            label10.Text = "0";
            label11.Text = "0";

           



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

      /*  SELECT TOP(1000) [Round]
      ,[Player1]
      ,[Player2]
      ,[Point]
      ,[MiniBunco]
      ,[Bunco]*/
        private void label2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label10.Text, out int integerValue))
            {
                if (int.TryParse(label11.Text, out int intvalue))
                {
                    if (intvalue > integerValue)
                    {
                        MessageBox.Show("Your team wins", "Congratulations!", MessageBoxButtons.OK);
                        Form3 form = new Form3();
                        form.Show();
                        Hide();
                        string Query = "insert into RTU1 (Round, Player1, Player2, Team1Point,Team2Point, MiniBunco, Bunco) values('" + rnumber + "','" + "You" + "','" + "Hagi" + "','" + integerValue + "','" + intvalue + "','" + minbunco + "','" + bunco + "');";
                        SqlConnection condb = new SqlConnection(connectionstring);
                        SqlCommand cmddatabase = new SqlCommand(Query, condb);
                        SqlDataReader myreader;
                        try
                        {
                            condb.Open();
                            myreader = cmddatabase.ExecuteReader();
                            MessageBox.Show("Data has been saved successfully", "Information", MessageBoxButtons.OK);
                            while (myreader.Read())
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Team 2 wins");
                        Form4 form = new Form4();
                        form.Show();
                        this.Hide();
                        string Query = "insert into RTU1 (Round, Player1, Player2, Team1Point,Team2Point, MiniBunco, Bunco) values('" + rnumber + "','" + "Joe" + "','" + "Alex" + "','" + integerValue + "','" + intvalue + "','" + minbunco + "','" + bunco + "');";
                        SqlConnection condb = new SqlConnection(connectionstring);
                        SqlCommand cmddatabase = new SqlCommand(Query, condb);
                        SqlDataReader myreader;
                        try
                        {
                            condb.Open();
                            myreader = cmddatabase.ExecuteReader();
                            MessageBox.Show("Data has been saved successfully", "Information", MessageBoxButtons.OK);
                            while (myreader.Read())
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }




                    }
                }

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            this.Hide();
        }
    }
    }

