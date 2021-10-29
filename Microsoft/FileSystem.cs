using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms_and_Data_Structures.Microsoft
{
    public class FileSystem
    {

        private class FileSystemEntry
        {
            //file/folder name
            public string name { get; set; }
            public bool isFile { get; set; }
            public string content { get; set; }
            //keep children here
            public SortedDictionary<string, FileSystemEntry> childEntries;

            public FileSystemEntry(string name, bool isFile)
            {
                this.name = name;
                this.isFile = isFile;
                if (!isFile)
                    childEntries = new SortedDictionary<string, FileSystemEntry>();
            }
        }

        private FileSystemEntry root;

        public FileSystem()
        {
            //initialize root folder
            root = new FileSystemEntry("/", false);
        }

        public IList<string> Ls(string path)
        {
            List<string> lresult = new List<string>();
            FileSystemEntry entry = OpenOrCreateEntry(path, false);
            if (entry.isFile)
            {
                lresult.Add(entry.name);
                return lresult;
            }
            foreach (var kvp in entry.childEntries)
            {
                lresult.Add(kvp.Key);
            }
            return lresult;
        }

        public void Mkdir(string path)
        {
            OpenOrCreateEntry(path, false);
        }

        public void AddContentToFile(string filePath, string content)
        {
            FileSystemEntry file = OpenOrCreateEntry(filePath, true);
            StringBuilder builder = new StringBuilder(file.content);
            builder.Append(content);
            file.content = builder.ToString();
            //Console.WriteLine(file.name);
            //Console.WriteLine(file.content);
        }

        public string ReadContentFromFile(string filePath)
        {
            return OpenOrCreateEntry(filePath, true).content;
        }

        //creates folder if does not exist
        private FileSystemEntry OpenOrCreateEntry(string path, bool isFile)
        {
            //"/first/second/third" -> split folders
            bool createFile = false;
            string[] folders = path.Split(new char[] { '/' });
            FileSystemEntry curFolder = root;
            for (int i = 0; i < folders.Length; i++)
            {
                if (folders[i] == string.Empty) continue; //if blank ignore
                if (!curFolder.childEntries.ContainsKey(folders[i])) //if there is no such folder create it
                {
                    createFile = (i == folders.Length - 1 && isFile);
                    curFolder.childEntries.Add(folders[i], new FileSystemEntry(folders[i], createFile));
                }
                //move inside created/already existing folder
                curFolder = curFolder.childEntries[folders[i]];
            }
            return curFolder;
        }
    }

}
