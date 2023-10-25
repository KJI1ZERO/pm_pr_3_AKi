using pm_pr_3_AKi.DB;
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

namespace pm_pr_3_AKi.Pagess
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Polzovatel> polzovatels = new List<Polzovatel>();
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();
            List<Polzovatel> Polzovatel = new List<Polzovatel>(Connection.pm_pr_3_AKiEntities1.Polzovatel.ToList());
            Polzovatel currentPolzovatel = Polzovatel.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentPolzovatel != null)
            {
                NavigationService.Navigate(new MainMenuPage(currentPolzovatel));
            }
            else
            {
                var dan = "Перейдем на страницу регистрации?";
                if (MessageBox.Show(dan, "Неправильный логин или пароль", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    loginTb.Text = "";
                    passwordTb.Password = "";
                }
                else
                {
                    NavigationService.Navigate(new RegistrationPage());
                }
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }


    }
}
