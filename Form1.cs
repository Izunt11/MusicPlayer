using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String[] paths, files, directories;


        private void btnSelect_Click(object sender, EventArgs e)
        {
            //var paths = new List<String>();
            //var files = new List<String>();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //tBoxPath.Text = Path.GetFileName(ofd.FileName);

                directories = ofd.FileNames;
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;


                for (int i = 0; i < files.Length; i++)
                //for(int i = files.GetLowerBound(0); i <= files.GetUpperBound(0); ++i)
                //foreach (int i in files) 
                {
                    lBoxPath.Items.Add(directories[i]);
                    listBoxSongs.Items.Add(files[i]);
                    //Array.Resize(ref files, files.Length + 1);
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {

            mediaPlayer.URL = paths[listBoxSongs.SelectedIndex];

            //  Array.Resize(ref paths, paths.Length + 1);
            //  Mp3Lib.Mp3File file = new Mp3Lib.Mp3File(paths[listBoxSongs.SelectedIndex]);
            //  file.TagHandler.Artist = tboxTChange.Text;

        }

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {


            bool found = false;
            for (int i = 0; i <= listBoxSongs.Items.Count - 1; i++)
            {
                if (listBoxSongs.Items[i].ToString().ToLower().Contains(tboxSearch.Text.ToLower()))
                {
                    listBoxSongs.SetSelected(i, true);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show("Item not found!");
            }
        }

        private void lBoxPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            lBoxPath.HorizontalScrollbar = true;
        }


        private void lBoxPath_TextChanged(object sender, EventArgs e)
        {
            //lBoxPath.Text = Path.GetFileName(listBoxSongs)
            //tBoxPath.Text = Path.GetFileName(listBoxSongs.SelectedIndex.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
