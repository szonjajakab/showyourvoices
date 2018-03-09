using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Show_Your_Voices
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Tag = this;
            form1.Show(this);
            Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            int i = this.bunifuDropdown1.selectedIndex;
            this.bunifuDropdown1.selectedIndex = this.bunifuDropdown2.selectedIndex;
            this.bunifuDropdown2.selectedIndex = i;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer2.uiMode = "none";
            bunifuDropdown1.selectedIndex = -1;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var pl1 = axWindowsMediaPlayer1.playlistCollection.newPlaylist("plList1");
            pl1.appendItem(axWindowsMediaPlayer1.newMedia("budapestcsiga.avi"));
            axWindowsMediaPlayer1.currentPlaylist = pl1;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            var pl2 = axWindowsMediaPlayer2.playlistCollection.newPlaylist("plList2");
            pl2.appendItem(axWindowsMediaPlayer2.newMedia("csiga szeged.avi"));
            axWindowsMediaPlayer2.currentPlaylist = pl2;
            axWindowsMediaPlayer2.Ctlcontrols.play();
        }
    }
}
