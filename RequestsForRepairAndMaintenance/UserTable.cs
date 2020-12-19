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
using RequestsForRepairAndMaintenance.Properties;

namespace RequestsForRepairAndMaintenance
{
    public partial class UserTable : Form
    {
        int mainID = 0;
        //int secondaryID = 0;
        string usersAction = string.Empty;
        public string typeSearchTransfer;
        public string stringReaderBoxTransfer;

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_SmallHeader = new Font("Arial", 16, FontStyle.Bold);
        Font font_mainText = new Font("Arial", 14, FontStyle.Regular);
        Font font_MiddleText = new Font("Arial", 12, FontStyle.Regular);
        Font font_SmallText = new Font("Arial", 8, FontStyle.Regular);
        Font font_MiddleLinkText = new Font("Arial", 10, FontStyle.Regular);

        GroupBox groupBoxTop = new System.Windows.Forms.GroupBox();

        Button btn_Back = new System.Windows.Forms.Button();
        Button btn_LogOut = new System.Windows.Forms.Button();
        Button btn_Search = new System.Windows.Forms.Button();
        Button btn_UpdateData = new System.Windows.Forms.Button();

        TextBox textBox_DataForSearch = new System.Windows.Forms.TextBox();

        LinkLabel linkLabel_UserName = new System.Windows.Forms.LinkLabel();

        Label label_Header = new System.Windows.Forms.Label();
        //Label label_AdditionalText = new System.Windows.Forms.Label();
        Label label_SearchCriteria = new System.Windows.Forms.Label();
        Label label_EnterDataForSearch = new System.Windows.Forms.Label();

        DataGridView dataGridView_Customer = new System.Windows.Forms.DataGridView();
        DataGridView dataGridView_Executors = new System.Windows.Forms.DataGridView();
        DataGridView dataGridView_All = new System.Windows.Forms.DataGridView();

        ComboBox comboBox_SearchCustomer = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_SearchExecutors = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_SearchAll = new System.Windows.Forms.ComboBox();

        DataBase dataBase = new DataBase();

