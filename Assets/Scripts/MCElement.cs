using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCElement : MonoBehaviour
{
    public int size=1;

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
        GameObject instance = Instantiate(prefab,parent.transform,false) as GameObject;
        instance.GetComponent<MCElement>().labelText = element.Text;
        foreach (Transform child in instance.transform) if (child.CompareTag("AnswerText")) {
                child.GetComponent<TextMesh>().text = element.Text;
        }
        //instance.GetComponentInChildren<TextMesh>().text = element.Text;

        instance.GetComponent<MCElement>().isCorrect = element.IsCorrect;
        return instance;
    }
}
