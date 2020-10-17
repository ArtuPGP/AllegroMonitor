using AllegroMonitorClassLibrary;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AllegroMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public ObservableCollection<Item> items { get; set; } = new ObservableCollection<Item>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ApiHelper.ClientInitialization();
        }

        private async void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            bool resultsFound = false;
            items.Clear();
            ApiHelper.ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiHelper.ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", $"{ AccessTokenModel.accessToken }");

            foreach (char c in searchBar.Text)
            {
                if (c > 127)
                {
                    items.Add(new Item("", "Polskie znaki we frazie", "", "", "", new BitmapImage(new Uri(@"pack://application:,,,/Images/noResult.png"))));
                    return;
                }
            }

            string responseString = await Offer.GetOffer(searchBar.Text, minimumPrice.Text, maximumPrice.Text, TypeSelector.selectType(sortType.SelectedIndex));
            var res = JsonConvert.DeserializeObject<ResultItemsModel>(responseString);

            try
            {
                for (int i = 0; i < 60; i++)
                {
                    var uri = new Uri(res.items.promoted[i].images[0].url, UriKind.Absolute);
                    BitmapImage bitmapImage = new BitmapImage(uri);
                    items.Add(new Item(res.items.promoted[i].id, res.items.promoted[i].name, res.items.promoted[i].sellingMode.price.amount, res.items.promoted[i].stock.available,
                                        res.items.promoted[i].delivery.lowestPrice.amount, bitmapImage));
                    resultsFound = true;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (!resultsFound)
                {
                    items.Add(new Item("", "Brak wyników", "", "", "", new BitmapImage(new Uri(@"pack://application:,,,/Images/noResult.png"))));
                }
            }
            resultsFound = false;
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TokenModel tokenModel = await Token.GetToken();
                AccessTokenModel.accessToken = tokenModel.Access_token;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void goToAllegroBtn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Item item = button.DataContext as Item;
            int index = items.IndexOf(item);
            Process.Start("explorer", $"https://allegro.pl/oferta/{ items[index].id }");
        }
    }
}
