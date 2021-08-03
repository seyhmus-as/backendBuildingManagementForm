using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
	public partial class UserForm : Form
	{
		private Label Id;
		private Label emailLabel;
		private Label userFirstNameLabel;
		private Label userLastNameLabel;
		private Button updateButton;
		private Button showAddingButton;
		private Button refreshButton;
		private Button showUpdateButton;
		private Button deleteButton;
		private Button addButton;
		private TextBox userEmailTextBox;
		private TextBox userFirstNameTextBox;
		private TextBox userLastNameTextBox;
		private ListView userListView;
		private ColumnHeader userLastName;
		private ColumnHeader userFirstName;
		private ColumnHeader userId;

		private IUserService userService = new UserManager(new EfUserDal(),new EfUserOperationClaimDal());
		private UserForShowingDto selectedUser = new UserForShowingDto();
		private UserForShowingDto user = new UserForShowingDto();

		public UserForm()
		{
			InitializeComponent();
			this.FormClosed += new FormClosedEventHandler(UserFormClosed);

		}

		void UserFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.Show();
		}

		private void InitializeComponent()
		{
			this.userLastNameTextBox = new System.Windows.Forms.TextBox();
			this.userLastName = new System.Windows.Forms.ColumnHeader();
			this.userFirstName = new System.Windows.Forms.ColumnHeader();
			this.userId = new System.Windows.Forms.ColumnHeader();
			this.userLastNameLabel = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.showAddingButton = new System.Windows.Forms.Button();
			this.userFirstNameLabel = new System.Windows.Forms.Label();
			this.refreshButton = new System.Windows.Forms.Button();
			this.showUpdateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.userListView = new System.Windows.Forms.ListView();
			this.userFirstNameTextBox = new System.Windows.Forms.TextBox();
			this.emailLabel = new System.Windows.Forms.Label();
			this.userEmailTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// userLastNameTextBox
			// 
			this.userLastNameTextBox.Location = new System.Drawing.Point(120, 177);
			this.userLastNameTextBox.Name = "userLastNameTextBox";
			this.userLastNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.userLastNameTextBox.TabIndex = 52;
			this.userLastNameTextBox.Visible = false;
			// 
			// userLastName
			// 
			this.userLastName.Text = "User Last Name";
			this.userLastName.Width = 120;
			// 
			// userFirstName
			// 
			this.userFirstName.Text = "User First Name";
			this.userFirstName.Width = 120;
			// 
			// userId
			// 
			this.userId.Text = "User Id";
			this.userId.Width = 82;
			// 
			// userLastNameLabel
			// 
			this.userLastNameLabel.AutoSize = true;
			this.userLastNameLabel.Location = new System.Drawing.Point(20, 177);
			this.userLastNameLabel.Name = "userLastNameLabel";
			this.userLastNameLabel.Size = new System.Drawing.Size(69, 15);
			this.userLastNameLabel.TabIndex = 53;
			this.userLastNameLabel.Text = "Last Name :";
			this.userLastNameLabel.Visible = false;
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(120, 319);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(220, 34);
			this.updateButton.TabIndex = 51;
			this.updateButton.Text = "Update User";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// showAddingButton
			// 
			this.showAddingButton.Location = new System.Drawing.Point(16, 33);
			this.showAddingButton.Name = "showAddingButton";
			this.showAddingButton.Size = new System.Drawing.Size(357, 38);
			this.showAddingButton.TabIndex = 50;
			this.showAddingButton.Text = "Add";
			this.showAddingButton.UseVisualStyleBackColor = true;
			this.showAddingButton.Click += new System.EventHandler(this.showAddingButton_Click_1);
			// 
			// userFirstNameLabel
			// 
			this.userFirstNameLabel.AutoSize = true;
			this.userFirstNameLabel.Location = new System.Drawing.Point(20, 136);
			this.userFirstNameLabel.Name = "userFirstNameLabel";
			this.userFirstNameLabel.Size = new System.Drawing.Size(70, 15);
			this.userFirstNameLabel.TabIndex = 49;
			this.userFirstNameLabel.Text = "First Name :";
			this.userFirstNameLabel.Visible = false;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(396, 33);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(531, 38);
			this.refreshButton.TabIndex = 47;
			this.refreshButton.Text = "Refresh List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// showUpdateButton
			// 
			this.showUpdateButton.Location = new System.Drawing.Point(664, 376);
			this.showUpdateButton.Name = "showUpdateButton";
			this.showUpdateButton.Size = new System.Drawing.Size(263, 39);
			this.showUpdateButton.TabIndex = 46;
			this.showUpdateButton.Text = "Update";
			this.showUpdateButton.UseVisualStyleBackColor = true;
			this.showUpdateButton.Click += new System.EventHandler(this.showUpdateButton_Click_1);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(395, 376);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(263, 39);
			this.deleteButton.TabIndex = 45;
			this.deleteButton.Text = "Delete ";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click_1);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(120, 267);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(220, 37);
			this.addButton.TabIndex = 44;
			this.addButton.Text = "Add New User";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Visible = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click_1);
			// 
			// userListView
			// 
			this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userId,
            this.userFirstName,
            this.userLastName});
			this.userListView.FullRowSelect = true;
			this.userListView.HideSelection = false;
			this.userListView.Location = new System.Drawing.Point(396, 77);
			this.userListView.MultiSelect = false;
			this.userListView.Name = "userListView";
			this.userListView.Size = new System.Drawing.Size(531, 293);
			this.userListView.TabIndex = 43;
			this.userListView.UseCompatibleStateImageBehavior = false;
			this.userListView.View = System.Windows.Forms.View.Details;
			// 
			// userFirstNameTextBox
			// 
			this.userFirstNameTextBox.Location = new System.Drawing.Point(120, 133);
			this.userFirstNameTextBox.Name = "userFirstNameTextBox";
			this.userFirstNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.userFirstNameTextBox.TabIndex = 48;
			this.userFirstNameTextBox.Visible = false;
			// 
			// emailLabel
			// 
			this.emailLabel.AutoSize = true;
			this.emailLabel.Location = new System.Drawing.Point(20, 219);
			this.emailLabel.Name = "emailLabel";
			this.emailLabel.Size = new System.Drawing.Size(36, 15);
			this.emailLabel.TabIndex = 57;
			this.emailLabel.Text = "Email";
			this.emailLabel.Visible = false;
			// 
			// userEmailTextBox
			// 
			this.userEmailTextBox.Location = new System.Drawing.Point(120, 216);
			this.userEmailTextBox.Name = "userEmailTextBox";
			this.userEmailTextBox.Size = new System.Drawing.Size(220, 23);
			this.userEmailTextBox.TabIndex = 56;
			this.userEmailTextBox.Visible = false;
			// 
			// UserForm
			// 
			this.ClientSize = new System.Drawing.Size(971, 460);
			this.Controls.Add(this.emailLabel);
			this.Controls.Add(this.userEmailTextBox);
			this.Controls.Add(this.userLastNameTextBox);
			this.Controls.Add(this.userLastNameLabel);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.showAddingButton);
			this.Controls.Add(this.userFirstNameLabel);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.showUpdateButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.userFirstNameTextBox);
			this.Controls.Add(this.userListView);
			this.Name = "UserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			IUserService userService = new UserManager(new EfUserDal(), new EfUserOperationClaimDal());

			userListView.Items.Clear();
			IDataResult<List<UserForShowingDto>> users = userService.GetUserAll();
			foreach (var i in users.Data)
			{
				ListViewItem userLVT = new ListViewItem(i.UserId.ToString());
				userLVT.SubItems.Add(i.FirstName);
				userLVT.SubItems.Add(i.LastName);
				userLVT.SubItems.Add(i.Email);

				userListView.Items.Add(userLVT);
			}
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			user.UserId = 0;
			user.FirstName = userFirstNameTextBox.Text;
			user.LastName = userLastNameTextBox.Text;
			user.LastName = userEmailTextBox.Text;

			//userService.Add(user);
			userFirstNameTextBox.Clear();
			userLastNameTextBox.Clear();
			refreshButton_Click(sender, e);
		}

		private void showUpdateButton_Click(object sender, EventArgs e)
		{
			this.userFirstNameLabel.Visible = true;
			this.userLastNameLabel.Visible = true;

			this.userFirstNameTextBox.Visible = true;
			this.userLastNameTextBox.Visible = true;

			this.updateButton.Visible = true;

			selectedUser.UserId = Int32.Parse(userListView.SelectedItems[0].SubItems[0].Text);
			selectedUser.FirstName = userListView.SelectedItems[0].SubItems[1].Text;
			selectedUser.LastName = userListView.SelectedItems[0].SubItems[2].Text;
			selectedUser.Email= userListView.SelectedItems[0].SubItems[3].Text;

			userFirstNameTextBox.Text = selectedUser.FirstName.ToString();
			userLastNameTextBox.Text = selectedUser.LastName.ToString();
		}

		private void showAddingButton_Click_1(object sender, EventArgs e)
		{
			this.userFirstNameLabel.Visible = true;
			this.userLastNameLabel.Visible = true;
			this.emailLabel.Visible = true;

			this.userFirstNameTextBox.Visible = true;
			this.userLastNameTextBox.Visible = true;
			this.userEmailTextBox.Visible = true;

			this.addButton.Visible = true;
		}

		private void deleteButton_Click_1(object sender, EventArgs e)
		{
			selectedUser.UserId = Int32.Parse(userListView.SelectedItems[0].SubItems[0].Text);
			selectedUser.FirstName = userListView.SelectedItems[0].SubItems[1].Text;
			selectedUser.LastName = userListView.SelectedItems[0].SubItems[2].Text;
			selectedUser.Email = userListView.SelectedItems[0].SubItems[3].Text;

			userService.Delete(selectedUser.Email);
			refreshButton_Click(sender, e);
		}

		private void showUpdateButton_Click_1(object sender, EventArgs e)
		{
			this.userFirstNameLabel.Visible = true;
			this.userLastNameLabel.Visible = true;

			this.userFirstNameTextBox.Visible = true;
			this.userLastNameTextBox.Visible = true;

			this.updateButton.Visible = true;

			selectedUser.UserId = Int32.Parse(userListView.SelectedItems[0].SubItems[0].Text);
			selectedUser.FirstName = userListView.SelectedItems[0].SubItems[1].Text;
			selectedUser.LastName = userListView.SelectedItems[0].SubItems[2].Text;
			selectedUser.Email = userListView.SelectedItems[0].SubItems[3].Text;

			userFirstNameTextBox.Text = selectedUser.FirstName.ToString();
			userLastNameTextBox.Text = selectedUser.LastName.ToString();
		}

		private void addButton_Click_1(object sender, EventArgs e)
		{
			user.UserId = 0;
			user.FirstName = userFirstNameTextBox.Text;
			user.LastName = userLastNameTextBox.Text;
			user.LastName = userEmailTextBox.Text;

			//userService.Add(user);
			userFirstNameTextBox.Clear();
			userLastNameTextBox.Clear();
			refreshButton_Click(sender, e);
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			selectedUser.Email = userEmailTextBox.Text;
			selectedUser.FirstName = userFirstNameTextBox.Text;
			selectedUser.LastName = userLastNameTextBox.Text;

			userService.Delete(selectedUser.Email);
			refreshButton_Click(sender, e);

			userEmailTextBox.Clear();
			userFirstNameTextBox.Clear();
			userLastNameTextBox.Clear();
		}
	}
}
