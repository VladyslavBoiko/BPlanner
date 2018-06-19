using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BinSerializationDA : SerializationDA
    {
        readonly BinaryFormatter binaryFormatter;

        public BinSerializationDA(string nameOfClassToSerialization):base(nameOfClassToSerialization)
        {
            binaryFormatter = new BinaryFormatter();
        }

        public override void SetData(object data)
        {
            using (FileStream fs = new FileStream(pathForFile, FileMode.Create, FileAccess.Write, FileShare.Read))
                binaryFormatter.Serialize(fs, data);
        }

        public override object GetData()
        {
            FileStream fs = null;

            try
            {
                fs = new FileStream(pathForFile, FileMode.Open, FileAccess.Write, FileShare.Write);
                return binaryFormatter.Deserialize(fs);
            }
            catch(FileNotFoundException)
            {
                throw new InvalidOperationException("There is not such a file");
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}
