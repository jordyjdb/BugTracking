using BugManagement.Properties;
using BugTracking;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace BugManagement
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

	//Todo add Help button?

		public BugTracking.Bug Bug{ get; private set; }
		

		public MainWindow()
		{
			InitializeComponent();


			populateBugDetails();

			refreshGrid();
		}


		public void refreshGrid()
		{


		List< DeveloperBug> developerBugs =   DeveloperBug.Get();


			grdBugs.ItemsSource = developerBugs;
	

		}

		public void populateBugDetails()
		{



			if (Bug != null)
			{


				txtTitle.Text = this.Bug.Title;
				txtComment.Text = this.Bug.Comment;

			}
			populateAppList();
	
			
			populateActionList();
		}

		public void populateAppList()
		{
			
			cboApplication.DisplayMemberPath = "Name";
			cboApplication.SelectedValuePath = "Id";


			List<BugTracking.App> AppList = BugTracking.App.get();

			foreach (BugTracking.App app in AppList)
			{
				cboApplication.Items.Add(app);
			}
		}

		public void populateControlList(long AppID)
		{
			cboControl.DisplayMemberPath = "Label";
			cboControl.SelectedValuePath = "Id";

			List<BugTracking.FormControl> AppList = BugTracking.FormControl.get(AppID);

			foreach (BugTracking.FormControl app in AppList)
			{
				cboControl.Items.Add(app);
			}
		}

		public void populateFormList(long AppID)
		{
			cboForm.DisplayMemberPath = "label";
			cboForm.SelectedValuePath = "id";
			List<BugTracking.AppForm> AppFormList = BugTracking.AppForm.Get(AppID);

			foreach (BugTracking.AppForm app in AppFormList)
			{
				cboForm.Items.Add(app);
			}
		}

		public void populateActionList()
		{
			cboActions.DisplayMemberPath = "Name";
			cboActions.SelectedValuePath = "Id";
			List<BugTracking.Action> ActionList = BugTracking.Action.Get();

			foreach (BugTracking.Action action in ActionList)
			{
				cboActions.Items.Add(action);
			}
		}
		

		private void btnReport_Click(object sender, RoutedEventArgs e)
		{

		
				long applicationID, formID, controlID, lineNumber;
				String action, relatedMethod, relatedParameter, title, comment, Priority;
				bool check;

				title = txtTitle.Text;
			comment = txtComment.Text;
			applicationID = (long)cboApplication.SelectedValue;
				formID = (long) cboApplication.SelectedValue;
				controlID = (long) cboApplication.SelectedValue;
				lineNumber = (long) Convert.ToDouble(txtLineNumber.Text);
			action = (String)	cboActions.Text ;
				relatedMethod = (String) txtRelatedMethod.Text;
			relatedParameter = (String)txtRelatedParameter.Text;
			check = (bool) chkSolutionFound.IsChecked;


			BugLocation location = new BugLocation(applicationID,formID, controlID, action, relatedMethod, relatedParameter, lineNumber);

				location.Save();



			DeveloperBug bug = new DeveloperBug(title, comment, location, 0, "Priority", check);
	
			

			bug.Save();
				









		}

		private void button_Click(object sender, RoutedEventArgs e)
		{

		}
		private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void cboApplication_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			populateControlList((long)cboApplication.SelectedValue);
			populateFormList((long)cboApplication.SelectedValue);
		}

		private void cboForm_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}





		private void grdBugs_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (grdBugs.Items.Count >= 1)
			{
				if (Settings.Default.Developer == true)
				{
					grdBugs.Columns[0].Visibility = Visibility.Collapsed;
				}
				else
				{
					grdBugs.Columns[0].Visibility = Visibility.Hidden;
				}

			}
		}

		private void grdBugs_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (grdBugs.Items.Count >= 1)
			{
				if (Settings.Default.Developer == true)
				{
					grdBugs.Columns[0].Visibility = Visibility.Collapsed;
				}
				else
				{
					grdBugs.Columns[0].Visibility = Visibility.Hidden;
				}

			}
		}

		private void grdBugs_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
		{

		}
	}
}
