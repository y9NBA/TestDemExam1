using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Логика взаимодействия для WindowPersonGroup.xaml
    /// </summary>
    public partial class WindowPersonGroup : Window
    {
        public WindowPersonGroup()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.Person.ToList();
            Singleton.DB.Group.ToList();
            Persons.ItemsSource = Singleton.DB.Person.Local;
            Groups.ItemsSource = Singleton.DB.Group.Local;
        }

        private void Persons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persons.ItemsSource = Persons.Items.Cast<Person>().Where(person => person.Group.Count == 0).ToList();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Group group = Groups.SelectedItem as Group;

            if (group == null) return;

            List<Person> persons = Persons.Items.Cast<Person>().Where(person => person.Group.Count == 0).ToList() as List<Person>;

            foreach (var person in persons)
            {
                person.Group.Add(group);
            }

            Singleton.DB.SaveChanges();
        }

        private void Check_st_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCheckBoxColumn check = Check_st as DataGridCheckBoxColumn;
            if (CheckBox.CheckedEvent.Equals(check)) {
                Person person = Persons.SelectedItems as Person;
            }
        }
    }
}
