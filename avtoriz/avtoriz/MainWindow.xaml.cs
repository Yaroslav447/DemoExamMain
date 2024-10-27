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
using MySql.Data.MySqlClient;

namespace avtoriz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Page1();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string loginUser;//= logbox.Text;
        //    string passwordUser;// = passbox.Text;

        //    DB db = new DB();
           
        //    DataTable table = new DataTable();
            
        //    MySqlDataAdapter adapter = new MySqlDataAdapter();

        //    MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass`= @uP", db.getConnection());
        //    //command.Parameters.Add("@uL",MySqlDbType.VarChar).Value =loginUser;
        //    //command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

        //    adapter.SelectCommand = command;
        //    adapter.Fill(table);


        //    if (table.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Готово");
        //    }
        //    else 
        //    {
        //        MessageBox.Show("Не верно");
        //    }
        //}
    }
}
