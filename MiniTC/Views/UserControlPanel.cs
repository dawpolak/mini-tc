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
                if (comboBoxDrives.Items.Count!=0 && comboBoxDrives.SelectedIndex!=-1) return new[] { comboBoxDrives.SelectedItem.ToString() }; else return new[] {"null"};
            }
            set
            {
                comboBoxDrives.Items.Clear();
                comboBoxDrives.Items.AddRange(value);
            }
        }
        public FolderOrFile[] Files
        {
            get
            {
                //return new[] { listBoxFiles.SelectedItem.ToString() };
                List<FolderOrFile> tmp = new List<FolderOrFile>();
                foreach (FolderOrFile el in listBoxFiles.Items)
                {
                    tmp.Add(el);
                }
                FolderOrFile[] files = tmp.ToArray();
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
