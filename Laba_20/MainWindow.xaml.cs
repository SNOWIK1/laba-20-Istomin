using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileHelpClass;

namespace Laba_20
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Stroke> undidStrokes = new List<Stroke>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Функция находится в доработке", "Laba 20 by Istomin", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Лабораторная работа №20\nАвтор: Истомин Дмитрий\nГруппа: 11ИС-273\nНомер компьютера: 2", "Laba 20 by Istomin", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            FileHelpClass.OpenSaver.WriteFile(picBox);
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            FileHelpClass.OpenSaver.OpenFile(picBox);
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            if (picBox.Strokes.Count > 0)
            {
                Stroke stroke = picBox.Strokes[picBox.Strokes.Count - 1];
                undidStrokes.Add(stroke);
                picBox.Strokes.Remove(stroke);
            }
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            if (undidStrokes.Count > 0)
            {
                Stroke stroke = undidStrokes[undidStrokes.Count - 1];
                undidStrokes.Remove(stroke);
                picBox.Strokes.Add(stroke);
            }
        }

    }
}
