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
    public partial class Authorization_TypeOfAccount : Form
    {
        string userEmail = string.Empty;
        string userPassword = string.Empty;
        int userID = 0;

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_MainText = new Font("Arial", 14, FontStyle.Regular);

        Button btn_Administrator = new System.Windows.Forms.Button();
        Button btn_Executors = new System.Windows.Forms.Button();
        Button btn_Customers = new System.Windows.Forms.Button();

        Label label_Ask = new System.Windows.Forms.Label();

        DataBase dataBase = new DataBase();

        string queryCheckUsersData = string.Empty;
        string queryUsersID_GET = string.Empty;

        public Authorization_TypeOfAccount(string Email, string Password)
        {
            InitializeComponent();

            userEmail = Email;
            userPassword = Password;

            this.Size = new Size(600, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = "Тип аккаунта";

            label_Ask.Text = "Под каким аккаунтом вы хотите зайти?";
            label_Ask.Font = font_MainText;
            label_Ask.ForeColor = Color.DimGray;
            label_Ask.TextAlign = ContentAlignment.MiddleLeft;

            btn_Administrator.Text = "Системный администратор";
            btn_Administrator.Font = font_MainText;
            btn_Administrator.ForeColor = Color.DimGray;
            btn_Administrator.BackColor = Color.LightSteelBlue;
            btn_Administrator.TextAlign = ContentAlignment.MiddleCenter;
            btn_Administrator.Click += new System.EventHandler(btn_Administrator_Click);

            btn_Customers.Text = "Заказчик";
            btn_Customers.Font = font_MainText;
            btn_Customers.ForeColor = Color.DimGray;
            btn_Customers.BackColor = Color.LightSteelBlue;
            btn_Customers.TextAlign = ContentAlignment.MiddleCenter;
            btn_Customers.Click += new System.EventHandler(btn_Customers_Click);

            btn_Executors.Text = "Исполнитель";
            btn_Executors.Font = font_MainText;
            btn_Executors.ForeColor = Color.DimGray;
            btn_Executors.BackColor = Color.LightSteelBlue;
            btn_Executors.TextAlign = ContentAlignment.MiddleCenter;
            btn_Executors.Click += new System.EventHandler(btn_Executors_Click);

            SizeLocation_New();
            ControlsAdd();

            queryCheckUsersData = string.Format("SELECT type_of_account FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");
            queryUsersID_GET = string.Format("SELECT id_user FROM Users WHERE user_login = '" + userEmail + "' AND user_password = '" + userPassword + "';");

        }

        public void SizeLocation_New()
        {
            label_Ask.Location = new System.Drawing.Point((int)LocationX(5, 20), (int)LocationY(1, 20));
            label_Ask.Size = new System.Drawing.Size((int)LocationX(15, 20), (int)LocationY(2, 20));

            btn_Administrator.Location = new System.Drawing.Point((int)LocationX(7, 20), (int)LocationY(4, 20));
            btn_Administrator.Size = new System.Drawing.Size((int)LocationX(6, 20), (int)LocationY(3, 20));

            btn_Customers.Location = new System.Drawing.Point((int)LocationX(7, 20), (int)LocationY(8, 20));
            btn_Customers.Size = new System.Drawing.Size((int)LocationX(6, 20), (int)LocationY(3, 20));

            btn_Executors.Location = new System.Drawing.Point((int)LocationX(7, 20), (int)LocationY(12, 20));
            btn_Executors.Size = new System.Drawing.Size((int)LocationX(6, 20), (int)LocationY(3, 20));
        }

        public void ControlsAdd()
        {
            this.Controls.Add(label_Ask);
            this.Controls.Add(btn_Administrator);
            this.Controls.Add(btn_Customers);
            this.Controls.Add(btn_Executors);
        }

        private void btn_Administrator_Click(object sender, EventArgs e)
        {
            
            if (dataBase.GetResult(queryCheckUsersData) == "Системный администратор")
            {
                userID = dataBase.GetID(queryUsersID_GET);

                Menu_Administrator menu_Administrator = new Menu_Administrator(userID);
                this.Close();
                menu_Administrator.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
            }
        }

        private void btn_Customers_Click(object sender, EventArgs e)
        {
            if (dataBase.GetResult(queryCheckUsersData) == "Заказчик")
            {
                userID = dataBase.GetID(queryUsersID_GET);

                Menu_Customers menu_Customers = new Menu_Customers(userID);
                this.Close();
                menu_Customers.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
            }
        }

        private void btn_Executors_Click(object sender, EventArgs e)
        {
            if (dataBase.GetResult(queryCheckUsersData) == "Исполнитель")
            {
                userID = dataBase.GetID(queryUsersID_GET);

                Menu_Executors menu_Executors = new Menu_Executors(userID);
                Authorization authorization = new Authorization();
                
                this.Close();
                authorization.Close();
                menu_Executors.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
            }
        }

        private double LocationX(int locationX, int partOfScreen_NUM)
        {
            string clientScreenWidth = this.Size.Width.ToString();
            double partOfScreen_WIDTH = Convert.ToInt32(clientScreenWidth) / partOfScreen_NUM;
            return locationX * partOfScreen_WIDTH;
        }

        private double LocationY(int locationY, int partOfScreen_NUM)
        {
            string clientScreenHeight = this.Size.Height.ToString();
            int partOfScreen_HEIGHT = Convert.ToInt32(clientScreenHeight) / partOfScreen_NUM;
            return locationY * partOfScreen_HEIGHT;
        }
    }
}
