using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private int holdUp;
    public int holdUpDuration;
    private int wait;
    private int holdDown;
    public int holdDownDuration;
    public int waitDuration;
    private float size;
    private bool flipSwitch;
    public float upRate;
    public float downRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector2(size, size);

        
        if (wait >= waitDuration)
        {         
            if (size < 1 && !flipSwitch)
            {
                size += upRate;
                if (size >= 1)
                    size = 1;
                
            }
            if (size > 0 && flipSwitch)
            {
                size -= downRate;
                if (size <= 0)
                    size = 0;
            }
            if (size == 0)
            {
                holdDown += 1;
                if (holdDown >= holdDownDuration)
                {
                    
                        flipSwitch = false;

                    holdDown = 0;
                }
            }
            if (size == 1)
            {
                holdUp += 1;
                if (holdUp >= holdUpDuration)
                {

                    flipSwitch = true;

                    holdUp = 0;
                }
            }
        }
        else
        {
            wait += 1;
        }
    }
}
