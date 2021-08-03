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
	public partial class FlatForm : Form
	{
		private Button updateButton;
		private Button showAddingButton;
		private Label aparmentIdLabel;
		private Label flatNoLabel;
		private TextBox renterIdTextBox;
		private TextBox flatNoTextBox;
		private Button refreshButton;
		private Button showUpdateButton;
		private Button deleteButton;
		private Button addButton;
		private ListView flatListView;
		private ColumnHeader flatId;
		private ColumnHeader FlatNo;
		private ColumnHeader renterId;
		private ColumnHeader apartmentId;
		private ColumnHeader priceOfRent;
		private TextBox aparmentIdTextBox;
		private Label renterIdLabel;
		private Label priceOfRentLabel;
		private TextBox priceOfRentTextBox;

		private IFlatService flatService = new FlatManager(new EfFlatDal());
		private Flat selectedFlat = new Flat();
		private Flat flat = new Flat();
		

		public FlatForm()
		{
			InitializeComponent();
			this.FormClosed += new FormClosedEventHandler(FlatFormClosed);

		}
		void FlatFormClosed(object sender, FormClosedEventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.Show();
		}

		private void InitializeComponent()
		{
			this.updateButton = new System.Windows.Forms.Button();
			this.showAddingButton = new System.Windows.Forms.Button();
			this.aparmentIdLabel = new System.Windows.Forms.Label();
			this.flatNoLabel = new System.Windows.Forms.Label();
			this.renterIdTextBox = new System.Windows.Forms.TextBox();
			this.flatNoTextBox = new System.Windows.Forms.TextBox();
			this.refreshButton = new System.Windows.Forms.Button();
			this.showUpdateButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.addButton = new System.Windows.Forms.Button();
			this.flatListView = new System.Windows.Forms.ListView();
			this.flatId = new System.Windows.Forms.ColumnHeader();
			this.FlatNo = new System.Windows.Forms.ColumnHeader();
			this.renterId = new System.Windows.Forms.ColumnHeader();
			this.apartmentId = new System.Windows.Forms.ColumnHeader();
			this.priceOfRent = new System.Windows.Forms.ColumnHeader();
			this.aparmentIdTextBox = new System.Windows.Forms.TextBox();
			this.renterIdLabel = new System.Windows.Forms.Label();
			this.priceOfRentLabel = new System.Windows.Forms.Label();
			this.priceOfRentTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// updateButton
			// 
			this.updateButton.Location = new System.Drawing.Point(119, 351);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(220, 34);
			this.updateButton.TabIndex = 25;
			this.updateButton.Text = "Update Flat";
			this.updateButton.UseVisualStyleBackColor = true;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
			// 
			// showAddingButton
			// 
			this.showAddingButton.Location = new System.Drawing.Point(15, 34);
			this.showAddingButton.Name = "showAddingButton";
			this.showAddingButton.Size = new System.Drawing.Size(357, 38);
			this.showAddingButton.TabIndex = 24;
			this.showAddingButton.Text = "Add";
			this.showAddingButton.UseVisualStyleBackColor = true;
			this.showAddingButton.Click += new System.EventHandler(this.showAddingButton_Click);
			// 
			// aparmentIdLabel
			// 
			this.aparmentIdLabel.AutoSize = true;
			this.aparmentIdLabel.Location = new System.Drawing.Point(19, 217);
			this.aparmentIdLabel.Name = "aparmentIdLabel";
			this.aparmentIdLabel.Size = new System.Drawing.Size(83, 15);
			this.aparmentIdLabel.TabIndex = 23;
			this.aparmentIdLabel.Text = "Apartment Id :";
			this.aparmentIdLabel.Visible = false;
			// 
			// flatNoLabel
			// 
			this.flatNoLabel.AutoSize = true;
			this.flatNoLabel.Location = new System.Drawing.Point(19, 130);
			this.flatNoLabel.Name = "flatNoLabel";
			this.flatNoLabel.Size = new System.Drawing.Size(51, 15);
			this.flatNoLabel.TabIndex = 21;
			this.flatNoLabel.Text = "Flat No :";
			this.flatNoLabel.Visible = false;
			// 
			// renterIdTextBox
			// 
			this.renterIdTextBox.Location = new System.Drawing.Point(119, 172);
			this.renterIdTextBox.Name = "renterIdTextBox";
			this.renterIdTextBox.Size = new System.Drawing.Size(220, 23);
			this.renterIdTextBox.TabIndex = 19;
			this.renterIdTextBox.Visible = false;
			// 
			// flatNoTextBox
			// 
			this.flatNoTextBox.Location = new System.Drawing.Point(119, 130);
			this.flatNoTextBox.Name = "flatNoTextBox";
			this.flatNoTextBox.Size = new System.Drawing.Size(220, 23);
			this.flatNoTextBox.TabIndex = 18;
			this.flatNoTextBox.Visible = false;
			// 
			// refreshButton
			// 
			this.refreshButton.Location = new System.Drawing.Point(395, 34);
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(531, 38);
			this.refreshButton.TabIndex = 17;
			this.refreshButton.Text = "Refresh List";
			this.refreshButton.UseVisualStyleBackColor = true;
			this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
			// 
			// showUpdateButton
			// 
			this.showUpdateButton.Location = new System.Drawing.Point(663, 377);
			this.showUpdateButton.Name = "showUpdateButton";
			this.showUpdateButton.Size = new System.Drawing.Size(263, 39);
			this.showUpdateButton.TabIndex = 16;
			this.showUpdateButton.Text = "Update";
			this.showUpdateButton.UseVisualStyleBackColor = true;
			this.showUpdateButton.Click += new System.EventHandler(this.showUpdateButton_Click);
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(394, 377);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(263, 39);
			this.deleteButton.TabIndex = 15;
			this.deleteButton.Text = "Delete ";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// addButton
			// 
			this.addButton.Location = new System.Drawing.Point(119, 299);
			this.addButton.Name = "addButton";
			this.addButton.Size = new System.Drawing.Size(220, 37);
			this.addButton.TabIndex = 14;
			this.addButton.Text = "Add New Flat";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Visible = false;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// flatListView
			// 
			this.flatListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.flatId,
            this.FlatNo,
            this.renterId,
            this.apartmentId,
            this.priceOfRent});
			this.flatListView.FullRowSelect = true;
			this.flatListView.HideSelection = false;
			this.flatListView.Location = new System.Drawing.Point(395, 78);
			this.flatListView.MultiSelect = false;
			this.flatListView.Name = "flatListView";
			this.flatListView.Size = new System.Drawing.Size(531, 293);
			this.flatListView.TabIndex = 13;
			this.flatListView.UseCompatibleStateImageBehavior = false;
			this.flatListView.View = System.Windows.Forms.View.Details;
			this.flatListView.SelectedIndexChanged += new System.EventHandler(this.apartmentListView_SelectedIndexChanged);
			// 
			// flatId
			// 
			this.flatId.Text = "Flat Id";
			this.flatId.Width = 82;
			// 
			// FlatNo
			// 
			this.FlatNo.Text = "Flat No";
			this.FlatNo.Width = 104;
			// 
			// renterId
			// 
			this.renterId.Text = "Renter Id";
			this.renterId.Width = 94;
			// 
			// apartmentId
			// 
			this.apartmentId.Text = "Aparment Id";
			this.apartmentId.Width = 120;
			// 
			// priceOfRent
			// 
			this.priceOfRent.Text = "Price Of Rent";
			this.priceOfRent.Width = 100;
			// 
			// aparmentIdTextBox
			// 
			this.aparmentIdTextBox.Location = new System.Drawing.Point(119, 214);
			this.aparmentIdTextBox.Name = "aparmentIdTextBox";
			this.aparmentIdTextBox.Size = new System.Drawing.Size(220, 23);
			this.aparmentIdTextBox.TabIndex = 20;
			this.aparmentIdTextBox.Visible = false;
			// 
			// renterIdLabel
			// 
			this.renterIdLabel.AutoSize = true;
			this.renterIdLabel.Location = new System.Drawing.Point(19, 175);
			this.renterIdLabel.Name = "renterIdLabel";
			this.renterIdLabel.Size = new System.Drawing.Size(60, 15);
			this.renterIdLabel.TabIndex = 22;
			this.renterIdLabel.Text = "Renter Id :";
			this.renterIdLabel.Visible = false;
			// 
			// priceOfRentLabel
			// 
			this.priceOfRentLabel.AutoSize = true;
			this.priceOfRentLabel.Location = new System.Drawing.Point(19, 258);
			this.priceOfRentLabel.Name = "priceOfRentLabel";
			this.priceOfRentLabel.Size = new System.Drawing.Size(82, 15);
			this.priceOfRentLabel.TabIndex = 27;
			this.priceOfRentLabel.Text = "Price Of Rent :";
			this.priceOfRentLabel.Visible = false;
			// 
			// priceOfRentTextBox
			// 
			this.priceOfRentTextBox.Location = new System.Drawing.Point(119, 258);
			this.priceOfRentTextBox.Name = "priceOfRentTextBox";
			this.priceOfRentTextBox.Size = new System.Drawing.Size(220, 23);
			this.priceOfRentTextBox.TabIndex = 26;
			this.priceOfRentTextBox.Visible = false;
			// 
			// FlatForm
			// 
			this.ClientSize = new System.Drawing.Size(960, 460);
			this.Controls.Add(this.priceOfRentLabel);
			this.Controls.Add(this.priceOfRentTextBox);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.showAddingButton);
			this.Controls.Add(this.aparmentIdLabel);
			this.Controls.Add(this.renterIdLabel);
			this.Controls.Add(this.flatNoLabel);
			this.Controls.Add(this.renterIdTextBox);
			this.Controls.Add(this.flatNoTextBox);
			this.Controls.Add(this.refreshButton);
			this.Controls.Add(this.showUpdateButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.addButton);
			this.Controls.Add(this.flatListView);
			this.Controls.Add(this.aparmentIdTextBox);
			this.Name = "FlatForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void apartmentListView_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void refreshButton_Click(object sender, EventArgs e)
		{

			IFlatService flatService = new FlatManager(new EfFlatDal());

			flatListView.Items.Clear();
			IDataResult<List<Flat>> flats = flatService.GetAll();
			foreach (var i in flats.Data)
			{
				ListViewItem flatLVT = new ListViewItem(i.Id.ToString());
				flatLVT.SubItems.Add(i.FlatNo.ToString());
				flatLVT.SubItems.Add(i.RenterId.ToString());
				flatLVT.SubItems.Add(i.ApartmentId.ToString());
				flatLVT.SubItems.Add(i.PriceOfRent.ToString());

				flatListView.Items.Add(flatLVT);
			}
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			selectedFlat.Id = Int32.Parse(flatListView.SelectedItems[0].SubItems[0].Text);
			selectedFlat.FlatNo = Int32.Parse(flatListView.SelectedItems[0].SubItems[1].Text);
			selectedFlat.RenterId = Int32.Parse(flatListView.SelectedItems[0].SubItems[2].Text);
			selectedFlat.ApartmentId = Int32.Parse(flatListView.SelectedItems[0].SubItems[3].Text);
			selectedFlat.PriceOfRent = Int32.Parse(flatListView.SelectedItems[0].SubItems[4].Text);

			flatService.Delete(selectedFlat.Id);
			refreshButton_Click(sender, e);
		}

		private void showAddingButton_Click(object sender, EventArgs e)
		{
			this.flatNoLabel.Visible = true;
			this.renterIdLabel.Visible = true;
			this.aparmentIdLabel.Visible = true;
			this.priceOfRentLabel.Visible = true;

			this.flatNoTextBox.Visible = true;
			this.aparmentIdTextBox.Visible = true;
			this.renterIdTextBox.Visible = true;
			this.priceOfRentTextBox.Visible = true;
			this.addButton.Visible = true;
		}

		private void updateButton_Click(object sender, EventArgs e)
		{
			selectedFlat.FlatNo = Int32.Parse(flatNoTextBox.Text);
			selectedFlat.RenterId = Int32.Parse(renterIdTextBox.Text);
			selectedFlat.ApartmentId = Int32.Parse(aparmentIdTextBox.Text);
			selectedFlat.PriceOfRent = Int32.Parse(priceOfRentTextBox.Text);

			flatService.Update(selectedFlat);
			refreshButton_Click(sender, e);

			flatNoTextBox.Clear();
			aparmentIdTextBox.Clear();
			renterIdTextBox.Clear();
		}

		private void showUpdateButton_Click(object sender, EventArgs e)
		{
			this.flatNoLabel.Visible = true;
			this.renterIdLabel.Visible = true;
			this.aparmentIdLabel.Visible = true;
			this.priceOfRentLabel.Visible = true;

			this.aparmentIdTextBox.Visible = true;
			this.flatNoTextBox.Visible = true;
			this.priceOfRentTextBox.Visible = true;
			this.renterIdTextBox.Visible = true;

			this.updateButton.Visible = true;

			selectedFlat.Id = Int32.Parse(flatListView.SelectedItems[0].SubItems[0].Text);
			selectedFlat.FlatNo = Int32.Parse(flatListView.SelectedItems[0].SubItems[1].Text);
			selectedFlat.RenterId = Int32.Parse(flatListView.SelectedItems[0].SubItems[2].Text);
			selectedFlat.ApartmentId = Int32.Parse(flatListView.SelectedItems[0].SubItems[3].Text);
			selectedFlat.PriceOfRent = Int32.Parse(flatListView.SelectedItems[0].SubItems[4].Text);

			flatNoTextBox.Text = selectedFlat.FlatNo.ToString();
			renterIdTextBox.Text = selectedFlat.RenterId.ToString();
			aparmentIdTextBox.Text = selectedFlat.ApartmentId.ToString();
			priceOfRentTextBox.Text = selectedFlat.PriceOfRent.ToString();
		}

		private void addButton_Click(object sender, EventArgs e)
		{

			flat.Id = 0;
			flat.FlatNo = Int32.Parse(flatNoTextBox.Text);
			flat.RenterId = Int32.Parse(renterIdTextBox.Text);
			flat.ApartmentId = Int32.Parse(aparmentIdTextBox.Text);
			flat.PriceOfRent = Int32.Parse(priceOfRentTextBox.Text);

			flatService.Add(flat);
			flatNoTextBox.Clear();
			aparmentIdTextBox.Clear();
			renterIdTextBox.Clear();
			priceOfRentTextBox.Clear();
			refreshButton_Click(sender, e);
		}
	}
}
