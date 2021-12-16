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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
                dataGridView1.Columns.Add("idUniversity", "idUniversity");
                dataGridView1.Columns.Add("NameOfUniversity", "NameOfUniversity");
                dataGridView1.Columns.Add("DateOfBirth", "DateOfBirth");
                dataGridView1.Columns.Add("CountOfStudents", "CountOfStudents");
                dataGridView1.Columns.Add("CountOfTeachers", "CountOfTeachers");
            }

            string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";

            string sqlExpression = "SELECT * FROM University";
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
                        object id = reader.GetValue(0);
                        object name = reader.GetValue(1);
                        object dateofbirth = reader.GetValue(2);
                        object countstudents = reader.GetValue(3);
                        object countteachers = reader.GetValue(4);

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[counter].Cells[0].Value = id;
                        dataGridView1.Rows[counter].Cells[1].Value = name;
                        dataGridView1.Rows[counter].Cells[2].Value = dateofbirth;
                        dataGridView1.Rows[counter].Cells[3].Value = countstudents;
                        dataGridView1.Rows[counter].Cells[4].Value = countteachers;

                        counter++;
                    }
                }

                reader.Close();
            }

            Console.Read();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRow = dataGridView1.SelectedCells[0].RowIndex;
            object idUniversity = dataGridView1.Rows[idRow].Cells[0].Value;

            Form frm = new Form4(idUniversity);
            frm.Show();
        }
    }
}
