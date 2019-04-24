using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            model.Copy();
        }

        private void View_Move()
        {
            if (view.LeftPanel.SelectedIndex != -1) model.Move(view.LeftPanel.SelectedIndex, view.LeftPanel.Files, view.LeftPanel.CurrentPath,view.RightPanel.CurrentPath);
            if (view.RightPanel.SelectedIndex != -1) model.Move(view.RightPanel.SelectedIndex, view.RightPanel.Files, view.RightPanel.CurrentPath, view.RightPanel.CurrentPath);
            view.LeftPanel.Files = model.SetFiles(view.LeftPanel.Drives, view.LeftPanel.CurrentPath);
            view.RightPanel.Files = model.SetFiles(view.RightPanel.Drives, view.RightPanel.CurrentPath);
        }

        private void View_Delete()
        {
            if(view.LeftPanel.SelectedIndex!=-1)model.Delete(view.LeftPanel.SelectedIndex,view.LeftPanel.Files,view.LeftPanel.CurrentPath);
            if(view.RightPanel.SelectedIndex!=-1) model.Delete(view.RightPanel.SelectedIndex, view.RightPanel.Files, view.RightPanel.CurrentPath);
            view.LeftPanel.Files = model.SetFiles(view.LeftPanel.Drives, view.LeftPanel.CurrentPath);
            view.RightPanel.Files = model.SetFiles(view.RightPanel.Drives, view.RightPanel.CurrentPath);
        }

    }
}
