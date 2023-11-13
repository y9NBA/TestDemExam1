using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ДЭ1
{
    /// <summary>
    /// Логика взаимодействия для WindowListStudent.xaml
    /// </summary>
    public partial class WindowListStudent : Window
    {
        public WindowListStudent()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AcademicYear current = Get_CurrentYear();
            Year.ItemsSource = Singleton.DB.AcademicLoad.Select(academicLoad => academicLoad.AcademicYear).Distinct().ToList();
            if (Year.Items.Cast<AcademicYear>().ToList().Find(academicY => academicY == current) != null)
            {
                Year.SelectedItem = current;
            }
        }
        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AcademicYear year = Year.SelectedItem as AcademicYear;
            if (year == null)
            {
                Students.ItemsSource = null;
                return;
            }

            Groups.ItemsSource = Singleton.DB.AcademicLoad.Where(academ => academ.AcademicYearID == year.ID).Select(academ => academ.Group).Distinct().ToList();
            Disciplins.ItemsSource = Singleton.DB.AcademicLoad.Where(academ => academ.AcademicYearID == year.ID).Select(academ => academ.Discipline).Distinct().ToList();

            Students_SelectionChanged();
        }

        private void Groups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AcademicYear year = Year.SelectedItem as AcademicYear;
            Group group = Groups.SelectedItem as Group;
            if (group == null || year == null)
            {
                Students.ItemsSource = null;
                return;
            }

            Students.ItemsSource = group.Person;
            Disciplins.ItemsSource = Singleton.DB.AcademicLoad.Where(academ => academ.AcademicYearID == year.ID && academ.GroupID == group.ID).Select(academ => academ.Discipline).Distinct().ToList();

            Students_SelectionChanged();
        }

        private void Disciplins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AcademicYear year = Year.SelectedItem as AcademicYear;
            Discipline discipline = Disciplins.SelectedItem as Discipline;
            if (discipline == null || year == null)
            {
                Students.ItemsSource = null;
                return;
            }

            Groups.ItemsSource = Singleton.DB.AcademicLoad.Where(academ => academ.AcademicYearID == year.ID && academ.DisciplineID == discipline.ID).Select(academ => academ.Group).Distinct().ToList();

            Students_SelectionChanged();
        }

        private void Students_SelectionChanged()
        {
            AcademicYear year = Year.SelectedItem as AcademicYear;
            Discipline discipline = Disciplins.SelectedItem as Discipline;
            Group group = Groups.SelectedItem as Group;

            if (year == null || discipline == null || group == null) return;

            //Students.ItemsSource = Singleton.DB.AcademicLoad.Where(academicLoad => academicLoad.AcademicYearID == year.ID && academicLoad.DisciplineID == discipline.ID && academicLoad.GroupID == group.ID).ToList().Count() != 0 ? group.Person : null;
        }

        private AcademicYear Get_CurrentYear()
        {
            List<AcademicYear> items = Singleton.DB.AcademicYear.ToList();

            DateTime currentDate = DateTime.UtcNow;

            Year.ItemsSource = items;

           return currentDate.Month >= 9 ?
                items.Where(year => year.StartYear == currentDate.Year).Last() :
                items.Where(year => year.EndYear == currentDate.Year).Last();
        }
    }
}
