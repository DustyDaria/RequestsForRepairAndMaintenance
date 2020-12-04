using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestsForRepairAndMaintenance
{
    class Style
    {
        public int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
        public int sccreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

        //Расположение элементов на форме рассчитывается в зависимости от размеров экрана
        //public int screenWidth_OnePart = screenWidth / 12;
            //this.Width = x;
            //this.Height = y;
            //this.WindowState = FormWindowState.Maximized;

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_MainText = new Font("Arial", 16, FontStyle.Regular);
        Font font_SmallText = new Font("Arial", 12, FontStyle.Regular);

        

        public void Header(string name, string text, int locationX, int locationY, int partOfScreen_NUM)
        {
            //Находим размеры монитора
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Делим длину и ширину на определенное кол-во частей
            int partOfScreen_WIDTH = screenWidth / partOfScreen_NUM;
            int partOfScreen_HEIGHT = screenHeight / partOfScreen_NUM;
            //Выбираем "выделенный квадрат" для элемента управления
            locationX = locationX * partOfScreen_WIDTH;
            locationY = locationY * partOfScreen_HEIGHT;

            
            name.Text = text;
            name.Location = new System.Drawing.Point(locationX, locationY);
            name.ForeColor = System.Drawing.Color.DarkGray;

            

        }

    }
}
