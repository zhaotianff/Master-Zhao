﻿using System;
using System.Collections.Generic;
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

namespace Master_Zhao.Shell.View.Beautify.UserControls
{
    /// <summary>
    /// MouseEffectItemControl.xaml 的交互逻辑
    /// </summary>
    public partial class MouseEffectItemControl : UserControl
    {
        public static readonly RoutedEvent OnOpenSettingEvent = EventManager.RegisterRoutedEvent("OnOpenSetting", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MouseEffectItemControl));

        public event RoutedEventHandler OnOpenSetting
        {
            add
            {
                AddHandler(OnOpenSettingEvent, value);
            }
            remove
            {
                RemoveHandler(OnOpenSettingEvent, value);
            }
        }

        public static readonly RoutedEvent OnSetEvent = EventManager.RegisterRoutedEvent("OnSet", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MouseEffectItemControl));

        public event RoutedEventHandler OnSet
        {
            add
            {
                AddHandler(OnSetEvent, value);
            }
            remove
            {
                RemoveHandler(OnSetEvent, value);
            }
        }

        public string Title
        {
            get => this.title.Content.ToString();
            set => this.title.Content = value;
        }

        public string PreviewImage
        {
            set
            {
                this.image.Source = new Uri(value);
                this.image.Play();
            }
        }

        public MouseEffectItemControl()
        {
            InitializeComponent();

            this.image.LoadedBehavior = MediaState.Manual;
            this.image.Volume = 0;
        }

        private void btn_Setting_Click(object sender, RoutedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(OnOpenSettingEvent));
        }

        private void set_Click(object sender, RoutedEventArgs e)
        {
            this.RaiseEvent(new RoutedEventArgs(OnSetEvent));
        }

        private void image_MediaEnded(object sender, RoutedEventArgs e)
        {
            this.image.Play();
        }
    }
}