        public UserTable(int returnID, string action)
        {
            InitializeComponent();

            mainID = returnID;
            //secondaryID = usersID;
            usersAction = action;

            // ФОРМА
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(990, 720);
            this.ResizeRedraw = true;
            this.BackColor = Color.Azure;
            this.AutoScroll = true;
            this.Icon = Resources.logo;
            //

            // ШАПКА
            groupBoxTop.Text = "Учет заявок на техническое обслуживание и ремонт (ТОиР)";
            groupBoxTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            groupBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            groupBoxTop.BackColor = Color.SteelBlue;
            groupBoxTop.ForeColor = Color.Azure;
            groupBoxTop.Font = font_Header;

            label_Header.Font = font_SmallHeader;
            label_Header.ForeColor = Color.MidnightBlue;
            label_Header.TextAlign = ContentAlignment.MiddleCenter;

            btn_Back.Text = string.Empty;
            btn_Back.BackgroundImage = Resources.left_arrow128;
            btn_Back.BackgroundImageLayout = ImageLayout.Zoom;
            btn_Back.BackColor = Color.SteelBlue;
            btn_Back.Cursor = Cursors.Hand;
            btn_Back.FlatAppearance.BorderSize = 0;
            btn_Back.FlatStyle = FlatStyle.Flat;
            btn_Back.Click += new System.EventHandler(btn_Back_Click);

            btn_LogOut.Text = string.Empty;
            btn_LogOut.BackgroundImage = Resources.logout128;
            btn_LogOut.BackgroundImageLayout = ImageLayout.Zoom;
            btn_LogOut.BackColor = Color.SteelBlue;
            btn_LogOut.Cursor = Cursors.Hand;
            btn_LogOut.FlatAppearance.BorderSize = 0;
            btn_LogOut.FlatStyle = FlatStyle.Flat;
            btn_LogOut.Click += new System.EventHandler(btn_LogOut_Click);

            linkLabel_UserName.Font = font_MiddleLinkText;
            linkLabel_UserName.TextAlign = ContentAlignment.MiddleRight;
            linkLabel_UserName.LinkColor = Color.Azure;
            linkLabel_UserName.BackColor = Color.SteelBlue;
            linkLabel_UserName.Cursor = Cursors.Hand;
            linkLabel_UserName.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            linkLabel_UserName.Click += new System.EventHandler(linkLabel_UserName_Click);
            //

            // ДАННЫЕ ЗАКАЗЧИКОВ
            dataGridView_Customer.Columns.Add("id_user", "ID");
            dataGridView_Customer.Columns[0].Width = (int)LocationX(2, 40);
            dataGridView_Customer.Columns.Add("user_login", "Логин");
            dataGridView_Customer.Columns[1].Width = (int)LocationX(6, 40);
            dataGridView_Customer.Columns.Add("last_name", "Фамилия");
            dataGridView_Customer.Columns[2].Width = (int)LocationX(6, 40);
            dataGridView_Customer.Columns.Add("name", "Имя");
            dataGridView_Customer.Columns[3].Width = (int)LocationX(5, 40);
            dataGridView_Customer.Columns.Add("middle_name", "Отчество");
            dataGridView_Customer.Columns[4].Width = (int)LocationX(5, 40);
            dataGridView_Customer.Columns.Add("position", "Должность");
            dataGridView_Customer.Columns[5].Width = (int)LocationX(5, 40);
            dataGridView_Customer.Columns.Add("phone", "Телефон");
            dataGridView_Customer.Columns[6].Width = (int)LocationX(5, 40);
            dataGridView_Customer.Columns.Add("number_of_rooms", "Количество помещений");
            dataGridView_Customer.Columns[7].Width = (int)LocationX(5, 40);
            dataGridView_Customer.Columns.Add("number_of_request", "Количество заявок");
            dataGridView_Customer.Columns[8].Width = (int)LocationX(5, 40);
            dataGridView_Customer.ColumnHeadersDefaultCellStyle.Font = font_MiddleText;
            dataGridView_Customer.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView_Customer.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Customer.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Customer.ColumnHeadersHeight = (int)LocationY(2, 20);
            //

            //ДАННЫЕ ИСПОЛНИТЕЛЕЙ
            dataGridView_Executors.Columns.Add("id_user", "ID");
            dataGridView_Executors.Columns[0].Width = (int)LocationX(2, 40);
            dataGridView_Executors.Columns.Add("user_login", "Логин");
            dataGridView_Executors.Columns[1].Width = (int)LocationX(6, 40);
            dataGridView_Executors.Columns.Add("last_name", "Фамилия");
            dataGridView_Executors.Columns[2].Width = (int)LocationX(6, 40);
            dataGridView_Executors.Columns.Add("name", "Имя");
            dataGridView_Executors.Columns[3].Width = (int)LocationX(5, 40);
            dataGridView_Executors.Columns.Add("middle_name", "Отчество");
            dataGridView_Executors.Columns[4].Width = (int)LocationX(5, 40);
            dataGridView_Executors.Columns.Add("position", "Должность");
            dataGridView_Executors.Columns[5].Width = (int)LocationX(5, 40);
            dataGridView_Executors.Columns.Add("category_executors", "Категория исполнителя");
            dataGridView_Executors.Columns[6].Width = (int)LocationX(5, 40);
            dataGridView_Executors.Columns.Add("phone", "Телефон");
            dataGridView_Executors.Columns[7].Width = (int)LocationX(5, 40);
            dataGridView_Executors.Columns.Add("number_of_request", "Количество заявок");
            dataGridView_Executors.Columns[8].Width = (int)LocationX(5, 40);
            dataGridView_Executors.ColumnHeadersDefaultCellStyle.Font = font_MiddleText;
            dataGridView_Executors.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView_Executors.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_Executors.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Executors.ColumnHeadersHeight = (int)LocationY(2, 20);
            //

            //ДАННЫЕ ВСЕХ ПОЛЬЗОВАТЕЛЕЙ
            dataGridView_All.Columns.Add("id_user", "ID");
            dataGridView_All.Columns[0].Width = (int)LocationX(2, 40);
            dataGridView_All.Columns.Add("user_login", "Логин");
            dataGridView_All.Columns[1].Width = (int)LocationX(6, 40);
            dataGridView_All.Columns.Add("last_name", "Фамилия");
            dataGridView_All.Columns[2].Width = (int)LocationX(6, 40);
            dataGridView_All.Columns.Add("name", "Имя");
            dataGridView_All.Columns[3].Width = (int)LocationX(5, 40);
            dataGridView_All.Columns.Add("middle_name", "Отчество");
            dataGridView_All.Columns[4].Width = (int)LocationX(5, 40);
            dataGridView_All.Columns.Add("position", "Должность");
            dataGridView_All.Columns[5].Width = (int)LocationX(5, 40);
            dataGridView_All.Columns.Add("type_of_account", "Тип аккаунта");
            dataGridView_All.Columns[6].Width = (int)LocationX(5, 40);
            dataGridView_All.Columns.Add("category_executors", "Категория исполнителя");
            dataGridView_All.Columns[7].Width = (int)LocationX(5, 40);
            dataGridView_All.Columns.Add("phone", "Телефон");
            dataGridView_All.Columns[8].Width = (int)LocationX(5, 40);
            dataGridView_All.ColumnHeadersDefaultCellStyle.Font = font_MiddleText;
            dataGridView_All.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView_All.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_All.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_All.ColumnHeadersHeight = (int)LocationY(2, 20);
            //

            //ПОИСК
            comboBox_SearchCustomer.Font = font_MiddleText;
            comboBox_SearchCustomer.ForeColor = Color.DimGray;
            comboBox_SearchCustomer.DropDownStyle = ComboBoxStyle.DropDown;
            //comboBox_SearchCustomer.TextChanged += new System.EventHandler(comboBox_SearchCustomer_TextChanged);
            comboBox_SearchCustomer.Items.AddRange(new string[] { "ID", "Логин", "Фамилия", "Имя", "Отчество"
                , "Должность", "Телефон", "Количество помещений", "Количество заявок" });

            comboBox_SearchExecutors.Font = font_MiddleText;
            comboBox_SearchExecutors.ForeColor = Color.DimGray;
            comboBox_SearchExecutors.DropDownStyle = ComboBoxStyle.DropDown;
            //comboBox_SearchExecutors.TextChanged += new System.EventHandler(comboBox_SearchExecutors_TextChanged);
            comboBox_SearchExecutors.Items.AddRange(new string[] { "ID", "Логин", "Фамилия", "Имя", "Отчество"
                , "Должность", "Категория исполнителя", "Телефон", "Количество заявок" });

            comboBox_SearchAll.Font = font_MiddleText;
            comboBox_SearchAll.ForeColor = Color.DimGray;
            comboBox_SearchAll.DropDownStyle = ComboBoxStyle.DropDown;
            //comboBox_SearchAll.TextChanged += new System.EventHandler(comboBox_SearchAll_TextChanged);
            comboBox_SearchAll.Items.AddRange(new string[] { "ID", "Логин", "Фамилия", "Имя", "Отчество"
                , "Должность", "Тип аккаунта" , "Категория исполнителя", "Телефон" });

            btn_Search.Text = "Поиск";
            btn_Search.Font = font_mainText;
            btn_Search.ForeColor = Color.DimGray;
            btn_Search.BackColor = Color.LightSteelBlue;
            btn_Search.TextAlign = ContentAlignment.MiddleCenter;
            btn_Search.Click += new System.EventHandler(btn_Search_Click);

            btn_UpdateData.Text = "Обновить данные";
            btn_UpdateData.Font = font_mainText;
            btn_UpdateData.ForeColor = Color.DimGray;
            btn_UpdateData.BackColor = Color.LightSteelBlue;
            btn_UpdateData.TextAlign = ContentAlignment.MiddleCenter;
            btn_UpdateData.Click += new System.EventHandler(btn_UpdateData_Click);

            label_SearchCriteria.Font = font_MiddleText;
            label_SearchCriteria.Text = "Выберите критерий поиска: ";
            label_SearchCriteria.ForeColor = Color.DimGray;
            label_SearchCriteria.TextAlign = ContentAlignment.MiddleLeft;

            label_EnterDataForSearch.Font = font_MiddleText;
            label_EnterDataForSearch.Text = "Введите данные для поиска: ";
            label_EnterDataForSearch.ForeColor = Color.DimGray;
            label_EnterDataForSearch.TextAlign = ContentAlignment.MiddleLeft;
            //

            string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");

            if (usersAction == "Executor")
            {
                this.Text = "Исполнители";
                label_Header.Text = "Исполнители";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                LoadDataExecutor();
            }
            else if (usersAction == "Customer")
            {
                this.Text = "Заказчики";
                label_Header.Text = "Заказчики";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                LoadDataCustomer();

            }
            else if (usersAction == "All")
            {
                this.Text = "Все пользователи";
                label_Header.Text = "Все пользователи";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                LoadDataAll();
            }

        }

