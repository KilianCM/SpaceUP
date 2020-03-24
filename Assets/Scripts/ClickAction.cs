using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    [SerializeField]
    private Material materialTrue;
    [SerializeField]
    private float turnSpeed;

    private Material materialDefault;

    
    public bool isActive = false;
    public int shouldRotate = 0;//0=>no, 1=>clockwise -1=>counterclockwise

    // Start is called before the first frame update
    void Start()
    {
        materialDefault=gameObject.transform.GetChild(0).GetComponent<Renderer>().material;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, (turnSpeed*shouldRotate*-100) * Time.deltaTime);
        if((shouldRotate==1 && transform.rotation.x >= 0.5) || (shouldRotate == -1 && transform.rotation.x <= 0)) {
            shouldRotate = 0;
        }
    }

    private void OnMouseDown()
    {
        isActive= !isActive;

        if(isActive)
        {
            shouldRotate = 1;
            foreach (Transform child in transform)
            {
                child.GetComponent<Renderer>().material = materialTrue;
            }
        }
        else
        {
            shouldRotate = -1;
            foreach (Transform child in transform)
            {
                child.GetComponent<Renderer>().material = materialDefault;
            }
        }
    }
}
