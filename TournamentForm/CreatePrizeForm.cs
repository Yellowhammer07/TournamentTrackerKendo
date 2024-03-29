﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TournamentLibrary;
using TournamentLibrary.DataAccess;
using TournamentLibrary.Models;

namespace TournamentForm
{
    public partial class CreatePrizeForm : Form
    {
		IPrizeRequester callingForm;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

			callingForm = caller;
		}

		private void createPrizeButton_Click(object sender, EventArgs e)
        {
			if(ValidateForm())
            {
				PrizeModel model = new PrizeModel(
					prizeNameValue.Text,
					prizeNumberValue.Text,
					prizeAmountValue.Text);

				GlobalConfig.Connections.CreatePrize(model);

				callingForm.PrizeComplete(model);

				this.Close();
			}
			else
            {
				MessageBox.Show("This form has invalid information.");
            }
        }
		private bool ValidateForm()
		{
			bool output = true;
			bool prizeNumberValidNumber = int.TryParse(prizeNumberValue.Text, out int prizeNumber);

			if (prizeNumberValidNumber == false)
			{
				output = false;
			}

			if (prizeNameValue.Text.Length == 0)
			{
				output = false;
			}

			if (prizeNumber < 1)
			{
				output = false;
			}

			bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmount);

			return output;
		}
	}
}
