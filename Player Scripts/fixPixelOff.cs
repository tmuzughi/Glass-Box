using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixPixelOff : MonoBehaviour
{
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (!script.jumping)
        {
            timer += 1;
            if (timer > 90)
            {
                //do work
                float number = gameObject.transform.rotation.z;
                if ((number < -179) && (number > -181))
                {
                    transform.eulerAngles = new Vector3(0, 0, -180);
                }
                if ((number < -269) && (number > -271))
                {
                    transform.eulerAngles = new Vector3(0, 0, -270);
                }
                if ((number < -89) && (number > -91))
                {
                    transform.eulerAngles = new Vector3(0, 0, -90);
                }
                if ((number < 1) && (number > -1))
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if ((number < -361) && (number > -359))
                {
                    transform.eulerAngles = new Vector3(0, 0, -360);
                }
                timer = 0;
                //a check to stop the occasional "player drift"
                if (!Input.GetKey("a") && !Input.GetKey("d"))
                {
                    script.speedForce = 0;
                }
            }
        }
    }
}
