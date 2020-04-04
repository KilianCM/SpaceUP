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
    public bool isTransparent;

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
        if (isTransparent)
        {
            if (gameObject.GetComponent<Outliner>() == null)
            {
                gameObject.AddComponent<Outliner>();
            }
        }
        else
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.material.shader = outlineShader;
            }
        }
    }

    private void OnMouseExit()
    {
        titleContainer.text = "";
        textContainer.text = defaultText;
        if (isTransparent)
        {
            Destroy(gameObject.GetComponent<Outliner>());
            foreach(GameObject outline in GameObject.FindGameObjectsWithTag("Outline"))
            {
                Destroy(outline);
            }
        }
        else
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.material.shader = defaultShader;
            }
        }
    }
}
