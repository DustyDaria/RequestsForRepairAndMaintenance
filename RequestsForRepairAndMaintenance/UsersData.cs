using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RequestsForRepairAndMaintenance.Properties;

namespace RequestsForRepairAndMaintenance
{
    public partial class UsersData : Form
    {
        int mainID = 0;
        int secondaryID = 0;
        string usersAction = string.Empty;
        bool btn_EditClick_FLAG = false;
        char charToTrim = ' ';

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_SmallHeader = new Font("Arial", 16, FontStyle.Bold);
        Font font_mainText = new Font("Arial", 14, FontStyle.Regular);
        Font font_MiddleText = new Font("Arial", 12, FontStyle.Regular);
        Font font_SmallText = new Font("Arial", 8, FontStyle.Regular);
        Font font_MiddleLinkText = new Font("Arial", 10, FontStyle.Regular);

        GroupBox groupBoxTop = new System.Windows.Forms.GroupBox();

        Button btn_Save = new System.Windows.Forms.Button();
        Button btn_Cancel = new System.Windows.Forms.Button();
        Button btn_Edit = new System.Windows.Forms.Button();
        Button btn_Back = new System.Windows.Forms.Button();
        Button btn_LogOut = new System.Windows.Forms.Button();

        LinkLabel linkLabel_UserName = new System.Windows.Forms.LinkLabel();

        Label label_Header = new System.Windows.Forms.Label();
        Label label_AdditionalText = new System.Windows.Forms.Label();
        Label label_user_login = new System.Windows.Forms.Label();
        Label label_user_password = new System.Windows.Forms.Label();
        Label label_repeat_user_password = new System.Windows.Forms.Label();
        Label label_type_of_account = new System.Windows.Forms.Label();
        Label label_last_name = new System.Windows.Forms.Label();
        Label label_name = new System.Windows.Forms.Label();
        Label label_middle_name = new System.Windows.Forms.Label();
        Label label_position = new System.Windows.Forms.Label();
        Label label_category_executors = new System.Windows.Forms.Label();
        Label label_phone = new System.Windows.Forms.Label();
        Label label_room_number = new System.Windows.Forms.Label();

        TextBox textBox_position = new System.Windows.Forms.TextBox();
        TextBox textBox_user_login = new System.Windows.Forms.TextBox();

        ComboBox comboBox_type_of_account = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_category_executors = new System.Windows.Forms.ComboBox();

        MaskedTextBox maskedTextBox_phone = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_last_name = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_name = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_middle_name = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_user_password = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_repeat_user_password = new System.Windows.Forms.MaskedTextBox();
        MaskedTextBox maskedTextBox_room_number = new System.Windows.Forms.MaskedTextBox();

        DataBase dataBase = new DataBase();