        private void LoadDataCustomer()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, phone FROM Users WHERE type_of_account = 'Заказчик' ORDER BY id_user;";

            SqlCommand command = new SqlCommand(queryPat, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

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
            myConnection.Close();
            foreach (string[] cus in data)
                dataGridView_Customer.Rows.Add(cus);
        }

        private void LoadDataExecutor()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE type_of_account = 'Исполнитель' ORDER BY id_user;";

            SqlCommand command = new SqlCommand(queryPat, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

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
            myConnection.Close();
            foreach (string[] exe in data)
                dataGridView_Executors.Rows.Add(exe);
        }

        private void LoadDataAll()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string queryPat = "SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users ORDER BY id_user;";

            SqlCommand command = new SqlCommand(queryPat, myConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

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
            myConnection.Close();
            foreach (string[] all in data)
                dataGridView_All.Rows.Add(all);
        }


        private void SizeLocation_New()
        {
            //ШАПКА
            groupBoxTop.Size = new System.Drawing.Size((int)LocationX(20, 20), (int)LocationY(3, 20));

            label_Header.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(3, 20));
            label_Header.Size = new System.Drawing.Size((int)LocationX(20, 40), (int)LocationY(2, 20));

            btn_Back.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(1, 20));
            btn_Back.Size = new System.Drawing.Size((int)LocationX(1, 24), (int)LocationY(1, 20));

