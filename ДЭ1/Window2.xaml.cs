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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Singleton.DB.Group.ToList();
            Group.ItemsSource = Singleton.DB.Group.Local;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Singleton.DB.SaveChanges();
        }

        private void Btn_Add_Student_Form_Click(object sender, RoutedEventArgs e)
        {
            Singleton.DB.SaveChanges();
            Window3 window3 = new Window3();
            window3.ShowDialog();
            
        }
    }
}
