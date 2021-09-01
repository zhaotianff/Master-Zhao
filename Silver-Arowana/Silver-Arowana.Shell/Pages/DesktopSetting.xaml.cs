﻿using System;
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

using Silver_Arowana.Shell.PInvoke;

namespace Silver_Arowana.Shell.Pages
{
    /// <summary>
    /// DesktopSetting.xaml 的交互逻辑
    /// </summary>
    public partial class DesktopSetting : Page
    {
        public DesktopSetting()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            (System.Windows.Application.Current.MainWindow as MainWindow).EndShowMenuAnimation();
        }
    }

}

