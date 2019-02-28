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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    class MemeImage
    {
        private string name;

        public string Name { get => name; set => name = value; }
        public MemeImage(string v1)
        {
            Name = v1;
        }
    }




    public partial class MainWindow : Window
    {
        List<MemeImage> MemeImgTable = new List<MemeImage>();
        public MainWindow()
        {
            InitializeComponent();
            //LoadMemeImgTable();
            //Butt.DataContext = MemeImgTable;
        }

        void LoadMemeImgTable()
        {
            string[] lines = System.IO.File.ReadAllLines("MemeImgNames.txt");
            foreach (string s in lines)
            {
                MemeImgTable.Add(new MemeImage(s));
            }
        }

        private void imageSwitch(object sender, MouseButtonEventArgs e)
        {
            mainImg.Source = ((Image)sender).Source ;
        }

        private void fontChange(object sender, SelectionChangedEventArgs e)
        {
            TopTextBox.FontFamily = (FontFamily)TextFonts.SelectedValue;
            BottomTextBox.FontFamily = (FontFamily)TextFonts.SelectedValue;
        }
    }
}
