using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC
{
    public interface IPanel
    {
        string CurrentPath { get; set; }
        string[] Drives { get; set; }
        string[] Files { get; set; }
        List<string> Filess { get; set; }
        int SelectedIndex { get; set; }

        event Action SelectedDriveChanged;
        event Action ComboBoxClick;
        event Action PathChanged;
        event Action FolderDoubleClick;
        event Action SelectedListBox;
    }
}
