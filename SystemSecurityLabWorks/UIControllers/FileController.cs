using Microsoft.Win32;
using Spire.Doc;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Xceed.Words.NET;

namespace SystemSecurityLabWorks.UIControllers
{
    internal class FileController : IFileController
    {
        public void NewFile(TextBox file)
        {
            file.Text = "";
        }

        public void OpenFile(TextBox file)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "Text files (*.txt; *.doc; *.docx)|*.txt;*.doc;*.docx|All files (*.*)|*.*",
            };
            if (openFile.ShowDialog() == true)
            {
                NewFile(file);
                if (Path.GetExtension(openFile.FileName) == ".doc" ||
                    Path.GetExtension(openFile.FileName) == ".docx")
                {
                    Document doc = new Document();
                    doc.LoadFromFile(openFile.FileName);
                    PrintFile(file, doc.GetText());
                }
                else if (Path.GetExtension(openFile.FileName) == ".txt")
                {
                    PrintFile(file, File.ReadAllText(openFile.FileName));
                }
                else
                {
                    MessageBox.Show("Unknown file extension. It is only .txt, " +
                        ".doc, .docx provided");
                }
            }
        }

        public void PrintFile(TextBox file, string text)
        {
            NewFile(file);
            file.AppendText(text);
            //MessageBox.Show(answer);
        }

        public void SaveFile(TextBox file, string text)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|Microsoft Word document (*.docx)|*.docx|All files (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),

            };
            if (saveFile.ShowDialog() == true)
            {
                if (Path.GetExtension(saveFile.FileName) == ".txt")
                {
                    File.WriteAllText(saveFile.FileName, text);
                }
                else if (Path.GetExtension(saveFile.FileName) == ".doc" ||
                    Path.GetExtension(saveFile.FileName) == ".docx")
                {
                    var doc = DocX.Create(saveFile.FileName);
                    doc.InsertParagraph(text);
                    doc.Save();

                }
            }
        }
    }
}
