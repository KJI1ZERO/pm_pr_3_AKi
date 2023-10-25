using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using pm_pr_3_AKi.DB;

namespace pm_pr_3_AKi.Pagess
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        Polzovatel polzovatel1 = new Polzovatel();
        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {


            polzovatel1.Name = NameTb.Text.Trim();
            polzovatel1.Login = LoginTb.Text.Trim();
            polzovatel1.Password = PasswordPb.Password.Trim();
            Connection.pm_pr_3_AKiEntities1.Polzovatel.Add(polzovatel1);
            Connection.pm_pr_3_AKiEntities1.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            NavigationService.GoBack();

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
          
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                polzovatel1.image = File.ReadAllBytes(openFileDialog.FileName);
                TestImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
    }
}
