using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCLeverHandler : MCElement
{
    public GameObject axe;
    public float maxRotation;
    private int isOn = -1;//1 or -1
  

    private void OnMouseDown()
    {
        axe.transform.Rotate(0, 0, maxRotation*isOn);
        isOn*=-1;
        base.callCheckValue(isOn);
    }
}