        public UsersData(int returnID, string action, int usersID)
        {
            InitializeComponent();

            mainID = returnID;
            secondaryID = usersID;
            usersAction = action;

            // ФОРМА
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(990, 720);
            this.ResizeRedraw = true;
            this.BackColor = Color.Azure;
            //this.AutoScroll = true;
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

            //ФАМИЛИЯ
            label_last_name.Font = font_MiddleText;
            label_last_name.Text = "*\nФамилия пользователя: ";
            label_last_name.ForeColor = Color.DimGray;
            label_last_name.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_last_name.Font = font_MiddleText;
            maskedTextBox_last_name.Text = string.Empty;
            maskedTextBox_last_name.ForeColor = Color.DimGray;
            maskedTextBox_last_name.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_last_name.Mask = "??????????????????????????????";
            maskedTextBox_last_name.BeepOnError = true;
            maskedTextBox_last_name.Cursor = Cursors.IBeam;
            //

            //ИМЯ
            label_name.Font = font_MiddleText;
            label_name.Text = "*\nИмя пользователя: ";
            label_name.ForeColor = Color.DimGray;
            label_name.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_name.Font = font_MiddleText;
            maskedTextBox_name.Text = string.Empty;
            maskedTextBox_name.ForeColor = Color.DimGray;
            maskedTextBox_name.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_name.Mask = "??????????????????????????????";
            maskedTextBox_name.BeepOnError = true;
            maskedTextBox_name.Cursor = Cursors.IBeam;
            //
            
            //ОТЧЕСТВО
            label_middle_name.Font = font_MiddleText;
            label_middle_name.Text = "\nОтчество пользователя: ";
            label_middle_name.ForeColor = Color.DimGray;
            label_middle_name.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_middle_name.Font = font_MiddleText;
            maskedTextBox_middle_name.Text = string.Empty;
            maskedTextBox_middle_name.ForeColor = Color.DimGray;
            maskedTextBox_middle_name.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_middle_name.Mask = "??????????????????????????????";
            maskedTextBox_middle_name.BeepOnError = true;
            maskedTextBox_middle_name.Cursor = Cursors.IBeam;
            //

            //ДОЛЖНОСТЬ
            label_position.Font = font_MiddleText;
            label_position.Text = "*\nДолжность пользователя: ";
            label_position.ForeColor = Color.DimGray;
            label_position.TextAlign = ContentAlignment.MiddleLeft;

            textBox_position.Font = font_MiddleText;
            textBox_position.Text = string.Empty;
            textBox_position.ForeColor = Color.DimGray;
            textBox_position.TextAlign = HorizontalAlignment.Left;
            textBox_position.Cursor = Cursors.IBeam;
            //

            //ТЕЛЕФОН
            label_phone.Font = font_MiddleText;
            label_phone.Text = "*\nТелефон пользователя: ";
            label_phone.ForeColor = Color.DimGray;
            label_phone.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_phone.Font = font_MiddleText;
            maskedTextBox_phone.ForeColor = Color.DimGray;
            maskedTextBox_phone.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_phone.Mask = "+7(000)00-00-000";
            maskedTextBox_phone.BeepOnError = true;
            maskedTextBox_phone.Cursor = Cursors.IBeam;
            //

            //ЛОГИН
            label_user_login.Font = font_MiddleText;
            label_user_login.Text = "*\nEmail пользователя: ";
            label_user_login.ForeColor = Color.DimGray;
            label_user_login.TextAlign = ContentAlignment.MiddleLeft;

            textBox_user_login.Font = font_MiddleText;
            textBox_user_login.ForeColor = Color.DimGray;
            textBox_user_login.TextAlign = HorizontalAlignment.Left;
            textBox_user_login.Cursor = Cursors.IBeam;
            //

            //ПАРОЛЬ
            label_user_password.Font = font_MiddleText;
            label_user_password.Text = "*\nПароль пользователя: ";
            label_user_password.ForeColor = Color.DimGray;
            label_user_password.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_user_password.Font = font_MiddleText;
            maskedTextBox_user_password.ForeColor = Color.DimGray;
            maskedTextBox_user_password.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_user_password.UseSystemPasswordChar = true;
            maskedTextBox_user_password.Cursor = Cursors.IBeam;

            label_repeat_user_password.Font = font_MiddleText;
            label_repeat_user_password.Text = "*\nПовторите пароль пользователя: ";
            label_repeat_user_password.ForeColor = Color.DimGray;
            label_repeat_user_password.TextAlign = ContentAlignment.MiddleLeft;

            maskedTextBox_repeat_user_password.Font = font_MiddleText;
            maskedTextBox_repeat_user_password.ForeColor = Color.DimGray;
            maskedTextBox_repeat_user_password.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_repeat_user_password.UseSystemPasswordChar = true;
            maskedTextBox_repeat_user_password.Cursor = Cursors.IBeam;
            //

            //ТИП АКК
            label_type_of_account.Font = font_MiddleText;
            label_type_of_account.Text = "*\nТип аккаунта: ";
            label_type_of_account.ForeColor = Color.DimGray;
            label_type_of_account.TextAlign = ContentAlignment.MiddleLeft;

            comboBox_type_of_account.Font = font_MiddleText;
            comboBox_type_of_account.ForeColor = Color.DimGray;
            comboBox_type_of_account.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_type_of_account.TextChanged += new System.EventHandler(comboBox_type_of_account_TextChanged);
            comboBox_type_of_account.Items.AddRange(new string[] { "Системный администратор", "Заказчик", "Исполнитель" });
            //

            // КАТЕГОРИЯ ИСПОЛНИТЕЛЯ
            label_category_executors.Font = font_MiddleText;
            label_category_executors.Text = "*\nКатегория исполнителя: ";
            label_category_executors.ForeColor = Color.DimGray;
            label_category_executors.TextAlign = ContentAlignment.MiddleLeft;
            label_category_executors.Visible = false;

            comboBox_category_executors.Font = font_MiddleText;
            comboBox_category_executors.ForeColor = Color.DimGray;
            comboBox_category_executors.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_category_executors.Items.AddRange(new string[] { "Электрик", "Плотник", "IT-специалист" });
            comboBox_category_executors.Visible = false;
            //

            //НОМЕР КАБИНЕТА
            label_room_number.Font = font_MiddleText;
            label_room_number.Text = "*\nНомер кабинета: ";
            label_room_number.ForeColor = Color.DimGray;
            label_room_number.TextAlign = ContentAlignment.MiddleLeft;
            label_room_number.Visible = false;


            maskedTextBox_room_number.Font = font_MiddleText;
            maskedTextBox_room_number.ForeColor = Color.DimGray;
            maskedTextBox_room_number.TextAlign = HorizontalAlignment.Left;
            maskedTextBox_room_number.Mask = "000";
            maskedTextBox_room_number.BeepOnError = true;
            maskedTextBox_room_number.Cursor = Cursors.IBeam;
            maskedTextBox_room_number.Visible = false;
            //

            //КНОПКИ
            btn_Save.Font = font_mainText;
            btn_Save.Text = "Сохранить";
            btn_Save.ForeColor = Color.DimGray;
            btn_Save.BackColor = Color.LightSteelBlue;
            btn_Save.TextAlign = ContentAlignment.MiddleCenter;
            btn_Save.Cursor = Cursors.Hand;
            btn_Save.Click += new System.EventHandler(btn_Save_Click);

            btn_Cancel.Font = font_mainText;
            btn_Cancel.Text = "Отмена";
            btn_Cancel.ForeColor = Color.DimGray;
            btn_Cancel.BackColor = Color.LightSteelBlue;
            btn_Cancel.TextAlign = ContentAlignment.MiddleCenter;
            btn_Cancel.Cursor = Cursors.Hand;
            btn_Cancel.Click += new System.EventHandler(btn_Cancel_Click);

            btn_Edit.Font = font_mainText;
            btn_Edit.Text = "Редактировать";
            btn_Edit.ForeColor = Color.DimGray;
            btn_Edit.BackColor = Color.LightSteelBlue;
            btn_Edit.TextAlign = ContentAlignment.MiddleCenter;
            btn_Edit.Cursor = Cursors.Hand;
            btn_Edit.Click += new System.EventHandler(btn_Edit_Click);
            //


            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + mainID + "';");
            string queryUserMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Создать")
                {
                    this.Text = "Зарегистрировать нового пользователя";
                    label_Header.Text = "Зарегистрировать нового пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);


                    maskedTextBox_last_name.Enabled = true;
                    maskedTextBox_name.Enabled = true;
                    maskedTextBox_middle_name.Enabled = true;
                    textBox_position.Enabled = true;
                    maskedTextBox_phone.Enabled = true;
                    textBox_user_login.Enabled = true;
                    maskedTextBox_user_password.Enabled = true;
                    maskedTextBox_repeat_user_password.Enabled = true;
                    comboBox_type_of_account.Enabled = true;

                    btn_Edit.Enabled = false;
                    btn_Edit.Visible = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                }
                else if (usersAction == "Редактировать")
                {
                    string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");
                    string queryCheckRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + secondaryID + "';");

