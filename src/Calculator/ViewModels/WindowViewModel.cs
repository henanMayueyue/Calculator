﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Calculator.ViewModels.Base;
using Calculator.WindowHelper;

namespace Calculator.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private member

        private Window window;

        #endregion

        #region Public properties

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder); } }

        //Height of the title bar
        public int TitleHeight { get; set; } = 26;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        #endregion

        public WindowViewModel(Window window)
        {
            this.window = window;

            //Window resize
            this.window.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
            };

            //Create command
            MinimizeCommand = new RelayCommand(() => this.window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => this.window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => this.window.Close());

            //Fix window resize issue
            var resizer = new WindowResizer(this.window);
        }
    }
}