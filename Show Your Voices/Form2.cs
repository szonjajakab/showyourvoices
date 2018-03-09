using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Show_Your_Voices
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            
        }
        
        public string VideoId
        {
            get
            {
                string _ytUrlm = "https://www.youtube.com/watch?v=K7l1OGHNfeE";
                var ytMatch = new Regex(@"youtu(?:\.be|be\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)").Match(_ytUrlm);
                return ytMatch.Success ? ytMatch.Groups[1].Value : string.Empty;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate($"https://www.youtube.com/v/qcFDOdcVKnE&list=PLTe8eExcqIcHqq_zIf6qj2nGObMvR4uNg");
        }

        private void bunifuFlatButton6_Click_1(object sender, EventArgs e)
        {
            webBrowser1.Navigate($"https://www.youtube.com/v/DXryFnzyCwE&list=PLgt9o6zUPR2_2WR2YIpYDPkA-_7yMno1x");
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Tag = this;
            form1.Show(this);
            Hide();
        }

        private void bunifuImageButton2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
