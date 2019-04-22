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

namespace AdoNet_HW_3
{
    public partial class Form1 : Form
    {
        SqlConnection connect = null;
        SqlCommand comand = null;
        SqlDataReader reader = null;
        string connection = null;
        string query1 = "select * from Client";
        string query2 = "select * from Seller";
        string query3 = "select * from sales";


        public Form1()
        {
            
            InitializeComponent();
        }

        private void Load_data()
        {
            connection = @"Data Source = DESKTOP-OHQR73G;
                                        Initial Catalog = Sales;
                                        Integrated Security = True";
            connect = new SqlConnection(connection);
            try
            {
                connect.Open();
                if (comboBox1.Text == "Client")
                {
                    comand = new SqlCommand(query1, connect);
                    reader = comand.ExecuteReader();
                    List<string[]> data = new List<string[]>();
                    while (reader.Read())
                    {
                        data.Add(new string[3]);

                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();

                    }

                    reader.Close();
                    connect.Close();

                    foreach(string[] i in data)
                    {
                        dataGridView1.Rows.Add(i);
                    }
                }
                else if (comboBox1.Text == "Seller")
                {
                    comand = new SqlCommand(query2, connect);
                    reader = comand.ExecuteReader();
                    List<string[]> data2 = new List<string[]>();
                    while (reader.Read())
                    {
                        data2.Add(new string[3]);

                        data2[data2.Count - 1][0] = reader[0].ToString();
                        data2[data2.Count - 1][1] = reader[1].ToString();
                        data2[data2.Count - 1][2] = reader[2].ToString();

                    }

                    reader.Close();
                    connect.Close();

                    foreach (string[] i in data2)
                    {
                        dataGridView1.Rows.Add(i);
                    }
                }
                else 
                {
                    comand = new SqlCommand(query3, connect);
                    reader = comand.ExecuteReader();
                    List<string[]> data3 = new List<string[]>();
                    while (reader.Read())
                    {
                        data3.Add(new string[5]);

                        data3[data3.Count - 1][0] = reader[0].ToString();
                        data3[data3.Count - 1][1] = reader[1].ToString();
                        data3[data3.Count - 1][2] = reader[2].ToString();
                        data3[data3.Count - 1][3] = reader[3].ToString();
                        data3[data3.Count - 1][4] = reader[4].ToString();
                    }

                    reader.Close();
                    connect.Close();

                    foreach (string[] i in data3)
                    {
                        dataGridView2.Rows.Add(i);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect?.Close();
                comand?.Clone();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Load_data();
        }

   

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
