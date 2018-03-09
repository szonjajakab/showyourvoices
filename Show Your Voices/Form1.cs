using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Show_Your_Voices
{
    public partial class Form1 : Form
    {

        struct Jel
        {
            public int ID;
            public List<string> jelentes;
            public string faj;
            public List<string> mihez;
        }

        List<Jel> L_Szotovek = new List<Jel>();
        List<Jel> L_Todalekok = new List<Jel>();

        public Form1()
        {
            InitializeComponent();
            ReadFile("szavak.csv", ref L_Szotovek, false);
            ReadFile("toldalékok.csv", ref L_Todalekok, true);
            panel5.Visible = false;
            axWindowsMediaPlayer1.uiMode = "none";

        }

        private void ReadFile(string path, ref List<Jel> list, bool toldalek)
        {
            string[] input = File.ReadAllLines(path, Encoding.Default);
            foreach (var item in input)
            {
                string[] seged = item.Split(';');
                Jel s;

                s.ID = int.Parse(seged[0]);
                s.jelentes = new List<string>(seged[1].Split('-'));
                s.faj = seged[2];
                s.mihez = toldalek ? new List<string>(seged[3].Split(' ')) : s.mihez = new List<string>();
                list.Add(s);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            bunifuFlatButton5.Enabled = false;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Tag = this;
            form3.Show(this);
            Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            string[] input = bunifuMaterialTextbox1.Text.ToLower().Split(' ');

            List<Jel> szoveg = new List<Jel>();
            foreach (var item_of_input in input)
                for (int i = 0; i < L_Szotovek.Count; i++)
                {
                    List<Jel> seged = new List<Jel>();
                    bool Contains = false;
                    int j = -1;
                    foreach (var item_of_jelentesek in L_Szotovek[i].jelentes)
                    {
                        j++;
                        if (item_of_input.Contains(item_of_jelentesek))
                        {
                            Contains = true;
                            break;
                        }
                    }
                    if (Contains)
                    {
                        szoveg.Add(L_Szotovek[i]);
                        if (item_of_input.Length != L_Szotovek[i].jelentes[j].Length)
                        {
                            string toldalekok = item_of_input.Remove(0, L_Szotovek[i].jelentes[j].Length);
                            foreach (var item_of_ragok in L_Todalekok.Where(x => x.faj == "rag" && x.jelentes[0].Length <= toldalekok.Length /*&& x.mihez.Contains(L_Szotovek[i].faj)*/))
                                if (toldalekok.Substring(toldalekok.Length - item_of_ragok.jelentes[0].Length, item_of_ragok.jelentes[0].Length) == item_of_ragok.jelentes[0])
                                {
                                    szoveg.Add(item_of_ragok);
                                    toldalekok = toldalekok.Remove(toldalekok.IndexOf(item_of_ragok.jelentes[0]), item_of_ragok.jelentes[0].Length);
                                    break;
                                }
                            foreach (var item_of_jelek in L_Todalekok.Where(x => x.faj == "jel" /*&& x.mihez.Contains(L_Szotovek[i].faj)*/))
                                if (toldalekok.Contains(item_of_jelek.jelentes[0]))
                                {
                                    szoveg.Add(item_of_jelek);
                                    toldalekok = toldalekok.Remove(toldalekok.IndexOf(item_of_jelek.jelentes[0]), item_of_jelek.jelentes[0].Length);
                                }
                        }
                        i = L_Szotovek.Count;
                    }
                }

            List<Jel> szoveg_rendezett = new List<Jel>();
            foreach (var item in szoveg) if (item.faj != "ige" && !item.mihez.Contains("ige")) szoveg_rendezett.Add(item);
            foreach (var item in szoveg) if (item.faj == "ige" || item.mihez.Contains("ige")) szoveg_rendezett.Add(item);

            var pl = axWindowsMediaPlayer1.playlistCollection.newPlaylist("plList");
            foreach (var item1 in szoveg_rendezett)
            {
                pl.appendItem(axWindowsMediaPlayer1.newMedia(item1.ID + ".avi"));
            }
            axWindowsMediaPlayer1.currentPlaylist = pl;
            axWindowsMediaPlayer1.Ctlcontrols.play();



        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Tag = this;
            form2.Show(this);
            Hide();
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }
    }
}
