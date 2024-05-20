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
using MySql.Data.MySqlClient;


namespace BuncoGame
{
    public partial class Form5 : Form
    {
        string connectionstring = "Data Source=DESKTOP-KIH1OI6;Initial Catalog=Rtu;Integrated Security=True";
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // Create a list of insert commands
            var insertCommands = new[]
            {
           new { Round = 1, Player1 = "Can", Player2 = "Daisy", Team1Point = 20, Team2Point = 15, MiniBunco = 2, Bunco = 1 },
            new { Round = 1, Player1 = "Fei", Player2 = "Yohannes", Team1Point = 18, Team2Point = 19, MiniBunco = 3, Bunco = 0 },
            new { Round = 2, Player1 = "Leo", Player2 = "Icardi", Team1Point = 21, Team2Point = 16, MiniBunco = 3, Bunco = 0 },
            new { Round = 2, Player1 = "Alex", Player2 = "Chole", Team1Point = 22, Team2Point = 14, MiniBunco = 1, Bunco = 1 },
            new { Round = 3, Player1 = "CJ", Player2 = "Ronaldo", Team1Point = 24, Team2Point = 17, MiniBunco = 2, Bunco = 2 },
            new { Round = 3, Player1 = "Can", Player2 = "Daisy", Team1Point = 20, Team2Point = 15, MiniBunco = 3, Bunco = 0 },
            new { Round = 4, Player1 = "Fei", Player2 = "Yohannes", Team1Point = 19, Team2Point = 20, MiniBunco = 4, Bunco = 1 },
            new { Round = 4, Player1 = "Leo", Player2 = "Icardi", Team1Point = 22, Team2Point = 18, MiniBunco = 2, Bunco = 0 },
            new { Round = 5, Player1 = "Alex", Player2 = "Chole", Team1Point = 23, Team2Point = 19, MiniBunco = 3, Bunco = 1 },
            new { Round = 5, Player1 = "CJ", Player2 = "Ronaldo", Team1Point = 21, Team2Point = 17, MiniBunco = 2, Bunco = 2 },
            new { Round = 6, Player1 = "Can", Player2 = "Daisy", Team1Point = 20, Team2Point = 15, MiniBunco = 1, Bunco = 0 },
            new { Round = 6, Player1 = "Fei", Player2 = "Yohannes", Team1Point = 18, Team2Point = 20, MiniBunco = 3, Bunco = 1 }
            // Add more entries here
        };

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                foreach (var command in insertCommands)
                {
                    string query = "INSERT INTO rtu1 (round, player1, player2, team1point, team2point, minibunco, bunco) VALUES (@Round, @Player1, @Player2, @Team1Point, @Team2Point, @MiniBunco, @Bunco)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Round", command.Round);
                        cmd.Parameters.AddWithValue("@Player1", command.Player1);
                        cmd.Parameters.AddWithValue("@Player2", command.Player2);
                        cmd.Parameters.AddWithValue("@Team1Point", command.Team1Point);
                        cmd.Parameters.AddWithValue("@Team2Point", command.Team2Point);
                        cmd.Parameters.AddWithValue("@MiniBunco", command.MiniBunco);
                        cmd.Parameters.AddWithValue("@Bunco", command.Bunco);

                        cmd.ExecuteNonQuery();
                    }
                }


                SqlDataAdapter sqlda = new SqlDataAdapter("select *  from RTU1", connection);

                DataTable dtbl = new DataTable();

                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                string totalPointsQuery = @"
                SELECT Player, SUM(CAST(TotalPoints AS INT)) AS TotalPoints
                FROM (
                    SELECT player1 AS Player, team1point AS TotalPoints FROM rtu1
                    UNION ALL
                    SELECT player2 AS Player, team2point AS TotalPoints FROM rtu1
                ) AS CombinedPoints
                GROUP BY Player
            ";

                using (SqlCommand cmd = new SqlCommand(totalPointsQuery, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int highestPoints = 0;
                        string winner = "";

                        Console.WriteLine("Total Points:");
                        while (reader.Read())
                        {
                            string player = reader["Player"].ToString();

                            int totalPoints = Convert.ToInt32(reader["TotalPoints"]);

                            if (totalPoints > highestPoints)
                            {
                                highestPoints = totalPoints;
                                winner = player;
                            }

                            MessageBox.Show($"Players: {player}, Total Points: {totalPoints}");
                        }

                        MessageBox.Show($"\nWinner: {winner} with {highestPoints} points");
                    }
                }
            }
        }
        
    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from RTU1 where Round='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("select *  from RTU1", connection);

                DataTable dtbl = new DataTable();

                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0; // Reset progress bar value

            // Simulate a task by incrementing the progress bar value
            for (int i = 0; i <= 100; i++)
            {
                Task.Delay(20); // Simulate work being done
                progressBar1.Value = i; // Update progress bar value
            }
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}
