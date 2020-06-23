using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCButtonHandlerV2 : MCElement
{
    public GameObject button;
    public float maxPosition;

    private bool isDown = false;
    private float maxDownDelay = 0.5f;
    private float currentDownDelay = 0f;

    private void Update()
    {
        if (isDown)
        {
            if (currentDownDelay >= maxDownDelay)
            {
                isDown = false;
                currentDownDelay = 0f;
                button.transform.Translate(0, 0, -maxPosition);
            }
            else
            {
                currentDownDelay += Time.deltaTime;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!isDown)
        {
            base.callCheckValue(1);
            button.transform.Translate(0, 0, maxPosition);
            isDown = true;
        }
    }
}
