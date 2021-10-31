using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Task2
{
    class Program
    {
        static string historyFolder;
        static string watchableFolder;
        static char? mode = null;

        public static void MakeCopy(string from, string to) 
        {
            DateTime dateTime = DateTime.Now;
            string archivedFolderName = dateTime.Year.ToString() + "-" + dateTime.Month.ToString() +
                "-" + dateTime.Day.ToString() + " " + dateTime.Hour.ToString() + "_" + dateTime.Minute.ToString() +
                "_" + dateTime.Second.ToString();

            DirectoryInfo hisInfo = new DirectoryInfo(to);
            DirectoryInfo watchInfo = new DirectoryInfo(from);
            hisInfo.CreateSubdirectory(archivedFolderName);
            string archivedFolder = hisInfo.GetDirectories(archivedFolderName)[0].ToString();
            MoveFilesAndDirectories(watchInfo, new DirectoryInfo(archivedFolder));
        }

        public static void MakeCopyFromHistory(string from, string to)
        {
            DirectoryInfo hisInfo = new DirectoryInfo(from);
            DirectoryInfo watchInfo = new DirectoryInfo(to);
            MoveFilesAndDirectories(hisInfo, watchInfo);
        }

        public static void ClearDir(DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                
                file.Delete();
                
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo directory in dirs)
            {

                ClearDir(directory);
                directory.Delete();
            }
        }

        public static void MoveFilesAndDirectories(DirectoryInfo from, DirectoryInfo to)
        {
            DirectoryInfo[] dirs = from.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destinationDir = Path.Combine(to.FullName, dir.Name);
                Directory.CreateDirectory(destinationDir);
                MoveFilesAndDirectories(dir, new DirectoryInfo(destinationDir));
            }

            FileInfo[] files = from.GetFiles();
            
            foreach (FileInfo file in files)
            {
                try
                {
                    file.CopyTo(Path.Combine(to.FullName, file.Name));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public static void StatusRenewer()
        {
            while(true)
            {
                mode = Console.ReadKey().KeyChar;
            }
        }

        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            path = dirInfo.Parent.Parent.Parent.ToString();
            dirInfo = new DirectoryInfo(path);
            string confFile = dirInfo.GetFiles("conf.txt")[0].ToString();

            Console.WriteLine("Какой режим работы хотите использовать?");
            Console.WriteLine("w - отслеживание; b - откат");
            Console.WriteLine("Введите букву режима");

            mode = Console.ReadKey().KeyChar;

            Thread statusThread = new Thread(new ThreadStart(StatusRenewer));
            statusThread.Start();

            using (StreamReader sr = new StreamReader(confFile))
            {
                watchableFolder = sr.ReadLine();
                historyFolder = sr.ReadLine();
            }

            while (true)
            {
                if (mode == 'w')
                {
                    Console.WriteLine();
                    Console.WriteLine("Программа перешла в режим отслеживания");
                    DirectoryInfo di = new DirectoryInfo(historyFolder);
                    if (!di.Exists)
                    {
                        Directory.CreateDirectory(historyFolder);
                    }

                    di = new DirectoryInfo(watchableFolder);
                    if (!di.Exists)
                    {
                        Directory.CreateDirectory(watchableFolder);
                    }

                    using FileSystemWatcher watcher = new FileSystemWatcher(watchableFolder);
                    watcher.NotifyFilter = NotifyFilters.LastWrite
                                         | NotifyFilters.FileName
                                         | NotifyFilters.DirectoryName
                                         | NotifyFilters.Size
                                         | NotifyFilters.CreationTime
                                         | NotifyFilters.Attributes;

                    watcher.Changed += OnChanged;
                    watcher.Created += OnCreated;
                    watcher.Deleted += OnDeleted;
                    watcher.Renamed += OnRenamed;

                    watcher.Filter = "*.txt";
                    watcher.IncludeSubdirectories = true;
                    watcher.EnableRaisingEvents = true;
                    while (mode == 'w')
                    {

                    }
                }

                if (mode == 'b')
                {
                    Console.WriteLine();
                    Console.WriteLine("Программа перешла в режим отката");
                    Console.WriteLine("Введите дату и время, на которое надо откатиться");
                    Console.WriteLine("Доступные опции для отката");

                    DirectoryInfo di = new DirectoryInfo(historyFolder);
                    DirectoryInfo[] oldCopies = di.GetDirectories();

                    List<DateTime> oldCopiesTime = new List<DateTime>();

                    foreach (DirectoryInfo oldcopy in oldCopies)
                    {
                        DateTime value;
                        DateTime.TryParse(oldcopy.Name.Replace('_', ':'), out value);
                        oldCopiesTime.Add(value);
                        Console.WriteLine(value);
                    }

                    DateTime dateTime = new DateTime();
                    DateTime.TryParse(Console.ReadLine(), out dateTime);

                    foreach (DateTime time in oldCopiesTime)
                    {
                        if (time == dateTime)
                        {
                            string timeStr = time.Year + "-" + time.Month + "-" + time.Day + " " + time.Hour + "_" + time.Minute + "_" + time.Second ;
                            Console.WriteLine(timeStr);
                            string oldCopyFolder = di.GetDirectories(timeStr)[0].ToString();
                            ClearDir(new DirectoryInfo(watchableFolder));
                            MakeCopyFromHistory(oldCopyFolder, watchableFolder);
                            Console.WriteLine("Откат выполнен!");
                        }
                    }

                    while (mode == 'b')
                    {

                    }
                }

                if (mode != null && mode != 'w' && mode != 'b')
                {
                    Console.WriteLine();
                    Console.WriteLine("Такой опции не существует");
                    mode = null;
                }
            }
        }    

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            Console.WriteLine($"Changed: {e.FullPath}");
            MakeCopy(watchableFolder, historyFolder);

        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string value = $"Created: {e.FullPath}";
            Console.WriteLine(value);
            MakeCopy(watchableFolder, historyFolder);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string value = $"Deleted: {e.FullPath}";
            Console.WriteLine(value);
            MakeCopy(watchableFolder, historyFolder);
        }

        private static void OnRenamed(object sender, FileSystemEventArgs e)
        {
            string value = $"Renamed: {e.FullPath}";
            Console.WriteLine(value);
            MakeCopy(watchableFolder, historyFolder);
        }
    }
}
