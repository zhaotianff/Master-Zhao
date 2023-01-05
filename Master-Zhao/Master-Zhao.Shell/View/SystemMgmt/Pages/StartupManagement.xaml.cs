﻿using Master_Zhao.Shell.Model.SystemMgmt;
using Master_Zhao.Shell.PInvoke;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Master_Zhao.Shell.View.SystemMgmt.Pages
{
    /// <summary>
    /// StartupManagement.xaml 的交互逻辑
    /// </summary>
    public partial class StartupManagement : Page
    {
        public StartupManagement()
        {
            InitializeComponent();
        }

        private void LoadStartUpItem()
        {
            //temp 10
            int count = 10;
            var itemSize = Marshal.SizeOf<tagSTARTUPITEM>();
            int size = count * itemSize;
            IntPtr buffer = Marshal.AllocHGlobal(size);
            var result = PInvoke.StartupTool.GetStartupItems(buffer, size, ref count);

            if (result == false)
                return;

            var startupItemList = new List<StartupItem>();

            for(int i = 0;i<count;i++)
            {
                byte[] startupItemBuffer = new byte[itemSize];
                Marshal.Copy(buffer, startupItemBuffer, 0, itemSize);

                IntPtr newPtr = Marshal.AllocHGlobal(itemSize);
                Marshal.Copy(startupItemBuffer, 0, newPtr, itemSize);

                var tagStartupItem = Marshal.PtrToStructure<tagSTARTUPITEM>(newPtr);
                
                buffer = new IntPtr(buffer.ToInt64() + itemSize);

                StartupItem startupItem = new StartupItem();
                startupItem.Name = tagStartupItem.szName;

                if (string.IsNullOrEmpty(tagStartupItem.szPath))
                    continue;

                startupItem.Path = tagStartupItem.szPath;
                startupItem.Description = tagStartupItem.szDescription;
                startupItem.IsEnabled = true;
                startupItemList.Add(startupItem);
            }

            this.listbox.ItemsSource = startupItemList;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadStartUpItem();
        }

        private void openProperty_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.listbox.SelectedItem as StartupItem;

            if (selectedItem != null)
            {
                DesktopTool.OpenFileProperty(selectedItem.Path);
            }
        }

        private void openFilePath_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = this.listbox.SelectedItem as StartupItem;

            if(selectedItem != null)
            {
                DesktopTool.SelectFile(selectedItem.Path);
            }
        }
    }
}
