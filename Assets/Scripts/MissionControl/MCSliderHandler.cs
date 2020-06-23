using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class MCSliderHandler : MCElement, IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData)
    {
        base.callCheckValue((int)this.GetComponent<Slider>().value);
    }
}
