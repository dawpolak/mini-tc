﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTC
{
    class PresenterForm
    {
        IForm view;
        Model model;
        PresenterPanel left;
        PresenterPanel right;

        public PresenterForm(IForm view, Model model)
        {
            this.view = view;
            this.model = model;

            this.left = new PresenterPanel(view.LeftPanel,model);
            this.right = new PresenterPanel(view.RightPanel, model);
            this.view.Copy += View_Copy;
            this.view.Move += View_Move;
            this.view.Delete += View_Delete;
        }

        private void View_Copy()
        {
            if (view.LeftPanel.SelectedIndex != -1 && view.RightPanel.Drives[0] != "null")
            {
                if (MessageBox.Show("Czy na pewno chcesz skopiowac ?", view.LeftPanel.Files[view.LeftPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Copy(view.LeftPanel.SelectedIndex, view.LeftPanel.Files, view.RightPanel.CurrentPath);
                }
            }
            if (view.RightPanel.SelectedIndex != -1 && view.LeftPanel.Drives[0] != "null")
            {
                if (MessageBox.Show("Czy na pewno chcesz skopiowac ?", view.RightPanel.Files[view.RightPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Copy(view.RightPanel.SelectedIndex, view.RightPanel.Files, view.LeftPanel.CurrentPath);
                }
            }
            if (view.LeftPanel.Drives[0] != "null") view.LeftPanel.Files = model.SetFiles(view.LeftPanel.Drives, view.LeftPanel.CurrentPath);
            if (view.RightPanel.Drives[0] != "null") view.RightPanel.Files = model.SetFiles(view.RightPanel.Drives, view.RightPanel.CurrentPath);
            //if (view.LeftPanel.Drives[0] != "null") view.LeftPanel.CurrentPath = view.LeftPanel.CurrentPath;
            //if (view.RightPanel.Drives[0] != "null") view.RightPanel.CurrentPath = view.RightPanel.CurrentPath;
        }

        private void View_Move()
        {
            if (view.LeftPanel.SelectedIndex != -1 && view.RightPanel.Drives[0] != "null")
            {
                if (MessageBox.Show("Czy na pewno chcesz przenieść ?", view.LeftPanel.Files[view.LeftPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Move(view.LeftPanel.SelectedIndex, view.LeftPanel.Files, view.RightPanel.CurrentPath);
                }
            }
            if (view.RightPanel.SelectedIndex != -1 && view.LeftPanel.Drives[0] != "null")
            {
                if (MessageBox.Show("Czy na pewno chcesz przenieść ?", view.RightPanel.Files[view.RightPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Move(view.RightPanel.SelectedIndex, view.RightPanel.Files, view.LeftPanel.CurrentPath);
                }
            }
            if (view.LeftPanel.Drives[0] != "null") view.LeftPanel.Files = model.SetFiles(view.LeftPanel.Drives, view.LeftPanel.CurrentPath);
            if (view.RightPanel.Drives[0] != "null") view.RightPanel.Files = model.SetFiles(view.RightPanel.Drives, view.RightPanel.CurrentPath);
        }

        private void View_Delete()
        {
            if (view.LeftPanel.SelectedIndex != -1)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunac ?", view.LeftPanel.Files[view.LeftPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Delete(view.LeftPanel.SelectedIndex, view.LeftPanel.Files);
                }
            }
            if (view.RightPanel.SelectedIndex != -1)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunac ?", view.RightPanel.Files[view.RightPanel.SelectedIndex].PathOf, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    model.Delete(view.RightPanel.SelectedIndex, view.RightPanel.Files);
                }
            }
            if (view.LeftPanel.Drives[0] != "null") view.LeftPanel.Files = model.SetFiles(view.LeftPanel.Drives, view.LeftPanel.CurrentPath);
            if (view.RightPanel.Drives[0] != "null") view.RightPanel.Files = model.SetFiles(view.RightPanel.Drives, view.RightPanel.CurrentPath);
        }

    }
}
