using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingEngine : MonoBehaviour
{
    public ClickAction oxygen;
    public ClickAction rp1;

    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(oxygen.isActive);
        if (oxygen.isActive && rp1.isActive)
        {
            particle.Play();
        }
        else
            particle.Stop();
    }
}
