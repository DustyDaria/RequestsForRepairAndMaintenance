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


        public void Select_9(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(new string[9]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                        data[data.Count - 1][7] = reader[7].ToString();
                        data[data.Count - 1][8] = reader[8].ToString();

                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка!\n" + e.ToString());
            }
        }


        public void Select_8(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(new string[8]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                        data[data.Count - 1][7] = reader[7].ToString();
                        //data[data.Count - 1][8] = reader[8].ToString();

                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка!\n" + e.ToString());
            }
        }


        public void Select_7(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        data.Add(new string[7]);
                        data[data.Count - 1][0] = reader[0].ToString();
                        data[data.Count - 1][1] = reader[1].ToString();
                        data[data.Count - 1][2] = reader[2].ToString();
                        data[data.Count - 1][3] = reader[3].ToString();
                        data[data.Count - 1][4] = reader[4].ToString();
                        data[data.Count - 1][5] = reader[5].ToString();
                        data[data.Count - 1][6] = reader[6].ToString();
                        //data[data.Count - 1][7] = reader[7].ToString();
                        //data[data.Count - 1][8] = reader[8].ToString();

                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка!\n" + e.ToString());
            }
        }

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
