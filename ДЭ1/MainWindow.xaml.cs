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

namespace ДЭ1
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

        private void LoginBtr_Click(object sender, RoutedEventArgs e)
        {
            List <User> users = Singleton.DB.User.Where(user => user.login == login.Text && user.password == password.Password).ToList();

            if ( users.Count == 1)
            {
                User user = users[0];
                List <string> roles = new List<string>();
                string separator = ", ";
                foreach (Role role in user.Role)
                {
                    roles.Add(role.Name);
                }
                MessageBox.Show(string.Join(separator, roles), "Ваши роли:");
                if (roles.Contains("Зав. Отделением"))
                {
                    ListGroups listGroups = new ListGroups();
                    Hide();
                    listGroups.ShowDialog();
                    Show();
                }
                else if (roles.Contains("Администратор"))
                {
                    UserRole userRole = new UserRole();
                    Hide();
                    userRole.ShowDialog();
                    Show();
                }
                else
                {
                    ListUsers listUsers = new ListUsers();
                    Hide();
                    listUsers.ShowDialog();
                    Show();
                }
            }
        }
    }
}
