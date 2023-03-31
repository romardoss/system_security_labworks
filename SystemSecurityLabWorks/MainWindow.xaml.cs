using SystemSecurityLabWorks.Cipher;
using System.Windows;
using SystemSecurityLabWorks.UIControllers;

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
            var answer = CipherManager.Encrypt(input, KeyText.Text);
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string input = WorkingText.Text;
            var answer = CipherManager.Decrypt(input, KeyText.Text);
            var fileController = new FileController();
            fileController.PrintFile(WorkingText, answer);
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
