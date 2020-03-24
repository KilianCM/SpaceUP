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
    public Shader outlineShader;
    public Text titleContainer;
    public Text textContainer;

    private string defaultText = "Veuillez appuyer sur un élément pour en afficher la description.";
    private Shader defaultShader;
    private List<Renderer> renderers = new List<Renderer>();
    void Start()
    {
        if (gameObject.GetComponent<Renderer>() != null)
        {
            renderers.Add(gameObject.GetComponent<Renderer>());
            defaultShader = renderers[0].material.shader;
        }
        else
        {
            foreach (Transform child in transform)
            {
                renderers.Add(child.gameObject.GetComponent<Renderer>());
            }
            defaultShader = renderers[0].material.shader;
        }
    }

    private void OnMouseOver()
    {
        titleContainer.text = title;
        textContainer.text = infos;
        foreach (Renderer renderer in renderers)
        {
            renderer.material.shader = outlineShader;
        }
    }

    private void OnMouseExit()
    {
        titleContainer.text = "";
        textContainer.text = defaultText;
        foreach (Renderer renderer in renderers)
        {
            renderer.material.shader = defaultShader;
        }
    }
}