                    GetDataToViewAndChange();

                    this.Text = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = true;
                    maskedTextBox_name.Enabled = true;
                    maskedTextBox_middle_name.Enabled = true;
                    textBox_position.Enabled = true;
                    maskedTextBox_phone.Enabled = true;
                    textBox_user_login.Enabled = true;
                    maskedTextBox_user_password.Enabled = true;
                    maskedTextBox_repeat_user_password.Enabled = true;
                    comboBox_type_of_account.Enabled = true;

                    if (dataBase.Check(queryCheckRoomNumber_GET, Convert.ToString(secondaryID)) == true)
                    {
                        label_room_number.Visible = true;
                        maskedTextBox_room_number.Visible = true;
                        maskedTextBox_room_number.Enabled = true;
                    }
                    else
                    {
                        label_room_number.Visible = false;
                        maskedTextBox_room_number.Visible = false;
                        maskedTextBox_room_number.Enabled = false;
                    }

                    if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                    {
                        label_category_executors.Visible = true;
                        comboBox_category_executors.Visible = true;
                        comboBox_category_executors.Enabled = true;
                    }
                    else
                    {
                        label_category_executors.Visible = false;
                        comboBox_category_executors.Visible = false;
                        comboBox_category_executors.Enabled = false;
                    }

                    btn_Edit.Enabled = false;
                    btn_Edit.Visible = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;

                }
                else if (usersAction == "Просмотреть")
                {
                    string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");
                    string queryCheckRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + secondaryID + "';");

