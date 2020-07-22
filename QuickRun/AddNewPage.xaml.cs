﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
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

namespace QuickRun
{
    /// <summary>
    /// Interaction logic for AddNewPage.xaml
    /// </summary>
    public partial class AddNewPage : Page
    {
        public AddNewPage()
        {
            InitializeComponent();
            softwaretext.Visibility = Visibility.Hidden;
            softwarebox.Visibility = Visibility.Hidden;
            linktext.Visibility = Visibility.Hidden;
            linkbox.Visibility = Visibility.Hidden;
            
        }

        private bool handle = true;

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handle) Handle();
            handle = true;
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private void Handle()
        {
            switch (Typebox.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last())
            {
                case "Website":
                case "Email":
                    softwaretext.Visibility = Visibility.Hidden;
                    softwarebox.Visibility = Visibility.Hidden;
                    linktext.Visibility = Visibility.Visible;
                    linkbox.Visibility = Visibility.Visible;
                    break;
                case "Software":
                    softwaretext.Visibility = Visibility.Visible;
                    softwarebox.Visibility = Visibility.Visible;
                    linktext.Visibility = Visibility.Hidden;
                    linkbox.Visibility = Visibility.Hidden;
                    break;
                case "Folder":
                    softwaretext.Visibility = Visibility.Hidden;
                    softwarebox.Visibility = Visibility.Hidden;
                    linktext.Visibility = Visibility.Hidden;
                    linkbox.Visibility = Visibility.Hidden;
                    break;
            }


        }

        private void Backbtn(object sender, RoutedEventArgs e)
        {
            //AddNewPage.Visi = Visibility.Hidden;
            this.Visibility = Visibility.Hidden;
        }

        private void Erase(object sender, RoutedEventArgs e)
        {
            test.Text = "";
        }

        private void ListenToKeys(object sender, RoutedEventArgs e)
        {
            //AddHandler(Keyboard.KeyDownEvent, (KeyEventHandler)ListenToKeys
            var window = Window.GetWindow(this);
            window.KeyDown += Keys;
        }

        private void Keys(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftShift))
                test.Text += "LShift";

            if (Keyboard.IsKeyDown(Key.RightShift))
                test.Text += "RShift";

            if (Keyboard.IsKeyDown(Key.LeftCtrl))
                test.Text += "LControl";

            if (Keyboard.IsKeyDown(Key.RightCtrl))
                test.Text += "RControl";


        }
    }
}
