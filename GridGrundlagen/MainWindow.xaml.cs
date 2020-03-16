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
using System.Windows.Threading;

namespace GridGrundlagen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _blendeHinweisAusTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            _blendeHinweisAusTimer.Tick += BlendeHinweisAus;
        }

        private void BlendeHinweisAus(object sender, EventArgs e)
        {
            _blendeHinweisAusTimer.Stop();
            HinweisLabel.Visibility = Visibility.Hidden;
        }
        private void ZeigeHinweis(string hinweis, int ausblendeZeitInSekunden = 0)
        {

            HinweisLabel.Content = hinweis;
            HinweisLabel.Visibility = Visibility.Visible;

            if ((ausblendeZeitInSekunden > 0) && (!_blendeHinweisAusTimer.IsEnabled))
            {
                _blendeHinweisAusTimer.Interval = TimeSpan.FromSeconds(ausblendeZeitInSekunden);
                _blendeHinweisAusTimer.Start();
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string url = YoutubeUrlTextBox.Text;
            string videoId = "ugji-_yWoRk"; //falls keine andere videoId gefunden werden kann

            if (url == string.Empty)
            {
                ZeigeHinweis("Bitte gib eine YouTube-URL in die weiße Textbox ein!", 5);
            }
            else if (url.Contains("youtu.be"))
            {
                string[] elements = url.Split('/');
                videoId = elements.Last();
            }
            else if (url.Contains("youtube.com"))
            {
                int startIndex = url.IndexOf("v=") + 2;
                int endIndex = url.IndexOf("&");
                videoId = url.Substring(startIndex, endIndex - startIndex);
            }

            YouTubePlayer.Address = $"https://www.youtube.com/embed/{videoId}?start=68&fs=1";
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            ZeigeHinweis("Dieser Button hat noch keine Funktion!", 5);
        }
    }
}
