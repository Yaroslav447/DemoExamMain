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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string loginUser= logbox.Text;
            string passwordUser = passbox.Password;
            
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass`= @uP", db.getConnection());
            command.Parameters.Add("@uL",MySqlDbType.VarChar).Value =loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            DataTable table2 = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlCommand command2 = new MySqlCommand("SELECT * FROM `users`" +
                " WHERE `login` = @uL1 AND prava = 'admin'", db.getConnection());
            command2.Parameters.Add("@uL1", MySqlDbType.VarChar).Value = loginUser;
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);

            if (table.Rows.Count > 0)
            {
               if(table2.Rows.Count > 0)
                {
                    NavigationService.Navigate(new Page3());
                }
                else
                {
                    NavigationService.Navigate(new Page4());
                }
            }
            else
            {
                MessageBox.Show("Не верно");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void ColumnDefinition_TouchEnter(object sender, TouchEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }
    }
}
