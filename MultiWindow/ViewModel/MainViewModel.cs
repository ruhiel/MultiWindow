using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MultiWindow.ViewModel
{
	/// <summary>
	/// ViewModel
	/// </summary>
	public class MainViewModel : ViewModelBase
	{
		public ICommand OpenSubWindowCommand { get; private set; }
		public event EventHandler OpenSubWindow;

		// プロパティの値を保持するメンバ変数
		private bool _visibleproperty = true;

		// プロパティ
		public bool VisibleProperty
		{
			get { return _visibleproperty; }
			set
			{
				// 値が変更されたら、INotifyPropertyChanged.PropertyChanged を発生させる。
				if (_visibleproperty != value)
				{
					_visibleproperty = value;
					RaisePropertyChanged(nameof(VisibleProperty));
				}
			}
		}

		public ICommand ChangeCommand { get; private set; }

		// コンストラクタ
		public MainViewModel()
		{
			ChangeCommand = CreateCommand(v => {
				VisibleProperty = !VisibleProperty;
			});

			OpenSubWindowCommand = CreateCommand(v =>
			{
				OpenSubWindow?.Invoke(this, EventArgs.Empty);
			});
		}
	}
}
