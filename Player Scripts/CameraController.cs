using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public bool positionFixed;
    public float speed;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        positionFixed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player(Clone)") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            setGravity script = player.GetComponent<setGravity>();


            if (positionFixed)
            {
                //set rotation based on player variable "direction"
                if (script.direction == 0)
                {
                    //set position relative to player
                    transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .75f, -10);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else if (script.direction == 1)
                {
                    //set position relative to player
                    transform.position = new Vector3(player.transform.position.x - .75f, player.transform.position.y, -10);
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
                else if (script.direction == 2)
                {
                    //set position relative to player
                    transform.position = new Vector3(player.transform.position.x, player.transform.position.y - .75f, -10);
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }
                else if (script.direction == 3)
                {
                    //set position relative to player
                    transform.position = new Vector3(player.transform.position.x + .75f, player.transform.position.y, -10);
                    transform.eulerAngles = new Vector3(0, 0, -90);
                }
            }
            //reset
            if (Input.GetKey("w") || Input.GetKey("e") || Input.GetKey("q") || Input.GetKey("a") || Input.GetKey("d"))
            {
                positionFixed = true;
                timer += 1;
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("e") || Input.GetKeyUp("q") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                timer = 0;
            }
            if (timer == 0)
            {


                //move
                if (Input.GetKey("left"))
                {
                    if (script.direction == 0)
                    {
                        transform.position = new Vector3(transform.position.x - speed, transform.position.y, -10);
                    }
                    else if (script.direction == 1)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed, -10);
                    }
                    else if (script.direction == 2)
                    {
                        transform.position = new Vector3(transform.position.x + speed, transform.position.y, -10);
                    }
                    else if (script.direction == 3)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed, -10);
                    }
                    positionFixed = false;
                }

                if (Input.GetKey("right"))
                {
                    if (script.direction == 0)
                    {
                        transform.position = new Vector3(transform.position.x + speed, transform.position.y, -10);
                    }
                    else if (script.direction == 1)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed, -10);
                    }
                    else if (script.direction == 2)
                    {
                        transform.position = new Vector3(transform.position.x - speed, transform.position.y, -10);
                    }
                    else if (script.direction == 3)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed, -10);
                    }
                    positionFixed = false;
                }

                if (Input.GetKey("up"))
                {
                    if (script.direction == 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed, -10);
                    }
                    else if (script.direction == 1)
                    {
                        transform.position = new Vector3(transform.position.x - speed, transform.position.y, -10);
                    }
                    else if (script.direction == 2)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed, -10);
                    }
                    else if (script.direction == 3)
                    {
                        transform.position = new Vector3(transform.position.x + speed, transform.position.y, -10);
                    }
                    positionFixed = false;
                }

                if (Input.GetKey("down"))
                {
                    if (script.direction == 0)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y - speed, -10);
                    }
                    else if (script.direction == 1)
                    {
                        transform.position = new Vector3(transform.position.x + speed, transform.position.y, -10);
                    }
                    else if (script.direction == 2)
                    {
                        transform.position = new Vector3(transform.position.x, transform.position.y + speed, -10);
                    }
                    else if (script.direction == 3)
                    {
                        transform.position = new Vector3(transform.position.x - speed, transform.position.y, -10);
                    }
                    positionFixed = false;
                }
            }
        }
            
        

        
    }
}
