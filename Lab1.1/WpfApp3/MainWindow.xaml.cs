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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try // создаем проверку на ввод формата числа
            {
                int num1 = int.Parse(TextBox1.Text);
                int num2 = int.Parse(TextBox2.Text);

                int sum = (num1 + num2);
                int proiz = (num1 * num2);

                result.Text = "Результат: " +num1+ " + "+num2+ " = "+sum  
                    +"                                                Pезультат: " + num1 + " " +" * " + num2 + " = " + proiz; 
                //result.Text = "Результат: " + num1 + "*" + num2 + "=" + proiz;
            }
            catch
            {
                MessageBox.Show("Не верные данные. Попробуйте снова!");
            }
        }
    }
}
