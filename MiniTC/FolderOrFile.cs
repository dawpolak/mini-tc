using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MiniTC
{
    public class FolderOrFile
    {
        private string type;
        private string nameOf;
        private string pathOf;

        public string NameOf
        {
            get
            {
                return nameOf;
            }

        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public string PathOf
        {
            get
            {
                return pathOf;
            }
        }


        public FolderOrFile(string path)
        {
            if (Directory.Exists(path))this.type = "📁";else this.type = "📄";
            this.nameOf = Path.GetFileName(path);
            this.pathOf = path;
        }

        public FolderOrFile(string type,string name, string path)
        {
            this.type = type;
            this.nameOf = name;
            this.pathOf = path;
        }


        public override string ToString()
        {
            return type + " " + nameOf;
        }

    }
}
