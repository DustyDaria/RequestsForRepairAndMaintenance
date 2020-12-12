using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestsForRepairAndMaintenance
{
    public partial class Menu_Users : Form /// Эта форма будет шаблонным меню
    {
        int mainID = 0;


        /* МЕНЮ АДМИНИСТРАТОРА
         * 
         * Пользователи ("Все пользователи")
         * Заказчики ("Заказчики")
         * Исполнители ("Исполнители")
         * Регистрация нового пользователя ("Зарегистрировать..")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Просмотр текущих заявок ("Текущие заявки")
         * Просмотр выполненных заявок ("Архивные заявки")
         * Создание отчёта ("Создать отчёт")
         */

        /* МЕНЮ ЗАКАЗЧИКА
         * 
         * Создание новой заявки ("Создать новую заявку")
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */

        /* МЕНЮ ИСПОЛНПИТЕЛЯ
         * 
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_SmallHeader = new Font("Arial", 16, FontStyle.Bold);
        Font font_MainText = new Font("Arial", 14, FontStyle.Regular);

        GroupBox groupBoxTop = new System.Windows.Forms.GroupBox();

        Button btn_AllUsers = new System.Windows.Forms.Button();
        Button btn_CustomerUsers = new System.Windows.Forms.Button();
        Button btn_ExecutorsUsers = new System.Windows.Forms.Button();
        Button btn_RegistrationNewUser = new System.Windows.Forms.Button();
        Button btn_CreateNewRequest = new System.Windows.Forms.Button();
        Button btn_MyRequest = new System.Windows.Forms.Button();
        Button btn_MyArchivedRequest = new System.Windows.Forms.Button();
        Button btn_EditPersonalData = new System.Windows.Forms.Button();
        Button btn_ReportGeneration = new System.Windows.Forms.Button();

        Label label_HeaderMenu = new System.Windows.Forms.Label();

        DataBase dataBase = new DataBase();

        //string typeOfAccount = string.Empty;

        public Menu_Users(int ID)
        {
            InitializeComponent();

            mainID = ID;

            /*string queryCheckTypeOfAccount_GET_Test = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            mainID = ID;
            //usersAction = action;
            //requestID = requestID_GET;
            typeOfAccount = dataBase.getResultTest(queryCheckTypeOfAccount_GET_Test);
            label2.Text = "id users: " + mainID;
            label1.Text = "тип акк: " + typeOfAccount;*/

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(800, 600);
            this.ResizeRedraw = true;
            this.BackColor = Color.Azure;

            groupBoxTop.Text = "Учет заявок на техническое обслуживание и ремонт (ТОиР)";
            groupBoxTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            groupBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            groupBoxTop.BackColor = Color.SteelBlue;
            groupBoxTop.ForeColor = Color.Azure;
            groupBoxTop.Font = font_Header;

            label_HeaderMenu.Font = font_SmallHeader;
            label_HeaderMenu.ForeColor = Color.MidnightBlue;
            label_HeaderMenu.TextAlign = ContentAlignment.MiddleCenter;

            btn_CreateNewRequest.Text = "Создать новую заявку";
            btn_CreateNewRequest.Font = font_MainText;
            btn_CreateNewRequest.ForeColor = Color.DimGray;
            btn_CreateNewRequest.BackColor = Color.LightSteelBlue;
            btn_CreateNewRequest.TextAlign = ContentAlignment.MiddleCenter;
            btn_CreateNewRequest.Click += new System.EventHandler(btn_CreateNewRequest_Click);

            btn_RegistrationNewUser.Text = "Зарегистрировать..";
            btn_RegistrationNewUser.Font = font_MainText;
            btn_RegistrationNewUser.ForeColor = Color.DimGray;
            btn_RegistrationNewUser.BackColor = Color.LightSteelBlue;
            btn_RegistrationNewUser.TextAlign = ContentAlignment.MiddleCenter;
            btn_RegistrationNewUser.Click += new System.EventHandler(btn_RegistrationNewUser_Click);

            btn_ExecutorsUsers.Text = "Исполнители";
            btn_ExecutorsUsers.Font = font_MainText;
            btn_ExecutorsUsers.ForeColor = Color.DimGray;
            btn_ExecutorsUsers.BackColor = Color.LightSteelBlue;
            btn_ExecutorsUsers.TextAlign = ContentAlignment.MiddleCenter;
            btn_ExecutorsUsers.Click += new System.EventHandler(btn_ExecutorsUsers_Click);

            btn_CustomerUsers.Text = "Заказчики";
            btn_CustomerUsers.Font = font_MainText;
            btn_CustomerUsers.ForeColor = Color.DimGray;
            btn_CustomerUsers.BackColor = Color.LightSteelBlue;
            btn_CustomerUsers.TextAlign = ContentAlignment.MiddleCenter;
            btn_CustomerUsers.Click += new System.EventHandler(btn_CustomerUsers_Click);

            btn_AllUsers.Text = "Все пользователи";
            btn_AllUsers.Font = font_MainText;
            btn_AllUsers.ForeColor = Color.DimGray;
            btn_AllUsers.BackColor = Color.LightSteelBlue;
            btn_AllUsers.TextAlign = ContentAlignment.MiddleCenter;
            btn_AllUsers.Click += new System.EventHandler(btn_AllUsers_Click);

            btn_MyRequest.Font = font_MainText;
            btn_MyRequest.ForeColor = Color.DimGray;
            btn_MyRequest.BackColor = Color.LightSteelBlue;
            btn_MyRequest.TextAlign = ContentAlignment.MiddleCenter;
            btn_MyRequest.Click += new System.EventHandler(btn_MyRequest_Click);

            btn_MyArchivedRequest.Font = font_MainText;
            btn_MyArchivedRequest.ForeColor = Color.DimGray;
            btn_MyArchivedRequest.BackColor = Color.LightSteelBlue;
            btn_MyArchivedRequest.TextAlign = ContentAlignment.MiddleCenter;
            btn_MyArchivedRequest.Click += new System.EventHandler(btn_MyArchivedRequest_Click);

            btn_EditPersonalData.Text = "Редактировать личный профиль";
            btn_EditPersonalData.Font = font_MainText;
            btn_EditPersonalData.ForeColor = Color.DimGray;
            btn_EditPersonalData.BackColor = Color.LightSteelBlue;
            btn_EditPersonalData.TextAlign = ContentAlignment.MiddleCenter;
            btn_EditPersonalData.Click += new System.EventHandler(btn_EditPersonalData_Click);

            btn_ReportGeneration.Text = "Создать отчёт";
            btn_ReportGeneration.Font = font_MainText;
            btn_ReportGeneration.ForeColor = Color.DimGray;
            btn_ReportGeneration.BackColor = Color.LightSteelBlue;
            btn_ReportGeneration.TextAlign = ContentAlignment.MiddleCenter;
            btn_ReportGeneration.Click += new System.EventHandler(btn_ReportGeneration_Click);

            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                this.Text = "Меню системного администратора";
                label_HeaderMenu.Text = "Меню системного администратора";
                btn_MyRequest.Text = "Текущие заявки";
                btn_MyArchivedRequest.Text = "Архивные заявки";
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                this.Text = "Меню заказчика";
                label_HeaderMenu.Text = "Меню заказчика";
                btn_MyRequest.Text = "Мои заявки";
                btn_MyArchivedRequest.Text = "Мои архивные заявки";
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                this.Text = "Меню исполнителя";
                label_HeaderMenu.Text = "Меню исполнителя";
                btn_MyRequest.Text = "Мои заявки";
                btn_MyArchivedRequest.Text = "Мои архивные заявки";
            }

            SizeLocation_New();
            ControlsAdd();
        }

        private void btn_CreateNewRequest_Click(object sender, EventArgs e)
        {

            UsersRequest usersRequest = new UsersRequest(mainID, "Создать", 0);
            this.Close();
            usersRequest.Show();
        }

        private void btn_RegistrationNewUser_Click(object sender, EventArgs e)
        {
            UsersData usersData = new UsersData(mainID, "Создать", 0);
            this.Close();
            usersData.Show();
        }

        private void btn_ExecutorsUsers_Click(object sender, EventArgs e)
        {

        }

        private void btn_CustomerUsers_Click(object sender, EventArgs e)
        {

        }

        private void btn_AllUsers_Click(object sender, EventArgs e)
        {

        }

        private void btn_MyRequest_Click(object sender, EventArgs e)
        {

        }

        private void btn_MyArchivedRequest_Click(object sender, EventArgs e)
        {

        }

        private void btn_EditPersonalData_Click(object sender, EventArgs e)
        {

        }

        private void btn_ReportGeneration_Click(object sender, EventArgs e)
        {

        }

        /* МЕНЮ АДМИНИСТРАТОРА
         * 
         * Пользователи ("Все пользователи")
         * Заказчики ("Заказчики")
         * Исполнители ("Исполнители")
         * Регистрация нового пользователя ("Зарегистрировать..")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Просмотр текущих заявок ("Текущие заявки")
         * Просмотр выполненных заявок ("Архивные заявки")
         * Создание отчёта ("Создать отчёт")
         */

        /* МЕНЮ ЗАКАЗЧИКА
         * 
         * Создание новой заявки ("Создать новую заявку")
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */

        /* МЕНЮ ИСПОЛНПИТЕЛЯ
         * 
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */

        private void SizeLocation_New()
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            groupBoxTop.Size = new Size((int)LocationX(20, 20), (int)LocationY(3, 20));

            label_HeaderMenu.Location = new System.Drawing.Point((int)LocationX(9, 24), (int)LocationY(6, 20));
            label_HeaderMenu.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                btn_AllUsers.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(6, 20));
                btn_AllUsers.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_EditPersonalData.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(6, 20));
                btn_EditPersonalData.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_CustomerUsers.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(10, 20));
                btn_CustomerUsers.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_ExecutorsUsers.Location = new System.Drawing.Point((int)LocationX(9, 24), (int)LocationY(10, 20));
                btn_ExecutorsUsers.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_RegistrationNewUser.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(10, 20));
                btn_RegistrationNewUser.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(14, 20));
                btn_MyRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyArchivedRequest.Location = new System.Drawing.Point((int)LocationX(9, 24), (int)LocationY(14, 20));
                btn_MyArchivedRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_ReportGeneration.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(14, 20));
                btn_ReportGeneration.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));
                

            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                btn_CreateNewRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(6, 20));
                btn_CreateNewRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_EditPersonalData.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(6, 20));
                btn_EditPersonalData.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(10, 20));
                btn_MyRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyArchivedRequest.Location = new System.Drawing.Point((int)LocationX(9, 24), (int)LocationY(10, 20));
                btn_MyArchivedRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_ReportGeneration.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(10, 20));
                btn_ReportGeneration.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                btn_EditPersonalData.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(6, 20));
                btn_EditPersonalData.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyRequest.Location = new System.Drawing.Point((int)LocationX(1, 24), (int)LocationY(10, 20));
                btn_MyRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_MyArchivedRequest.Location = new System.Drawing.Point((int)LocationX(9, 24), (int)LocationY(10, 20));
                btn_MyArchivedRequest.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));

                btn_ReportGeneration.Location = new System.Drawing.Point((int)LocationX(17, 24), (int)LocationY(10, 20));
                btn_ReportGeneration.Size = new System.Drawing.Size((int)LocationX(6, 24), (int)LocationY(3, 20));
            }
        }

        private void ControlsAdd()
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            this.Controls.Add(groupBoxTop);
            this.Controls.Add(label_HeaderMenu);
            this.Controls.Add(btn_MyRequest);
            this.Controls.Add(btn_MyArchivedRequest);
            this.Controls.Add(btn_ReportGeneration);

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                this.Controls.Add(btn_AllUsers);
                this.Controls.Add(btn_RegistrationNewUser);
                this.Controls.Add(btn_CustomerUsers);
                this.Controls.Add(btn_ExecutorsUsers);
                this.Controls.Add(btn_EditPersonalData);
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                this.Controls.Add(btn_CreateNewRequest);
                this.Controls.Add(btn_EditPersonalData);
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                this.Controls.Add(btn_EditPersonalData);
            }
        }

        private double LocationX(int locationX, int partOfScreen_NUM)
        {
            string clientScreenWidth = this.Size.Width.ToString();
            double partOfScreen_WIDTH = Convert.ToInt32(clientScreenWidth) / partOfScreen_NUM;
            return locationX * partOfScreen_WIDTH;
        }

        private double LocationY(int LocationY, int partOfScreen_Num)
        {
            string clientScreenHeight = this.Size.Height.ToString();
            int partOfScreen_HEIGHT = Convert.ToInt32(clientScreenHeight) / partOfScreen_Num;
            return LocationY * partOfScreen_HEIGHT;
        }

        private void Menu_Executors_Load(object sender, EventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Close();
        }

        private void Menu_Executors_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void Menu_Executors_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }
    }
}
