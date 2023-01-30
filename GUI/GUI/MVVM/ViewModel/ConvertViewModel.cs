using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using ModernDesign.Core;
using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace GUI.MVVM.ViewModel
{
    internal class ConvertViewModel
    {
        // Save scripts
        string scriptA = @"C:\Users\edwin\OneDrive\Documentos\Universidad\Sistemas inteligentes\GUI\GUI\scripts\Average.py";
        string scriptM = @"C:\Users\edwin\OneDrive\Documentos\Universidad\Sistemas inteligentes\GUI\GUI\scripts\Midgray.py";
        string scriptL = @"C:\Users\edwin\OneDrive\Documentos\Universidad\Sistemas inteligentes\GUI\GUI\scripts\Luminosity.py";
        // Prepare python
        ScriptRuntime python3 = Python.CreateRuntime();
        
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
            ChooseFolder = new RelayCommand(o => {
                FolderBrowserDialog folderBrowserDialog= new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = false;
                folderBrowserDialog.SelectedPath = System.AppDomain.CurrentDomain.BaseDirectory;
                DialogResult result = folderBrowserDialog.ShowDialog();
                
                if (result == DialogResult.OK) 
                {
                    String sPath = folderBrowserDialog.SelectedPath;
                    folder= sPath;
                    folder = folder.Replace(@"\", "/");
                }
                System.Windows.MessageBox.Show("Path: "+folder);
            });

            ChoosePhoto = new RelayCommand(o => 
            { 
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.png;)|*.jpg; *.jpeg; *.png;";

                if (open.ShowDialog() == DialogResult.OK)
                {  
                    String sPath = open.FileName;
                    photo= sPath;
                    photo = photo.Replace(@"\", "/");
                }
                System.Windows.MessageBox.Show("Photo: " + photo);
            });

            Average = new RelayCommand(o => 
            {
                if (photo != string.Empty && folder != string.Empty)
                {
                    dynamic program = python3.UseFile(scriptA);
                    program.save(this.photo, this.folder, "Average");
                    System.Windows.MessageBox.Show("Listo");
                }
                else
                {
                    System.Windows.MessageBox.Show("No estan completos los campos");
                }
            });

            Midgray = new RelayCommand(o => 
            {
                if (photo != string.Empty && folder != string.Empty)
                {
                    dynamic program = python3.UseFile(scriptM);
                    program.save(this.photo, this.folder, "Midgray");
                    System.Windows.MessageBox.Show("Listo");
                }
                else
                {
                    System.Windows.MessageBox.Show("No estan completos los campos");
                }
            });

            Luminosity = new RelayCommand(o => {
                if (photo != string.Empty && folder != string.Empty)
                {
                    dynamic program = python3.UseFile(scriptL);
                    program.save(this.photo, this.folder);
                    System.Windows.MessageBox.Show("Listo");
                }
                else
                {
                    System.Windows.MessageBox.Show("No estan completos los campos");
                }
            });
        }
    }
}
