using System.Windows.Controls;

namespace SystemSecurityLabWorks.UIControllers
{
    internal interface IFileController
    {
        void OpenFile(TextBox file);
        void SaveFile(TextBox file, string text);
        void NewFile(TextBox file);
        void PrintFile(TextBox file, string text);
    }
}
