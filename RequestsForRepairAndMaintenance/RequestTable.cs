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
    public partial class RequestTable : Form
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

        DataGridView dataGridView_ActualRequest = new System.Windows.Forms.DataGridView();
        DataGridView dataGridView_ArchiveRequest = new System.Windows.Forms.DataGridView();

        //ComboBox comboBox_SearchCustomer = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_SearchArchiveRequest = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_SearchActualRequest = new System.Windows.Forms.ComboBox();

        DataBase dataBase = new DataBase();


        public RequestTable(int returnID, string action)
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

            //ПОИСК
            comboBox_SearchActualRequest.Font = font_MiddleText;
            comboBox_SearchActualRequest.ForeColor = Color.DimGray;
            comboBox_SearchActualRequest.DropDownStyle = ComboBoxStyle.DropDown;
            //comboBox_SearchAll.TextChanged += new System.EventHandler(comboBox_SearchAll_TextChanged);
            comboBox_SearchActualRequest.Items.AddRange(new string[] { "ID", "Название", "Дата начала", "Дата окончания"
                , "Статус заявки", "Номер помещения", "Категория заявки" });

            comboBox_SearchArchiveRequest.Font = font_MiddleText;
            comboBox_SearchArchiveRequest.ForeColor = Color.DimGray;
            comboBox_SearchArchiveRequest.DropDownStyle = ComboBoxStyle.DropDown;
            //comboBox_SearchAll.TextChanged += new System.EventHandler(comboBox_SearchAll_TextChanged);
            comboBox_SearchArchiveRequest.Items.AddRange(new string[] { "ID", "Название", "Дата начала", "Дата окончания"
                , "Фактическая дата окончания", "Статус заявки", "Номер помещения" , "Категория заявки", "ФИО заказчика"
                , "ФИО исполнителя" });

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

            // ДАННЫЕ ТЕКУЩИХ ЗАЯВОК
            dataGridView_ActualRequest.Columns.Add("id_request", "ID");
            dataGridView_ActualRequest.Columns[0].Width = (int)LocationX(2, 40);
            dataGridView_ActualRequest.Columns.Add("name_request", "Название");
            dataGridView_ActualRequest.Columns[1].Width = (int)LocationX(12, 40);
            dataGridView_ActualRequest.Columns.Add("date_start", "Дата начала");
            dataGridView_ActualRequest.Columns[2].Width = (int)LocationX(6, 40);
            dataGridView_ActualRequest.Columns.Add("date_end", "Дата окончания");
            dataGridView_ActualRequest.Columns[3].Width = (int)LocationX(5, 40);
            dataGridView_ActualRequest.Columns.Add("status_request", "Статус заявки");
            dataGridView_ActualRequest.Columns[4].Width = (int)LocationX(7, 40);
            dataGridView_ActualRequest.Columns.Add("room_number", "Номер помещения");
            dataGridView_ActualRequest.Columns[5].Width = (int)LocationX(5, 40);
            dataGridView_ActualRequest.Columns.Add("category_request", "Категория заявки");
            dataGridView_ActualRequest.Columns[6].Width = (int)LocationX(5, 40);
            dataGridView_ActualRequest.ColumnHeadersDefaultCellStyle.Font = font_MiddleText;
            dataGridView_ActualRequest.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView_ActualRequest.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_ActualRequest.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_ActualRequest.ColumnHeadersHeight = (int)LocationY(2, 20);
            //

            // ДАННЫЕ АРХИВНЫХ ЗАЯВОК
            dataGridView_ArchiveRequest.Columns.Add("id_request", "ID");
            dataGridView_ArchiveRequest.Columns[0].Width = (int)LocationX(2, 40);
            dataGridView_ArchiveRequest.Columns.Add("name_request", "Название");
            dataGridView_ArchiveRequest.Columns[1].Width = (int)LocationX(6, 40);
            dataGridView_ArchiveRequest.Columns.Add("date_start", "Дата начала");
            dataGridView_ArchiveRequest.Columns[2].Width = (int)LocationX(6, 40);
            dataGridView_ArchiveRequest.Columns.Add("date_end", "Дата окончания");
            dataGridView_ArchiveRequest.Columns[3].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("actual_date_end", "Фактическая дата окончания");
            dataGridView_ArchiveRequest.Columns[4].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("status_request", "Статус заявки");
            dataGridView_ArchiveRequest.Columns[5].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("room_number", "Категория заявки");
            dataGridView_ArchiveRequest.Columns[6].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("category_request", "Номер помещения");
            dataGridView_ArchiveRequest.Columns[7].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("fio_customer", "ФИО заказчика");
            dataGridView_ArchiveRequest.Columns[8].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.Columns.Add("fio_executor", "ФИО исполнителя");
            dataGridView_ArchiveRequest.Columns[9].Width = (int)LocationX(5, 40);
            dataGridView_ArchiveRequest.ColumnHeadersDefaultCellStyle.Font = font_MiddleText;
            dataGridView_ArchiveRequest.ColumnHeadersDefaultCellStyle.ForeColor = Color.DimGray;
            dataGridView_ArchiveRequest.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dataGridView_ArchiveRequest.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_ArchiveRequest.ColumnHeadersHeight = (int)LocationY(2, 20);
            //

            string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");


            if (usersAction == "Текущие")
            {
                this.Text = "Просмотр текущих заявок";
                label_Header.Text = "Просмотр текущих заявок";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                LoadDataActualRequest();
            }
            else if (usersAction == "Архивные")
            {
                this.Text = "Просмотр выполненных заявок";
                label_Header.Text = "Просмотр выполненных заявок";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);
                LoadDataArchiveRequest();

            }
        }

        private void LoadDataActualRequest()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request != 'В архиве' ORDER BY id_request;";

            SqlCommand command = new SqlCommand(query, myConnection);
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
            foreach (string[] act in data)
                dataGridView_ActualRequest.Rows.Add(act);
        }

        private void LoadDataArchiveRequest()
        {
            string connectionString = @"Server = DESKTOP-BSEODEL\SQLEXPRESS; DataBase = DB_RegistrationOfRequest; Trusted_Connection = True;";
            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();

            string query = "SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request, room_number FROM Requests WHERE status_request = 'В архиве' ORDER BY id_request;";

            SqlCommand command = new SqlCommand(query, myConnection);
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
            foreach (string[] arch in data)
                dataGridView_ArchiveRequest.Rows.Add(arch);
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
            dataGridView_ActualRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            dataGridView_ActualRequest.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));

            dataGridView_ArchiveRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            dataGridView_ArchiveRequest.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));

            //dataGridView_All.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(5, 20));
            //dataGridView_All.Size = new System.Drawing.Size((int)LocationX(17, 24), (int)LocationY(10, 20));
            //

            //ПОИСК
            btn_UpdateData.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(5, 20));
            btn_UpdateData.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            label_SearchCriteria.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(7, 20));
            label_SearchCriteria.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(1, 20));

            comboBox_SearchActualRequest.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            comboBox_SearchActualRequest.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            comboBox_SearchArchiveRequest.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            comboBox_SearchArchiveRequest.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

            //comboBox_SearchAll.Location = new System.Drawing.Point((int)LocationX(19, 24), (int)LocationY(8, 20));
            //comboBox_SearchAll.Size = new System.Drawing.Size((int)LocationX(4, 24), (int)LocationY(2, 20));

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
            if (usersAction == "Текущие")
            {
                this.Controls.Add(dataGridView_ActualRequest);
                this.Controls.Add(comboBox_SearchActualRequest);
            }
            else if (usersAction == "Архивные")
            {
                this.Controls.Add(dataGridView_ArchiveRequest);
                this.Controls.Add(comboBox_SearchArchiveRequest);
            }
            //
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (usersAction == "Текущие")
            {
                typeSearchTransfer = comboBox_SearchActualRequest.Text;
                stringReaderBoxTransfer = textBox_DataForSearch.Text;
            }
            else if (usersAction == "Архивные")
            {
                typeSearchTransfer = comboBox_SearchArchiveRequest.Text;
                stringReaderBoxTransfer = textBox_DataForSearch.Text;
            }

            ListStatus(typeSearchTransfer, stringReaderBoxTransfer);
        }

        public void ListStatus(string typeSearch, string stringReaderBox)
        {

            if (usersAction == "Текущие")
            {
                dataGridView_ActualRequest.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.
                                       //SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request != 'В архиве' ORDER BY id_request;

                string querySearchID_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE id_request LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchName_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE name_request LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchDateStart_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE date_start LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchDateEnd_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE date_end LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                //string querySearchActualDateEnd_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE actual_date_end LIKE '%"
                  //  + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchStatusRequest_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE status_request LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchRoomNumber_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE room_number LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");
                string querySearchCategoryRequest_GET = string.Format("SELECT id_request, name_request, date_start, date_end, status_request, room_number, category_request FROM Requests WHERE category_request LIKE '%"
                    + stringReaderBox + "%' AND status_request != 'В архиве' ORDER BY id_request;");

                if (typeSearch == "ID")
                {
                    dataBase.Select_7(querySearchID_GET);
                    foreach (string[] s in dataBase.data) // Загрузка данных из нашего буфера.
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Название")
                {
                    dataBase.Select_7(querySearchName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Дата начала")
                {
                    dataBase.Select_7(querySearchDateStart_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Дата окончания")
                {
                    dataBase.Select_7(querySearchDateEnd_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Статус заявки")
                {
                    dataBase.Select_7(querySearchStatusRequest_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Номер помещения")
                {
                    dataBase.Select_7(querySearchStatusRequest_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else if (typeSearch == "Категория заявки")
                {
                    dataBase.Select_7(querySearchCategoryRequest_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ActualRequest.Rows.Add(s);
                }
                else
                {
                    MessageBox.Show("Выберите критерий поиска");
                }
            }
            else if (usersAction == "Архивные")
            {
                dataGridView_ArchiveRequest.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.

                string querySearchID_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE id_request LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchName_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE name_request LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchDateStart_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE date_start LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchDateEnd_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE date_end LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchActualDateEnd_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE actual_date_end LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchStatusRequest_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE status_request LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchRoomNumber_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE room_number LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");
                string querySearchCategoryRequest_GET = string.Format("SELECT id_request, name_request, date_start, date_end, actual_date_end, status_request, category_request , room_number FROM Requests WHERE category_request LIKE '%"
                    + stringReaderBox + "%' AND status_request = 'В архиве' ORDER BY id_request;");

                if (typeSearch == "ID")
                {
                    dataBase.Select_8(querySearchID_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Название")
                {
                    dataBase.Select_8(querySearchName_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Дата начала")
                {
                    dataBase.Select_8(querySearchDateStart_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Дата окончания")
                {
                    dataBase.Select_8(querySearchDateEnd_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Фактическая дата окончания")
                {
                    dataBase.Select_8(querySearchActualDateEnd_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Статус заявки")
                {
                    dataBase.Select_8(querySearchStatusRequest_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Номер помещения")
                {
                    dataBase.Select_8(querySearchRoomNumber_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                }
                else if (typeSearch == "Категория заявки")
                {
                    dataBase.Select_8(querySearchCategoryRequest_GET);
                    foreach (string[] s in dataBase.data)
                        dataGridView_ArchiveRequest.Rows.Add(s);
                    //MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else if (typeSearch == "ФИО заказчика")
                {
                    /*dataBase.Select(querySearchSpecializ);
                    foreach (string[] s in dataBase.data)
                        dataGridViewDoc.Rows.Add(s);*/
                    MessageBox.Show("Приносим свои извинения, поиск по данной категории пока что недоступен.\nСпасибо за понимание");
                }
                else if (typeSearch == "ФИО исполнителя")
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
            
        }

        private void btn_UpdateData_Click(object sender, EventArgs e)
        {
            if (usersAction == "Текущие")
            {
                comboBox_SearchActualRequest.Text = string.Empty;
                textBox_DataForSearch.Text = string.Empty;
                dataGridView_ActualRequest.Rows.Clear(); // Чистка старых  данных.
                dataBase.data.Clear(); // чистка нашего буфера данных.
                LoadDataActualRequest();
            }
            else if (usersAction == "Архивные")
            {
                comboBox_SearchArchiveRequest.Text = string.Empty;
                textBox_DataForSearch.Text = string.Empty;
                dataGridView_ArchiveRequest.Rows.Clear();
                dataBase.data.Clear();
                LoadDataArchiveRequest();
            }
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

        private void linkLabel_UserName_Click(object sender, EventArgs e)
        {
            UsersData usersData = new UsersData(mainID, "Просмотреть", 0);
            this.Close();
            usersData.Show();
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

        private void RequestTable_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void RequestTable_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }
    }
}
