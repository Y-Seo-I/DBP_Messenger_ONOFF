using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace on_off_proj
{
    static class imageBt
    {
        public static byte[] insert_imagebyte(string image_path)
        {
            byte[] imageBtye = null;
            FileStream fstream = new FileStream(image_path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imageBtye = br.ReadBytes((int)fstream.Length);

            return imageBtye;
        }

        public static System.Drawing.Image read_imagebyte(byte[] image)
        {
            MemoryStream mStream = new MemoryStream(image);
            return System.Drawing.Image.FromStream(mStream);
        }
    }
}
