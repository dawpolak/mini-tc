using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTC
{
    public partial class Form1 : Form,IForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Implementacja IForm
        public IPanel LeftPanel
        {
            get
            {
                return userControlPanelLeft;
            }
        }

        public IPanel RightPanel
        {
            get
            {
                return userControlPanelRight;
            }
        }

        public event Action Copy;
        public event Action Move;
        public event Action Delete;
        #endregion

        private void userControlPanelLeft_SelectedListBox()
        {
            RightPanel.SelectedIndex = -1;
        }

        private void userControlPanelRight_SelectedListBox()
        {
            LeftPanel.SelectedIndex = -1;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            Move?.Invoke();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            Copy?.Invoke();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Delete?.Invoke();
        }
    }
}
