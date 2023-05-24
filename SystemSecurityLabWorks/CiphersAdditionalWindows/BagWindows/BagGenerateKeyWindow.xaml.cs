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
using SystemSecurityLabWorks.Cipher.BagCipher;

namespace SystemSecurityLabWorks.CiphersAdditionalWindows.BagWindows
{
    /// <summary>
    /// Interaction logic for BagGenerateKeyWindow.xaml
    /// </summary>
    public partial class BagGenerateKeyWindow : Window
    {
        public BagGenerateKeyWindow()
        {
            InitializeComponent();
        }

        private void GenerateKeyBagWindowButton_Click(object sender, RoutedEventArgs e)
        {
            BagGenerateKey genKey = new BagGenerateKey();
            if (!int.TryParse(KeySizeTextBox.Text, out int size))
            {
                MessageBox.Show("The input must be a number. Default number is 5 elements");
            }
            genKey.KeySize = size;
            genKey.GenerateKey();
            PrivateKeyGenerateTextBox.Text = genKey.GetStringOfSequence(genKey.PrivateSequence);
            BagMTextBox.Text = genKey.M.ToString();
            BagTTextBox.Text = genKey.T.ToString();
            PublicKeyGenerateTextBox.Text = genKey.GetStringOfSequence(genKey.PublicSequence);
        }

        private void CopyTextPublicKeyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PublicKeyGenerateTextBox.Text);
        }

        private void CopyTextPrivateKeyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PrivateKeyGenerateTextBox.Text);
        }

        private void CopyTextMKeyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(BagMTextBox.Text);
        }

        private void CopyTextTKeyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(BagTTextBox.Text);
        }
    }
}
