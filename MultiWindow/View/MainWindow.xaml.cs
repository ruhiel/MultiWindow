using MultiWindow.View;
using MultiWindow.ViewModel;
using System.Windows;

namespace MultiWindow
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			DataContextChanged += (o, e) =>
			{
				var vm = DataContext as MainViewModel;
				vm.OpenSubWindow += (sender, arg) =>
				{
					// サブウィンドウ表示
					SubView wnd = new SubView();
					wnd.Left = this.Left + this.Width;
					wnd.DataContext = vm;
					wnd.Show();

					// サブウィンドウ表示
					wnd = new SubView();
					wnd.Left = this.Left + this.Width + 100;
					wnd.DataContext = vm;
					wnd.Show();
				};
			};

			DataContext = new MainViewModel();
		}
	}
}
