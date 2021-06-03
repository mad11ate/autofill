using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace autofillDatabase_0._0._1
{
    public partial class connectionForm : Form
    {
        public connectionForm()
        {
            InitializeComponent();
            optionButton.Select();
        }

        private void optionButton_Click(object sender, EventArgs e)
        {
            Storage.IPAddress = IPTextBox.Text;
            Storage.port = portTextBox.Text;
            Storage.login = loginTextBox.Text;
            Storage.password = passwordTextBox.Text;

            if (loginTextBox.Text == "")  //Проверка на ввод пустых данных в IPTextBox
            {
                MessageBox.Show("Логин", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passwordTextBox.Text == "") //Проверка на ввод пустых данных в portTextBox
            {
                MessageBox.Show("Введите пароль", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IPTextBox.Text == "")  //Проверка на ввод пустых данных в IPTextBox
            {
                MessageBox.Show("Введите IP-адрес", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (portTextBox.Text == "")//Проверка на ввод пустых данных в portTextBox
            {
                MessageBox.Show("Введите порт", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                optionButton.Select();

                string conn = @"Data Source=" + Storage.IPAddress + "," + Storage.port + ";Initial Catalog=PlanAZS_DB; Integrated Security = false; User ID=" + Storage.login + ";Password=" + Storage.password;
                SqlConnection myConnection = new SqlConnection(conn);

                myConnection.Open();

                MessageBox.Show("Подключение прошло успешно", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                myConnection.Close();  

                this.Hide();
                enteringADocument newForm = new enteringADocument();
                newForm.Show();
            }

            catch { MessageBox.Show("Не удалось подключиться к выбранной базе данных. \nПроверьте правильность введенных данных.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void IPTextBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == 8) { }
            else e.Handled = true;
        }

        private void portTextBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '.' || e.KeyChar == 8) { }
            else e.Handled = true;
        }

        Point lastPoint;

        private void connectionForm_MouseMove(object sender, MouseEventArgs e) //Отсчет новых координат формы
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }          
        }

        private void connectionForm_MouseDown(object sender, MouseEventArgs e) //Запись новый координат в переменную
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e) //Проверка перед закрытием приложения
        {
            DialogResult res = new DialogResult();
            res = MessageBox.Show("Вы действительно хотите выйти?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res.ToString() == "Yes")
            {
                Application.Exit();
            }           
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) //Меняем фон и цвет closeButton 
        {
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.Red;

        }

        private void closeButton_MouseLeave(object sender, EventArgs e) //Возвращаем начальный вид closeButton
        {
            closeButton.ForeColor = Color.Black;
            closeButton.BackColor = Color.Transparent;
        }
    }
}
