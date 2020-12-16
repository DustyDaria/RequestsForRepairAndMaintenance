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
    public partial class UserTable : Form
    {
        int mainID = 0;
        //int secondaryID = 0;
        string usersAction = string.Empty;

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

        TextBox textBox_DataForSearch = new System.Windows.Forms.TextBox();

        LinkLabel linkLabel_UserName = new System.Windows.Forms.LinkLabel();

        Label label_Header = new System.Windows.Forms.Label();
        //Label label_AdditionalText = new System.Windows.Forms.Label();

        DataGridView dataGridView_Customer = new System.Windows.Forms.DataGridView();
        DataGridView dataGridView_Executors = new System.Windows.Forms.DataGridView();
        DataGridView dataGridView_All = new System.Windows.Forms.DataGridView();

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

            //
            dataGridView_Customer.Columns.Add("id_user", "ID");
            dataGridView_Customer.Columns.Add("user_login", "Логин");
            dataGridView_Customer.Columns.Add("last_name", "Фамилия");
            dataGridView_Customer.Columns.Add("name", "Имя");
            dataGridView_Customer.Columns.Add("middle_name", "Отчество");
            dataGridView_Customer.Columns.Add("position", "Должность");
            dataGridView_Customer.Columns.Add("phone", "Телефон");
            dataGridView_Customer.Columns.Add("number_of_rooms", "Количество помещений");
            dataGridView_Customer.Columns.Add("number_of_request", "Количество заявок");

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

            }
            else if (usersAction == "Customer")
            {
                this.Text = "Заказчики";
                label_Header.Text = "Заказчики";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

            }
            else if (usersAction == "All")
            {
                this.Text = "Все пользователи";
                label_Header.Text = "Все пользователи";
                linkLabel_UserName.Text = dataBase.GetResult(queryUserLastName_GET) + " "
                    + dataBase.GetResult(queryUserName_GET) + " " + dataBase.GetResult(queryUserMiddleName_GET);

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
