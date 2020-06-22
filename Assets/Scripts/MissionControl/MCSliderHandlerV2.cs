using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSliderHandlerV2 : MCElement
{
    public GameObject cusrsor;
    public float minPosition;
    public float maxPostion;
    public int steps;

    private void Start()
    {
        cusrsor.GetComponent<MCSliderCursor>().setPositions(minPosition, maxPostion, steps);
    }

    public void EmitValue(int value)
    {
        base.callCheckValue(value);
    }
}
