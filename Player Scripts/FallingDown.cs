using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour
{
    //hold current x and y positions
    private float x;
    private float y;
    //timer for snippets
    private int timer;
    //hold snippets of x and y positions every few frames
    private float xPast;
    private float yPast;
    //hold difference in x and y positions
    private float xDiff;
    private float yDiff;

    public bool falling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inc timer
        timer += 1;
        //set x and y snippets
        if (timer > 15)
        {
            yPast = gameObject.transform.position.y;
            timer = 0;
        }
        //set x and y values each frame
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;

        if (y > 0)
        {
            if ((yPast - y ) <= 0)
            {
                falling = false;
            }
            if ((y - yPast) <= 0)
            {
                falling = true;
            }

        }
        else
        {

        }
    }
}
