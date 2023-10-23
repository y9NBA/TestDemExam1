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
    /// Логика взаимодействия для WindowEditRolesUser.xaml
    /// </summary>
    public partial class WindowEditRolesUser : Window
    {
        public WindowEditRolesUser()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.User.ToList();
            Singleton.DB.Role.ToList();
            Names.ItemsSource = Singleton.DB.User.Local;
        }

        private void Take_Lists_Roles()
        {
            User user = Names.SelectedItem as User;
            List<Role> roles_on = new List<Role>();
            List<Role> roles_off = Singleton.DB.Role.ToList();

            foreach (Role role in user.Role)
            {
                roles_on.Add(role);
                if (roles_off.Contains(role))
                    roles_off.Remove(role);
            }

            Roles_on.ItemsSource = roles_on;
            Roles_off.ItemsSource = roles_off;
        }

        private void Names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Names.SelectedItem == null)
                return;

            Take_Lists_Roles();
        }

        private void Btn_Add_One_Role_Click(object sender, RoutedEventArgs e)
        {
            User user = Names.SelectedItem as User;
            Role role = Roles_off.SelectedItem as Role;

            if (role == null || user == null) return;

            user.Role.Add(role);

            Take_Lists_Roles();
        }

        private void Btn_Add_All_Role_Click(object sender, RoutedEventArgs e)
        {
            User user = Names.SelectedItem as User;

            if (user == null) return;

            foreach(Role role in Singleton.DB.Role.ToList())
            {
                if (!user.Role.Contains(role))
                    user.Role.Add(role);
            }

            Take_Lists_Roles();
        }
        
        private void Btn_Delete_One_Role_Click(object sender, RoutedEventArgs e)
        {
            User user = Names.SelectedItem as User;
            Role role = Roles_on.SelectedItem as Role;

            if (role == null || user == null) return;

            user.Role.Remove(role);

            Take_Lists_Roles();
        }

        private void Btn_Delete_All_Role_Click(object sender, RoutedEventArgs e)
        {
            User user = Names.SelectedItem as User;

            if (user == null) return;

            foreach (Role role in Singleton.DB.Role.ToList())
            {
                if (user.Role.Contains(role))
                    user.Role.Remove(role);
            }

            Take_Lists_Roles();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Singleton.DB.SaveChanges();
        }
    }
}
