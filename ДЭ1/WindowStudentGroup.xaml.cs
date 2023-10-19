using System;
using System.Collections.Generic;
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
            FYO.ItemsSource = Singleton.DB.Person.Local;
            Groups.ItemsSource = Singleton.DB.Group.Local;
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (FYO.SelectedItem == null || Groups.SelectedItem == null)
                return;

            Singleton.DB.Student.ToList();
            var students = Singleton.DB.Student.Local;

            Student studentLocal = new Student();
            studentLocal.Member_name = FYO.Text;
            studentLocal.Group_Student = Groups.Text;

            foreach (Student student in students) 
            {
                if (student.Member_name == studentLocal.Member_name)
                {
                    if (MessageBox.Show($"Такой студент уже зачислен в группу {student.Group_Student}.\n Хотите перевести студента в другую группу?", "Ошибочка!", MessageBoxButton.YesNo, 0, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        student.Group_Student = studentLocal.Group_Student;
                        Singleton.DB.SaveChanges();
                    }
                    else
                    {
                        Singleton.DB.Student.Local.Add(studentLocal);
                        Singleton.DB.SaveChanges();
                    }
                    return;
                }
            }
        }
    }
}
