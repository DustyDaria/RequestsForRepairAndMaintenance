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
    public partial class Authorization : Form
    {
        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_MainText = new Font("Arial", 14, FontStyle.Regular);

        GroupBox groupBoxTop = new System.Windows.Forms.GroupBox();

        Label label_Please = new System.Windows.Forms.Label();
        Label label_Email = new System.Windows.Forms.Label();
        Label label_Password = new System.Windows.Forms.Label();

        TextBox textBox_Email = new System.Windows.Forms.TextBox();
        TextBox textBox_Password = new System.Windows.Forms.TextBox();

        Button btn_Login = new System.Windows.Forms.Button();
        //Button btn_Cancel = new System.Windows.Forms.Button();

        string Email = string.Empty;
        string Password = string.Empty;

        DataBase dataBase = new DataBase();

        public Authorization()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(800, 600);
            this.Text = "Авторизация";
            this.ResizeRedraw = true;
            this.BackColor = Color.Azure;
            
            groupBoxTop.Text = "Учет заявок на техническое обслуживание и ремонт (ТОиР)";
            groupBoxTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            groupBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            groupBoxTop.BackColor = Color.SteelBlue;
            groupBoxTop.ForeColor = Color.Azure;
            groupBoxTop.Font = font_Header;

            label_Please.Text = "Пожалуйста, авторизуйтесь в системе,\nиспользуя ваш адрес электронной почты и пароль.";
            label_Please.Font = font_MainText;
            label_Please.ForeColor = Color.DimGray;
            label_Please.TextAlign = ContentAlignment.MiddleCenter;

            label_Email.Text = "Email: ";
            label_Email.Font = font_MainText;
            label_Email.ForeColor = Color.DimGray;
            label_Email.TextAlign = ContentAlignment.MiddleLeft;

            label_Password.Text = "Password: ";
            label_Password.Font = font_MainText;
            label_Password.ForeColor = Color.DimGray;
            label_Password.TextAlign = ContentAlignment.MiddleLeft;

            textBox_Email.Text = "Enter your email address";
            textBox_Email.Font = font_MainText;
            textBox_Email.ForeColor = Color.Gray;
            textBox_Email.TextAlign = HorizontalAlignment.Left;

            textBox_Password.Text = "Enter your password";
            textBox_Password.Font = font_MainText;
            textBox_Password.ForeColor = Color.Gray;
            textBox_Password.TextAlign = HorizontalAlignment.Left;

            btn_Login.Text = "Войти";
            btn_Login.Font = font_MainText;
            btn_Login.ForeColor = Color.DimGray;
            btn_Login.BackColor = Color.LightSteelBlue;
            btn_Login.TextAlign = ContentAlignment.MiddleCenter;
            btn_Login.Click += new System.EventHandler(btn_Login_Click);

            SizeLocation_New();
            ControlsAdd();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Email = textBox_Email.Text;
            Password = textBox_Password.Text;

            string queryCheckUserData_GET = string.Format("SELECT user_password FROM Users WHERE user_login = '" + Email + "';");

            if (Email == string.Empty || Email == "Enter your email address")
            {
                MessageBox.Show("Пожалуйста, введите Email!");
            }
            else if(Password == string.Empty || Password == "Enter your password")
            {
                MessageBox.Show("Пожалуйста, введите пароль!");
            }
            else
            {
                if (dataBase.GetResult(queryCheckUserData_GET) == Password)
                {
                    Authorization_TypeOfAccount authorization_TypeOfAccount = new Authorization_TypeOfAccount(Email, Password);
                    this.Enabled = false;
                    authorization_TypeOfAccount.Show();
                    authorization_TypeOfAccount.FormClosed += (obj, args) => this.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите корректные пользовательские данные!");
                }

                
            }
        }

        private void SizeLocation_New()
        {
            groupBoxTop.Size = new Size((int)LocationX(20, 20), (int)LocationY(3, 20));

            label_Please.Location = new System.Drawing.Point((int)LocationX(5, 20), (int)LocationY(3, 20));
            label_Please.Size = new System.Drawing.Size((int)LocationX(10, 20), (int)LocationY(5, 20));

            label_Email.Location = new System.Drawing.Point((int)LocationX(6, 20), (int)LocationY(13, 30));
            label_Email.Size = new System.Drawing.Size((int)LocationX(2, 20), (int)LocationY(2, 20));

            label_Password.Location = new System.Drawing.Point((int)LocationX(6, 20), (int)LocationY(17, 30));
            label_Password.Size = new System.Drawing.Size((int)LocationX(3, 20), (int)LocationY(2, 20));

            textBox_Email.Location = new System.Drawing.Point((int)LocationX(10, 20), (int)LocationY(10, 22));
            textBox_Email.Size = new System.Drawing.Size((int)LocationX(4, 20), (int)LocationY(1, 20));

            textBox_Password.Location = new System.Drawing.Point((int)LocationX(10, 20), (int)LocationY(13, 22));
            textBox_Password.Size = new System.Drawing.Size((int)LocationX(4, 20), (int)LocationY(1, 20));

            btn_Login.Location = new System.Drawing.Point((int)LocationX(9, 20), (int)LocationY(15, 20));
            btn_Login.Size = new System.Drawing.Size((int)LocationX(2, 20), (int)LocationY(1, 20));
        }

        private void ControlsAdd()
        {
            this.Controls.Add(groupBoxTop);
            this.Controls.Add(label_Please);
            this.Controls.Add(label_Email);
            this.Controls.Add(label_Password);
            this.Controls.Add(textBox_Email);
            this.Controls.Add(textBox_Password);
            this.Controls.Add(btn_Login);
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
            return  locationY * partOfScreen_HEIGHT;
        }

        private void Authorization_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void Authorization_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }
    }
}
