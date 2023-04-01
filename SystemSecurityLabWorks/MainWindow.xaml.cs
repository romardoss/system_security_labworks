using SystemSecurityLabWorks.Cipher;
using System.Windows;
using SystemSecurityLabWorks.UIControllers;
using System.Windows.Controls;

namespace SystemSecurityLabWorks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.OpenFile(WorkingText);
        }

        private void NewFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.NewFile(WorkingText);
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = WorkingText.Text;
            var answer = CipherManager.Encrypt(input, KeyText.Text, CipherChecked());
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = WorkingText.Text;
            var answer = CipherManager.Decrypt(input, KeyText.Text, CipherChecked());
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
        }

        private string CipherChecked()
        {
            RadioButton[] radioButtons = { CaesarRadioButton, 
                TritemiusLinearRadioButton, TritemiusSquaireRadioButton,
                TritemiusSloganRadioButton};

            foreach (var item in radioButtons)
            {
                if((bool)item.IsChecked) 
                {
                    return item.Content.ToString();
                }
            }
            return null;
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            var file = new FileController();
            file.SaveFile(WorkingText, WorkingText.Text);
        }
    }
}
