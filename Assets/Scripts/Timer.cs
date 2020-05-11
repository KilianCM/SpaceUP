using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool isStarted = true;
    public float remainingTime = 10;
    public float totalTime = 10;
    public MCEvent mcEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            remainingTime -= Time.deltaTime;
            float percentage = 0;
            if(remainingTime > 0)
            {
                percentage = (float)remainingTime / totalTime;
            }
            else
            {
                percentage = 0;
                this.isStarted = false;
                mcEvent.TimerComplete();
            }
            this.gameObject.transform.GetChild(0).gameObject.transform.localScale = new Vector3(percentage, 1, 1);

        }
    }

    public void Reset()
    {
        this.isStarted = false;
        this.remainingTime = this.totalTime;
    }
}
