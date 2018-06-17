using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    abstract class SerializationDA : IDataAccess
    {
        protected readonly string pathForFile;

        protected SerializationDA(string nameOfClass)
        {
            pathForFile = GetPathForFile() + @"\" + nameOfClass + ".dat";
        }

        private string GetPathForFile()
        {
            string nameOfDirectory = @"\Data";
            DirectoryInfo directoryInfo = null;
            string path = null;

            if (Directory.Exists(Directory.GetCurrentDirectory() + nameOfDirectory))
                directoryInfo = Directory.CreateDirectory(Directory.GetCurrentDirectory() + nameOfDirectory);
            else
                path = Directory.GetCurrentDirectory() + nameOfDirectory;

            return path ?? directoryInfo.FullName;
        }

        public abstract object GetData();

        public abstract void SetData(Object data);
    }
}
