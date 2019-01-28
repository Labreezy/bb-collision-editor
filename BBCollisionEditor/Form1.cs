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
namespace BBCollisionEditor
{
    public partial class Form1 : Form
    {
        PACFile img;
        PACFile col;
        OverlaidImage oi;
        bool is_gg;
        List<PACFile.PACEntry> spritelist = new List<PACFile.PACEntry>();
        List<PACFile.PACEntry> collisionlist = new List<PACFile.PACEntry>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.RestoreDirectory = true;
                ofd.Filter = "Image PAC files (*_img.pac)|*_img.pac|Guilty Gear Collission Files (COL_*)|COL_*";
                ofd.Title = "Open Image/GG Collision PAC";
                bool imgsuccess = false;
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName.Contains("COL_"))
                    {
                        col = new PACFile(ofd.FileName);
                        is_gg = true;
                    }
                    else
                    {
                        imgsuccess = true;
                        img = new PACFile(ofd.FileName);
                    }
                }
                if (imgsuccess)
                {
                    ofd.Filter = "Collision PAC files (*_col.pac)|*_col.pac";
                    ofd.Title = "Open Collision PAC";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        col = new PACFile(ofd.FileName);
                    }
                } else if (is_gg)
                {
                    spriteList.Items.Clear();
                    boxList.Items.Clear();
                    foreach(var entry in col.pacentries)
                    {
                        spriteList.Items.Add(entry);
                    }
                }
            }
            if(col != null && img != null && !is_gg)
            {
                spriteList.Items.Clear();
                boxList.Items.Clear();
                foreach (var pe in img.pacentries)
                {
                    var filtered = col.pacentries.Where(p => p.name.StartsWith(pe.name.Substring(0, 8)));
                    if (filtered.Count() > 0)
                    {
                        spriteList.Items.Add(filtered.First());
                    }
                }
            }
        }

        private void spriteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PACFile.PACEntry colentry = (PACFile.PACEntry)spriteList.Items[spriteList.SelectedIndex];
            var coloffset = col.getOffsetByName(colentry.name);
            if (!is_gg)
            {
                var spritename = colentry.name.Substring(0, colentry.name.Length - 7) + ".hip";
                var spriteoffset = img.getOffsetByName(spritename);
                oi = new OverlaidImage(img.path, spriteoffset, col.path, coloffset);
            }
            else
            {
                oi = new OverlaidImage(col.path, coloffset);
            }
                boxList.Items.Clear();
                foreach (var box in oi.hurtboxes)
                {
                    boxList.Items.Add(box);
                }
                foreach (var box in oi.hitboxes)
                {
                    boxList.Items.Add(box);
                }
                if (boxList.Items.Count != 0)
                {
                    boxList.SelectedIndex = 0;
                }
            spriteBox.Image = oi.boxbitmap;
        }

        private void boxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            JonbinBox currbox = (JonbinBox)boxList.Items[boxList.SelectedIndex];
            textBoxX.TextChanged -= textBoxX_TextChanged;
            textBoxY.TextChanged -= textBoxY_TextChanged;
            textBoxW.TextChanged -= textBoxW_TextChanged;
            textBoxH.TextChanged -= textBoxH_TextChanged;
            textBoxX.Text = currbox.x.ToString();
            textBoxY.Text = currbox.y.ToString();
            textBoxW.Text = currbox.width.ToString();
            textBoxH.Text = currbox.height.ToString();
            textBoxX.TextChanged += textBoxX_TextChanged;
            textBoxY.TextChanged += textBoxY_TextChanged;
            textBoxW.TextChanged += textBoxW_TextChanged;
            textBoxH.TextChanged += textBoxH_TextChanged;
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        { 
           JonbinBox currbox = (JonbinBox)boxList.Items[boxList.SelectedIndex];
           float newx;
           if(float.TryParse(textBoxX.Text, out newx))
            {
                currbox.x = newx;
                oi.renderBoxes();
                spriteBox.Image = oi.boxbitmap;
            }
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            JonbinBox currbox = (JonbinBox)boxList.Items[boxList.SelectedIndex];
            float newY;
            if (float.TryParse(textBoxY.Text, out newY))
            {
                currbox.y = newY;
                oi.renderBoxes();
                spriteBox.Image = oi.boxbitmap;
            }
        }

        private void textBoxW_TextChanged(object sender, EventArgs e)
        {
            JonbinBox currbox = (JonbinBox)boxList.Items[boxList.SelectedIndex];
            float newW;
            if (float.TryParse(textBoxW.Text, out newW))
            {
                currbox.width = newW;
                oi.renderBoxes();
                spriteBox.Image = oi.boxbitmap;
            }
        }

        private void textBoxH_TextChanged(object sender, EventArgs e)
        {
            JonbinBox currbox = (JonbinBox)boxList.Items[boxList.SelectedIndex];
            float newH;
            if (float.TryParse(textBoxH.Text, out newH))
            {
                currbox.y = newH;
                oi.renderBoxes();
                spriteBox.Image = oi.boxbitmap;
            }
        }

        private void saveCurrentBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".pac files (*.pac)|*.pac|Guilty gear COL files (COL_*)|COL_*";
            sfd.Title = "Save edited collision file";
            sfd.OverwritePrompt = true;
            sfd.ShowDialog();
            if (sfd.FileName != "" && !is_gg)
            {
                PACFile.PACEntry colentry = (PACFile.PACEntry)spriteList.Items[spriteList.SelectedIndex];
                int writestart = (int)(colentry.offset + col.data_start);
                int writeend = writestart;
                byte[] oldpac = File.ReadAllBytes(col.path);
                
                writeend += 4;
                writeend += 2 + BitConverter.ToInt16(oldpac, writeend) * 0x20 + 3;
                var chunkssize = BitConverter.ToInt32(oldpac, writeend) * 0x50;
                writeend += 8 + 41 * 2 + chunkssize;
                int boxcount = boxList.Items.Count;
                byte[] currfloat = { 0, 0, 0, 0 };
                for (var i = 0; i < boxcount; i++)
                {
                    writeend += 4;
                    var currbox = (JonbinBox)boxList.Items[i];
                    currfloat = System.BitConverter.GetBytes(currbox.x);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4;
                    currfloat = System.BitConverter.GetBytes(currbox.y);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4; currfloat = System.BitConverter.GetBytes(currbox.width);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4; currfloat = System.BitConverter.GetBytes(currbox.height);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4;
                }
                File.WriteAllBytes(sfd.FileName, oldpac);
                
            } else if (sfd.FileName != "")
            {
                PACFile.PACEntry colentry = (PACFile.PACEntry)spriteList.Items[spriteList.SelectedIndex];
                int writestart = (int)(colentry.offset + col.data_start);
                int writeend = writestart;
                byte[] oldpac = File.ReadAllBytes(col.path);
                writeend += 0x3C;
                writeend += 2 + BitConverter.ToInt16(oldpac, writeend) * 0x20 + 3;
                var chunkssize = BitConverter.ToInt32(oldpac, writeend) * 0x50;
                writeend += 8 + 41 * 2 + chunkssize;
                int boxcount = boxList.Items.Count;
                byte[] currfloat = { 0, 0, 0, 0 };
                for (var i = 0; i < boxcount; i++)
                {
                    writeend += 4;
                    var currbox = (JonbinBox)boxList.Items[i];
                    currfloat = System.BitConverter.GetBytes(currbox.x);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4;
                    currfloat = System.BitConverter.GetBytes(currbox.y);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4; currfloat = System.BitConverter.GetBytes(currbox.width);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4; currfloat = System.BitConverter.GetBytes(currbox.height);
                    Array.Copy(currfloat, 0, oldpac, writeend, 4);
                    writeend += 4;
                }
                File.WriteAllBytes(sfd.FileName, oldpac);
            }
            

            

        }
    }
}