            btn_LogOut.Location = new System.Drawing.Point((int)LocationX(22, 24), (int)LocationY(1, 20));
            btn_LogOut.Size = new System.Drawing.Size((int)LocationX(1, 24), (int)LocationY(1, 20));

            linkLabel_UserName.Location = new System.Drawing.Point((int)LocationX(18, 24), (int)LocationY(1, 20));
            linkLabel_UserName.Size = new System.Drawing.Size((int)LocationX(3, 24), (int)LocationY(1, 20));

            //label_AdditionalText.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(3, 20));
            //label_AdditionalText.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 20));
            //

            //ДАННЫЕ ПОЛЬЗОВАТЕЛЕЙ
            dataGridView_Customer.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            dataGridView_Customer.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));

            dataGridView_Executors.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            dataGridView_Executors.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));

            dataGridView_All.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            dataGridView_All.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));
            //

            //ПОИСК
            btn_UpdateData.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(5, 20));
            btn_UpdateData.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            label_SearchCriteria.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(7, 20));
            label_SearchCriteria.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(1, 20));

            comboBox_SearchCustomer.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            comboBox_SearchCustomer.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            comboBox_SearchExecutors.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            comboBox_SearchExecutors.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            comboBox_SearchAll.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            comboBox_SearchAll.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            label_EnterDataForSearch.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(10, 20));
            label_EnterDataForSearch.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(1, 20));

            textBox_DataForSearch.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(11, 20));
            textBox_DataForSearch.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            btn_Search.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(13, 20));
            btn_Search.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(1, 20));
            //
        }

        private void ControlsAdd()
        {
            //ШАПКА
            this.Controls.Add(btn_Back);
            this.Controls.Add(btn_LogOut);
            this.Controls.Add(linkLabel_UserName);
            this.Controls.Add(groupBoxTop);
            this.Controls.Add(label_Header);
            //

            // ПОИСК
            this.Controls.Add(label_SearchCriteria);
            this.Controls.Add(btn_Search);
            this.Controls.Add(btn_UpdateData);
            this.Controls.Add(label_EnterDataForSearch);
            this.Controls.Add(textBox_DataForSearch);
            //

            //ДАННЫЕ ПОЛЬЗОВАТЕЛЕЙ
            if (usersAction == "Executor")
            {
                this.Controls.Add(dataGridView_Executors);
                this.Controls.Add(comboBox_SearchExecutors);
            }
            else if (usersAction == "Customer")
            {
                this.Controls.Add(dataGridView_Customer);
                this.Controls.Add(comboBox_SearchCustomer);
            }
            else if (usersAction == "All")
            {
                this.Controls.Add(dataGridView_All);
                this.Controls.Add(comboBox_SearchAll);
            }
            //
        }

        private void btn_UpdateData_Click(object sender, EventArgs e)
        {
            if (usersAction == "Customer")
            {
                comboBox_SearchCustomer.Text = string.Empty;
                textBox_DataForSearch.Text = string.Empty;
                dataGridView_Customer.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.
                LoadDataCustomer();
            }
            else if (usersAction == "Executor")
            {
                comboBox_SearchExecutors.Text = string.Empty;
                textBox_DataForSearch.Text = string.Empty;
                dataGridView_Executors.Rows.Clear();
                dataBase.data.Clear();
                LoadDataExecutor();
            }
            else if (usersAction == "All")
            {
                comboBox_SearchAll.Text = string.Empty;
                textBox_DataForSearch.Text = string.Empty;
                dataGridView_All.Rows.Clear();
                dataBase.data.Clear();
                LoadDataAll();
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (usersAction == "Customer")
            {
                typeSearchTransfer = comboBox_SearchCustomer.Text;
                stringReaderBoxTransfer = textBox_DataForSearch.Text;
            }
            else if (usersAction == "Executor")
            {
                typeSearchTransfer = comboBox_SearchExecutors.Text;
                stringReaderBoxTransfer = textBox_DataForSearch.Text;
            }
            else if (usersAction == "All")
            {
                typeSearchTransfer = comboBox_SearchAll.Text;
                stringReaderBoxTransfer = textBox_DataForSearch.Text;
            }

            ListStatus(typeSearchTransfer, stringReaderBoxTransfer);
        }

        public void ListStatus(string typeSearch, string stringReaderBox)
        {

            if (usersAction == "Customer")
            {
                dataGridView_Customer.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.

                string querySearchID_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE id_user LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchLogin_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE user_login LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchLastName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE last_name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchMiddleName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE middle_name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchPosition_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE position LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                string querySearchPhone_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, phone  FROM Users WHERE phone LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Заказчик' ORDER BY id_user;");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");

                if (typeSearch == "ID")
                {
                    dataBase.Select_7(querySearchID_GET);
                    foreach (string[] s in dataBase.data) // Загрузка данных из нашего буфера.
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Логин")
                {
                    dataBase.Select_7(querySearchLogin_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Фамилия")
                {
                    dataBase.Select_7(querySearchLastName_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Имя")
                {
                    dataBase.Select_7(querySearchName_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Отчество")
                {
                    dataBase.Select_7(querySearchMiddleName_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Должность")
                {
                    dataBase.Select_7(querySearchPosition_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Телефон")
                {
                    dataBase.Select_7(querySearchPhone_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Customer.Rows.Add(s);
                }
                else if (typeSearch == "Количество помещений")
                {
                    /*dataBase.Select(querySearchSpecializ);
                    foreach (string[] s in dataBase.data) 
                        dataGridViewDoc.Rows.Add(s);*/
                    MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else if (typeSearch == "Количество заявок")
                {
                    /*dataBase.Select(querySearchSpecializ);
                    foreach (string[] s in dataBase.data) // Загрузка данных из нашего буфера.
                        dataGridViewDoc.Rows.Add(s);*/
                    MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else
                {
                    MessageBox.Show("Выберите критерий поиска");
                }
            }
            else if (usersAction == "Executor")
            {
                dataGridView_Executors.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.

                string querySearchID_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE id_user LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchLogin_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE user_login LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchLastName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE last_name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchMiddleName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE middle_name LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchPosition_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE position LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchCategoryExecutors_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE category_executors LIKE '%" 
                    + stringReaderBox+ "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                string querySearchPhone_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, category_executors, phone FROM Users WHERE phone LIKE '%" 
                    + stringReaderBox + "%' AND type_of_account = 'Исполнитель' ORDER BY id_user;");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");

                if (typeSearch == "ID")
                {
                    dataBase.Select_8(querySearchID_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Логин")
                {
                    dataBase.Select_8(querySearchLogin_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Фамилия")
                {
                    dataBase.Select_8(querySearchLastName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Имя")
                {
                    dataBase.Select_8(querySearchName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Отчество")
                {
                    dataBase.Select_8(querySearchMiddleName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Должность")
                {
                    dataBase.Select_8(querySearchPosition_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Категория исполнителя")
                {
                    dataBase.Select_8(querySearchCategoryExecutors_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_Executors.Rows.Add(s);
                }
                else if (typeSearch == "Телефон")
                {
                    dataBase.Select_8(querySearchPhone_GET);
                    foreach (string[] s in dataBase.data) 
                        dataGridView_Executors.Rows.Add(s);
                    //MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else if (typeSearch == "Количество заявок")
                {
                    /*dataBase.Select(querySearchSpecializ);
                    foreach (string[] s in dataBase.data)
                        dataGridViewDoc.Rows.Add(s);*/
                    MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else
                {
                    MessageBox.Show("Выберите критерий поиска");
                }
            }
            else if (usersAction == "All")
            {
                dataGridView_All.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.


                string querySearchID_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE id_user LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchLogin_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE user_login LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchLastName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE last_name LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE name LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchMiddleName_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE middle_name LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchPosition_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE position LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchTypeOfAccount_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE type_of_account LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchCategoryExecutors_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE category_executors LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                string querySearchPhone_GET = string.Format("SELECT id_user, user_login, last_name, name, middle_name, position, type_of_account, category_executors, phone FROM Users WHERE phone LIKE '%" 
                    + stringReaderBox + "%' ORDER BY id_user;");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");
                //string querySearchID_GET = string.Format("SELECT * FROM Users WHERE id_user LIKE '%" + stringReaderBox + "%';");

                if (typeSearch == "ID")
                {
                    dataBase.Select_9(querySearchID_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Логин")
                {
                    dataBase.Select_9(querySearchLogin_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Фамилия")
                {
                    dataBase.Select_9(querySearchLastName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Имя")
                {
                    dataBase.Select_9(querySearchName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Отчество")
                {
                    dataBase.Select_9(querySearchMiddleName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Должность")
                {
                    dataBase.Select_9(querySearchPosition_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Тип аккаунта")
                {
                    dataBase.Select_9(querySearchTypeOfAccount_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                }
                else if (typeSearch == "Категория исполнителя")
                {
                    dataBase.Select_9(querySearchCategoryExecutors_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                    //MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else if (typeSearch == "Телефон")
                {
                    dataBase.Select_9(querySearchPhone_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_All.Rows.Add(s);
                    //MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else
                {
                    MessageBox.Show("Выберите критерий поиска");
                }

            }
        }

        private void linkLabel_UserName_Click(object sender, EventArgs e)
        {
            UsersData usersData = new UsersData(mainID, "Просмотреть", 0);
            this.Close();
            usersData.Show();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Menu_Users menu_Users = new Menu_Users(mainID);
            this.Close();
            menu_Users.Show();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            this.Close();
            authorization.Show();
        }

        private double LocationX(int locationX, int partOfScreen_NUM)
        {
            string clientScreenWidth = this.Size.Width.ToString();
            double partOfScreen_WIDTH = Convert.ToInt32(clientScreenWidth) / partOfScreen_NUM;
            return locationX * partOfScreen_WIDTH;
        }

        private double LocationY(int LocationY, int partOfScreen_NUM)
        {
            string clientScreenHeight = this.Size.Height.ToString();
            int partOfScreen_HEIGHT = Convert.ToInt32(clientScreenHeight) / partOfScreen_NUM;
            return LocationY * partOfScreen_HEIGHT;
        }

        private void UserTable_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void UserTable_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }
    }
}
