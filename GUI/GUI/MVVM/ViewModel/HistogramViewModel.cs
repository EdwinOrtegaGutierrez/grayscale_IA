using CliWrap;
using ModernDesign.Core;
using System;
using System.Windows.Forms;
using CliWrap.Buffered;

namespace GUI.MVVM.ViewModel
{
    internal class HistogramViewModel
    {
        public string Img_histogram { get; set; }
        public RelayCommand ChoosePhoto { get; set; }
        public string folder = "C:/Users/edwin/OneDrive/Imágenes/histogram.png";
        public string photo = string.Empty;
        
        public HistogramViewModel(){
            Img_histogram = "C:\\Users\\edwin\\OneDrive\\Documentos\\Universidad\\grayscale_IA\\GUI\\GUI\\Histogram_Images\\hBG.png";

            ChoosePhoto = new RelayCommand(async o =>
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    String sPath = open.FileName;
                    photo = sPath;
                    photo = photo.Replace(@"\", "/");
                }

                System.Windows.MessageBox.Show(photo);
                string argumento = "Histogram.py " + photo;
                var program = await Cli.Wrap("python")
                                    .WithValidation(CommandResultValidation.None)
                                    .WithWorkingDirectory(@"C:\Users\edwin\OneDrive\Documentos\Universidad\grayscale_IA\GUI\GUI\scripts\")
                                    .WithArguments(argumento)
                                    .ExecuteBufferedAsync();
                System.Windows.MessageBox.Show(program.ToString());
                Img_histogram = folder;
            });
        }
    }
}
