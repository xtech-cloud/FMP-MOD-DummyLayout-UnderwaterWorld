
using System.Xml.Serialization;

namespace XTC.FMP.MOD.DummyLayoutUnderwaterWorld.LIB.Unity
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class MyConfig : MyConfigBase
    {
        public class Layer
        {
            [XmlAttribute("image")]
            public string image { get; set; } = "";
        }

        public class Card
        {
            [XmlAttribute("height")]
            public int height { get; set; } = 0;
            [XmlAttribute("column")]
            public int column { get; set; } = 0;
            [XmlAttribute("offset")]
            public int offset { get; set; } = 0;
            [XmlElement("CloseButton")]
            public UiElement closeButton { get; set; } = new UiElement();
            [XmlArray("SubjectS"), XmlArrayItem("Subject")]
            public Subject[] subjectS { get; set; } = new Subject[0];
        }

        public class UiOptions
        {
            [XmlAttribute("mode")]
            public string mode { get; set; } = "Overlay";
        }

        public class WorldOptions
        {
            [XmlAttribute("offsetY")]
            public int offsetY { get; set; } = 0;
        }

        public class CameraOptions
        {
            [XmlAttribute("fieldOfView")]
            public int fieldOfView { get; set; } = 60;
            [XmlAttribute("distance")]
            public int distance { get; set; } = 0;
        }

        public class Renderer
        {
            [XmlElement("CameraOptions")]
            public CameraOptions cameraOptions { get; set; } = new CameraOptions();
            [XmlElement("UiOptions")]
            public UiOptions uiOptions { get; set; } = new UiOptions();

            [XmlElement("WorldOptions")]
            public WorldOptions worldOptions { get; set; } = new WorldOptions();
        }

        public class Agent
        {
            [XmlAttribute("name")]
            public string name { get; set; } = "";
            [XmlAttribute("card")]
            public string card { get; set; } = "";
            [XmlAttribute("uri")]
            public string uri { get; set; } = "";
        }

        public class Style
        {
            [XmlAttribute("name")]
            public string name { get; set; } = "";
            [XmlArray("FrontLayerS"), XmlArrayItem("Layer")]
            public Layer[] frontLayerS { get; set; } = new Layer[0];
            [XmlArray("BackLayerS"), XmlArrayItem("Layer")]
            public Layer[] backLayerS { get; set; } = new Layer[0];

            [XmlElement("Renderer")]
            public Renderer renderer { get; set; } = new Renderer();
            [XmlElement("Card")]
            public Card card { get; set; } = new Card();
            [XmlArray("AgentS"), XmlArrayItem("Agent")]
            public Agent[] agentS { get; set; } = new Agent[0];
        }

        [XmlArray("Styles"), XmlArrayItem("Style")]
        public Style[] styles { get; set; } = new Style[0];
    }
}
