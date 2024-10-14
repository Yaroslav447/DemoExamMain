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

namespace Lab1._2
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
        List<string> people = new List<string>();// создаем список т.к. списк , так как массив должен быть заранее известен по размеру
        string name;// переменная в которой храниться данные поля "имя"

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            name = inputtext.Text;
            if (name != "")// проверка на пустое поле
            {
                if(people.Contains(name))// проверка на повторяющиеся эл. в списке
                {
                    inputtext.Clear();
                    MessageBox.Show("Имя уже существует в списке");

                }
                else
                {
                    people.Add(name);// добавление обьекста в список
                    inputtext.Clear();// очистка поля в которое мы вводили имя
                    outtext.Text = string.Join(Environment.NewLine, people); // вывод в всего списка в текстблок
                }
            }
            else
            {
                MessageBox.Show("Поле имя пустое!");
            }
            
            
            //for (int i = 0; i < people.Count; i++)
            //    {
            //        outtext.Text = i.ToString();
            //    }
        }
    }
}
