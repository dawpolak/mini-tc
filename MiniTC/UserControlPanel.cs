using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTC
{
    public partial class UserControlPanel : UserControl, IPanel
    {

        public UserControlPanel()
        { 
            InitializeComponent();
           // myInit();
        } 

        private void myInit()
        {
            #region Pobranie dyskow logicznych
            string[] drives = new string[System.Environment.GetLogicalDrives().Length];
            int i = 0;
            foreach (string dr in System.Environment.GetLogicalDrives())
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                if (di.IsReady)
                {
                    drives[i]= dr;
                    i++;
                }
            }
            Array.Resize<string>(ref drives, i);
            Drives = drives;
            #endregion
        }

        #region Implementacja IPanel
        public string CurrentPath
        {
            get
            {
                return textBoxPath.Text;
            }
            set
            {
                textBoxPath.Text = value;
            }
        }
        public string[] Drives
        {
            get
            {
                return new[] { comboBoxDrives.SelectedItem.ToString() };
            }
            set
            {
                comboBoxDrives.Items.Clear();
                comboBoxDrives.Items.AddRange(value);
            }
        }
        public string[] Files
        {
            get
            {
                //return new[] { listBoxFiles.SelectedItem.ToString() };
                List<string> tmp = new List<string>();
                foreach (string el in listBoxFiles.Items)
                {
                    tmp.Add(el.ToString());
                }
                string[] files = tmp.ToArray();
                return files;
            }
            set
            {
                listBoxFiles.Items.Clear();
                listBoxFiles.Items.AddRange(value);
                //foreach (var d in value)
                //{
                //    comboBox1.Items.Add(d);
                //}
            }
        }
        public List<string> Filess
        {
            get
            {
                return new List<string> { listBoxFiles.Items.ToString() };
            }
            set
            {
                listBoxFiles.Items.Clear();
                foreach (var d in value)
                {
                    listBoxFiles.Items.Add(d);
                }
            }
        }
        public int SelectedIndex
        {
            get
            {
                return listBoxFiles.SelectedIndex;
            }

            set
            {
                listBoxFiles.SelectedIndex = value;
            }
        }

        public event Action SelectedDriveChanged;
        public event Action ComboBoxClick;
        public event Action PathChanged;
        public event Action FolderDoubleClick;
        public event Action SelectedListBox;
        #endregion

        #region eventy
        private void comboBoxDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedDriveChanged != null && comboBoxDrives.SelectedIndex > -1)
            {
                SelectedDriveChanged();
            }
        }
        private void comboBoxDrives_Click(object sender, EventArgs e)
        {
            ComboBoxClick?.Invoke();
        }
        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            PathChanged?.Invoke();
        }
        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedIndex != -1) FolderDoubleClick?.Invoke();
        }
        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedListBox?.Invoke();
        }
        #endregion


    }
}
