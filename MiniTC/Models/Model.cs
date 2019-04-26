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
        #region Panel
        //zwraca wybrany dysk jako sciezke
        public string ChangeDrive(string[] drives)
        { 
            if (Directory.Exists(drives[0]))
            {
                return drives[0];
            }
            else
            {
                MessageBox.Show("Dysk jest nieosiągalny");
                return "";
            }
        }

        //zwraca tablice dyskow gotowych do uzycia
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

        //zwraca tablice instacji folderow i plikow w danej sciezce
        public FolderOrFile[] SetFiles(string[] drive, string path)
        {
            System.IO.DriveInfo di = new System.IO.DriveInfo(drive[0]);
            if (di.IsReady)
            {
                string[] tmp = Directory.GetDirectories(path);
                FolderOrFile[] folders = new FolderOrFile[tmp.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    folders[i] = new FolderOrFile(tmp[i]);
                }

                tmp = Directory.GetFiles(path);
                FolderOrFile[] files = new FolderOrFile[tmp.Length];
                for (int i = 0; i < tmp.Length; i++)
                {
                    files[i] = new FolderOrFile(tmp[i]);
                }

                FolderOrFile[] all;
                if (path == drive[0])
                {
                    all = new FolderOrFile[folders.Length + files.Length];
                    Array.Copy(folders, all, folders.Length);
                    Array.Copy(files, 0, all, folders.Length, files.Length);
                }
                else
                {
                    all = new FolderOrFile[folders.Length + files.Length + 1];
                    all[0] = new FolderOrFile("📂", "[..]", Path.GetDirectoryName(path));
                    Array.Copy(folders, 0, all, 1, folders.Length);
                    Array.Copy(files, 0, all, folders.Length + 1, files.Length);
                }
                Console.WriteLine("zwraca cos nowego");
                return all;
            }else
            {
                Console.WriteLine("Zwraca pusta");
                return new FolderOrFile[0];
            }
        }

        //jesli przekazany zostal folder, zwraca jego sciezke
        public string ChangeFolder(int index, FolderOrFile[] folder, string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (Directory.Exists(folder[index].PathOf))
            {
                try
                {
                    string[] folders = Directory.GetDirectories(folder[index].PathOf);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd! Odmowa dostępu");
                    return path;
                }
                return folder[index].PathOf;

            }
            else
            {
                //Console.WriteLine("This is file, not folder");
                return path;
            }

        }
        #endregion region

        #region Form
        public void Copy(int index, FolderOrFile[] filesSource, string destinationPath)
        {
            if (System.IO.Directory.Exists(filesSource[index].PathOf) && System.IO.Directory.Exists(destinationPath))
            {
                //kopiowanie folderu
                try
                {
                    if (!Directory.Exists(destinationPath + "\\" + filesSource[index].NameOf))
                    {
                        Directory.CreateDirectory(destinationPath + "\\" + filesSource[index].NameOf);

                        string[] tmp = Directory.GetDirectories(filesSource[index].PathOf);
                        FolderOrFile[] folders = new FolderOrFile[tmp.Length];
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            folders[i] = new FolderOrFile(tmp[i]);
                            //rekurencja wchodzaca w podfoldery
                            Copy(i, folders, (destinationPath + "\\" + filesSource[index].NameOf));
                        }

                        //kopiowanie plikow w folderach
                        tmp = Directory.GetFiles(filesSource[index].PathOf);
                        FolderOrFile[] files = new FolderOrFile[tmp.Length];
                        for (int i = 0; i < tmp.Length; i++)
                        {
                            files[i] = new FolderOrFile(tmp[i]);
                            System.IO.File.Copy(files[i].PathOf, (destinationPath + "\\" + filesSource[index].NameOf + "\\" + files[i].NameOf));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Folder o takiej nazwie w sciezce docelowej juz istnieje");
                    }
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }



            }else if (System.IO.File.Exists(filesSource[index].PathOf) && System.IO.Directory.Exists(destinationPath))
            {
                //kopiowanie pliku
                try
                {
                    System.IO.File.Copy(filesSource[index].PathOf, (destinationPath + "\\" + filesSource[index].NameOf));
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }else
            {
                if ((filesSource[index].Type) == "📄") MessageBox.Show("Blad! Wybrany plik nie istnieje"); else MessageBox.Show("Blad! Wybrany folder nie istnieje");
                if (!System.IO.Directory.Exists(destinationPath)) MessageBox.Show("Blad! Sciezka docelowa nie istnieje");

            }
        }

        public void Move(int index, FolderOrFile[] filesSource, string destinationPath)
        {
            if (System.IO.File.Exists(filesSource[index].PathOf) && System.IO.Directory.Exists(destinationPath))
            {
                //przenoszenie pliku
                    try
                    {
                        //System.IO.File.Move(files[index].PathOf, (destinationPath + "\\" + files[index].NameOf)); 
                        Copy(index, filesSource, destinationPath);
                        Delete(index, filesSource);
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                
            }
            else if (System.IO.Directory.Exists(filesSource[index].PathOf) && System.IO.Directory.Exists(destinationPath))
            {
                //przenoszenie folderu
                try
                {
                    //System.IO.Directory.Move(files[index].PathOf, (destinationPath + "\\" + files[index].NameOf)); <- nie dziala miedzy woluminami
                    Copy(index, filesSource, destinationPath);
                    Delete(index, filesSource);
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }else
            {
                if ((filesSource[index].Type)=="📄") MessageBox.Show("Blad! Wybrany plik nie istnieje"); else MessageBox.Show("Blad! Wybrany folder nie istnieje");
                if (!System.IO.Directory.Exists(destinationPath)) MessageBox.Show("Blad! Sciezka docelowa nie istnieje");
            }
        }

        public void Delete(int index, FolderOrFile[] files)
        {
            //usuwanie pliku
            if (System.IO.File.Exists(files[index].PathOf))
            {
                try
                {
                    System.IO.File.Delete(files[index].PathOf);
                }
                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else if (System.IO.Directory.Exists(files[index].PathOf))
            {
                //usuwanie folderu
                try
                {
                    System.IO.Directory.Delete(files[index].PathOf, true);
                }

                catch (System.IO.IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }else
            {
                MessageBox.Show("Blad! Dany element nie istnieje");
            }
        }
        #endregion
    }
}
