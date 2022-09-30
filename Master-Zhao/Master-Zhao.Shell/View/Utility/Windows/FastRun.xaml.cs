﻿using Master_Zhao.Config;
using Master_Zhao.Config.Model;
using Master_Zhao.Shell.Controls;
using Master_Zhao.Shell.PInvoke;
using Master_Zhao.Shell.Util;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Master_Zhao.Shell.Windows
{
    /// <summary>
    /// Interaction logic for FastRun.xaml
    /// </summary>
    public partial class FastRun : Window
    {
        private bool isExecuted = false;
        private bool hasPressedVKMENU = false;

        public int SelectedIndex { get; set; } = 0;
        private bool IsFirstRun { get; set; } = true;

        private System.Windows.Point dragStartPoint = new Point();

        public FastRun()
        {
            InitializeComponent();

            LoadFastRunList();
        }

        public int RegisterHotKey()
        {
            var result = PInvoke.SystemTool.RegisterFastRunHotKey(new WindowInteropHelper(this).Handle);
            var errorCode = PInvoke.Kernel32.GetLastError();
            return errorCode;
        }

        public int UnregisterHotKey()
        {
            var result = PInvoke.SystemTool.UnRegisterFastRunHotKey();
            var errorCode = PInvoke.Kernel32.GetLastError();
            return errorCode;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Canvas.SetLeft(img_DragArea, (canvas.ActualWidth - img_DragArea.Width) / 2);
            //Canvas.SetTop(img_DragArea, (canvas.ActualHeight - img_DragArea.Height) / 2);
            this.Visibility = Visibility.Hidden;
        }

        public void RefreshFastRunItem(int index)
        {
            //TODO 
            //var list = GlobalConfig.Instance.ToolsConfig.FastRunConfig.FastRunList;

            //if (index < list.Count && index < canvas.Children.Count)
            //{
            //    (canvas.Children[index] as FastRunButton).FastRunItem.Path = list[index].Path;
            //}
        }

        public void LoadFastRunList()
        {

            /*
             * <local:FastRunButton ContentRadiusX="48" ContentRadiusY="48" Center="50,50" VerticalContentAlignment="Bottom" Foreground="White" FontSize="20" Content="abc" Width="100" Height="100" ImagePath="../Icon/system.png" HostCanvas="{Binding ElementName=canvas}">
            </local:FastRunButton>/*
            */

            //canvas.Children.Clear();

            //var list = GetTestList();
            var list = GlobalConfig.Instance.ToolsConfig.FastRunConfig.FastRunList;

            foreach (var item in list)
            {
                FastRunButton fastRunButton = new FastRunButton();
                fastRunButton.FastRunItem = item;
                fastRunButton.ContentRadiusX = 48;
                fastRunButton.ContentRadiusY = 48;
                fastRunButton.Center = new Point(50, 50);
                fastRunButton.VerticalAlignment = VerticalAlignment.Bottom;
                fastRunButton.Foreground = Brushes.White;
                fastRunButton.FontSize = 20;
                fastRunButton.Content = item.Name;
                fastRunButton.Width = 100;
                fastRunButton.Height = 100;
                //fastRunButton.ImagePath = @"C:\Users\Administrator\Desktop\compu.png";
                fastRunButton.ImagePath = GetCachedIconPath(item.Path);
                //fastRunButton.HostCanvas = canvas;
                fastRunButton.Click += FastRunButton_Click;
                //canvas.Children.Add(fastRunButton);
            }

            //btn_Left.FastRunName = list[0].Name;
            //btn_Left.FastRunIcon = GetCachedIconPath(list[0].Path);
            //btn_Left.FastRunData = list[0];
            //btn_Left.Click += FastRunButton_Click;

            //btn_Top.FastRunName = list[1].Name;
            //btn_Top.FastRunIcon = GetCachedIconPath(list[1].Path);
            //btn_Top.FastRunData = list[1];
            //btn_Top.Click += FastRunButton_Click;

            //btn_Right.FastRunName = list[1].Name;
            //btn_Right.FastRunIcon = GetCachedIconPath(list[1].Path);
            //btn_Right.FastRunData = list[1];
            //btn_Right.Click += FastRunButton_Click;

            //btn_Bottom.FastRunName = list[2].Name;
            //btn_Bottom.FastRunIcon = GetCachedIconPath(list[2].Path);
            //btn_Bottom.FastRunData = list[2];
            //btn_Bottom.Click += FastRunButton_Click;

            //(canvas.Children[0] as FastRunButton).IsSelected = true;
        }

        private string GetCachedIconPath(string path)
        {
            var temp = System.IO.Path.Combine(System.IO.Path.GetTempPath(),"Master-Zhao");
            var iconPath = System.IO.Path.Combine(temp, System.IO.Path.GetFileNameWithoutExtension(path) + ".png");
            if (System.IO.Directory.Exists(temp) == false)
                System.IO.Directory.CreateDirectory(temp);

            if(System.IO.File.Exists(iconPath) == false)
            {
                IntPtr hIcon = IntPtr.Zero;
                if(IconTool.ExtractFirstIconFromFile(path, true, ref hIcon))
                {
                    var bi = ImageHelper.GetBitmapImageFromHIcon(hIcon);
                    ImageHelper.SaveBitmapImageToFile(bi, iconPath);
                }          
            }

            return iconPath;
        }

        private void FastRunButton_Click(object sender, RoutedEventArgs e)
        {
            //var pathButton = sender as PathButton;

            //if (pathButton != null)
            //{
            //    var psInfo = new System.Diagnostics.ProcessStartInfo();
            //    psInfo.UseShellExecute = true;
            //    psInfo.FileName = pathButton.FastRunData.Path;
            //    System.Diagnostics.Process.Start(psInfo);
            //    this.Visibility = Visibility.Hidden;
            //    isExecuted = true;
            //}
        }

        #region Test Code
        private List<FastRunItem> GetTestList()
        {
            var list = new List<FastRunItem>();
    
            FastRunItem fastRunItem1 = new FastRunItem();
            fastRunItem1.Name = "notepad";
            fastRunItem1.RunType = FastRunType.Applicataion;
            fastRunItem1.Path = "C:\\windows\\system32\\notepad.exe";
            list.Add(fastRunItem1);

            FastRunItem fastRunItem2 = new FastRunItem();
            fastRunItem2.Name = "cmd";
            fastRunItem2.RunType = FastRunType.Applicataion;
            fastRunItem2.Path = "C:\\windows\\system32\\cmd.exe";
            list.Add(fastRunItem2);

            FastRunItem fastRunItem3 = new FastRunItem();
            fastRunItem3.Name = "control";
            fastRunItem3.RunType = FastRunType.Applicataion;
            fastRunItem3.Path = "C:\\windows\\system32\\control.exe";
            list.Add(fastRunItem3);

            FastRunItem fastRunItem4 = new FastRunItem();
            fastRunItem4.Name = "calc";
            fastRunItem4.RunType = FastRunType.Applicataion;
            fastRunItem4.Path = "C:\\windows\\system32\\calc.exe";
            list.Add(fastRunItem4);

            return list;
        }

        #endregion

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            hwndSource.AddHook(HwndProc);
        }

        private IntPtr HwndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            //bug : first run
            switch(msg)
            {
                case PInvoke.User32.WM_INPUT:
                    if(InputTool.IsKeyPressed(InputTool.VK_MENU))
                    {
                        if(this.Visibility == Visibility.Hidden && isExecuted == false)
                        {
                            ShowWindowWithAnimation();
                            var point = new PInvoke.POINT();
                            PInvoke.User32.GetCursorPos(ref point);
                            this.Left = point.x - this.Width / 2;
                            this.Top = point.y - this.Height / 2;
                            hasPressedVKMENU = true;
                            break;
                        }

                        DealWithKeyPress();
                    }
                    else
                    {
                        if (hasPressedVKMENU == true)
                        {
                            this.Visibility = Visibility.Hidden;
                            isExecuted = false;
                            hasPressedVKMENU = false;
                        }
                        break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void DealWithKeyPress()
        {
            if (this.Visibility == Visibility.Hidden)
                return;

            if (Keyboard.IsKeyDown(Key.D1))
            {
                SelectFastRunItem(0, true);
                this.Visibility = Visibility.Hidden;
            }

            if (Keyboard.IsKeyDown(Key.D2))
            {
                SelectFastRunItem(1, true);
                this.Visibility = Visibility.Hidden;
            }

            if (Keyboard.IsKeyDown(Key.D3))
            {
                SelectFastRunItem(2, true);
                this.Visibility = Visibility.Hidden;
            }

            if (Keyboard.IsKeyDown(Key.D4))
            {
                SelectFastRunItem(3, true);
                this.Visibility = Visibility.Hidden;
            }
        }

        private void SelectFastRunItem(int index, bool isRun = false)
        {
           //for(int i = 0;i<canvas.Children.Count;i++)
           // {
           //     if(index == i)
           //     {
           //         var fastRunButton = canvas.Children[i] as FastRunButton;

           //         fastRunButton.IsSelected = true;

           //         if (isRun)
           //         {
           //             fastRunButton.Dispatcher.Invoke(() => {
           //                 fastRunButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
           //             });

           //         }
           //     }
           //     else
           //     {
           //         (canvas.Children[i] as FastRunButton).IsSelected = false;
           //     }
           // }
        }

        public void ShowWindowWithAnimation()
        {   
            //for (int i = 0; i < canvas.Children.Count; i++)
            //{
            //    var fastRunButton = canvas.Children[i] as FastRunButton;
            //    fastRunButton?.OnApplyTemplate();
            //}

            this.Visibility = Visibility.Visible;

            //TODO reset animation position
        }

        private void Window_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            dragStartPoint = e.GetPosition(this);
        }

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if(e.RightButton == MouseButtonState.Pressed)
            {
                Point dragEndPoint = e.GetPosition(this);
                Vector vector = dragEndPoint - dragStartPoint;
                this.Left += vector.X;
                this.Top += vector.Y;
            }
        }
    }
}
