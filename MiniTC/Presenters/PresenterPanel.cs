using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC
{
    class PresenterPanel
    {
        IPanel view;
        Model model;

        public PresenterPanel(IPanel view, Model model)
        {
            this.view = view;
            this.model = model;
            this.view.SelectedDriveChanged += View_SelectedDriveChanged;
            this.view.ComboBoxClick += View_ComboBoxClick;
            this.view.PathChanged += View_PathChanged;
            this.view.FolderDoubleClick += View_FolderDoubleClick;
        }

        private void View_ComboBoxClick()
        {
            view.Drives = model.SetDrives();
            
        }

        private void View_SelectedDriveChanged()
        {
            view.CurrentPath = model.ChangeDrive(view.Drives);
            if(view.CurrentPath=="")view.Drives= model.SetDrives();
        }

        private void View_PathChanged()
        {
            if(view.Drives[0] != "null")view.Files = model.SetFiles(view.Drives,view.CurrentPath);
        }

        private void View_FolderDoubleClick()
        {
            view.CurrentPath=model.ChangeFolder(view.SelectedIndex,view.Files,view.CurrentPath);
        }
    }
}
