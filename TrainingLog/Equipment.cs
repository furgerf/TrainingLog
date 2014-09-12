using System.Drawing;
using System.Xml.Serialization;

namespace TrainingLog
{
    [XmlRoot("Equipment")]
    public class Equipment
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("ImageName")]
        public string ImageName { get; set; }

        [XmlElement("Sport")]
        public Common.Sport Sport { get; set; }

        [XmlIgnore]
        public Image Image { get; private set; }

        public void LoadImage()
        {
            Image = Image.FromFile("images\\" + ImageName);
        }

        public Equipment(string name, string imageName, Common.Sport sport)
        {
            Name = name;
            ImageName = imageName;
            Sport = sport;

            LoadImage();
        }

        public Equipment()
        {
        }
    }
}
