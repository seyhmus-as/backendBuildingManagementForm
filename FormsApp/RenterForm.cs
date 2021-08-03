using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
	public partial class RenterForm : Form
	{
		private TextBox renterLastNameTextBox;
		private ColumnHeader renterLastName;
		private ColumnHeader renterFirstName;
		private ColumnHeader renterId;
		private Label renterLastNameLabel;
		private Button updateButton;
		private Button showAddingButton;
		private Label renterFirstNameLabel;
		private Button refreshButton;
		private Button showUpdateButton;
		private Button deleteButton;
		private Button addButton;
		private ListView renterListView;
		private TextBox renterFirstNameTextBox;

		private IRenterService renterService = new RenterManager(new EfRenterDal());
		private Renter selectedRenter = new Renter();
		private Renter renter = new Renter();
		public RenterForm()
		{
			InitializeComponent();
			this.FormClosed += new FormClosedEventHandler(RenterFormClosed);

		}
		void RenterFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.Show();
		}

		private void InitializeComponent()
		{
			this.renterLastNameTextBox = new System.Windows.Forms.TextBox();
			this.renterLastName = new System.Windows.Forms.ColumnHeader();
			this.renterFirstName = new System.Windows.Forms.ColumnHeader();
			this.renterId = new System.Windows.Forms.ColumnHeader();
			this.renterLastNameLabel = new System.Windows.Forms.Label();
			this.updateButton = new System.Windows.Forms.Button();
			this.showAddingButton = new System.Windows.Forms.Button();
			this.renterFirstNameLabel = new System.Windows.Forms.Label();
			this.refreshButton = new System.Windows.Forms.Button();
			this.showUpdateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.renterListView = new System.Windows.Forms.ListView();
			this.renterFirstNameTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// renterLastNameTextBox
			// 
			this.renterLastNameTextBox.Location = new System.Drawing.Point(120, 216);
			this.renterLastNameTextBox.Name = "renterLastNameTextBox";
			this.renterLastNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.renterLastNameTextBox.TabIndex = 41;
			this.renterLastNameTextBox.Visible = false;
			// 
			// renterLastName
			// 
			this.renterLastName.Text = "Renter Last Name";
			this.renterLastName.Width = 120;
			// 
			// renterFirstName
			// 
			this.renterFirstName.Text = "Renter First Name";
			this.renterFirstName.Width = 120;
			// 
			// renterId
			// 
			this.renterId.Text = "Renter Id";
			this.renterId.Width = 82;
			// 
			// renterLastNameLabel
			// 
			this.renterLastNameLabel.AutoSize = true;
			this.renterLastNameLabel.Location = new System.Drawing.Point(20, 216);
			this.renterLastNameLabel.Name = "renterLastNameLabel";
			this.renterLastNameLabel.Size = new System.Drawing.Size(69, 15);
			this.renterLastNameLabel.TabIndex = 42;
			this.renterLastNameLabel.Text = "Last Name :";
			this.renterLastNameLabel.Visible = false;
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(120, 309);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(220, 34);
			this.updateButton.TabIndex = 40;
			this.updateButton.Text = "Update Renter";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// showAddingButton
			// 
			this.showAddingButton.Location = new System.Drawing.Point(16, 33);
			this.showAddingButton.Name = "showAddingButton";
			this.showAddingButton.Size = new System.Drawing.Size(357, 38);
			this.showAddingButton.TabIndex = 39;
			this.showAddingButton.Text = "Add";
			this.showAddingButton.UseVisualStyleBackColor = true;
			this.showAddingButton.Click += new System.EventHandler(this.showAddingButton_Click);
			// 
			// renterFirstNameLabel
			// 
			this.renterFirstNameLabel.AutoSize = true;
			this.renterFirstNameLabel.Location = new System.Drawing.Point(20, 175);
			this.renterFirstNameLabel.Name = "renterFirstNameLabel";
			this.renterFirstNameLabel.Size = new System.Drawing.Size(70, 15);
			this.renterFirstNameLabel.TabIndex = 38;
			this.renterFirstNameLabel.Text = "First Name :";
			this.renterFirstNameLabel.Visible = false;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(396, 33);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(531, 38);
			this.refreshButton.TabIndex = 32;
			this.refreshButton.Text = "Refresh List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// showUpdateButton
			// 
			this.showUpdateButton.Location = new System.Drawing.Point(664, 376);
			this.showUpdateButton.Name = "showUpdateButton";
			this.showUpdateButton.Size = new System.Drawing.Size(263, 39);
			this.showUpdateButton.TabIndex = 31;
			this.showUpdateButton.Text = "Update";
			this.showUpdateButton.UseVisualStyleBackColor = true;
			this.showUpdateButton.Click += new System.EventHandler(this.showUpdateButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(395, 376);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(263, 39);
			this.deleteButton.TabIndex = 30;
			this.deleteButton.Text = "Delete ";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(120, 257);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(220, 37);
			this.addButton.TabIndex = 29;
			this.addButton.Text = "Add New Renter";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Visible = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// renterListView
			// 
			this.renterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.renterId,
            this.renterFirstName,
            this.renterLastName});
			this.renterListView.FullRowSelect = true;
			this.renterListView.HideSelection = false;
			this.renterListView.Location = new System.Drawing.Point(396, 77);
			this.renterListView.MultiSelect = false;
			this.renterListView.Name = "renterListView";
			this.renterListView.Size = new System.Drawing.Size(531, 293);
			this.renterListView.TabIndex = 28;
			this.renterListView.UseCompatibleStateImageBehavior = false;
			this.renterListView.View = System.Windows.Forms.View.Details;
			// 
			// renterFirstNameTextBox
			// 
			this.renterFirstNameTextBox.Location = new System.Drawing.Point(120, 172);
			this.renterFirstNameTextBox.Name = "renterFirstNameTextBox";
			this.renterFirstNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.renterFirstNameTextBox.TabIndex = 35;
			this.renterFirstNameTextBox.Visible = false;
			// 
			// RenterForm
			// 
			this.ClientSize = new System.Drawing.Size(960, 460);
			this.Controls.Add(this.renterLastNameTextBox);
			this.Controls.Add(this.renterLastNameLabel);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.showAddingButton);
			this.Controls.Add(this.renterFirstNameLabel);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.showUpdateButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.renterListView);
			this.Controls.Add(this.renterFirstNameTextBox);
			this.Name = "RenterForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			IRenterService renterService = new RenterManager(new EfRenterDal());

			renterListView.Items.Clear();
			IDataResult<List<Renter>> renters = renterService.GetAll();
			foreach (var i in renters.Data)
			{
				ListViewItem renterLVT = new ListViewItem(i.Id.ToString());
				renterLVT.SubItems.Add(i.FirstName);
				renterLVT.SubItems.Add(i.LastName);

				renterListView.Items.Add(renterLVT);
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			selectedRenter.Id = Int32.Parse(renterListView.SelectedItems[0].SubItems[0].Text);
			selectedRenter.FirstName = renterListView.SelectedItems[0].SubItems[1].Text;
			selectedRenter.LastName = renterListView.SelectedItems[0].SubItems[2].Text;

			renterService.Delete(selectedRenter.Id);
			refreshButton_Click(sender, e);
		}

		private void showAddingButton_Click(object sender, EventArgs e)
		{
			this.renterFirstNameLabel.Visible = true;
			this.renterLastNameLabel.Visible = true;

			this.renterFirstNameTextBox.Visible = true;
			this.renterLastNameTextBox.Visible = true;

			this.addButton.Visible = true;
		}

		private void addButton_Click(object sender, EventArgs e)
		{
			renter.Id = 0;
			renter.FirstName = renterFirstNameTextBox.Text;
			renter.LastName = renterLastNameTextBox.Text;

			renterService.Add(renter);
			renterFirstNameTextBox.Clear();
			renterLastNameTextBox.Clear();
			refreshButton_Click(sender, e);
		}

		private void showUpdateButton_Click(object sender, EventArgs e)
		{
			this.renterFirstNameLabel.Visible = true;
			this.renterLastNameLabel.Visible = true;

			this.renterFirstNameTextBox.Visible = true;
			this.renterLastNameTextBox.Visible = true;

			this.updateButton.Visible = true;

			selectedRenter.Id = Int32.Parse(renterListView.SelectedItems[0].SubItems[0].Text);
			selectedRenter.FirstName = renterListView.SelectedItems[0].SubItems[1].Text;
			selectedRenter.LastName = renterListView.SelectedItems[0].SubItems[2].Text;

			renterFirstNameTextBox.Text = selectedRenter.FirstName.ToString();
			renterLastNameTextBox.Text = selectedRenter.LastName.ToString();
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			selectedRenter.FirstName = renterFirstNameTextBox.Text;
			selectedRenter.LastName = renterLastNameTextBox.Text;

			renterService.Update(selectedRenter);
			refreshButton_Click(sender, e);

			renterFirstNameTextBox.Clear();
			renterLastNameTextBox.Clear();
		}
	}
}
