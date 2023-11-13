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
using System.Windows.Shapes;

namespace ДЭ1
{
    /// <summary>
    /// Логика взаимодействия для WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.User.ToList();
            Singleton.DB.Person.ToList();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (Last_Name.Text == "" || First_Name.Text == "" || Middle_Name.Text == ""
                || Login.Text == "" || (Password.Password == "" && PasswordCheck.Password == ""))
            {
                MessageBox.Show("Введены не все данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Password.Password != PasswordCheck.Password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибочка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = new User();
            Person person = new Person();

            user.login = Login.Text;
            user.password = Password.Password;

            person.Last_name = Last_Name.Text;
            person.First_name = First_Name.Text;
            person.Middle_name = Middle_Name.Text;

            user.Person.Add(person);

            Singleton.DB.User.Local.Add(user);
            Singleton.DB.SaveChanges();
            Singleton.DB.User.Local.ToList();
            Singleton.DB.Person.Local.Add(person);
            Singleton.DB.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались!", "Итог регистрации", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
