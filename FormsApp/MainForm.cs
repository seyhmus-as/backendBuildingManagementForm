using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void aparmentFormButton_Click(object sender, EventArgs e)
		{
			ApartmentForm apartmentForm = new ApartmentForm();
			this.Hide();
			apartmentForm.Show();
		}

		private void flatFormButton_Click(object sender, EventArgs e)
		{
			FlatForm flatForm = new FlatForm();
			this.Hide();
			flatForm.Show();
		}

		private void renterFormButton_Click(object sender, EventArgs e)
		{
			RenterForm renterForm = new RenterForm();
			this.Hide();
			renterForm.Show();
		}

		private void userFormButton_Click(object sender, EventArgs e)
		{
			UserForm userForm = new UserForm();
			this.Hide();
			userForm.Show();
		}

		private void userClaimFormButton_Click(object sender, EventArgs e)
		{
			UserClaimForm userClaimForm = new UserClaimForm();
			this.Hide();
			userClaimForm.Show();
		}

		private void exitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
