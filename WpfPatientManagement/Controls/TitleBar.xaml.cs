using CommunityToolkit.Mvvm.ComponentModel;
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
using WpfLib.Extensions;

namespace WpfPatientManagement.Controls
{
    [ObservableObject]
    public partial class TitleBar : UserControl
    {
        #region Fields
        private Window? _parentWindow;
        private WindowState _winState;
        #endregion

        #region Properties
        public Window? ParentWindow
        {
            get
            {
                if (_parentWindow == null)
                {
                    _parentWindow = this.FindParent<Window>();
                }
                return _parentWindow; 
            }
            set { _parentWindow = value; }
        }

        public WindowState WinState
        {
            get { return _winState; }
            set { 
                SetProperty(ref _winState, value);
            }
        }
        #endregion

        public TitleBar()
        {
            InitializeComponent();

            btnExit.Click += BtnExit_Click;
            btnMaximize.Click += BtnMaximize_Click;
            btnMinimize.Click += BtnMinimize_Click;

            Loaded += TitleBar_Loaded;
        }

        #region Events
        private void TitleBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                ParentWindow.StateChanged += ParentWindow_StateChanged;
                WinState = ParentWindow.WindowState;
            }
        }

        private void ParentWindow_StateChanged(object? sender, EventArgs e)
        {
            WinState = ParentWindow.WindowState;
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WinState = WindowState.Minimized;
            ParentWindow.WindowState = WinState;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            WinState = ParentWindow.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
            ParentWindow.WindowState = WinState;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            ParentWindow.Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                ParentWindow?.DragMove();
            }
        }
        #endregion
    }
}