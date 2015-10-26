using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinaryImageLib
{
    [Serializable]
    public class BinaryImage
    {

        public BinaryImage(Image image)
        {
            BinaryData = ConvertImageToBinary(image);
        }

        public byte[] BinaryData { get; private set; }

        private byte[] ConvertImageToBinary(Image image)
        {
            MemoryStream xStream = new MemoryStream();

            BinaryFormatter xFormatter = new BinaryFormatter();

            xFormatter.Serialize(xStream, image);
            return xStream.ToArray();
        }

        public Image ConvertBinaryToImage()
        {
            MemoryStream xStream = new MemoryStream(BinaryData);
            BinaryFormatter xFormatter = new BinaryFormatter();
            Image returnImage = (Image)xFormatter.Deserialize(xStream);
            return returnImage;
        }
    }
}