                    GetDataToViewAndChange();

                    this.Text = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = false;
                    maskedTextBox_name.Enabled = false;
                    maskedTextBox_middle_name.Enabled = false;
                    textBox_position.Enabled = false;
                    maskedTextBox_phone.Enabled = false;
                    textBox_user_login.Enabled = false;
                    maskedTextBox_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Visible = false;
                    comboBox_type_of_account.Enabled = false;

                    if (dataBase.Check(queryCheckRoomNumber_GET, Convert.ToString(secondaryID)) == true)
                    {
                        label_room_number.Visible = true;
                        maskedTextBox_room_number.Visible = true;
                        maskedTextBox_room_number.Enabled = false;
                    }
                    else
                    {
                        label_room_number.Visible = false;
                        maskedTextBox_room_number.Visible = false;
                        maskedTextBox_room_number.Enabled = false;
                    }

                    if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                    {
                        label_category_executors.Visible = true;
                        comboBox_category_executors.Visible = true;
                        comboBox_category_executors.Enabled = false;
                    }
                    else
                    {
                        label_category_executors.Visible = false;
                        comboBox_category_executors.Visible = false;
                        comboBox_category_executors.Enabled = false;
                    }

                    btn_Edit.Enabled = true;
                    btn_Edit.Visible = true;

                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (usersAction == "Редактировать")
                {
                    GetDataToViewAndChange();

                    this.Text = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = true;
                    maskedTextBox_name.Enabled = true;
                    maskedTextBox_middle_name.Enabled = true;
                    textBox_position.Enabled = true;
                    maskedTextBox_phone.Enabled = true;
                    textBox_user_login.Enabled = true;
                    maskedTextBox_user_password.Enabled = true;
                    maskedTextBox_repeat_user_password.Enabled = true;
                    comboBox_type_of_account.Enabled = false;
                    label_room_number.Visible = true;
                    maskedTextBox_room_number.Visible = true;
                    maskedTextBox_room_number.Enabled = true;
                    label_category_executors.Visible = false;
                    comboBox_category_executors.Visible = false;
                    comboBox_category_executors.Enabled = false;
                   
                    btn_Edit.Enabled = false;
                    btn_Edit.Visible = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                }
                else if (usersAction == "Просмотреть")
                {
                    GetDataToViewAndChange();

                    this.Text = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = false;
                    maskedTextBox_name.Enabled = false;
                    maskedTextBox_middle_name.Enabled = false;
                    textBox_position.Enabled = false;
                    maskedTextBox_phone.Enabled = false;
                    textBox_user_login.Enabled = false;
                    maskedTextBox_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Visible = false;
                    comboBox_type_of_account.Enabled = false;
                    label_room_number.Visible = true;
                    maskedTextBox_room_number.Visible = true;
                    maskedTextBox_room_number.Enabled = false;
                    label_category_executors.Visible = false;
                    comboBox_category_executors.Visible = false;
                    comboBox_category_executors.Enabled = false;
                    
                    btn_Edit.Enabled = true;
                    btn_Edit.Visible = true;

                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {

                if (usersAction == "Редактировать")
                {
                    GetDataToViewAndChange();

                    this.Text = "Редактировать данные пользователя";
                    label_Header.Text = "Редактировать данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = true;
                    maskedTextBox_name.Enabled = true;
                    maskedTextBox_middle_name.Enabled = true;
                    textBox_position.Enabled = true;
                    maskedTextBox_phone.Enabled = true;
                    textBox_user_login.Enabled = true;
                    maskedTextBox_user_password.Enabled = true;
                    maskedTextBox_repeat_user_password.Enabled = true;
                    comboBox_type_of_account.Enabled = false;
                    label_room_number.Visible = false;
                    maskedTextBox_room_number.Visible = false;
                    maskedTextBox_room_number.Enabled = false;
                    label_category_executors.Visible = true;
                    comboBox_category_executors.Visible = true;
                    comboBox_category_executors.Enabled = false;

                    btn_Edit.Enabled = false;
                    btn_Edit.Visible = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;

                }
                else if (usersAction == "Просмотреть")
                {
                    GetDataToViewAndChange();

                    this.Text = "Просмотреть данные пользователя";
                    label_Header.Text = "Просмотреть данные пользователя";
                    linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

                    maskedTextBox_last_name.Enabled = false;
                    maskedTextBox_name.Enabled = false;
                    maskedTextBox_middle_name.Enabled = false;
                    textBox_position.Enabled = false;
                    maskedTextBox_phone.Enabled = false;
                    textBox_user_login.Enabled = false;
                    maskedTextBox_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Enabled = false;
                    maskedTextBox_repeat_user_password.Visible = false;
                    comboBox_type_of_account.Enabled = false;
                    label_room_number.Visible = false;
                    maskedTextBox_room_number.Visible = false;
                    maskedTextBox_room_number.Enabled = false;
                    label_category_executors.Visible = true;
                    comboBox_category_executors.Visible = true;
                    comboBox_category_executors.Enabled = false;

                    btn_Edit.Enabled = true;
                    btn_Edit.Visible = true;
                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = true;
                }
            }

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

            //1 РЯД
            label_last_name.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(6, 22));
            label_last_name.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_last_name.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(7, 22));
            maskedTextBox_last_name.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_name.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(8, 22));
            label_name.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_name.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(9, 22));
            maskedTextBox_name.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_middle_name.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(10, 22));
            label_middle_name.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_middle_name.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(11, 22));
            maskedTextBox_middle_name.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_position.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(12, 22));
            label_position.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            textBox_position.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(13, 22));
            textBox_position.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_phone.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(14, 22));
            label_phone.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_phone.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(15, 22));
            maskedTextBox_phone.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            btn_Edit.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(17, 22));
            btn_Edit.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));
            //

            //2 РЯД
            label_user_login.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(6, 22));
            label_user_login.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            textBox_user_login.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(7, 22));
            textBox_user_login.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_user_password.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(8, 22));
            label_user_password.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_user_password.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(9, 22));
            maskedTextBox_user_password.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_repeat_user_password.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(10, 22));
            label_repeat_user_password.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_repeat_user_password.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(11, 22));
            maskedTextBox_repeat_user_password.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_type_of_account.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(12, 22));
            label_type_of_account.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            comboBox_type_of_account.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(13, 22));
            comboBox_type_of_account.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_category_executors.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(14, 22));
            label_category_executors.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            comboBox_category_executors.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(15, 22));
            comboBox_category_executors.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            label_room_number.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(14, 22));
            label_room_number.Size = new System.Drawing.Size((int)LocationX(7, 40), (int)LocationY(2, 22));

            maskedTextBox_room_number.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(15, 22));
            maskedTextBox_room_number.Size = new System.Drawing.Size((int)LocationX(6, 40), (int)LocationY(2, 22));

            btn_Save.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(17, 22));
            btn_Save.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));

            btn_Cancel.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(17, 22));
            btn_Cancel.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));
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

            //1 РЯД
            this.Controls.Add(label_name);
            this.Controls.Add(label_last_name);
            this.Controls.Add(label_middle_name);
            this.Controls.Add(label_position);
            this.Controls.Add(label_phone);

            this.Controls.Add(maskedTextBox_name);
            this.Controls.Add(maskedTextBox_last_name);
            this.Controls.Add(maskedTextBox_middle_name);
            this.Controls.Add(textBox_position);
            this.Controls.Add(maskedTextBox_phone);

            this.Controls.Add(btn_Edit);
            //

            //2 РЯД
            this.Controls.Add(label_user_login);
            this.Controls.Add(label_user_password);
            this.Controls.Add(label_repeat_user_password);
            this.Controls.Add(label_type_of_account);
            this.Controls.Add(label_category_executors);
            this.Controls.Add(label_room_number);

            this.Controls.Add(textBox_user_login);
            this.Controls.Add(maskedTextBox_user_password);
            this.Controls.Add(maskedTextBox_repeat_user_password);
            this.Controls.Add(comboBox_type_of_account);
            this.Controls.Add(comboBox_category_executors);
            this.Controls.Add(maskedTextBox_room_number);

            this.Controls.Add(btn_Save);
            this.Controls.Add(btn_Cancel);
            //
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


        private void btn_Save_Click(object sender, EventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Создать")
                {
                    //INSERT
                    if (maskedTextBox_last_name.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите фамилию пользователя!");
                    }
                    else if (maskedTextBox_name.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите имя пользователя!");
                    }
                    else if (textBox_position.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите должность пользователя!");
                    }
                    else if (!maskedTextBox_phone.MaskCompleted)
                    {
                        MessageBox.Show("Пожалуйста, введите телефон пользователя!");
                    }
                    else if (textBox_user_login.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите Email пользователя!");
                    }
                    else if (maskedTextBox_user_password.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите пароль пользователя!");
                    }
                    else if (maskedTextBox_user_password.Text != maskedTextBox_repeat_user_password.Text)
                    {
                        MessageBox.Show("Введенные пароли не совпадают!");
                    }
                    else if (comboBox_type_of_account.Text == string.Empty)//нужна проверка от левых данных
                    {//нужна проверка от левых данных
                        MessageBox.Show("Пожалуйста, выберите тип аккаунта!");
                    }
                    else if ((comboBox_category_executors.Text == string.Empty) && (comboBox_type_of_account.Text == "Исполнитель"))
                    {//нужна проверка от левых данных
                        MessageBox.Show("Пожалуйста, выберите категорию исполнителя!");
                    }
                    else
                    {
                        string queryCheckCountAdm_GET = string.Format("SELECT COUNT(id_user) FROM Users WHERE type_of_account = 'Системный администратор';");
                        
                        try
                        {
                            if((dataBase.GetID(queryCheckCountAdm_GET) >= 3) && (comboBox_type_of_account.Text == "Системный администратор"))
                            {
                                MessageBox.Show("ОШИБКА!\nВы не можете зарегистрировать в системе более 3 системных администраторов!");
                            }
                            else 
                            {
                                string queryUsersData_SET = string.Format("INSERT INTO Users (user_login, user_password, type_of_account, last_name, name, middle_name, position, category_executors, phone) VALUES ('"
                                    + textBox_user_login.Text.Trim(charToTrim) + "', '" + maskedTextBox_user_password.Text.Trim(charToTrim) + "', '" 
                                    + comboBox_type_of_account.Text.Trim(charToTrim) + "', '" + maskedTextBox_last_name.Text.Trim(charToTrim) + "', '" 
                                    + maskedTextBox_name.Text.Trim(charToTrim) + "', '" + maskedTextBox_middle_name.Text.Trim(charToTrim) + "', '"
                                    + textBox_position.Text.Trim(charToTrim) + "', '" + comboBox_category_executors.Text.Trim(charToTrim) + "', '" 
                                    + maskedTextBox_phone.Text.Trim(charToTrim) + "');");

                                dataBase.Insert(queryUsersData_SET);

                                if (comboBox_type_of_account.Text == "Заказчик")
                                {
                                    string queryUserID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + textBox_user_login.Text.Trim(charToTrim) 
                                        + "' AND user_password = '" + maskedTextBox_user_password.Text.Trim(charToTrim) + "' AND type_of_account = '" 
                                        + comboBox_type_of_account.Text.Trim(charToTrim) + "' AND last_name = '" + maskedTextBox_last_name.Text.Trim(charToTrim) 
                                        + "' AND name = '" + maskedTextBox_name.Text.Trim(charToTrim) + "' AND middle_name = '" + maskedTextBox_middle_name.Text.Trim(charToTrim)
                                        + "' AND position = '" + textBox_position.Text.Trim(charToTrim) + "' AND category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) 
                                        + "' AND phone = '" + maskedTextBox_phone.Text.Trim(charToTrim) + "';");

                                    string queryU_RD_Rooms_SET = string.Format("INSERT INTO U_RD_Rooms (userID, roomNUMBER) VALUES ('" + dataBase.GetID(queryUserID_GET) + "', '"
                                    + maskedTextBox_room_number.Text.Trim(charToTrim) + "');");

                                    dataBase.Insert(queryU_RD_Rooms_SET);
                                }
                                MessageBox.Show("Пользователь был успешно зарегистрирован!");

                                Menu_Users menu_Users = new Menu_Users(mainID);
                                this.Close();
                                menu_Users.Show();
                            }
                            
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                        }
                        
                        
                    }

                }
                else if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    //UPDATE
                    try
                    {
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + maskedTextBox_user_password.Text.Trim(charToTrim) + "', type_of_account = '" 
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + maskedTextBox_last_name.Text.Trim(charToTrim) + "', name = '" 
                        + maskedTextBox_name.Text.Trim(charToTrim) + "', middle_name = '" + maskedTextBox_middle_name.Text.Trim(charToTrim) + "', position = '" 
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '" 
                        + maskedTextBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");

                        dataBase.Update(queryUpdateUserData_SET);

                        MessageBox.Show("Данные пользователя были успешно обновлены!\n");
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    try
                    {
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + maskedTextBox_user_password.Text.Trim(charToTrim) + "', type_of_account = '"
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + maskedTextBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        + maskedTextBox_name.Text.Trim(charToTrim) + "', middle_name = '" + maskedTextBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
                        + maskedTextBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");

                        dataBase.Update(queryUpdateUserData_SET);

                        MessageBox.Show("Ваши данные были успешно обновлены!\n");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }

                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if ((usersAction == "Редактировать") || (btn_EditClick_FLAG == true))
                {
                    try
                    {
                        string queryUpdateUserData_SET = string.Format("UPDATE Users SET user_login = '" + textBox_user_login.Text.Trim(charToTrim)
                        + "', user_password = '" + maskedTextBox_user_password.Text.Trim(charToTrim) + "', type_of_account = '"
                        + comboBox_type_of_account.Text.Trim(charToTrim) + "', last_name = '" + maskedTextBox_last_name.Text.Trim(charToTrim) + "', name = '"
                        + maskedTextBox_name.Text.Trim(charToTrim) + "', middle_name = '" + maskedTextBox_middle_name.Text.Trim(charToTrim) + "', position = '"
                        + textBox_position.Text.Trim(charToTrim) + "', category_executors = '" + comboBox_category_executors.Text.Trim(charToTrim) + "', phone = '"
                        + maskedTextBox_phone.Text.Trim(charToTrim) + "' WHERE id_user = '" + secondaryID + "';");

                        dataBase.Update(queryUpdateUserData_SET);

                        MessageBox.Show("Ваши данные были успешно обновлены!\n");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Menu_Users menu_Users = new Menu_Users(mainID);
            this.Close();
            menu_Users.Show();
        }

        private void comboBox_type_of_account_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox_type_of_account.Text) == "Исполнитель")
            {
                label_category_executors.Visible = true;
                comboBox_category_executors.Visible = true;
                comboBox_category_executors.Enabled = true;
            }
            else if (Convert.ToString(comboBox_type_of_account.Text) == "Заказчик")
            {
                label_room_number.Visible = true;
                maskedTextBox_room_number.Visible = true;
                maskedTextBox_room_number.Enabled = true;
            }
            else
            {
                label_category_executors.Visible = false;
                label_room_number.Visible = false;
                comboBox_category_executors.Visible = false;
                comboBox_category_executors.Enabled = false;
                maskedTextBox_room_number.Visible = false;
                maskedTextBox_room_number.Enabled = false;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            btn_EditClick_FLAG = true;

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                string queryCheckCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "';");

                GetDataToViewAndChange();

                label_Header.Text = "Редактировать данные пользователя";

                maskedTextBox_last_name.Enabled = true;
                maskedTextBox_name.Enabled = true;
                maskedTextBox_middle_name.Enabled = true;
                textBox_position.Enabled = true;
                maskedTextBox_phone.Enabled = true;
                textBox_user_login.Enabled = true;
                maskedTextBox_user_password.Enabled = true;
                maskedTextBox_repeat_user_password.Enabled = true;
                comboBox_type_of_account.Enabled = true;

                if (dataBase.Check(queryCheckCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
                {
                    comboBox_category_executors.Visible = true;
                    comboBox_category_executors.Enabled = true;
                }
                else
                {
                    comboBox_category_executors.Visible = false;
                    comboBox_category_executors.Enabled = false;
                }

                btn_Edit.Enabled = false;
                btn_Edit.Visible = false;
                btn_Save.Enabled = true;
                btn_Cancel.Enabled = true;
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                GetDataToViewAndChange();

                label_Header.Text = "Редактировать данные пользователя";

                maskedTextBox_last_name.Enabled = true;
                maskedTextBox_name.Enabled = true;
                maskedTextBox_middle_name.Enabled = true;
                textBox_position.Enabled = true;
                maskedTextBox_phone.Enabled = true;
                textBox_user_login.Enabled = true;
                maskedTextBox_user_password.Enabled = true;
                maskedTextBox_repeat_user_password.Enabled = true;
                comboBox_type_of_account.Enabled = true;
                comboBox_category_executors.Visible = false;
                comboBox_category_executors.Enabled = false;

                btn_Edit.Enabled = false;
                btn_Edit.Visible = false;
                btn_Save.Enabled = true;
                btn_Cancel.Enabled = true;
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                GetDataToViewAndChange();

                label_Header.Text = "Редактировать данные пользователя";

                maskedTextBox_last_name.Enabled = true;
                maskedTextBox_name.Enabled = true;
                maskedTextBox_middle_name.Enabled = true;
                textBox_position.Enabled = true;
                maskedTextBox_phone.Enabled = true;
                textBox_user_login.Enabled = true;
                maskedTextBox_user_password.Enabled = true;
                maskedTextBox_repeat_user_password.Enabled = true;
                comboBox_type_of_account.Enabled = true;
                comboBox_category_executors.Visible = true;
                comboBox_category_executors.Enabled = true;

                btn_Edit.Enabled = false;
                btn_Edit.Visible = false;
                btn_Save.Enabled = true;
                btn_Cancel.Enabled = true;
            }
        }

        private void GetDataToViewAndChange()
        {
            string queryLastName_GET = string.Format("SELECT last_name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryName_GET = string.Format("SELECT name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryMiddleName_GET = string.Format("SELECT middle_name FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryPosition_GET = string.Format("SELECT position FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryPhone_GET = string.Format("SELECT phone FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryUserLogin_GET = string.Format("SELECT user_login FROM Users WHERE id_user = '" + secondaryID + "';");
            string queryUserPassword_GET = string.Format("SELECT user_password FROM Users WHERE id_user = '" + secondaryID + "'; ");
            string queryTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + secondaryID + "'; ");
            string queryCategoryExecutors_GET = string.Format("SELECT category_executors FROM Users WHERE id_user = '" + secondaryID + "'; ");

            maskedTextBox_last_name.Text = dataBase.GetResult(queryLastName_GET);
            maskedTextBox_name.Text = dataBase.GetResult(queryName_GET);

            if (dataBase.Check(queryMiddleName_GET, Convert.ToString(secondaryID)) == true)
            {
                maskedTextBox_middle_name.Text = dataBase.GetResult(queryMiddleName_GET);
            }
            else
            {
                maskedTextBox_middle_name.Text = string.Empty;
            }

            textBox_position.Text = dataBase.GetResult(queryPosition_GET);
            maskedTextBox_phone.Text = dataBase.GetResult(queryPhone_GET);
            textBox_user_login.Text = dataBase.GetResult(queryUserLogin_GET);
            maskedTextBox_user_password.Text = dataBase.GetResult(queryUserPassword_GET);
            comboBox_type_of_account.Text = dataBase.GetResult(queryTypeOfAccount_GET);

            if (dataBase.Check(queryCategoryExecutors_GET, Convert.ToString(secondaryID)) == true)
            {
                comboBox_category_executors.Text = dataBase.GetResult(queryCategoryExecutors_GET);
            }
            else
            {
                comboBox_category_executors.Text = string.Empty;
            }

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

        private void UsersData_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void UsersData_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }
    }
}
