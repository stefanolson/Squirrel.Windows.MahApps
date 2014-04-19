using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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
using MahApps.Metro;
using ReactiveUI;

namespace UITester
{
    /// <summary>
    /// Interaction logic for RootWindow.xaml
    /// </summary>
    public partial class RootWindow
    {
        public RootWindow()
        {
            InitializeComponent();

            /*
            this.WhenAny(x => x.viewHost.Width, x => x.viewHost.Height, (w, h) => w.Value != 0 && h.Value != 0)
                .Where(x => x)
                .Subscribe(_ => { this.Width = viewHost.Width; this.Height = viewHost.Height; });
            */

            this.Loaded += (sender, args) => ThemeManager.ChangeAppStyle(Application.Current, 
                ThemeManager.Accents.First(x => x.Name == "Blue"), 
                ThemeManager.AppThemes.First(x => x.Name == "BaseDark"));
        }
    }
}
