using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MiniTC
{
    class Model
    {

        public string ChangeDrive(string[] path)
        {
            if (Directory.Exists(path[0]))
            {
                return path[0];
            }else
            {
                MessageBox.Show("Dysk jest nieosiągalny");
                return "";
            }
        }

        public string[] SetDrives()
        {
            List<string> readyDrives = new List<string>();
            foreach (string dr in System.Environment.GetLogicalDrives())
            {
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                if (di.IsReady) readyDrives.Add(dr.ToString());
            }
            string[] drives = readyDrives.ToArray();
            
            return drives;
        }

        public string[] SetFiles(string[] drive, string path)
        {
            string[] folders = Directory.GetDirectories(path);
            for (int i = 0; i < folders.Length; i++)
            {
                folders[i] ="[d] "+ Path.GetFileName(folders[i]);
            }

            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = "[f] "+Path.GetFileName(files[i]);
            }

            string[] all;
            if (path == drive[0])
            {
                all = new string[folders.Length + files.Length];
                Array.Copy(folders, all, folders.Length);
                Array.Copy(files, 0, all, folders.Length, files.Length);
            }
            else
            {
                all = new string[folders.Length + files.Length + 1];
                all[0] = "[..]";
                Array.Copy(folders, 0,  all, 1, folders.Length);
                Array.Copy(files, 0, all, folders.Length+1, files.Length);
            }
            
            return all;
        }

        public string ChangeFolder(int index,string[] folder, string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (folder[index] =="[..]")return Path.GetFullPath(path + folder[index].Remove(0,1).Remove(2,1) + "\\");
            
            if (Directory.Exists(path + folder[index].Remove(0, 4)))
            {
                try
                {
                    string[] folders = Directory.GetDirectories(path + folder[index].Remove(0, 4));
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd! Odmowa dostępu");
                    return path;
                }
                Console.WriteLine("hej");
                return Path.GetFullPath(path + folder[index].Remove(0, 4) + "\\");
                
            }else
            {
                Console.WriteLine("to nie folder");
                return path;
            }
            
        }

        #region Form
        public void Copy()
        {

        }

        public void Move(int index, string[] files, string sourcePath, string destinationPath)
        {
            if (System.IO.File.Exists(sourcePath + files[index].Remove(0, 4))&& System.IO.Directory.Exists(destinationPath))
            {
                try
                {
                    if (MessageBox.Show("Czy na pewno chcesz przenieść ten plik?", sourcePath + files[index].Remove(0, 4), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.IO.File.Move((sourcePath + files[index].Remove(0, 4)),((destinationPath + files[index].Remove(0, 4))));
                    }

                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (System.IO.Directory.Exists(sourcePath + files[index].Remove(0, 4)) && System.IO.Directory.Exists(destinationPath))
            {
                try
                {
                    if (MessageBox.Show("Czy na pewno chcesz przenieść ten folder z zawartością?", sourcePath + files[index].Remove(0, 4), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.IO.Directory.Move((sourcePath + files[index].Remove(0, 4)),(destinationPath));
                    }
                }

                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Delete(int index, string[] files, string path)
        {
            if (System.IO.File.Exists(path + files[index].Remove(0, 4)))
            {
                try
                {
                    if (MessageBox.Show("Czy na pewno chcesz usunąć ten plik?",path + files[index].Remove(0, 4), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.IO.File.Delete(path + files[index].Remove(0, 4));
                    }
                    
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }else if (System.IO.Directory.Exists(path + files[index].Remove(0, 4)))
            {
                try
                {
                    if (MessageBox.Show("Czy na pewno chcesz usunąć ten folder z zawartością?", path + files[index].Remove(0, 4), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        System.IO.Directory.Delete(path + files[index].Remove(0, 4),true);
                    }
                }

                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            
        }
        #endregion
    }
}
