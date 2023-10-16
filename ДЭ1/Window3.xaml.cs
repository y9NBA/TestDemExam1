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
using System.Xml.Linq;

namespace ДЭ1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.Group.ToList();
            Groups.ItemsSource = Singleton.DB.Group.Local;
            Groups.DisplayMemberPath = "Name";

            Singleton.DB.Person.ToList();
            FYO.ItemsSource = Singleton.DB.Person.Local;
            FYO.DisplayMemberPath = "Member_name";
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            FYO.Text = string.Empty;
            Groups.Text = string.Empty;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Singleton.DB.Student.Local.Add(new Student { Member_name = FYO.Text, Group_Student= Groups.Text});
            Singleton.DB.SaveChanges();
        }
    }
}
