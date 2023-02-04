using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace SzínKeverő;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void sli_ValueChanged() => rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb((byte)sliRed.Value, (byte)sliGreen.Value, (byte)sliBlue.Value));
    private void sliRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        sli_ValueChanged();
        tbRed.Content = $"Piros: {(byte)sliRed.Value}";
    }
    private void sliGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        sli_ValueChanged();
        lbGreen.Content = $"Zöld: {(byte)sliGreen.Value}";
    }
    private void sliBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        sli_ValueChanged();
        lbBlue.Content = $"Kék: {(byte)sliBlue.Value}";
    }


    private void btnRogzit_Click(object sender, RoutedEventArgs e)
    {
        string szin = $"{(byte)sliRed.Value};{(byte)sliGreen.Value};{(byte)sliBlue.Value}";
        if (!lbSzinek.Items.Contains(szin))
            lbSzinek.Items.Add(szin);
        else
            MessageBox.Show("Már van ilyen szín!");
    }
    private void btnTorol_Click(object sender, RoutedEventArgs e)
    {
        if (lbSzinek.SelectedIndex >= 0)
            lbSzinek.Items.RemoveAt(lbSzinek.SelectedIndex);
        else
            MessageBox.Show("Nincs semmi kiválasztva!!");
    }
    private void btnUrit_Click(object sender, RoutedEventArgs e) => lbSzinek.Items.Clear();

    private void lbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string[] tagok = lbSzinek.SelectedItem.ToString().Split(';');
        sliRed.Value = Convert.ToByte(tagok[0]);
        sliGreen.Value = Convert.ToByte(tagok[1]);
        sliBlue.Value = Convert.ToByte(tagok[2]);

        tbRed.Content = $"Piros: {(byte)sliRed.Value}";
        lbGreen.Content = $"Zöld: {(byte)sliGreen.Value}";
        lbBlue.Content = $"Kék: {(byte)sliBlue.Value}";
    }
}