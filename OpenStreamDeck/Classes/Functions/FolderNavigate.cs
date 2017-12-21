﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OpenStreamDeck.Functions;
using OpenStreamDeck.Handler;

namespace OpenStreamDeck.Functions
{
    class FolderNavigate : KeyFunction
    {
        public int PageReference;

        [JsonConstructor]
        public FolderNavigate()
        {
            base.isNavigationKey = true;
        }

        public FolderNavigate(DeckHandler dh) : base(dh)
        {
            base.isNavigationKey = true;
            dh.CurrentProfile.Pages.Add(new OpenStreamDeck.ProfileObjects.Page("New Page"));
            PageReference = dh.CurrentProfile.Pages.Count() - 1;
            dh.CurrentProfile.Pages[PageReference].Keys[4].setImage("Resources\\back.png");
            dh.CurrentProfile.Pages[PageReference].Keys[4].KeyPressedFunction = new GoBack(dh);
            dh.CurrentProfile.Pages[PageReference].Keys[4].KeyHeldFunction = new GoHome(dh);
        }

        public override string getFunctionName()
        {
            return "Navigate to folder";
        }

        public override void Run(DeckHandler dh)
        {
            dh.CurrentPage = PageReference;
            dh.renderPage();
        }

        public override void ShowForm()
        {
            MessageBox.Show("No settings to change for this function");
            //Form userInput = new Form();
            //userInput.Height = 200;
            //userInput.Width = 300;
            //userInput.FormBorderStyle = FormBorderStyle.FixedDialog;
            //userInput.Text = "";
            //TextBox pageReferenceBox = new TextBox()
            //{
            //    Location = new System.Drawing.Point(75, 50),
            //    Width = 125
            //};
            //userInput.Controls.Add(pageReferenceBox);
            //Button submitButton = new Button()
            //{
            //    Location = new System.Drawing.Point(100, 75),
            //    Text = "Submit"
            //};
            //submitButton.Click += submitButtonClicked;
            //userInput.Controls.Add(submitButton);

            //userInput.Show();
        }

        private void submitButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
