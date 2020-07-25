using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using Zendid.Models;
using Zendid.ViewModels.Base;

namespace Zendid.ViewModels
{/// <summary>
 /// the view model for a custom window
 /// </summary>
    class WindowViewModel : BaseViewModel
    {

        #region Private Member
        /// <summary>
        /// the window this view model controls
        /// </summary>
        private Window mWindow;
        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;
        /// <summary>
        /// the radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Public Properties

        /// <summary>
        /// minimum window width
        /// </summary>
        public double windowMinimumWidth { get; set; } = 1120;

        /// <summary>
        /// minimum window height
        /// </summary>
        public double windowMinimumHeight { get; set; } = 630;

        public int InnerContentPadding { get; set; } = 15;

        /// <summary>
        /// the size of the resize boreder around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// the size of the resize border around the window
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// the radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// the radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        /// <summary>
        /// The height of the title bar caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        /// <summary>
        /// The height of the title bar caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        /// <summary>
        /// the current page of application
        /// </summary>
        public ApplicationPageModel CurrentPage { get; set; } = ApplicationPageModel.Login;

        #endregion

        #region Commands

        /// <summary>
        /// the command for minizing the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }
        /// <summary>
        /// the command for maximizing the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// the command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// the command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        private void FullCloseCommand()
        {
            DatabaseModel database = DatabaseModel.Instance;
            DatabaseModel.connection.Close();
            mWindow.Close();
        }

        #endregion

        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                    //fire off event for all properties that are affected by a resize
                    OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            // create commands
            MinimizeCommand = new RelayCommandViewModel(() => mWindow.WindowState = WindowState.Minimized);
            // ^= is an XOR; Normal = 0; Minimized = 1; Maximized = 2; When applying an XOR we can jump from 0 to 2, from 2 to 0, essentially switching between normal state and maximized state
            MaximizeCommand = new RelayCommandViewModel(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommandViewModel(() => FullCloseCommand());
            MenuCommand = new RelayCommandViewModel(() => SystemCommands.ShowSystemMenu(mWindow, GetCursorPosition()));
        }

        public WindowViewModel()
        {
        }
        #endregion

        #region Private Helpers
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };

        /// <summary>
        /// gets the current position on the screen, WPF doesnt have a way to get the mouse position
        /// </summary>
        /// <returns></returns>
        public static Point GetCursorPosition()
        {
            Win32Point w32mouse = new Win32Point();
            GetCursorPos(ref w32mouse);
            return new Point(w32mouse.X, w32mouse.Y);
        }

        #endregion
    }
}
