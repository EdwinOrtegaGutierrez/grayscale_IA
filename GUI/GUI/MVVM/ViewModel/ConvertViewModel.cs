using CliWrap;
using ModernDesign.Core;
using System;
using System.Windows.Forms;
using CliWrap.Buffered;
using System.Threading.Tasks;

namespace GUI.MVVM.ViewModel
{
    internal class ConvertViewModel
    {
        // Commands
        public RelayCommand ChooseFolder { get; set; }
        public RelayCommand ChoosePhoto { get; set; }
        public RelayCommand Average { get; set; }
        public RelayCommand Midgray { get; set; }
        public RelayCommand Luminosity { get; set; }

        public string folder = string.Empty;
        public string photo = string.Empty;

        public ConvertViewModel()
        {
            ChooseFolder = new RelayCommand(o =>
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    String sPath = folderBrowserDialog.SelectedPath;
                    folder = sPath;
                    folder = folder.Replace(@"\", "/");
                }
                System.Windows.MessageBox.Show("Path: " + folder);
            });

            ChoosePhoto = new RelayCommand(o =>
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    String sPath = open.FileName;
                    photo = sPath;
                    photo = photo.Replace(@"\", "/");
                }
                System.Windows.MessageBox.Show("Photo: " + photo);
            });

            Average = new RelayCommand(async o => 
            {
                if (photo != string.Empty && folder != string.Empty)
                {
                    string argumento = "Average.py " + photo + " " + folder;
                    var program = await Cli.Wrap("python")
                                        .WithValidation(CommandResultValidation.None)
                                        .WithWorkingDirectory(@"C:\Users\edwin\OneDrive\Documentos\Universidad\grayscale_IA\GUI\GUI\scripts\")
                                        .WithArguments(argumento)
                                        .ExecuteBufferedAsync();
                    System.Windows.MessageBox.Show("TU FOTO ESTA LISTA!");
                }
                else 
                {
                    System.Windows.MessageBox.Show("Los campos no estan llenos");
                }
            });
            Midgray = new RelayCommand(async o =>
            {
                if (photo != string.Empty && folder != string.Empty)
                {
                    string argumento = "Midgray.py " + photo + " " + folder;
                    var program = await Cli.Wrap("python")
                                        .WithValidation(CommandResultValidation.None)
                                        .WithWorkingDirectory(@"C:\Users\edwin\OneDrive\Documentos\Universidad\grayscale_IA\GUI\GUI\scripts\")
                                        .WithArguments(argumento)
                                        .ExecuteBufferedAsync();
                    System.Windows.MessageBox.Show("TU FOTO ESTA LISTA!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Los campos no estan llenos");
                }
            });

            Luminosity = new RelayCommand(async o =>
            {
                if (photo != string.Empty && folder != string.Empty)
                {
                    string argumento = "Luminosity.py " + photo + " " + folder;
                    var program = await Cli.Wrap("python")
                                        .WithValidation(CommandResultValidation.None)
                                        .WithWorkingDirectory(@"C:\Users\edwin\OneDrive\Documentos\Universidad\grayscale_IA\GUI\GUI\scripts\")
                                        .WithArguments(argumento)
                                        .ExecuteBufferedAsync();
                    System.Windows.MessageBox.Show("TU FOTO ESTA LISTA!");
                }
                else
                {
                    System.Windows.MessageBox.Show("Los campos no estan llenos");
                }
            });
        }
    }
}
