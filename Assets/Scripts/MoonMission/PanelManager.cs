using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelManager : MonoBehaviour
{
    public UnityEngine.UI.Button closeButton;
    private GameObject panel;

    private void Start()
    {
        panel = this.gameObject;
        closeButton.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        panel.SetActive(false);
    }
}
