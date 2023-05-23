using SystemSecurityLabWorks.Cipher;
using System.Windows;
using SystemSecurityLabWorks.UIControllers;
using System.Windows.Controls;
using SystemSecurityLabWorks.CiphersAdditionalWindows.BagWindows;
using System.Runtime.DesignerServices;

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
                TritemiusSloganRadioButton, XORRadioButton, BookRadioButton, 
                DesCBCRadioButton, DesECBRadioButton, DesCFBRadioButton,
            ThreeCBCRadioButton, ThreeECBRadioButton, ThreeCFBRadioButton,
            AesCBCRadioButton, AesECBRadioButton, AesCFBRadioButton, };

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

        private void BagRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BagGenerateKeyButton.Visibility = Visibility.Visible;
            BagEncryptingKeyButton.Visibility = Visibility.Visible;
            BagDecryptingKeyButton.Visibility = Visibility.Visible;
            KeyText.Visibility = Visibility.Hidden;
        }

        private void BagRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            BagGenerateKeyButton.Visibility = Visibility.Hidden;
            BagEncryptingKeyButton.Visibility = Visibility.Hidden;
            BagDecryptingKeyButton.Visibility = Visibility.Hidden;
            KeyText.Visibility = Visibility.Visible;
        }

        private void BagGenerateKeyButton_Click(object sender, RoutedEventArgs e)
        {
            BagGenerateKeyWindow window = new BagGenerateKeyWindow();
            window.Show();
        }

        private void BagEncryptingKeyButton_Click(object sender, RoutedEventArgs e)
        {
            BagEncryptingKeyWindow window = new BagEncryptingKeyWindow();
            window.Show();
        }

        private void BagDecryptingKeyButton_Click(object sender, RoutedEventArgs e)
        {
            BagDecryptingKeyWindow window = new BagDecryptingKeyWindow();
            window.Show();
        }
    }
}
