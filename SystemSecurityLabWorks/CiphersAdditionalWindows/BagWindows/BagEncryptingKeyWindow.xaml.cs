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
using SystemSecurityLabWorks.Cipher;
using SystemSecurityLabWorks.UIControllers;

namespace SystemSecurityLabWorks.CiphersAdditionalWindows.BagWindows
{
    /// <summary>
    /// Interaction logic for BagEncryptingKeyWindow.xaml
    /// </summary>
    public partial class BagEncryptingKeyWindow : Window
    {
        public BagEncryptingKeyWindow()
        {
            InitializeComponent();
        }

        private void EncryptingButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = CipherManager.mainWindow;
            string input = w.WorkingText.Text;
            var answer = CipherManager.Encrypt(input, KeyText.Text, "Bag");
            var fileController = new FileController();
            fileController.PrintFile(w.WorkingText, answer);
            Close();
        }
    }
}
