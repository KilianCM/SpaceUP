using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCElement : MonoBehaviour
{
    private string labelText;
    private MCEvent eventHandler;

    public MCEvent EventHandler { set => eventHandler = value; }

    protected bool callCheckValue(int value)
    {
        return eventHandler.CheckAnswer(this.gameObject, value);
    }

    public static GameObject CreateInstance(GameObject prefab, string labelText,GameObject parent = null)
    {
        GameObject instance = Instantiate(prefab) as GameObject;
        instance.transform.SetParent(parent.transform, false);
        instance.GetComponent<MCElement>().labelText = labelText;
        instance.GetComponentInChildren<Text>().text = labelText;

        return instance;
    }
}
