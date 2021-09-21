using System;
using System.Collections.Generic;
using CharterUsers.Model;
using UIKit;
using Foundation;
namespace CharterUsers
{
    public partial class MasterViewController : UITableViewController
    {
        MainTableDataSource dataSource;
        MainTableDelegate tableDelegate;

        protected MasterViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = NSBundle.MainBundle.GetLocalizedString("Master", "Users");

            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add, AddNewItem);
            addButton.AccessibilityLabel = "addButton";
            NavigationItem.RightBarButtonItem = addButton;

            TableView.Source = dataSource = new MainTableDataSource(this);
            TableView.Delegate = tableDelegate = new MainTableDelegate(this);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.TableView.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        void AddNewItem(object sender, EventArgs args)
        {
            var detailsController = UIStoryboard.FromName("Main", null).InstantiateViewController(nameof(DetailViewController)) as DetailViewController;
            detailsController.EditingIndex = -1;
            this.NavigationController.PushViewController(detailsController, true);
        }

    
        class MainTableDataSource : UITableViewSource
        {
            static readonly NSString CellIdentifier = new NSString("Cell");
            
            readonly MasterViewController controller;

            public MainTableDataSource(MasterViewController controller)
            {
                this.controller = controller;
            }

            public IList<User> Objects
            {
                get { return DataManager.Instance.UsersList; }
            }

            // Customize the number of sections in the table view.
            public override nint NumberOfSections(UITableView tableView)
            {
                return 1;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Objects.Count;
            }

            // Customize the appearance of table view cells.
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath);

                cell.TextLabel.Text = Objects[indexPath.Row]?.UserName;

                return cell;
            }
        }

         class MainTableDelegate : UITableViewDelegate
         {
            readonly MasterViewController controller;

            public MainTableDelegate(MasterViewController controller)
            {
                this.controller = controller;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                var userObj = DataManager.Instance.UsersList[indexPath.Row];

                var detailsController = UIStoryboard.FromName("Main", null).InstantiateViewController(nameof(DetailViewController)) as DetailViewController;
                detailsController.UserDetails = userObj;
                detailsController.EditingIndex = indexPath.Row;
                this.controller.NavigationController.PushViewController(detailsController, true);
            }
        }
    }
}
