using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smash;
    public float speedForce;
    public float speed;
    public float jumpForce;
    public float vel;

    public GameObject airborne;
    public bool jumping;
    public int jumpTimer;

    public float platypus;
    public float plato;
    //
    public bool checkIDEK;
    //
    public float tempDistance;
    public bool touchingRight;
    public bool touchingLeft;
    public bool raySwitch;

    public int jumpExtensionTimer;

    public LayerMask layerMask;
    


    void Start()
    {
        smash = false;
        layerMask = ~layerMask;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        

            //get script with "direction" variable
            setGravity script = gameObject.GetComponent<setGravity>();
        int dir = script.direction;
        
            if (dir == 0)
            {
                //This applies the left, right, and stop controls
                transform.position = new Vector2(transform.position.x + speedForce + platypus, transform.position.y + plato);
                checkRightZero();
                checkLeftZero();
            }
            else if (dir == 1)
            {
                transform.position = new Vector2(transform.position.x + platypus, transform.position.y + speedForce + plato);
                checkRightOne();
                checkLeftOne();
            }
            else if (dir == 2)
            {
                transform.position = new Vector2(transform.position.x - speedForce + platypus, transform.position.y + plato);
                checkRightTwo();
                checkLeftTwo();
            }
            else if (dir == 3)
            {
                transform.position = new Vector2(transform.position.x + platypus, transform.position.y - speedForce + plato);
                checkRightThree();
                checkLeftThree();
            }
        //stop if we hit something
        cease();

        //Move Left
        if (Input.GetKey("a") && !touchingLeft)
        {
            if (speedForce > -speed)
            {
                speedForce -= vel;
            }
            
        }
        
            //Move Right
            if(Input.GetKey("d") && !touchingRight)
            {
                if (speedForce < speed)
                {
                    speedForce += vel;

                }
            
        }
        
        
        
        //Stop (niether left nor right are pressed) or (both left and right are pressed)
        if ((!(Input.GetKey("a")) && !(Input.GetKey("d"))) || (Input.GetKey("a")) && (Input.GetKey("d")))
        {
            if (jumping)
            {
                if (speedForce > 0)
                {
                    speedForce -= .0002f;
                }
                else if (speedForce < 0)
                {
                    speedForce += .0002f;
                }
                else
                {
                    speedForce = 0;
                }
            }
            else
            {
                if (speedForce > .001f)
                {
                    speedForce -= .001f;
                }
                if (speedForce < -.001f)
                {
                    speedForce += .001f;
                }
                if (speedForce < .001f && speedForce > -.001f)
                {
                    speedForce = 0;
                }
            }
                
        }
        
        //Jump
        if (jumpTimer > 1)
        {
            if (!Input.GetKeyDown("q") && !Input.GetKeyDown("w") && !Input.GetKeyDown("e"))
            {
                if (Input.GetKeyDown("space"))
                {
                    jumpTimer = 0;
                    if (GameObject.Find("Airborne(Clone)") == null)
                    {
                        if (dir == 0)
                        {
                            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                        }
                        else if (dir == 1)
                        {
                            GetComponent<Rigidbody2D>().AddForce(new Vector2(-jumpForce, 0), ForceMode2D.Impulse);
                        }
                        else if (dir == 2)
                        {
                            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
                        }
                        else if (dir == 3)
                        {
                            GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpForce, 0), ForceMode2D.Impulse);
                        }


                    }
                    
         
                }
            }
            
        }
        if (jumping)
        {
            
            jumpExtensionTimer += 1;
            if (jumpExtensionTimer == 6)
            {
                if (Input.GetKey("space"))
                {
                    if (dir == 0)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, (jumpForce / 10f)), ForceMode2D.Impulse);
                    }
                    else if (dir == 1)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(-(jumpForce / 10f), 0), ForceMode2D.Impulse);
                    }
                    else if (dir == 2)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -(jumpForce / 10f)), ForceMode2D.Impulse);
                    }
                    else if (dir == 3)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2((jumpForce / 10f), 0), ForceMode2D.Impulse);
                    }
                }
                
            }
        }
        else
        {
            jumpExtensionTimer = 0;
        }

        //set jumping bool
        if (GameObject.Find("Airborne(Clone)") == null)
        {            
            jumping = false;
        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource audioData = GetComponent<AudioSource>();
        audioData.PlayDelayed(0);
        jumpTimer += 1;

        //smash check
        if (jumpTimer > 10 && jumpExtensionTimer > 25)
        {
            smash = true;
            GameObject spawn = GameObject.FindGameObjectWithTag("Respawn");
            PlayerDeath script = spawn.GetComponent<PlayerDeath>();
            script.timeToDie = true;
        }
        

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        jumpTimer += 1;
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded();
        
    }
    private void grounded()
    {
        if (GameObject.Find("Airborne(Clone)") == null)
        {
            Instantiate(airborne);
            jumping = true;
        }       
    }
    
    private void checkRightZero()
    {
        

        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        //int layerMask = ~(1);
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * tempDistance, Color.yellow, 1f, true);

        

        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingRight = true;
            
        }
        else
        {
            touchingRight = false;
            
        }
    }
    private void checkLeftZero()
    {
        

        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        //int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingLeft = true;

            

        }
        else
        {
            touchingLeft = false;
            
        }
    }
    private void checkRightOne()
    {


        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.up * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingRight = true;

        }
        else
        {
            touchingRight = false;

        }
    }
    private void checkLeftOne()
    {


        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingLeft = true;



        }
        else
        {
            touchingLeft = false;

        }
    }
    private void checkRightTwo()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.left * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingRight = true;

        }
        else
        {
            touchingRight = false;

        }
    }
    private void checkLeftTwo()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * tempDistance, Color.red, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingLeft = true;

        }
        else
        {
            touchingLeft = false;

        }
    }
    private void checkRightThree()
    {


        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.down * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingRight = true;

        }
        else
        {
            touchingRight = false;

        }
    }
    private void checkLeftThree()
    {


        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        int layerMask = ~(1);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, tempDistance, layerMask);
        Debug.DrawRay(transform.position, Vector2.up * tempDistance, Color.yellow, 1f, true);



        // If it hits something...
        if (hit.collider != null)
        {

            //Debug.Log("You hit " + hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Wall"))
                touchingLeft = true;



        }
        else
        {
            touchingLeft = false;

        }
    }
    private void cease()
    {
        if (touchingRight && Input.GetKey("d"))
        {
            speedForce = 0;
        }
        if (touchingLeft && Input.GetKey("a"))
        {
            speedForce = 0;
        }
    }
   
    
}