using System;
using System.ComponentModel.Composition;
using Sharp3D.UI.ViewModels;

namespace Sharp3D.UI.Windows
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    [Export(typeof(IShellView))]
    public partial class ShellWindow : IShellView
    {
        public ShellWindow()
        {
            InitializeComponent();
        }

        public ShellViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}
