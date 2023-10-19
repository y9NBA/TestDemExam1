using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UserRole.xaml
    /// </summary>
    public partial class UserRole : Window
    {
        public UserRole()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.User.ToList();
            Singleton.DB.Role.ToList();
            Names.ItemsSource = Singleton.DB.User.Local;
            Roles.ItemsSource = Singleton.DB.Role.Local;
            
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            User user = Names.SelectedItem as User;
            Role role = Roles.SelectedItem as Role;

            if (user == null )
                return;

            user.Role.Clear();

            if (role != null)
                user.Role.Add(role);

            Singleton.DB.SaveChanges();
        }

        private void Btn_Clear_Roles_Click(object sender, RoutedEventArgs e)
        {
            Roles.SelectedItem = null; 
        }

        private void Names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User user = Names.SelectedItem as User;

            if (user == null) return;

            Roles.SelectedItem = user.Role.FirstOrDefault();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
