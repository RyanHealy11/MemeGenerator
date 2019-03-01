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
using System.Text.RegularExpressions;


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
    class DefaultText
    {
        private string Top;
        private string Bottom;

        public string top { get => Top; set => Top = value; }
        public string bottom { get => Bottom; set => Bottom = value; }

        public DefaultText(string toptext, string bottomtext)
        {
            top = toptext;
            bottom = bottomtext;
        }
    }



    public partial class MainWindow : Window
    {
        List<DefaultText> SuccessText = new List<DefaultText>();
        List<DefaultText> FryText = new List<DefaultText>();
        List<DefaultText> ThinkText = new List<DefaultText>();
        List<DefaultText> HighText = new List<DefaultText>();
        List<MemeImage> MemeImgTable = new List<MemeImage>();
        public MainWindow()
        {
            InitializeComponent();
            LoadSuccessText();
            LoadFryText();
            LoadHighText();
            LoadThinkText();
            
            Success.DataContext = SuccessText;
            Think.DataContext = ThinkText;
            Fry.DataContext = FryText;
            High.DataContext = HighText;
        }

        void LoadMemeImgTable()
        {
            string[] lines = System.IO.File.ReadAllLines("MemeImgNames.txt");
            foreach (string s in lines)
            {
                MemeImgTable.Add(new MemeImage(s));
            }
        }

        void LoadSuccessText()
        {
            string[] tmpvals;
            string[] lines = System.IO.File.ReadAllLines("SuccessKidText.txt");
            foreach (string s in lines)
            {
                tmpvals = s.Split(',');
                SuccessText.Add(new DefaultText(tmpvals[0], tmpvals[1])); 
            }
        }
        void LoadFryText()
        {
            string[] tmpvals;
            string[] lines = System.IO.File.ReadAllLines("NotSureFryText.txt");
            foreach (string s in lines)
            {
                tmpvals = s.Split(',');
                FryText.Add(new DefaultText(tmpvals[0], tmpvals[1]));
            }
        }
        void LoadThinkText()
        {
            string[] tmpvals;
            string[] lines = System.IO.File.ReadAllLines("ThinkText.txt");
            foreach (string s in lines)
            {
                tmpvals = s.Split(',');
                ThinkText.Add(new DefaultText(tmpvals[0], tmpvals[1]));
            }
        }
        void LoadHighText()
        {
            string[] tmpvals;
            string[] lines = System.IO.File.ReadAllLines("TooHighText.txt");
            foreach (string s in lines)
            {
                tmpvals = s.Split(',');
                HighText.Add(new DefaultText(tmpvals[0], tmpvals[1]));
            }
        }
        private void imageSwitch(object sender, MouseButtonEventArgs e)
        {
            mainImg.Source = ((Image)sender).Source ;
        }

        private void fontChange(object sender, SelectionChangedEventArgs e)
        {
            if (TopTextBox != null && BottomTextBox != null)
            {
                TopTextBox.FontFamily = (FontFamily)TextFonts.SelectedValue;
                BottomTextBox.FontFamily = (FontFamily)TextFonts.SelectedValue;
            }
        }
        private void TfontChange(object sender, SelectionChangedEventArgs e)
        {
            if (TopTextBox != null )
            {
                TopTextBox.FontFamily = (FontFamily)TTextFonts.SelectedValue;               
            }
        }
        private void BfontChange(object sender, SelectionChangedEventArgs e)
        {
            if (BottomTextBox != null)
            {
                BottomTextBox.FontFamily = (FontFamily)BTextFonts.SelectedValue;
            }
        }

        private void FontSizeChange(object sender, TextChangedEventArgs e)
        {
            if (TopTextBox != null && BottomTextBox != null)
            {
                if (Regex.IsMatch(FontSize.Text, @"^[0-9]+$"))
                {
                    TopTextBox.FontSize = Convert.ToInt32(FontSize.Text);
                    BottomTextBox.FontSize = Convert.ToInt32(FontSize.Text);
                }
            }
        }
        private void TFontSizeChange(object sender, TextChangedEventArgs e)
        {
            if (TopTextBox != null)
            {
                if (Regex.IsMatch(FontSize.Text, @"^[0-9]+$"))
                {
                    TopTextBox.FontSize = Convert.ToInt32(TFontSize.Text);                  
                }
            }
        }
        private void BFontSizeChange(object sender, TextChangedEventArgs e)
        {
            if (BottomTextBox != null)
            {
                if (Regex.IsMatch(FontSize.Text, @"^[0-9]+$"))
                {
                    BottomTextBox.FontSize = Convert.ToInt32(BFontSize.Text);
                }
            }
        }

        private void ColorChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)RedSlider.Value, (byte)GreenSlider.Value, (byte)BlueSlider.Value);

            TopTextBox.Foreground = new SolidColorBrush(color);
            BottomTextBox.Foreground = new SolidColorBrush(color);
        }

        private void TColorChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)TRedSlider.Value, (byte)TGreenSlider.Value, (byte)TBlueSlider.Value);

            TopTextBox.Foreground = new SolidColorBrush(color);
        }

        private void BColorChange(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)BRedSlider.Value, (byte)BGreenSlider.Value, (byte)BBlueSlider.Value);

            BottomTextBox.Foreground = new SolidColorBrush(color);
        }

        private void ChangeText(object sender, MouseButtonEventArgs e)
        {         
            TopTextBox.Text = ((TextBlock)((StackPanel)sender).Children[0]).Text;
            BottomTextBox.Text = ((TextBlock)((StackPanel)sender).Children[1]).Text;
        }
    }
}
