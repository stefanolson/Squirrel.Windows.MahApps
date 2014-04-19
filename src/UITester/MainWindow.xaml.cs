using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.Versioning;
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
using MahApps.Metro;
using NuGet;
using Shimmer.WiXUi.ViewModels;
using Shimmer.WiXUi.Views;

namespace UITester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void WelcomeView(object sender, RoutedEventArgs e)
        {
            var view = new WelcomeView();
            var vm = new WelcomeViewModel(null) {  PackageMetadata = new PackageData() };
            view.ViewModel = vm;
            var window = new RootWindow {View = {Content = view}};
            window.ShowDialog();
        }

        void InstallView(object sender, RoutedEventArgs e)
        {
            var view = new InstallingView();
            var vm = new InstallingViewModel(null) { PackageMetadata = new PackageData()};
            vm.ProgressValue.OnNext(50);
            view.ViewModel = vm;
            var window = new RootWindow { View = { Content = view } };
            window.ShowDialog();
        }

        void UninstallView(object sender, RoutedEventArgs e)
        {
            var view = new UninstallingView();
            var vm = new UninstallingViewModel(null) { PackageMetadata = new PackageData() };
            vm.ProgressValue.OnNext(50);
            view.ViewModel = vm;
            var window = new RootWindow { View = { Content = view } };
            window.ShowDialog();
        }

        void ErrorView(object sender, RoutedEventArgs e)
        {
            var view = new ErrorView();
            var vm = new ErrorViewModel(null) { PackageMetadata = new PackageData() };
            view.ViewModel = vm;
            var window = new RootWindow { View = { Content = view } };
            window.ShowDialog();
        }

        class PackageData : IPackage
        {
            public virtual string Id { get; private set; }
            public virtual SemanticVersion Version { get; private set; }
            public virtual string Title
            {
                get { return "Test Title"; }
            }
            public virtual IEnumerable<string> Authors { get; private set; }
            public virtual IEnumerable<string> Owners { get; private set; }
            public virtual Uri IconUrl { get; private set; }
            public virtual Uri LicenseUrl { get; private set; }
            public virtual Uri ProjectUrl { get; private set; }
            public virtual bool RequireLicenseAcceptance { get; private set; }
            public virtual string Description
            {
                get { return "Test Description"; }
            }
            public virtual string Summary { get; private set; }
            public virtual string ReleaseNotes { get; private set; }
            public virtual string Language { get; private set; }
            public virtual string Tags { get; private set; }
            public virtual string Copyright { get; private set; }
            public virtual IEnumerable<FrameworkAssemblyReference> FrameworkAssemblies { get; private set; }
            public virtual ICollection<PackageReferenceSet> PackageAssemblyReferences { get; private set; }
            public virtual IEnumerable<PackageDependencySet> DependencySets { get; private set; }
            public virtual Version MinClientVersion { get; private set; }
            public virtual Uri ReportAbuseUrl { get; private set; }
            public virtual int DownloadCount { get; private set; }
            public virtual IEnumerable<IPackageFile> GetFiles()
            {
                throw new NotImplementedException();
            }

            public virtual IEnumerable<FrameworkName> GetSupportedFrameworks()
            {
                throw new NotImplementedException();
            }

            public virtual Stream GetStream()
            {
                throw new NotImplementedException();
            }

            public virtual bool IsAbsoluteLatestVersion { get; private set; }
            public virtual bool IsLatestVersion { get; private set; }
            public virtual bool Listed { get; private set; }
            public virtual DateTimeOffset? Published { get; private set; }
            public virtual IEnumerable<IPackageAssemblyReference> AssemblyReferences { get; private set; }
        }
    }
}
