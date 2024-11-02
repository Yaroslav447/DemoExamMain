using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace avtoriz
{
    /// <summary>
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();
        }


        public Boolean proverka()
        {

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = logboxRegAdm.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table1);
            if (table1.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string admreglogin = logboxRegAdm.Text;
            string admregpass = passboxRegAdm.Password;
            string admregname = nameboxRegAdm.Text;
            string admregsurname = surnameboxAdm.Text;
            //string admpravareg = pravareg.Text;

            if (logboxRegAdm.Text != "" & passboxRegAdm.Password != "" & nameboxRegAdm.Text != "" & surnameboxAdm.Text != "" & pravareg.Text != "")
            {
                if (proverka())
                    return;
                if (pravareg.Text == "Администратор")
                {
                    pravareg.Text = "admin";
                }
                else if (pravareg.Text == "Пользователь")
                {
                    pravareg.Text = "user";
                }
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`, `prava`) VALUES (@log, @pass, @name, @surname, @pr)", db.getConnection());
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = logboxRegAdm.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passboxRegAdm.Password;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameboxRegAdm.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnameboxAdm.Text;
                command.Parameters.Add("@pr", MySqlDbType.VarChar).Value = pravareg.Text;

                db.openConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("аккаунт создан!");
                }
                else
                {
                    MessageBox.Show(" аккаунт не создан");
                }
                db.closeConnection();

                NavigationService.Navigate(new Page3());
            }
            else
            {
                MessageBox.Show("Поля не заполнены!");
            }

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }
    }
}
