using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    // Start is called before the first frame update
    public ScreenOrientation screenOrientation;
    void Start()
    {
        Screen.orientation = screenOrientation;
    }
}
