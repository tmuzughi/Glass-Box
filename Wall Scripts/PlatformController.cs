using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public int timer;
    public int duration;
    public float distance;
    public float speed;
    public float speed2;
    public bool ean;
    public bool LR;
    private Vector3 origin;
    private Vector3 destination;
    
    void Start()
    {
        origin = transform.position;

        if (LR)
        {
            destination = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        else
        {
            destination = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
        }

        timer = 0;

        ean = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1;
        if (timer > duration)
        {
            if (ean)
            {
                timer = 0;
                ean = false;

            }
            else
            {
                timer = 0;
                ean = true;

            }
        }

        if (ean)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, speed);
        }

        //speedtrap
        if ((transform.position == origin) || (transform.position == destination))
        {
            speed2 = 0;
        }
        else
        {
            speed2 = speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController script1 = player.GetComponent<PlayerController>();

        if (collision.gameObject.name == "Player(Clone)")
        {

            if (ean)
            {
                if (LR)
                {
                    script1.platypus = speed2;
                }
                else
                {
                    script1.plato = speed2;
                }

            }
            else
            {
                if (LR)
                {
                    script1.platypus = -speed2;
                }
                else
                {
                    script1.plato = -speed2;
                }
            }

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController script1 = player.GetComponent<PlayerController>();
        setGravity script2 = player.GetComponent<setGravity>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        

        int dir = script2.direction;

        if (collision.gameObject.name == "Player(Clone)")
        {
            
                if (ean)
                {                   
                    if (LR)
                    {
                        script1.platypus = speed2;
                    }
                    else
                    {
                        script1.plato = speed2;
                    }   
                    
                }
               else
                {
                    if (LR)
                    {
                        script1.platypus = -speed2;
                    }
                    else
                    {
                        script1.plato = -speed2;
                    }
                }
                
            
            

            




        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (GameObject.Find("Player(Clone)") != null)
        {


            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController script1 = player.GetComponent<PlayerController>();

            if (collision.gameObject.name == "Player(Clone)")
            {
                script1.platypus = 0;
                script1.plato = 0;
            }
        }
    }
}
