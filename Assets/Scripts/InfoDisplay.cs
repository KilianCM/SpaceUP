using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public string title;
    [TextArea(5, 10)]
    public string infos;
    public Text titleContainer;
    public Text textContainer;
    public bool isSelected = false;

    private string defaultText = "Veuillez appuyer sur un élément pour en afficher la description.";

    private void OnMouseOver()
    {
        isSelected = true;
        titleContainer.text = title;
        textContainer.text = infos;
    }

    private void OnMouseExit()
    {
        isSelected = false;
        titleContainer.text = "";
        textContainer.text = defaultText;
    }
}
