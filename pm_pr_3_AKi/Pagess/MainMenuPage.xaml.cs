using Microsoft.Win32;
using pm_pr_3_AKi.DB;
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

namespace pm_pr_3_AKi.Pagess
{
    /// <summary>
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public static List<Polzovatel> polzovatels = new List<Polzovatel>();
        public static Polzovatel polzovatel { get; set; }
        public static List<Tovar> Tovar { get; set; }
        public MainMenuPage(Polzovatel currentPolzovatel)
        {
            InitializeComponent();
            polzovatels = Connection.pm_pr_3_AKiEntities1.Polzovatel.ToList();
            polzovatel = currentPolzovatel;
            NameTb.Text = polzovatel.Name;
            this.DataContext = this;
            Tovar = new List<Tovar>(Connection.pm_pr_3_AKiEntities1.Tovar.ToList());
            TovarsLv.ItemsSource = Tovar;
            this.DataContext = this;

            //ImageTb.Source = polzovatels.IndexOf(currentPolzovatel.image);

        }
        private void AddTovar_Click(object sender, RoutedEventArgs e)
        {
            tovars.Name = NameeTb.Text.Trim();
            tovars.Cost = Convert.ToDecimal(CostTb.Text.Trim());

            Connection.pm_pr_3_AKiEntities1.Tovar.Add(tovars);
            Connection.pm_pr_3_AKiEntities1.SaveChanges();
            MessageBox.Show("Регистрация товара прошла успешно");
            TovarsLv.ItemsSource = new List<Tovar>(Connection.pm_pr_3_AKiEntities1.Tovar.ToList());
        }

        private void ClientsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        Tovar tovars = new Tovar();
        private void AddImage_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                tovars.image = File.ReadAllBytes(openFileDialog.FileName);
                
            }

        }
    }
}
