using LoadQuestions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UIBuilder : MonoBehaviour
{
    public GameObject panel;
    public GameObject scorePanel;
    public List<string> elementsTypesName;
    public GameObject filler1X1;
    public List<GameObject> elementsTypesPrefabs;
    public GameObject timer;

    private void Awake()
    {
        MCEvent.timer = timer;
        MCEvent.elementsType = elementsTypesName.Zip(elementsTypesPrefabs, (k, v) => new { k, v })
              .ToDictionary(x => x.k, x => x.v); ;
        MCEvent.panel = panel;
        MCEvent.scorePanel = scorePanel;
        MCEvent.filler = filler1X1;
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = Application.streamingAssetsPath + "/MCQuestionsData.xml";
        MCEvent.questions = Deserialize<Questions>(path);
        new MCEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static T Deserialize<T>(string path)
    {
        T deserialized;
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        if (Application.platform == RuntimePlatform.Android)
        {
            WWW androidReader = new WWW(path);
            while (!androidReader.isDone) { }
            MemoryStream stream = new MemoryStream(androidReader.bytes);
            deserialized = (T)serializer.Deserialize(stream);
        }
        else
        {
            StreamReader reader = new StreamReader(path);
            deserialized = (T)serializer.Deserialize(reader.BaseStream);
            reader.Close();
        }
        return deserialized;
    }
}
