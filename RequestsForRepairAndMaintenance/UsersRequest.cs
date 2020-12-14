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
    public partial class UsersRequest : Form
    {
        int mainID = 0;
        int requestID = 0;
        string usersAction = string.Empty;
        string typeOfAccount = string.Empty;

        /*string nameRequest = string.Empty;
        string descriptionRequest = string.Empty;
        string commentRequest = string.Empty;
        int roomNumber = 0;
        string inventoryNumber = string.Empty;*/
        string statusRequest = string.Empty;

        Font font_Header = new Font("Arial", 20, FontStyle.Bold);
        Font font_SmallHeader = new Font("Arial", 16, FontStyle.Bold);
        Font font_mainText = new Font("Arial", 14, FontStyle.Regular);
        Font font_MiddleText = new Font("Arial", 12, FontStyle.Regular);
        Font font_SmallText = new Font("Arial", 8, FontStyle.Regular);

        GroupBox groupBoxTop = new System.Windows.Forms.GroupBox();
        GroupBox groupBox_status_request = new System.Windows.Forms.GroupBox();

        Panel panel_status_request = new System.Windows.Forms.Panel();

        Button btn_Save = new System.Windows.Forms.Button();
        Button btn_Cancel = new System.Windows.Forms.Button();

        Label label_Header = new System.Windows.Forms.Label();
        Label label_AdditionalText = new System.Windows.Forms.Label();
        Label label_name_request = new System.Windows.Forms.Label();
        Label label_description_request = new System.Windows.Forms.Label();
        Label label_comment_request = new System.Windows.Forms.Label();
        Label label_room_number = new System.Windows.Forms.Label();
        Label label_inventory_number = new System.Windows.Forms.Label();
        Label label_date_start = new System.Windows.Forms.Label();
        Label label_date_end = new System.Windows.Forms.Label();
        Label label_category_request = new System.Windows.Forms.Label();

        TextBox textBox_name_request = new System.Windows.Forms.TextBox();
        TextBox textBox_inventory_number = new System.Windows.Forms.TextBox();

        RichTextBox richTextBox_description_request = new System.Windows.Forms.RichTextBox();
        RichTextBox richTextBox_comment_request = new System.Windows.Forms.RichTextBox();

        ComboBox comboBox_room_number = new System.Windows.Forms.ComboBox();
        ComboBox comboBox_category_request = new System.Windows.Forms.ComboBox();

        RadioButton radioButton_OnModeration = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_ModerationIsNotPassed = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_Waiting = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_WorkIsCompleted = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_AcceptedForWork = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_ReturnToWork = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_Finished = new System.Windows.Forms.RadioButton();
        RadioButton radioButton_InTheArchive = new System.Windows.Forms.RadioButton();

        DateTimePicker dateTime_Start = new System.Windows.Forms.DateTimePicker();
        DateTimePicker dateTime_End = new System.Windows.Forms.DateTimePicker();

        PictureBox pictureBox_Scrolling = new System.Windows.Forms.PictureBox();

        DataBase dataBase = new DataBase();

        public UsersRequest(int userID, string action, int requestID_GET)
        {
            InitializeComponent();

            mainID = userID;
            usersAction = action;
            requestID = requestID_GET;

            // ФОРМА
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(990, 720);
            this.ResizeRedraw = true;
            this.BackColor = Color.Azure;
            this.AutoScroll = true;
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

            label_AdditionalText.Font = font_SmallText;
            label_AdditionalText.Text = "В круглых скобках записывается значение по умолчанию";
            label_AdditionalText.ForeColor = Color.Red;
            label_AdditionalText.TextAlign = ContentAlignment.MiddleRight;
            //

            // НАЗВАНИЕ ЗАЯВКИ
            label_name_request.Font = font_MiddleText;
            label_name_request.Text = "*\nНазвание заявки";
            label_name_request.ForeColor = Color.DimGray;
            label_name_request.TextAlign = ContentAlignment.MiddleLeft;

            textBox_name_request.Font = font_MiddleText;
            textBox_name_request.Text = "Заявка ...";
            textBox_name_request.ForeColor = Color.DimGray;
            textBox_name_request.TextAlign = HorizontalAlignment.Left;
            textBox_name_request.Cursor = Cursors.IBeam;
            //

            // ОПИСАНИЕ ЗАЯВКИ
            label_description_request.Font = font_MiddleText;
            label_description_request.Text = "*\nОписание заявки";
            label_description_request.ForeColor = Color.DimGray;
            label_description_request.TextAlign = ContentAlignment.MiddleLeft;

            richTextBox_description_request.Font = font_MiddleText;
            richTextBox_description_request.Text = string.Empty;
            richTextBox_description_request.ForeColor = Color.DimGray;
            richTextBox_description_request.Cursor = Cursors.IBeam;
            //

            // КОММЕНТАРИЙ К ЗАЯВКЕ
            label_comment_request.Font = font_MiddleText;
            label_comment_request.Text = "\nКомментарий к заявке";
            label_comment_request.ForeColor = Color.DimGray;
            label_comment_request.TextAlign = ContentAlignment.MiddleLeft;

            richTextBox_comment_request.Font = font_MiddleText;
            richTextBox_comment_request.Text = string.Empty;
            richTextBox_comment_request.ForeColor = Color.DimGray;
            richTextBox_comment_request.Cursor = Cursors.IBeam;
            //

            // НОМЕР ПОМЕШЕНИЯ
            label_room_number.Font = font_MiddleText;
            label_room_number.Text = "*\nНомер помещения: ";
            label_room_number.ForeColor = Color.DimGray;
            label_room_number.TextAlign = ContentAlignment.MiddleLeft;

            comboBox_room_number.Font = font_MiddleText;
            comboBox_room_number.Text = string.Empty;
            comboBox_room_number.ForeColor = Color.DimGray;
            comboBox_room_number.DropDownStyle = ComboBoxStyle.DropDown;

            string queryRoomNumberCount_GET = string.Format("SELECT COUNT(roomNUMBER) FROM U_RD_Rooms WHERE userID = '" + mainID + "';");
            string queryRoomNumber_GET = string.Format("SELECT roomNUMBER FROM U_RD_Rooms WHERE userID = '" + mainID + "';");

            int roomCount = dataBase.GetID(queryRoomNumberCount_GET);

            for (int i = 1; i <= roomCount; i++){
                comboBox_room_number.Items.Add(dataBase.GetID(queryRoomNumber_GET));
            } //ПОЛУЧАЮ ОДИНАКОВЫЕ НОМЕРА КАБИНЕТОВ
            //

            // ИНВЕНТАРНЫЙ НОМЕР
            label_inventory_number.Font = font_MiddleText;
            label_inventory_number.Text = "Инвентарный номер ремонтируемого объекта: ";
            label_inventory_number.ForeColor = Color.DimGray;
            label_inventory_number.TextAlign = ContentAlignment.MiddleLeft;

            textBox_inventory_number.Font = font_MiddleText;
            textBox_inventory_number.Text = string.Empty;
            textBox_inventory_number.ForeColor = Color.DimGray;
            textBox_inventory_number.TextAlign = HorizontalAlignment.Left;
            textBox_inventory_number.Cursor = Cursors.IBeam;
            //

            // ДАТА НАЧАЛА
            label_date_start.Font = font_MiddleText;
            label_date_start.Text = "Дата начала выполнения работ (текущая дата): ";
            label_date_start.ForeColor = Color.DimGray;
            label_date_start.TextAlign = ContentAlignment.MiddleLeft;
            
            dateTime_Start.Format = DateTimePickerFormat.Custom;
            dateTime_Start.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            dateTime_Start.Value = DateTime.Now;
            dateTime_Start.MinDate = DateTime.Now;
            dateTime_Start.Cursor = Cursors.Hand;
            //

            // ДАТА ОКОНЧАНИЯ
            label_date_end.Font = font_MiddleText;
            label_date_end.Text = "Необходимая дата окончания выполнения работ (спустя неделю от даты начала выполнения работ): ";
            label_date_end.ForeColor = Color.DimGray;
            label_date_end.TextAlign = ContentAlignment.MiddleLeft;

            dateTime_End.Format = DateTimePickerFormat.Custom;
            dateTime_End.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            dateTime_End.Value = DateTime.Now;
            dateTime_End.MinDate = DateTime.Now;
            dateTime_End.Cursor = Cursors.Hand;
            //

            pictureBox_Scrolling.Image = Resources.down_arrow128;
            pictureBox_Scrolling.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Scrolling.BorderStyle = BorderStyle.None;

            // СТАТУС ЗАЯВКИ
            groupBox_status_request.Text = "Текущий статус заявки: ";
            groupBox_status_request.RightToLeft = System.Windows.Forms.RightToLeft.No;
            groupBox_status_request.ForeColor = Color.DimGray;
            groupBox_status_request.Font = font_MiddleText;
            //groupBox_status_request.Margin = new System.Windows.Forms.Padding(5); // НЕ РАБОТАЕТ

            radioButton_OnModeration.Text = "На модерации";
            radioButton_OnModeration.ForeColor = Color.DimGray;
            radioButton_OnModeration.Font = font_MiddleText;
            radioButton_OnModeration.Cursor = Cursors.Hand;
            radioButton_OnModeration.CheckedChanged += new System.EventHandler(radioButton_OnModeration_CheckedChanged);
            
            radioButton_ModerationIsNotPassed.Text = "Модерация не пройдена";
            radioButton_ModerationIsNotPassed.Font = font_MiddleText;
            radioButton_ModerationIsNotPassed.ForeColor = Color.DimGray;
            radioButton_ModerationIsNotPassed.Cursor = Cursors.Hand;
            radioButton_ModerationIsNotPassed.CheckedChanged += new System.EventHandler(radioButton_ModerationIsNotPassed_CheckedChanged);

            radioButton_Waiting.Text = "Ждет выполнения";
            radioButton_Waiting.Font = font_MiddleText;
            radioButton_Waiting.ForeColor = Color.DimGray;
            radioButton_Waiting.Cursor = Cursors.Hand;
            radioButton_Waiting.CheckedChanged += new System.EventHandler(radioButton_Waiting_CheckedChanged);

            radioButton_WorkIsCompleted.Text = "Работа выполнена";
            radioButton_WorkIsCompleted.Font = font_MiddleText;
            radioButton_WorkIsCompleted.ForeColor = Color.DimGray;
            radioButton_WorkIsCompleted.Cursor = Cursors.Hand;
            radioButton_WorkIsCompleted.CheckedChanged += new System.EventHandler(radioButton_WorkIsCompleted_CheckedChanged);

            radioButton_AcceptedForWork.Text = "Принято в работу";
            radioButton_AcceptedForWork.Font = font_MiddleText;
            radioButton_AcceptedForWork.ForeColor = Color.DimGray;
            radioButton_AcceptedForWork.Cursor = Cursors.Hand;
            radioButton_AcceptedForWork.CheckedChanged += new System.EventHandler(radioButton_AcceptedForWork_CheckedChanged);

            radioButton_ReturnToWork.Text = "Возврат в работу";
            radioButton_ReturnToWork.Font = font_MiddleText;
            radioButton_ReturnToWork.ForeColor = Color.DimGray;
            radioButton_ReturnToWork.Cursor = Cursors.Hand;
            radioButton_ReturnToWork.CheckedChanged += new System.EventHandler(radioButton_ReturnToWork_CheckedChanged);

            radioButton_Finished.Text = "Завершено";
            radioButton_Finished.Font = font_MiddleText;
            radioButton_Finished.ForeColor = Color.DimGray;
            radioButton_Finished.Cursor = Cursors.Hand;
            radioButton_Finished.CheckedChanged += new System.EventHandler(radioButton_Finished_CheckedChanged);

            radioButton_InTheArchive.Text = "В архиве";
            radioButton_InTheArchive.Font = font_MiddleText;
            radioButton_InTheArchive.ForeColor = Color.DimGray;
            radioButton_InTheArchive.Cursor = Cursors.Hand;
            radioButton_InTheArchive.CheckedChanged += new System.EventHandler(radioButton_InTheArchive_CheckedChanged);
            //

            // КАТЕГОРИЯ ЗАЯВКИ
            label_category_request.Font = font_MiddleText;
            label_category_request.Text = "*\nКатегория работ: ";
            label_category_request.ForeColor = Color.DimGray;
            label_category_request.TextAlign = ContentAlignment.MiddleLeft;

            comboBox_category_request.Font = font_MiddleText;
            comboBox_category_request.ForeColor = Color.DimGray;
            comboBox_category_request.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_category_request.Items.AddRange(new string[] { "Электрик", "Плотник", "IT-специалист" });
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
            //
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if (usersAction == "Модерация")
                {
                    label_Header.Text = "Редактировать заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = true;
                    radioButton_Waiting.Enabled = true;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = false;
                    radioButton_InTheArchive.Enabled = false;
                }
                if (usersAction == "В архив")
                {
                    label_Header.Text = "Редактировать заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = false;
                    radioButton_InTheArchive.Enabled = true;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (usersAction == "Создать")
                {
                    label_Header.Text = "Создать новую заявку";

                    textBox_name_request.Enabled = true;
                    richTextBox_description_request.Enabled = true;
                    richTextBox_comment_request.Enabled = true;
                    comboBox_room_number.Enabled = true;
                    textBox_inventory_number.Enabled = true;
                    dateTime_Start.Enabled = true;
                    dateTime_End.Enabled = true;
                    comboBox_category_request.Enabled = true;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = false;
                    radioButton_InTheArchive.Enabled = false;

                }
                else if(usersAction == "Просмотреть")
                {
                    label_Header.Text = "Просмотреть заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = false;
                    radioButton_InTheArchive.Enabled = false;
                }
                else if(usersAction == "Завершить/вернуть")
                {
                    label_Header.Text = "Редактировать заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = true;
                    radioButton_Finished.Enabled = true;
                    radioButton_InTheArchive.Enabled = false;
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if (usersAction == "Принять")
                {
                    label_Header.Text = "Принять заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = false;
                    radioButton_AcceptedForWork.Enabled = true;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = true;
                    radioButton_InTheArchive.Enabled = false;
                }
                else if (usersAction == "Сдать")
                {
                    label_Header.Text = "Сдать заявку";

                    GetDataToViewAndChange();

                    textBox_name_request.Enabled = false;
                    richTextBox_description_request.Enabled = false;
                    richTextBox_comment_request.Enabled = false;
                    comboBox_room_number.Enabled = false;
                    textBox_inventory_number.Enabled = false;
                    dateTime_Start.Enabled = false;
                    dateTime_End.Enabled = false;
                    comboBox_category_request.Enabled = false;
                    btn_Save.Enabled = true;
                    btn_Cancel.Enabled = true;
                    radioButton_OnModeration.Enabled = false;
                    radioButton_ModerationIsNotPassed.Enabled = false;
                    radioButton_Waiting.Enabled = false;
                    radioButton_WorkIsCompleted.Enabled = true;
                    radioButton_AcceptedForWork.Enabled = false;
                    radioButton_ReturnToWork.Enabled = false;
                    radioButton_Finished.Enabled = true;
                    radioButton_InTheArchive.Enabled = false;
                }
            }
            // РАСПОЛОЖЕНИЕ, РАЗМЕРЫ, ДОБАВЛЕНИЕ НА ФОРМУ
            SizeLocation_New();
            ControlsAdd();
            //
        }

        private void SizeLocation_New()
        {
            //ШАПКА
            groupBoxTop.Size = new System.Drawing.Size((int)LocationX(20, 20), (int)LocationY(3, 20));

            label_Header.Location = new System.Drawing.Point((int)LocationX(10, 40), (int)LocationY(3, 20));
            label_Header.Size = new System.Drawing.Size((int)LocationX(20, 40), (int)LocationY(2, 20));

            label_AdditionalText.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(3, 20));
            label_AdditionalText.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 20));
            //

            //1 РЯД
            label_name_request.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(8, 30));
            label_name_request.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(3, 20));

            textBox_name_request.Location = new System.Drawing.Point((int)LocationX(7, 40), (int)LocationY(7, 22));
            textBox_name_request.Size = new System.Drawing.Size((int)LocationX(11, 40), (int)LocationY(2, 22));

            label_description_request.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(12, 30));
            label_description_request.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(3, 20));

            richTextBox_description_request.Location = new System.Drawing.Point((int)LocationX(7, 40), (int)LocationY(10, 22));
            richTextBox_description_request.Size = new System.Drawing.Size((int)LocationX(11, 40), (int)LocationY(4, 22));

            label_comment_request.Location = new System.Drawing.Point((int)LocationX(1, 40), (int)LocationY(19, 30));
            label_comment_request.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(3, 20));

            richTextBox_comment_request.Location = new System.Drawing.Point((int)LocationX(7, 40), (int)LocationY(15, 22));
            richTextBox_comment_request.Size = new System.Drawing.Size((int)LocationX(11, 40), (int)LocationY(4, 22));
            //

            //2 РЯД
            label_room_number.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(8, 30));
            label_room_number.Size = new System.Drawing.Size((int)LocationX(10, 40), (int)LocationY(3, 30));

            comboBox_room_number.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(7, 22));
            comboBox_room_number.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));

            label_inventory_number.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(12, 30));
            label_inventory_number.Size = new System.Drawing.Size((int)LocationX(10, 40), (int)LocationY(3, 30));

            textBox_inventory_number.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(10, 22));
            textBox_inventory_number.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));
            
            label_date_start.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(16, 30));
            label_date_start.Size = new System.Drawing.Size((int)LocationX(10, 40), (int)LocationY(3, 30));

            dateTime_Start.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(13, 22));
            dateTime_Start.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));

            label_date_end.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(20, 30));
            label_date_end.Size = new System.Drawing.Size((int)LocationX(10, 40), (int)LocationY(3, 30));

            dateTime_End.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(15, 22));
            dateTime_End.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));
            //

            pictureBox_Scrolling.Location = new System.Drawing.Point((int)LocationX(18, 40), (int)LocationY(20, 22));
            pictureBox_Scrolling.Size = new System.Drawing.Size((int)LocationX(4, 40), (int)LocationY(1, 22));

            //1 РЯД ПОСЛЕ СКРОЛЛА
            panel_status_request.Location = new System.Drawing.Point((int)LocationX(7, 40), (int)LocationY(23, 22));
            panel_status_request.Size = new System.Drawing.Size((int)LocationX(11, 40), (int)LocationY(10, 22));

            groupBox_status_request.Location = new System.Drawing.Point((int)LocationForGroupBox_StatusRequest_X(3, 40),
                (int)LocationForGroupBox_StatusRequest_Y(3, 40));
            groupBox_status_request.Size = new System.Drawing.Size((int)LocationForGroupBox_StatusRequest_X(34, 40),
                (int)LocationForGroupBox_StatusRequest_Y(34, 40));

            radioButton_OnModeration.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(4, 40));
            radioButton_OnModeration.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_ModerationIsNotPassed.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(9, 40));
            radioButton_ModerationIsNotPassed.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_Waiting.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(14, 40));
            radioButton_Waiting.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_WorkIsCompleted.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(19, 40));
            radioButton_WorkIsCompleted.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_AcceptedForWork.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(24, 40));
            radioButton_AcceptedForWork.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_ReturnToWork.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(29, 40));
            radioButton_ReturnToWork.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_Finished.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(34, 40));
            radioButton_Finished.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));

            radioButton_InTheArchive.Location = new System.Drawing.Point((int)LocationForStatusRequest_X(3, 40),
                (int)LocationForStatusRequest_Y(39, 40));
            radioButton_InTheArchive.Size = new System.Drawing.Size((int)LocationForStatusRequest_X(34, 40),
                (int)LocationForStatusRequest_Y(4, 40));
            //

            // 2 РЯД ПОСЛЕ СКРОЛЛА
            label_category_request.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(31, 30));
            label_category_request.Size = new System.Drawing.Size((int)LocationX(10, 40), (int)LocationY(3, 30));

            comboBox_category_request.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(24, 22));
            comboBox_category_request.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(2, 22));

            btn_Save.Location = new System.Drawing.Point((int)LocationX(22, 40), (int)LocationY(37, 30));
            btn_Save.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(3, 30));

            btn_Cancel.Location = new System.Drawing.Point((int)LocationX(33, 40), (int)LocationY(37, 30));
            btn_Cancel.Size = new System.Drawing.Size((int)LocationX(5, 40), (int)LocationY(3, 30));
            //
        }

        private void ControlsAdd()
        {
            // ШАПКА
            this.Controls.Add(groupBoxTop);
            this.Controls.Add(label_Header);
            this.Controls.Add(label_AdditionalText);
            //

            // 1 РЯД
            this.Controls.Add(label_name_request);
            this.Controls.Add(textBox_name_request);

            this.Controls.Add(label_description_request);
            this.Controls.Add(richTextBox_description_request);

            this.Controls.Add(label_comment_request);
            this.Controls.Add(richTextBox_comment_request);
            //

            //2 РЯД
            this.Controls.Add(label_room_number);
            this.Controls.Add(comboBox_room_number);

            this.Controls.Add(label_inventory_number);
            this.Controls.Add(textBox_inventory_number);

            this.Controls.Add(label_date_start);
            this.Controls.Add(dateTime_Start);

            this.Controls.Add(label_date_end);
            this.Controls.Add(dateTime_End);
            //

            this.Controls.Add(pictureBox_Scrolling);

            // 1 РЯД ПОСЛЕ СКРОЛЛА
            this.Controls.Add(panel_status_request);

            panel_status_request.Controls.Add(groupBox_status_request);

            groupBox_status_request.Controls.Add(radioButton_OnModeration);
            groupBox_status_request.Controls.Add(radioButton_ModerationIsNotPassed);
            groupBox_status_request.Controls.Add(radioButton_Waiting);
            groupBox_status_request.Controls.Add(radioButton_WorkIsCompleted);
            groupBox_status_request.Controls.Add(radioButton_AcceptedForWork);
            groupBox_status_request.Controls.Add(radioButton_ReturnToWork);
            groupBox_status_request.Controls.Add(radioButton_Finished);
            groupBox_status_request.Controls.Add(radioButton_InTheArchive);
            //

            //2 РЯД ПОСЛЕ СКРОЛЛА
            this.Controls.Add(label_category_request);
            this.Controls.Add(comboBox_category_request);

            this.Controls.Add(btn_Save);
            this.Controls.Add(btn_Cancel);
            //
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string queryCheckTypeOfAccount_GET = string.Format("SELECT type_of_account FROM Users WHERE id_user = '" + mainID + "';");

            if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Системный администратор")
            {
                if ((usersAction == "Модерация") || (usersAction == "В архив"))
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\n");
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Заказчик")
            {
                if (usersAction == "Создать")
                {

                    if (textBox_name_request.Text == string.Empty || textBox_name_request.Text == "Заявка...")
                    {
                        MessageBox.Show("Пожалуйста, введите корректное название заявки!");
                    }
                    else if (richTextBox_description_request.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, введите соответствующее описание заявки!");
                    }
                    else if (comboBox_room_number.Text == string.Empty)  // Нужна проверка от левых (введенных вручную) значений
                    {
                        MessageBox.Show("Пожалуйста, выберите Ваше помещение!");
                    }
                    else if ((dateTime_End.Value == dateTime_Start.Value) || (dateTime_End.Value < dateTime_Start.Value))
                    {
                        MessageBox.Show("Необходимая дата окончания выполнения работ по заявке не может быть меньше или равна дате начала выполнения работ.\nПожалуйста, выберите корректную дату окончания выполнения работ по заявке!");
                    }
                    else if (comboBox_category_request.Text == string.Empty)
                    {
                        MessageBox.Show("Пожалуйста, выберите корректную категорию работ для заявки!");
                    }
                    else
                    {
                        try
                        {
                            string queryDataRequest_SET = string.Format("INSERT INTO Requests (date_start, date_end, status_request, room_number, name_request, description_request, comment_request, inventory_number, category_request) VALUES ('"
                            + dateTime_Start.Value + "', '" + dateTime_End.Value + "', 'На модерации', '" + comboBox_room_number.Text + "', '" + textBox_name_request.Text + "', '"
                            + richTextBox_description_request.Text + "', '" + richTextBox_comment_request.Text + "', '" + textBox_inventory_number.Text + "', '" 
                            + comboBox_category_request.Text + "');");

                            dataBase.Insert(queryDataRequest_SET);

                            string queryIDRequest_GET = string.Format("SELECT id_request FROM Requests WHERE date_start = '"
                                + dateTime_Start.Value + "' AND date_end = '" + dateTime_End.Value + "' AND status_request = 'На модерации' AND room_number = '"
                                + comboBox_room_number.Text + "' AND name_request = '" + textBox_name_request.Text + "' AND description_request = '"
                                + richTextBox_description_request.Text + "' AND comment_request = '" + richTextBox_comment_request.Text + "' AND inventory_number = '"
                                + textBox_inventory_number.Text + "' AND category_request = '" + comboBox_category_request.Text + "';");
                            string queryU_R_CustomersData_SET = string.Format("INSERT INTO U_R_Customers (userID, requestID) VALUES ('"
                                + mainID + "', '" + dataBase.GetID(queryIDRequest_GET) + "');");

                            dataBase.Insert(queryU_R_CustomersData_SET);

                            MessageBox.Show("Ваша заявка была успешно сохранена и передана на модерацию!");

                            Menu_Users menu_Users = new Menu_Users(mainID);
                            this.Close();
                            menu_Users.Show();
                        }
                        catch (Exception err)
                        {
                            MessageBox.Show("ОШИБКА!!!\n" + err.ToString());
                        }
                    }
                }
                else if (usersAction == "Завершить/вернуть")
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\n");
                }
            }
            else if (dataBase.GetResult(queryCheckTypeOfAccount_GET) == "Исполнитель")
            {
                if (usersAction == "Принять")
                {
                    string queryU_R_Executors_SET = string.Format("INSERT INTO U_R_Executors (userID, requestID) VALUES ('"
                        + mainID + "', '" + requestID + "');");
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID + "';");
                    dataBase.Update(queryStatusRequest_SET);
                    dataBase.Insert(queryU_R_Executors_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\nДанная заявка закреплена за Вами, можете приступать к выполнению работ по текущей заявке :D");
                }
                else if (usersAction == "Сдать")
                {
                    string queryStatusRequest_SET = string.Format("UPDATE Requests SET status_request = '" + statusRequest + "' WHERE id_request = '" + requestID + "';");
                    dataBase.Update(queryStatusRequest_SET);

                    MessageBox.Show("Данные заявки были успешно обновлены!\nЕсли вы успешно выполнили необходимые по заявке работы, она к Вам больше не вернется :D");
                }
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Menu_Users menu_Users = new Menu_Users(mainID);
            this.Close();
            menu_Users.Show();
        }


        private void radioButton_OnModeration_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_OnModeration.Text;
        }

        private void radioButton_ModerationIsNotPassed_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_ModerationIsNotPassed.Text;
        }

        private void radioButton_Waiting_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_Waiting.Text;
        }

        private void radioButton_WorkIsCompleted_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_WorkIsCompleted.Text;
        }

        private void radioButton_AcceptedForWork_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_AcceptedForWork.Text;
        }

        private void radioButton_ReturnToWork_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_ReturnToWork.Text;
        }

        private void radioButton_Finished_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_Finished.Text;
        }

        private void radioButton_InTheArchive_CheckedChanged(object sender, EventArgs e)
        {
            statusRequest = radioButton_InTheArchive.Text;
        }

        private void GetDataToViewAndChange()
        {
            string queryNameRequest_GET = string.Format("SELECT name_request FROM Request_Description WHERE id_request = '" + requestID + "';");
            string queryDescriptionRequest_GET = string.Format("SELECT description_request FROM Request_Description WHERE id_request = '" + requestID + "';");
            string queryCommentRequest_GET = string.Format("SELECT comment_request FROM Request_Description WHERE id_request = '" + requestID + "';");
            string queryRoomNumberRequest_GET = string.Format("SELECT room_number FROM Request_Description WHERE id_request = '" + requestID + "';");
            string queryInventoryNumberRequest_GET = string.Format("SELECT inventory_number FROM Request_Description WHERE id_request = '" + requestID + "';");
            string queryDateStartRequest_GET = string.Format("SELECT date_start FROM Requests WHERE id_request = '" + requestID + "';");
            string queryDateEndRequest_GET = string.Format("SELECT date_end FROM Requests WHERE id_request = '" + requestID + "';");
            string queryCategoryRequest_GET = string.Format("SELECT category_request Request_Description WHERE id_request = '" + requestID + "';");
            string queryStatusRequest_GET = string.Format("SELECT status_request FROM Requests WHERE id_request = '" + requestID + "';");

            textBox_name_request.Text = dataBase.GetResult(queryNameRequest_GET);
            richTextBox_description_request.Text = dataBase.GetResult(queryDescriptionRequest_GET);

            if (dataBase.Check(queryCommentRequest_GET, Convert.ToString(requestID)) == true)
            {
                richTextBox_comment_request.Text = dataBase.GetResult(queryCommentRequest_GET);
            }
            else
            {
                richTextBox_comment_request.Text = string.Empty;
            }

            comboBox_room_number.Text = dataBase.GetResult(queryRoomNumberRequest_GET);

            if (dataBase.Check(queryInventoryNumberRequest_GET, Convert.ToString(requestID)) == true)
            {
                textBox_inventory_number.Text = dataBase.GetResult(queryInventoryNumberRequest_GET);
            }
            else
            {
                textBox_inventory_number.Text = string.Empty;
            }

            dateTime_Start.Value = Convert.ToDateTime(dataBase.GetResult(queryDateStartRequest_GET));
            dateTime_End.Value = Convert.ToDateTime(dataBase.GetResult(queryDateEndRequest_GET));
            comboBox_category_request.Text = dataBase.GetResult(queryCategoryRequest_GET);

            if (dataBase.GetResult(queryStatusRequest_GET) == "На модерации")
            {
                radioButton_OnModeration.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Модерация не пройдена")
            {
                radioButton_ModerationIsNotPassed.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Ждет выполнения")
            {
                radioButton_Waiting.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Работа выполнена")
            {
                radioButton_WorkIsCompleted.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Принято в работу")
            {
                radioButton_AcceptedForWork.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Возврат в работу")
            {
                radioButton_ReturnToWork.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "Завершено")
            {
                radioButton_Finished.Checked = true;
            }
            else if (dataBase.GetResult(queryStatusRequest_GET) == "В архиве")
            {
                radioButton_InTheArchive.Checked = true;
            }
        }


        // СКОРРЕ ВСЕГО ИЗ-ЗА ЭТИХ МЕТОДОВ ЕДЕТ АДАПТАЦИЯ
        private double LocationForGroupBox_StatusRequest_X(int locationX, int partOfControls_NUM)
        {
            string panelWidth = panel_status_request.Size.Width.ToString();
            double partOfControls_WIDTH = Convert.ToInt32(panelWidth) / partOfControls_NUM;
            return locationX * partOfControls_WIDTH;
        }

        private double LocationForGroupBox_StatusRequest_Y(int locationY, int partOfControls_NUM)
        {
            string panelHeight = panel_status_request.Size.Height.ToString();
            double partOfControls_HEIGHT = Convert.ToInt32(panelHeight) / partOfControls_NUM;
            return locationY * partOfControls_HEIGHT;
        }

        private double LocationForStatusRequest_X(int locationX, int partOfControls_NUM)
        {
            string groupBoxWidth = groupBox_status_request.Size.Width.ToString();
            double partOfControls_WIDTH = Convert.ToInt32(groupBoxWidth) / partOfControls_NUM;
            return locationX * partOfControls_WIDTH;
        }

        private double LocationForStatusRequest_Y(int locationY, int partOfControls_NUM)
        {
            string groupBoxHeight = groupBox_status_request.Size.Height.ToString();
            double partOfControls_HEIGHT = Convert.ToInt32(groupBoxHeight) / partOfControls_NUM;
            return locationY * partOfControls_HEIGHT;
        }
        //

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

        private void CreateNewRequest_SizeChanged(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

        private void CreateNewRequest_ResizeEnd(object sender, EventArgs e)
        {
            SizeLocation_New();
            ControlsAdd();
        }

    }
}
