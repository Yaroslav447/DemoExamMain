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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }

        public Boolean proverka()
        {

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL ", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = logboxreg.Text;

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
            if (logboxreg.Text != "" & passboxreg.Password != "" & nameboxreg.Text != "" & surnamebox.Text != "")
            {
                if (proverka())
                    return;
                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@log, @pass, @name, @surname)", db.getConnection());
                command.Parameters.Add("@log", MySqlDbType.VarChar).Value = logboxreg.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passboxreg.Password;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameboxreg.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnamebox.Text;

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

                NavigationService.Navigate(new Page1());
            }
            else
            {
                MessageBox.Show("Поля не заполнены!");
            }
        }
    }
}
