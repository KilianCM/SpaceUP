using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [SerializeField]
    private Material materialTrue;
    private Material materialDefault;

    
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        materialDefault = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseDown()
    {
        isActive= !isActive;

        Renderer r = gameObject.GetComponent<Renderer>();

        

        if (isActive == false)
        {
            r.material = materialDefault;
        }
        else
        {
            r.material = materialTrue;
        }


    }


}
