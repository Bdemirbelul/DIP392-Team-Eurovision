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
    public partial class Form4 : Form
    {
        string connectionstring = "Data Source=DESKTOP-KIH1OI6;Initial Catalog=Rtu;Integrated Security=True";
        public int minbunco = 0;
        public int bunco = 0;
        public int rnumber = 2;
        public int roundnumber = 3;
        private System.Timers.Timer timer;
        private int secondsRemaining = 60;
        public Form4()
        {
            InitializeTimer();

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CompareLabels(label12, label13);

            int team1value = int.Parse(label12.Text);
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

            else if (number == number2 && number2 == number3)
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
                MessageBox.Show("Turn goes to opponent!", "Information", MessageBoxButtons.OK);
                button1.Visible = false;
            }

            label12.Text = newValue.ToString();
        }
        private void CompareLabels(Label label12, Label label13)
        {
            int value1, value2;

            // Check if the text in label1 and label2 can be parsed into integers
            if (!int.TryParse(label12.Text, out value1) || !int.TryParse(label13.Text, out value2))
            {

            }
            else
            {
                // Check if either value is 21
                if (value1 == 21 || value2 == 21)
                {
                    if (value1 > value2)
                    {
                        MessageBox.Show("Team 1 Wins  ");
                        MessageBox.Show("You win new opponets are on the way ");
                        rnumber++;
                        roundnumber++;
                        label12.Text = "0";
                        label13.Text = "0";
                        if (rnumber == 3)
                        {
                            pictureBox1.BackColor = Color.Pink;
                            pictureBox2.BackColor = Color.Pink;
                            label5.Text = "Can";
                            label3.Text = "Daisy";
                            label2.Text = "Header Table";

                            label14.Text = rnumber.ToString();
                        }
                        else if (rnumber == 4)
                        {
                            pictureBox1.BackColor = Color.Orange;
                            pictureBox2.BackColor = Color.Orange;
                            label5.Text = "Cj";
                            label3.Text = "Ronald";
                            label2.Text = "Header Table";

                            label14.Text = rnumber.ToString();

                        }
                        else if (rnumber == 5)
                        {
                            pictureBox1.BackColor = Color.Aquamarine;
                            pictureBox2.BackColor = Color.Aquamarine;
                            label5.Text = "Leo";
                            label3.Text = "Icardı";
                            label2.Text = "Header Table";

                            label14.Text = rnumber.ToString();

                        }
                        else if (rnumber == 6)
                        {
                            pictureBox1.BackColor = Color.Lavender;
                            pictureBox2.BackColor = Color.Lavender;
                            label5.Text = "Fei";
                            label3.Text = "Yohannes";

                            label14.Text = rnumber.ToString();
                            label2.Text = "Header Table";



                        }
                        else if (rnumber == 7)
                        {
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();




                        }



                    }
                    else if (value1 < value2)
                    {
                        MessageBox.Show("Team 2 Wins ");
                        rnumber++;
                        roundnumber++;
                        label12.Text = "0";
                        label13.Text = "0";
                        if (rnumber == 3)
                        {
                            pictureBox1.BackColor = Color.PapayaWhip;
                            pictureBox2.BackColor = Color.PapayaWhip;
                            label5.Text = "Ash";
                            label3.Text = "Nando";
                            label2.Text = "Table 2 ";

                            label14.Text = rnumber.ToString();
                        }
                        else if (rnumber == 4)
                        {
                            pictureBox1.BackColor = Color.Aquamarine;
                            pictureBox2.BackColor = Color.Aquamarine;
                            label5.Text = "Leo";
                            label3.Text = "Icardı";
                            label2.Text = "Table 2 ";



                            label14.Text = rnumber.ToString();

                        }
                        else if (rnumber == 5)
                        {
                            pictureBox1.BackColor = Color.Orange;
                            pictureBox2.BackColor = Color.Orange;
                            label5.Text = "Cj";
                            label3.Text = "Ronald";
                            label2.Text = "Table 2 ";



                            label14.Text = rnumber.ToString();

                        }
                        else if (rnumber == 6)
                        {
                            pictureBox1.BackColor = Color.LightGray;
                            pictureBox2.BackColor = Color.LightGray;
                            label5.Text = "Fei";
                            label3.Text = "Yohannes";
                            label2.Text = "Table 2 ";


                            label14.Text = rnumber.ToString();
                            MessageBox.Show("Team 1 Wins the bunco game !!!  ");


                        }
                        else if (rnumber == 7)
                        {
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();




                        }
                    

                    }
                    else
                    {
                        MessageBox.Show("Both values are equal: " + value1);
                    }
                }
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            CompareLabels(label12, label13);

            int team2value = int.Parse(label13.Text);
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

            else if (number == number2 && number2 == number3)
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
                MessageBox.Show("Turn goes to Hagi!", "Information", MessageBoxButtons.OK);
            }

            label13.Text = newValue2.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            CompareLabels(label12, label13);

            int team1value = int.Parse(label12.Text);
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

            else if (number == number2 && number2 == number3)
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
                MessageBox.Show("Turn goes to opponent!", "Information", MessageBoxButtons.OK);
            }

            label12.Text = newValue.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CompareLabels(label12, label13);

            int team2value = int.Parse(label13.Text);
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

            else if (number == number2 && number2 == number3)
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

            label13.Text = newValue2.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsRemaining--;

            if (secondsRemaining <= 0)
            {
                timer.Stop();
                MessageBox.Show("Header table reach to  21 !", "Information", MessageBoxButtons.OK);

                secondsRemaining = 60; // Reset the timer
            }
        }

        private void InitializeTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; // 1 second
            timer.Elapsed += timer1_Tick;
        }

          
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            timer.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label12.Text, out int value1) && int.TryParse(label13.Text, out int value2))
            {
                if (value1 > value2)
                {
                    MessageBox.Show("Team 1 Wins");
                    MessageBox.Show("You win new opponents are on the way");
                    MessageBox.Show("Your team wins", "Congratulations!", MessageBoxButtons.OK);
                   
                    string Query = "insert into RTU1 (Round, Player1, Player2, Team1Point,Team2Point, MiniBunco, Bunco) values('" + rnumber + "','" + "You" + "','" + "Hagi" + "','" + value1 + "','" + value2 + "','" + minbunco + "','" + bunco + "');";
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
                    label2.Text = "Table 1";
                    rnumber++;
                    roundnumber++;
                    label12.Text = "0";
                    label13.Text = "0";
                    UpdateUIForRNumberWinner();
                }
                else if (value1 < value2)
                {
                    MessageBox.Show("Team 2 Wins");
               
                    string Query = "insert into RTU1 (Round, Player1, Player2, Team1Point,Team2Point, MiniBunco, Bunco) values('" + rnumber + "','" + "Fei" + "','" + "Yohannes" + "','" + value1 + "','" + value2 + "','" + minbunco + "','" + bunco + "');";
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
                    rnumber++;
                    roundnumber++;
                    label12.Text = "0";
                    label13.Text = "0";
                    UpdateUIForRNumber();
                }
                else
                {
                    MessageBox.Show("Both values are equal: " + value1);
                }
            }
        }
        private void UpdateUIForRNumberWinner()
        {
            switch (rnumber)
            {
                case 3:
                    pictureBox1.BackColor = Color.Aquamarine;
                    pictureBox2.BackColor = Color.Aquamarine;
                    label5.Text = "Leo";
                    label3.Text = "Icardı";
                    label2.Text = "Table 2 ";
                    break;
               
                case 4:
                    pictureBox1.BackColor = Color.Orange;
                    pictureBox2.BackColor = Color.Orange;
                    label5.Text = "Cj";
                    label3.Text = "Ronald";
                    label2.Text = "Header Table";
                    break;
                case 5:
                    pictureBox1.BackColor = Color.Aquamarine;
                    pictureBox2.BackColor = Color.Aquamarine;
                    label5.Text = "Leo";
                    label3.Text = "Icardı";
                    label2.Text = "Header Table";
                    break;
                case 6:
                    pictureBox1.BackColor = Color.Lavender;
                    pictureBox2.BackColor = Color.Lavender;
                    label5.Text = "Fei";
                    label3.Text = "Yohannes";
                    label2.Text = "Header Table";
                    break;
                case 7:
                    MessageBox.Show("Bunco game is over!!!");
                    Form5 form = new Form5();
                    form.Show();
                    this.Hide();
                    break;
                    // Add more cases as needed
            }

            label14.Text = rnumber.ToString();
        }
        private void UpdateUIForRNumber()
        {
            switch (rnumber)
            {
                case 3:
                    pictureBox1.BackColor = Color.Pink;
                    pictureBox2.BackColor = Color.Pink;
                    label5.Text = "Can";
                    label3.Text = "Daisy";
                    label2.Text = "Table 2";
                    break;
                case 4:
                    pictureBox1.BackColor = Color.Orange;
                    pictureBox2.BackColor = Color.Orange;
                    label5.Text = "Cj"; 
                    label3.Text = "Ronald";
                    label2.Text = "Table 2 ";
                    break;
                case 5:
                    pictureBox1.BackColor = Color.Pink;
                    pictureBox2.BackColor = Color.Pink;
                    label5.Text = "Can";
                    label3.Text = "Daisy";
                    label2.Text = "Table 1";
                    break;
                case 6:
                    pictureBox1.BackColor = Color.Lavender;
                    pictureBox2.BackColor = Color.Lavender;
                    label5.Text = "Fei";
                    label3.Text = "Yohannes";
                    label2.Text = "Table 2 ";
                    break;
                case 7:
                    MessageBox.Show("Bunco game is over!!!");
                    Form5 form = new Form5();
                    form.Show();
                    this.Hide();

                    break;
                    // Add more cases as needed
            }

            label14.Text = rnumber.ToString();
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            label2.Text = "Table 1 ";
        }
    }
}
       