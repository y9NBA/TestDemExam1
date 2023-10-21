using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для StudentGroup.xaml
    /// </summary>
    public partial class StudentGroup : Window
    {
        public StudentGroup()
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

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Person person = Persons.SelectedItem as Person;
            Group group = Groups.SelectedItem as Group;

            if (person == null)
                return;

            person.Group.Clear();

            if (group != null)
                person.Group.Add(group);

            Singleton.DB.SaveChanges();
        }

        private void Persons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person person = Persons.SelectedItem as Person;

            if (person == null) 
                return;

            Groups.SelectedItem = person.Group.FirstOrDefault();
        }
    }
}
