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

namespace BugManager
{
	
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public BugTracking.Bug bug;

		public MainWindow(BugTracking.Bug bug)
		{
			InitializeComponent();

			this.bug = bug;

			txtTitle.Text = bug.Title;
			txtComment.Text = bug.Comment;


			List< BugTracking.Apps> AppList = BugTracking.Apps.get();

			foreach (BugTracking.Apps app in AppList)
			{
				cboApplication.Items.Add(app);
			}
			




		}




		private void btnReport_Click(object sender, RoutedEventArgs e)
		{

		}

		private void button_Click(object sender, RoutedEventArgs e)
		{

		}

		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
