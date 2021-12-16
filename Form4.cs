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
    public partial class Form4 : Form
    {
        public object data;
        public Form4(object _data)
        {
            InitializeComponent();
            data = _data;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            object idUniversityString = data;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
            }

            if (dataGridView1.Columns.Count < 1)
            {
                dataGridView1.Columns.Add("idFacultet", "idFacultet");
                dataGridView1.Columns.Add("University", "University");
                dataGridView1.Columns.Add("NameOfFacultet", "NameOfFacultet");
                dataGridView1.Columns.Add("Decan", "Decan");
                dataGridView1.Columns.Add("NumTelOfDecanat", "NumTelOfDecanat");
            }

            string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";

            string sqlExpression = "SELECT * FROM [Facultet] WHERE University="+ idUniversityString;
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
                        object idFacultet = reader.GetValue(0);
                        object University = reader.GetValue(1);
                        object NameOfFacultet = reader.GetValue(2);
                        object Decan = reader.GetValue(3);
                        object NumTelOfDecanat = reader.GetValue(4);

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[counter].Cells[0].Value = idFacultet;
                        dataGridView1.Rows[counter].Cells[1].Value = University;
                        dataGridView1.Rows[counter].Cells[2].Value = NameOfFacultet;
                        dataGridView1.Rows[counter].Cells[3].Value = Decan;
                        dataGridView1.Rows[counter].Cells[4].Value = NumTelOfDecanat;

                        counter++;
                    }
                }

                reader.Close();
            }

            Console.Read();
        }
    }
}
