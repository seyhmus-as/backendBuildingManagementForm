using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
	public partial class UserClaimForm : Form
	{
		private TextBox renterLastNameTextBox;
		private ColumnHeader operationClaimId;
		private ColumnHeader userId;
		private ColumnHeader userOperationClaimId;
		private Label operationClaimIdLabel;
		private Button updateButton;
		private Button showAddingButton;
		private Label userIdLabel;
		private Button refreshButton;
		private Button showUpdateButton;
		private Button deleteButton;
		private Button addButton;
		private ListView userOperationClaimListView;
		private TextBox renterFirstNameTextBox;

		private IUserOperationClaimService userOperationClaimService = new UserOperationClaimManager(new EfUserOperationClaimDal());
		private UserOperationClaim selectedUserOperationClaim = new UserOperationClaim();
		private UserOperationClaim userOperationClaim = new UserOperationClaim();

		public UserClaimForm()
		{
			InitializeComponent();
			this.FormClosed += new FormClosedEventHandler(UserClaimFormClosed);

		}
		void UserClaimFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.Show();
		}
		private void InitializeComponent()
		{
			this.renterLastNameTextBox = new System.Windows.Forms.TextBox();
			this.operationClaimId = new System.Windows.Forms.ColumnHeader();
			this.userId = new System.Windows.Forms.ColumnHeader();
			this.userOperationClaimId = new System.Windows.Forms.ColumnHeader();
			this.operationClaimIdLabel = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.showAddingButton = new System.Windows.Forms.Button();
			this.userIdLabel = new System.Windows.Forms.Label();
			this.refreshButton = new System.Windows.Forms.Button();
			this.showUpdateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.userOperationClaimListView = new System.Windows.Forms.ListView();
			this.renterFirstNameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// renterLastNameTextBox
			// 
			this.renterLastNameTextBox.Location = new System.Drawing.Point(132, 217);
			this.renterLastNameTextBox.Name = "renterLastNameTextBox";
			this.renterLastNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.renterLastNameTextBox.TabIndex = 52;
			this.renterLastNameTextBox.Visible = false;
			// 
			// operationClaimId
			// 
			this.operationClaimId.Text = "Operation Claim Id";
			this.operationClaimId.Width = 140;
			// 
			// userId
			// 
			this.userId.Text = "User Id";
			this.userId.Width = 140;
			// 
			// userOperationClaimId
			// 
			this.userOperationClaimId.Text = "User Operation Claim Id";
			this.userOperationClaimId.Width = 140;
			// 
			// operationClaimIdLabel
			// 
			this.operationClaimIdLabel.AutoSize = true;
			this.operationClaimIdLabel.Location = new System.Drawing.Point(20, 217);
			this.operationClaimIdLabel.Name = "operationClaimIdLabel";
			this.operationClaimIdLabel.Size = new System.Drawing.Size(107, 15);
			this.operationClaimIdLabel.TabIndex = 53;
			this.operationClaimIdLabel.Text = "Operation Claim Id";
			this.operationClaimIdLabel.Visible = false;
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(132, 311);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(220, 34);
			this.updateButton.TabIndex = 51;
			this.updateButton.Text = "Update Renter";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// showAddingButton
			// 
			this.showAddingButton.Location = new System.Drawing.Point(16, 34);
			this.showAddingButton.Name = "showAddingButton";
			this.showAddingButton.Size = new System.Drawing.Size(357, 38);
			this.showAddingButton.TabIndex = 50;
			this.showAddingButton.Text = "Add";
			this.showAddingButton.UseVisualStyleBackColor = true;
			this.showAddingButton.Click += new System.EventHandler(this.showAddingButton_Click);
			// 
			// userIdLabel
			// 
			this.userIdLabel.AutoSize = true;
			this.userIdLabel.Location = new System.Drawing.Point(20, 176);
			this.userIdLabel.Name = "userIdLabel";
			this.userIdLabel.Size = new System.Drawing.Size(43, 15);
			this.userIdLabel.TabIndex = 49;
			this.userIdLabel.Text = "User Id";
			this.userIdLabel.Visible = false;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(396, 34);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(531, 38);
			this.refreshButton.TabIndex = 47;
			this.refreshButton.Text = "Refresh List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// showUpdateButton
			// 
			this.showUpdateButton.Location = new System.Drawing.Point(664, 377);
			this.showUpdateButton.Name = "showUpdateButton";
			this.showUpdateButton.Size = new System.Drawing.Size(263, 39);
			this.showUpdateButton.TabIndex = 46;
			this.showUpdateButton.Text = "Update";
			this.showUpdateButton.UseVisualStyleBackColor = true;
			this.showUpdateButton.Click += new System.EventHandler(this.showUpdateButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(395, 377);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(263, 39);
			this.deleteButton.TabIndex = 45;
			this.deleteButton.Text = "Delete ";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(132, 259);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(220, 37);
			this.addButton.TabIndex = 44;
			this.addButton.Text = "Add New Renter";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Visible = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// userOperationClaimListView
			// 
			this.userOperationClaimListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.userOperationClaimId,
            this.userId,
            this.operationClaimId});
			this.userOperationClaimListView.FullRowSelect = true;
			this.userOperationClaimListView.HideSelection = false;
			this.userOperationClaimListView.Location = new System.Drawing.Point(396, 78);
			this.userOperationClaimListView.MultiSelect = false;
			this.userOperationClaimListView.Name = "userOperationClaimListView";
			this.userOperationClaimListView.Size = new System.Drawing.Size(531, 293);
			this.userOperationClaimListView.TabIndex = 43;
			this.userOperationClaimListView.UseCompatibleStateImageBehavior = false;
			this.userOperationClaimListView.View = System.Windows.Forms.View.Details;
			// 
			// renterFirstNameTextBox
			// 
			this.renterFirstNameTextBox.Location = new System.Drawing.Point(133, 173);
			this.renterFirstNameTextBox.Name = "renterFirstNameTextBox";
			this.renterFirstNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.renterFirstNameTextBox.TabIndex = 48;
			this.renterFirstNameTextBox.Visible = false;
			// 
			// UserClaimForm
			// 
			this.ClientSize = new System.Drawing.Size(960, 460);
			this.Controls.Add(this.renterLastNameTextBox);
			this.Controls.Add(this.operationClaimIdLabel);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.showAddingButton);
			this.Controls.Add(this.userIdLabel);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.showUpdateButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.userOperationClaimListView);
			this.Controls.Add(this.renterFirstNameTextBox);
			this.Name = "UserClaimForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private void refreshButton_Click(object sender, EventArgs e)
		{

			IUserOperationClaimService userOperationClaimService = new UserOperationClaimManager(new EfUserOperationClaimDal());

			userOperationClaimListView.Items.Clear();
			IDataResult<List<UserOperationClaim>> userOperationClaims = userOperationClaimService.GetAll();
			foreach (var i in userOperationClaims.Data)
			{
				ListViewItem userOperationClaimLVT = new ListViewItem(i.Id.ToString());
				userOperationClaimLVT.SubItems.Add(i.UserId.ToString());
				userOperationClaimLVT.SubItems.Add(i.OperationClaimId.ToString());

				userOperationClaimListView.Items.Add(userOperationClaimLVT);
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			selectedUserOperationClaim.Id = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[0].Text);
			selectedUserOperationClaim.UserId = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[1].Text);
			selectedUserOperationClaim.OperationClaimId = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[2].Text);

			userOperationClaimService.Delete(selectedUserOperationClaim.Id);
			refreshButton_Click(sender, e);
		}

		private void showAddingButton_Click(object sender, EventArgs e)
		{
			this.userIdLabel.Visible = true;
			this.operationClaimIdLabel.Visible = true;

			this.renterFirstNameTextBox.Visible = true;
			this.renterLastNameTextBox.Visible = true;
			this.addButton.Visible = true;
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			selectedUserOperationClaim.UserId = Int32.Parse(renterFirstNameTextBox.Text);
			selectedUserOperationClaim.OperationClaimId = Int32.Parse(renterLastNameTextBox.Text);

			userOperationClaimService.Update(selectedUserOperationClaim);
			refreshButton_Click(sender, e);

			renterFirstNameTextBox.Clear();
			renterLastNameTextBox.Clear();
		}

		private void showUpdateButton_Click(object sender, EventArgs e)
		{
			this.userIdLabel.Visible = true;
			this.operationClaimIdLabel.Visible = true;

			this.renterFirstNameTextBox.Visible = true;
			this.renterLastNameTextBox.Visible = true;

			this.updateButton.Visible = true;

			selectedUserOperationClaim.Id = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[0].Text);
			selectedUserOperationClaim.UserId = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[1].Text);
			selectedUserOperationClaim.OperationClaimId = Int32.Parse(userOperationClaimListView.SelectedItems[0].SubItems[2].Text);

			renterFirstNameTextBox.Text = selectedUserOperationClaim.UserId.ToString();
			renterLastNameTextBox.Text = selectedUserOperationClaim.OperationClaimId.ToString();
		}

		private void addButton_Click(object sender, EventArgs e)
		{

			userOperationClaim.Id = 0;
			userOperationClaim.UserId = Int32.Parse(renterFirstNameTextBox.Text);
			userOperationClaim.OperationClaimId = Int32.Parse(renterLastNameTextBox.Text);

			userOperationClaimService.Add(userOperationClaim);
			renterFirstNameTextBox.Clear();
			renterLastNameTextBox.Clear();
			refreshButton_Click(sender, e);
		}
	}
}
