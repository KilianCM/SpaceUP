using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MCSliderCursor : MonoBehaviour
{
    private List<float> positions = new List<float>();

    private float minX;
    private float maxX;
    private bool isDragging;

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Mathf.Abs(Camera.main.transform.position.z-transform.parent.position.z));
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.y = transform.position.y;
        objPosition.z = transform.position.z;
        transform.position = objPosition;

        transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, minX, maxX), transform.localPosition.y, transform.localPosition.z);

        isDragging = true;
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            int nearestIndex = this.nearest(transform.localPosition.x);
            transform.parent.GetComponent<MCSliderHandlerV2>().EmitValue(nearestIndex);
            transform.localPosition = new Vector3(positions[nearestIndex], transform.localPosition.y, transform.localPosition.z);
        }
    }
    private int nearest(float target)
    {
        int closestIndex = 0;
        for(int i = 0; i < positions.Count; i++)
        {
            if (Mathf.Abs(positions[i]-target)> Mathf.Abs(positions[closestIndex] - target))
            {
                break;
            }
            closestIndex = i;
        }
        return closestIndex;
    }

    public void setPositions(float min, float max, int steps)
    {
        minX = min;
        maxX = max;
        float range = Mathf.Abs(maxX - minX);
        for (int i = 0; i < steps; i++)
        {
            float XPos = (range / (steps - 1) * ((i-(steps-1))*-1)) + minX;
            positions.Add(XPos);
            GameObject unit = new GameObject("Unit_"+i.ToString());
            unit.transform.parent = transform.parent;
            TextMesh unitText =  unit.AddComponent<TextMesh>() as TextMesh;
            unitText.text = i.ToString();
            unit.transform.localPosition = new Vector3(XPos, transform.localPosition.y-0.002f, transform.localPosition.z);
        }
    }
}
