using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Library.FileSystem
{
    public class FileSystem
    {
        private string _directory;
        private string _file;
        private string _path;

        public FileSystem(string path)
        {
            _directory = Path.GetDirectoryName(path);
            _file = Path.GetFileName(path);
            _path = path;
        }

        public void UpdateCSV(string[] content)
        {
            string filename = Path.GetFileNameWithoutExtension(_path);

            File.Create(@$"{_directory}\{filename}.$$$");
            File.WriteAllLines(@$"{_directory}\{filename}.$$$", content);
            if (File.Exists(@$"{_directory}\{filename}.bak"))
                File.Delete(@$"{_directory}\{filename}.bak");
            File.Move(_path, @$"{_directory}\{filename}.bak");
            File.Move(@$"{_directory}\{filename}.$$$", _path);
        }

        public void UpdateCSV(string content)
        {
            string filename = Path.GetFileNameWithoutExtension(_path);

            File.Create(@$"{_directory}\{filename}.$$$");
            File.WriteAllText(@$"{_directory}\{filename}.$$$", content);
            if (File.Exists(@$"{_directory}\{filename}.bak"))
                File.Delete(@$"{_directory}\{filename}.bak");
            File.Move(_path, @$"{_directory}\{filename}.bak");
            File.Move(@$"{_directory}\{filename}.$$$", _path);
        }

        public string[] GetFileContent()
            => File.ReadAllLines(_path);
    }
}
