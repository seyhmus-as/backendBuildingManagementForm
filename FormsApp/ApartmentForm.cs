using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
	public partial class ApartmentForm : Form
	{
		private ListView apartmentListView;
		private TextBox apartmentNameTextBox;
		private TextBox numberOfFloorTextBox;
		private TextBox numberOfFlatTextBox;
		private Label apartmentNameLabel;
		private Label numberOfFlatLabel;
		private Label numberOfFloorLabel;
		private Button showUpdateButton;
		private ColumnHeader ApartmentId;
		private ColumnHeader ApartmentName;
		private ColumnHeader numberOfFloor;
		private ColumnHeader numberOfFlat;

		private Button addButton;
		private Button deleteButton;
		private Button refreshButton;
		private Button showAddingButton;
		private Button updateButton;

		private IApartmentService apartmentService = new ApartmentManager(new EfApartmentDal());
		private Apartment selectedApartment = new Apartment();
		private Apartment apartment = new Apartment();

		public ApartmentForm()
		{
			InitializeComponent();
			this.FormClosed += new FormClosedEventHandler(ApartmentForm_Closed);
		}		

		void ApartmentForm_Closed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.Show();
		}

		private void InitializeComponent()
		{
			this.apartmentListView = new System.Windows.Forms.ListView();
			this.ApartmentId = new System.Windows.Forms.ColumnHeader();
			this.ApartmentName = new System.Windows.Forms.ColumnHeader();
			this.numberOfFlat = new System.Windows.Forms.ColumnHeader();
			this.numberOfFloor = new System.Windows.Forms.ColumnHeader();
			this.addButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.showUpdateButton = new System.Windows.Forms.Button();
			this.refreshButton = new System.Windows.Forms.Button();
			this.apartmentNameTextBox = new System.Windows.Forms.TextBox();
			this.numberOfFloorTextBox = new System.Windows.Forms.TextBox();
			this.numberOfFlatTextBox = new System.Windows.Forms.TextBox();
			this.apartmentNameLabel = new System.Windows.Forms.Label();
			this.numberOfFlatLabel = new System.Windows.Forms.Label();
			this.numberOfFloorLabel = new System.Windows.Forms.Label();
			this.showAddingButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// apartmentListView
			// 
			this.apartmentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ApartmentId,
            this.ApartmentName,
            this.numberOfFlat,
            this.numberOfFloor});
			this.apartmentListView.FullRowSelect = true;
			this.apartmentListView.HideSelection = false;
			this.apartmentListView.Location = new System.Drawing.Point(395, 78);
			this.apartmentListView.MultiSelect = false;
			this.apartmentListView.Name = "apartmentListView";
			this.apartmentListView.Size = new System.Drawing.Size(531, 293);
			this.apartmentListView.TabIndex = 0;
			this.apartmentListView.UseCompatibleStateImageBehavior = false;
			this.apartmentListView.View = System.Windows.Forms.View.Details;
			// 
			// ApartmentId
			// 
			this.ApartmentId.Text = "Apartment Id";
			this.ApartmentId.Width = 82;
			// 
			// ApartmentName
			// 
			this.ApartmentName.Text = "Apartment Name";
			this.ApartmentName.Width = 104;
			// 
			// numberOfFlat
			// 
			this.numberOfFlat.Text = "Number Of Flat";
			this.numberOfFlat.Width = 94;
			// 
			// numberOfFloor
			// 
			this.numberOfFloor.Text = "Number Of Floor";
			this.numberOfFloor.Width = 304;
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(119, 263);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(220, 37);
			this.addButton.TabIndex = 1;
			this.addButton.Text = "Add New Apartment";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Visible = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(394, 377);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(263, 39);
			this.deleteButton.TabIndex = 2;
			this.deleteButton.Text = "Delete ";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// showUpdateButton
			// 
			this.showUpdateButton.Location = new System.Drawing.Point(663, 377);
			this.showUpdateButton.Name = "showUpdateButton";
			this.showUpdateButton.Size = new System.Drawing.Size(263, 39);
			this.showUpdateButton.TabIndex = 3;
			this.showUpdateButton.Text = "Update";
			this.showUpdateButton.UseVisualStyleBackColor = true;
			this.showUpdateButton.Click += new System.EventHandler(this.showUpdateButton_Click);
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(395, 34);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(531, 38);
			this.refreshButton.TabIndex = 4;
			this.refreshButton.Text = "Refresh List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// apartmentNameTextBox
			// 
			this.apartmentNameTextBox.Location = new System.Drawing.Point(119, 130);
			this.apartmentNameTextBox.Name = "apartmentNameTextBox";
			this.apartmentNameTextBox.Size = new System.Drawing.Size(220, 23);
			this.apartmentNameTextBox.TabIndex = 5;
			this.apartmentNameTextBox.Visible = false;
			// 
			// numberOfFloorTextBox
			// 
			this.numberOfFloorTextBox.Location = new System.Drawing.Point(119, 172);
			this.numberOfFloorTextBox.Name = "numberOfFloorTextBox";
			this.numberOfFloorTextBox.Size = new System.Drawing.Size(220, 23);
			this.numberOfFloorTextBox.TabIndex = 6;
			this.numberOfFloorTextBox.Visible = false;
			// 
			// numberOfFlatTextBox
			// 
			this.numberOfFlatTextBox.Location = new System.Drawing.Point(119, 214);
			this.numberOfFlatTextBox.Name = "numberOfFlatTextBox";
			this.numberOfFlatTextBox.Size = new System.Drawing.Size(220, 23);
			this.numberOfFlatTextBox.TabIndex = 7;
			this.numberOfFlatTextBox.Visible = false;
			// 
			// apartmentNameLabel
			// 
			this.apartmentNameLabel.AutoSize = true;
			this.apartmentNameLabel.Location = new System.Drawing.Point(10, 133);
			this.apartmentNameLabel.Name = "apartmentNameLabel";
			this.apartmentNameLabel.Size = new System.Drawing.Size(105, 15);
			this.apartmentNameLabel.TabIndex = 8;
			this.apartmentNameLabel.Text = "Apartment Name :";
			this.apartmentNameLabel.Visible = false;
			// 
			// numberOfFlatLabel
			// 
			this.numberOfFlatLabel.AutoSize = true;
			this.numberOfFlatLabel.Location = new System.Drawing.Point(10, 217);
			this.numberOfFlatLabel.Name = "numberOfFlatLabel";
			this.numberOfFlatLabel.Size = new System.Drawing.Size(93, 15);
			this.numberOfFlatLabel.TabIndex = 9;
			this.numberOfFlatLabel.Text = "Number of Flat :";
			this.numberOfFlatLabel.Visible = false;
			// 
			// numberOfFloorLabel
			// 
			this.numberOfFloorLabel.AutoSize = true;
			this.numberOfFloorLabel.Location = new System.Drawing.Point(10, 175);
			this.numberOfFloorLabel.Name = "numberOfFloorLabel";
			this.numberOfFloorLabel.Size = new System.Drawing.Size(101, 15);
			this.numberOfFloorLabel.TabIndex = 10;
			this.numberOfFloorLabel.Text = "Number of Floor :";
			this.numberOfFloorLabel.Visible = false;
			// 
			// showAddingButton
			// 
			this.showAddingButton.Location = new System.Drawing.Point(15, 34);
			this.showAddingButton.Name = "showAddingButton";
			this.showAddingButton.Size = new System.Drawing.Size(357, 38);
			this.showAddingButton.TabIndex = 11;
			this.showAddingButton.Text = "Add";
			this.showAddingButton.UseVisualStyleBackColor = true;
			this.showAddingButton.Click += new System.EventHandler(this.showAddingButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(119, 322);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(220, 34);
			this.updateButton.TabIndex = 12;
			this.updateButton.Text = "Update Aparment";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// ApartmentForm
			// 
			this.ClientSize = new System.Drawing.Size(960, 460);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.showAddingButton);
			this.Controls.Add(this.numberOfFloorLabel);
			this.Controls.Add(this.numberOfFlatLabel);
			this.Controls.Add(this.apartmentNameLabel);
			this.Controls.Add(this.numberOfFloorTextBox);
			this.Controls.Add(this.apartmentNameTextBox);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.showUpdateButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.apartmentListView);
			this.Controls.Add(this.numberOfFlatTextBox);
			this.Name = "ApartmentForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void addButton_Click(object sender, EventArgs e)
		{
			apartment.Id = 0;
			apartment.Name = apartmentNameTextBox.Text;
			apartment.NumberOfFloor = Int32.Parse(numberOfFloorTextBox.Text);
			apartment.NumberOfFlat = Int32.Parse(numberOfFlatTextBox.Text);

			apartmentService.Add(apartment);
			apartmentNameTextBox.Clear();
			numberOfFlatTextBox.Clear();
			numberOfFloorTextBox.Clear();
			refreshButton_Click(sender,e);
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			selectedApartment.Id = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[0].Text);
			selectedApartment.Name = apartmentListView.SelectedItems[0].SubItems[1].Text;
			selectedApartment.NumberOfFloor = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[2].Text);
			selectedApartment.NumberOfFlat = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[3].Text);

			apartmentService.Delete(selectedApartment.Id);
			refreshButton_Click(sender, e);
		}

		private void showUpdateButton_Click(object sender, EventArgs e)
		{
			this.apartmentNameLabel.Visible = true;
			this.numberOfFlatLabel.Visible = true;
			this.numberOfFloorLabel.Visible = true;
			this.apartmentNameTextBox.Visible = true;
			this.numberOfFlatTextBox.Visible = true;
			this.numberOfFloorTextBox.Visible = true;
			this.updateButton.Visible = true;

			selectedApartment.Id = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[0].Text);
			selectedApartment.Name = apartmentListView.SelectedItems[0].SubItems[1].Text;
			selectedApartment.NumberOfFloor = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[2].Text);
			selectedApartment.NumberOfFlat = Int32.Parse(apartmentListView.SelectedItems[0].SubItems[3].Text);

			apartmentNameTextBox.Text = selectedApartment.Name;
			numberOfFloorTextBox.Text = selectedApartment.NumberOfFloor.ToString();
			numberOfFlatTextBox.Text = selectedApartment.NumberOfFlat.ToString();
		}

		private void showAddingButton_Click(object sender, EventArgs e)
		{
			this.apartmentNameLabel.Visible = true;
			this.numberOfFlatLabel.Visible = true;
			this.numberOfFloorLabel.Visible = true;
			this.apartmentNameTextBox.Visible = true;
			this.numberOfFlatTextBox.Visible = true;
			this.numberOfFloorTextBox.Visible = true;
			this.addButton.Visible = true;
		}

		private void refreshButton_Click(object sender, EventArgs e)
		{
			apartmentListView.Items.Clear();
			IDataResult<List<Apartment>> apartments = apartmentService.GetAll();
			foreach (var i in apartments.Data)
			{
				ListViewItem apartmentLVT = new ListViewItem(i.Id.ToString());
				apartmentLVT.SubItems.Add(i.Name);
				apartmentLVT.SubItems.Add(i.NumberOfFloor.ToString());
				apartmentLVT.SubItems.Add(i.NumberOfFlat.ToString());

				apartmentListView.Items.Add(apartmentLVT);
			}
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			selectedApartment.Name = apartmentNameTextBox.Text;
			selectedApartment.NumberOfFloor = Int32.Parse(numberOfFloorTextBox.Text);
			selectedApartment.NumberOfFlat = Int32.Parse(numberOfFlatTextBox.Text);
			apartmentService.Update(selectedApartment);
			refreshButton_Click(sender, e);
			apartmentNameTextBox.Clear();
			numberOfFlatTextBox.Clear();
			numberOfFloorTextBox.Clear();
		}
	}
}
