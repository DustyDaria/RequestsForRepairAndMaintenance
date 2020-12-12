using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestsForRepairAndMaintenance
{
    class DataBase
    {
        string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";

        //отображает кол-во измененных/удаленных/добавленных элементов
        int number = 0;

        public List<string[]> data = new List<string[]>();

        public void Select(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно выбрано " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + e.ToString());
            }
        }

        public void Insert(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно добавлено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + e.ToString());
            }
        }

        public void Update(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно обновлено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + e.ToString());
            }
        }

        public void Delete(string query)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    number = command.ExecuteNonQuery();
                    connection.Close();
                }
                MessageBox.Show("Успешно удалено " + number + " объектов!");
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + e.ToString());
            }
        }

        public int GetID(string query)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                id = (int)reader[i];
                                i++;
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return id;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("ERROR!!!\n" + e.ToString());
                return 0;
            }
        }
        

        public string GetResult(string query)
        {
            string result = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                result = (string)reader[i];
                                i++;
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return result;
                }
            }
            catch(Exception e)
            {
                result = string.Empty;
                MessageBox.Show("ERROR!!!\n" + e.ToString());
                return result;
            }
        }


        public string getResultTest(string query)
        {
            string result = String.Empty;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(query);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            result = (string)reader[i];
                            i++;
                        }
                        reader.Close();
                    }
                }
                connection.Close();
                return result;
            }
        }

        public bool Check(string query, string data)
        {
            bool result = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = string.Format(query);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                if (data == reader[i].ToString())
                                {
                                    result = true;
                                }
                                else
                                {
                                    result = false;
                                }
                            }
                            reader.Close();
                        }
                    }
                    connection.Close();
                    return result;
                }
            }
            catch(Exception e)
            {
                result = false;
                MessageBox.Show("ERROR!!!\n" + e.ToString());
                return result;
            }
            
        }
    }
}
