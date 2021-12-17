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
    public partial class Form2 : Form
    {

        /// <summary>
        /// Verifies that the customer name text box is not empty.
        /// </summary>
        private bool checkInputInsert()
        {
            if (textBox1.Text == "" || textBox3.Text == ""
                || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Данные неверны");
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Clears the form data.
        /// </summary>
        private void ClearForm()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
        }

        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInputInsert())
            {

                string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";
                string NameOfUniversity = textBox1.Text;
                string DateOfBirth = textBox6.Text;
                string CountOfStudents = textBox3.Text;
                string CountOfTeachers = textBox4.Text;
                string Rector = textBox5.Text;

                string sqlExpression = "INSERT INTO University(NameOfUniversity, DateOfBirth, CountOfStudents, CountOfTeachers,Rector) VALUES('" + NameOfUniversity + "','" + DateOfBirth + "'," + CountOfStudents + "," + CountOfTeachers + "," + Rector + ")";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Университет добавлен успешно!");
                }
                Console.Read();
            }

            ClearForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
            }

            if (dataGridView1.Columns.Count < 1)
            {
                dataGridView1.Columns.Add("idUniversity", "idUniversity");
                dataGridView1.Columns.Add("NameOfUniversity", "NameOfUniversity");
                dataGridView1.Columns.Add("DateOfBirth", "DateOfBirth");
                dataGridView1.Columns.Add("CountOfStudents", "CountOfStudents");
                dataGridView1.Columns.Add("CountOfTeachers", "CountOfTeachers");
                dataGridView1.Columns.Add("Rector", "Rector");
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
                        object rector = reader.GetValue(5);

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[counter].Cells[0].Value = id;
                        dataGridView1.Rows[counter].Cells[1].Value = name;
                        dataGridView1.Rows[counter].Cells[2].Value = dateofbirth;
                        dataGridView1.Rows[counter].Cells[3].Value = countstudents;
                        dataGridView1.Rows[counter].Cells[4].Value = countteachers;
                        dataGridView1.Rows[counter].Cells[5].Value = rector;

                        counter++;
                    }
                }

                reader.Close();
            }

            Console.Read();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";
                string idUniversity = textBox2.Text;
                string NameOfUniversity = textBox11.Text;
                string DateOfBirth = textBox7.Text;
                string CountOfStudents = textBox10.Text;
                string CountOfTeachers = textBox9.Text;
                string Rector = textBox8.Text;

                string sqlExpression = "";
                if (radioButton1.Checked == true)
                {
                    sqlExpression = "UPDATE University SET NameOfUniversity='" + NameOfUniversity + "' WHERE idUniversity=" + idUniversity;
                }

                if (radioButton2.Checked == true)
                {
                    sqlExpression = "UPDATE University SET DateOfBirth='" + DateOfBirth + "' WHERE idUniversity=" + idUniversity;
                }

                if (radioButton3.Checked == true)
                {
                    sqlExpression = "UPDATE University SET CountOfStudents='" + CountOfStudents + "' WHERE idUniversity=" + idUniversity;
                }

                if (radioButton4.Checked == true)
                {
                    sqlExpression = "UPDATE University SET CountOfTeachers='" + CountOfTeachers + "' WHERE idUniversity=" + idUniversity;
                }

                if (radioButton5.Checked == true)
                {
                    sqlExpression = "UPDATE University SET Rector='" + Rector + "' WHERE idUniversity=" + idUniversity;
                }

                if (sqlExpression == "")
                {
                    MessageBox.Show("Ничего не выбрано");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Университет изменен успешно!");
                    }
                    Console.Read();
                }
            }
            else
            {
                MessageBox.Show("А где менять-то?");
            }

            ClearForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != "")
            {

                string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";
                string idUniversity = textBox12.Text;

                string sqlExpression = "DELETE  FROM University WHERE idUniversity='" + idUniversity + "'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Университет удален успешно!");
                }
            }
            else
            {
                MessageBox.Show("Не указано что удалить...");
            }
            ClearForm();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRow = dataGridView1.SelectedCells[0].RowIndex;
            object idUniversity = dataGridView1.Rows[idRow].Cells[0].Value;

            textBox12.Text = idUniversity.ToString();
            textBox2.Text = idUniversity.ToString();

            Form frm = new Form4(idUniversity);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearForm();

            string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";
            string sqlExpression = "Mark_avg";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var result = command.ExecuteScalar();
                textBox13.Text = result.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkInputInsert())
            {
                string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";
                string NameOfUniversity = textBox1.Text;
                string DateOfBirth = textBox6.Text;
                string CountOfStudents = textBox3.Text;
                string CountOfTeachers = textBox4.Text;
                string Rector = textBox5.Text;

                string sqlExpression = "INSERT INTO View4 VALUES('" + NameOfUniversity + "','" + DateOfBirth + "'," + CountOfStudents + "," + CountOfTeachers + "," + Rector + ")";

                try
                {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Университет добавлен успешно!");
                    }
                    Console.Read();
                }
                catch
                {
                    MessageBox.Show("Число студентов меньше 3000, так низя");
                }
            }

            ClearForm();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();
            }

            if (dataGridView1.Columns.Count < 1)
            {
                dataGridView2.Columns.Add("Passport", "Passport");
                dataGridView2.Columns.Add("Surname", "Surname");
                dataGridView2.Columns.Add("NameOfTeacher", "NameOfTeacher");
                dataGridView2.Columns.Add("Patronymic", "Patronymic");
            }

            string connectionString = @"Data Source = .\SQL_EXPRESS;Initial Catalog=finSql; Integrated Security = True";

            string sqlExpression = "SELECT * FROM Teacher";
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
                        dataGridView2.ReadOnly = true;
                        object id = reader.GetValue(0);
                        object surname = reader.GetValue(1);
                        object name = reader.GetValue(2);
                        object patronymic = reader.GetValue(3);

                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[counter].Cells[0].Value = id;
                        dataGridView2.Rows[counter].Cells[1].Value = surname;
                        dataGridView2.Rows[counter].Cells[2].Value = name;
                        dataGridView2.Rows[counter].Cells[3].Value = patronymic;

                        counter++;
                    }
                }

                reader.Close();
            }

            Console.Read();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idRow = dataGridView2.SelectedCells[0].RowIndex;
            object passport = dataGridView2.Rows[idRow].Cells[0].Value;

            textBox5.Text = passport.ToString();
            textBox8.Text = passport.ToString();
        }
    }
}
