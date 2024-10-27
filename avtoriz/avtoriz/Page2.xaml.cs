using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            
            //string loginreg = logboxreg.Text;
            //string passreg = passboxreg.Text;
            //string namereg = nameboxreg.Text;
            //string surnamereg = surnamebox.Text;
            DB db = new DB();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@log, @pass, @name, @surname)", db.getConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = logboxreg.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = passboxreg.Text;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameboxreg.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnamebox.Text;

                db.openConnection();
                         if(command.ExecuteNonQuery() == 1)
                    {
                    MessageBox.Show("аккаунт создан!");
                    }
                        else
                    {
                    MessageBox.Show(" аккаунт не создан");
            }

                db.closeConnection();
        }
    }
}
