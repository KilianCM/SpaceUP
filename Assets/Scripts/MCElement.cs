using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCElement : MonoBehaviour
{
    private string labelText; 
    private MCEvent eventHandler;
    private bool isCorrect;

    public MCEvent EventHandler { set => eventHandler = value; }

    protected bool callCheckValue(int value)
    {
        return eventHandler.CheckAnswer(this.isCorrect, value);
    }

    public static GameObject CreateInstance(GameObject prefab, LoadQuestions.Element element,GameObject parent = null)
    {
        GameObject instance = Instantiate(prefab) as GameObject;
        instance.transform.SetParent(parent.transform, false);
        instance.GetComponent<MCElement>().labelText = element.Text;
        instance.GetComponentInChildren<Text>().text = element.Text;
        instance.GetComponent<MCElement>().isCorrect = element.IsCorrect;

        return instance;
    }
}
