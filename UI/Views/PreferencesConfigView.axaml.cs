using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mesen.Utilities;
using Mesen.Config;
using Mesen.Controls;
using Avalonia.Themes.Fluent;
using Avalonia.Styling;
using System.Collections.Generic;
using Avalonia.Markup.Xaml.Styling;
using Avalonia.Interactivity;
using Mesen.Windows;
using Mesen.Interop;
using Avalonia.VisualTree;

namespace Mesen.Views
{
	public class PreferencesConfigView : UserControl
	{
		public PreferencesConfigView()
		{
			InitializeComponent();

			ComboBox cboUiScale = this.GetControl<ComboBox>("cboUiScale");
			cboUiScale.ItemsSource = new double[] { 0.5, 0.75, 1.0, 1.25, 1.5, 1.75, 2.0, 2.5, 3.0, 4.0 };
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
		
		private void btnResetLagCounter_OnClick(object sender, RoutedEventArgs e)
		{
			InputApi.ResetLagCounter();
		}

		private void btnChangeStorageFolder_OnClick(object sender, RoutedEventArgs e)
		{
			ShowSelectFolderWindow();
		}

		private async void ShowSelectFolderWindow()
		{
			SelectStorageFolderWindow wnd = new();
			if(await wnd.ShowCenteredDialog<bool>(this.GetVisualRoot() as Visual)) {
				(this.GetVisualRoot() as Window)?.Close();
				ApplicationHelper.GetMainWindow()?.Close();
				ConfigManager.RestartMesen();
			}
		}
	}
}
