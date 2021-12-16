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


namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

            if (dataGridView1.Columns.Count < 1)
            {
                dataGridView1.Columns.Add("NameOfFacultet", "NameOfFacultet");
                dataGridView1.Columns.Add("NameOfUniversity", "NameOfUniversity");
            }

            string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";

            string sqlExpression = "SELECT NameOfFacultet, NameOfUniversity FROM Facultet INNER JOIN University ON Facultet.University = University.idUniversity";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {

                    int counter = 0;
                    while (reader.Read()) // построчно считываем данные
                    {
                        dataGridView1.ReadOnly = true;
                        object NameOfFacultet = reader.GetValue(0);
                        object NameOfUniversity = reader.GetValue(1);

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[counter].Cells[0].Value = NameOfFacultet;
                        dataGridView1.Rows[counter].Cells[1].Value = NameOfUniversity;

                        counter++;
                    }
                }

                reader.Close();
            }

            Console.Read();
        }
    }
}
