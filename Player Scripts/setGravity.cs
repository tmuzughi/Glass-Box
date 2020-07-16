using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGravity : MonoBehaviour
{
    public int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
        Physics2D.gravity = new Vector3(0, -10F, 0);
    }

    void Update()
    {
       

        if (GameObject.Find("Airborne(Clone)") == null)
        {
            setTheGravity();
        }

        

    }
    private void setTheGravity()
    {
        /*
        GameObject player = GameObject.Find("Player(Clone)");
        PlayerController sc = player.GetComponent<PlayerController>();
        sc.jumping = true;
        */
        //Control 'Q' which changes gravity by -90 degrees
        if (Input.GetKeyDown("e"))
        {
            if (direction == 0)
            {
                Physics2D.gravity = new Vector3(10, 0, 0);
                direction = 1;
            }
            else if (direction == 1)
            {
                Physics2D.gravity = new Vector3(0, 10, 0);
                direction = 2;
            }
            else if (direction == 2)
            {
                Physics2D.gravity = new Vector3(-10, 0, 0);
                direction = 3;
            }
            else if (direction == 3)
            {
                Physics2D.gravity = new Vector3(0, -10, 0);
                direction = 0;
            }
            PlayerController script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Instantiate(script.airborne);
            script.speedForce = 0f;

        }
        //Control 'W' which changes gravity by 180 degrees
        if (Input.GetKeyDown("w"))
        {
            if (direction == 0)
            {
                Physics2D.gravity = new Vector3(0, 10F, 0);
                direction = 2;
            }
            else if (direction == 2)
            {
                Physics2D.gravity = new Vector3(0, -10F, 0);
                direction = 0;
            }
            else if (direction == 1)
            {
                Physics2D.gravity = new Vector3(-10, 0, 0);
                direction = 3;
            }
            else if (direction == 3)
            {
                Physics2D.gravity = new Vector3(10, 0, 0);
                direction = 1;
            }
            PlayerController script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            script.speedForce = -script.speedForce;
        }
        //Control 'E' which changes gravity by 90 degrees
        if (Input.GetKeyDown("q"))
        {
            if (direction == 0)
            {
                Physics2D.gravity = new Vector3(-10, 0, 0);
                direction = 3;
            }
            else if (direction == 1)
            {
                Physics2D.gravity = new Vector3(0, -10, 0);
                direction = 0;
            }
            else if (direction == 2)
            {
                Physics2D.gravity = new Vector3(10, 0, 0);
                direction = 1;
            }
            else if (direction == 3)
            {
                Physics2D.gravity = new Vector3(0, 10, 0);
                direction = 2;
            }
            PlayerController script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            Instantiate(script.airborne);
            script.speedForce = 0;
        }
        //zeroVel();
    }
    private void zeroVel()
    {
        if (GameObject.Find("Airborne(Clone)") == null)
        {
            Rigidbody2D myBody = gameObject.GetComponent<Rigidbody2D>();
            myBody.velocity = new Vector2(0, 0);

        }
    }
}
