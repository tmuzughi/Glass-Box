using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public bool timeToDie;
    public bool invincible;

    public int wait;
    public int duration;

    public GameObject deadBody;
    
    
    void Start()
    {
        timeToDie = false;
        invincible = false;

        wait = 0;
        duration = duration * 30;
    }

    // Update is called once per frame
    void Update()
    {

        
        

        if (timeToDie)
        {
            if (GameObject.Find("Airborne(Clone)") != null)
            {
                GameObject ab = GameObject.FindGameObjectWithTag("Airborne");
                Destroy(ab);
            }
                if (GameObject.Find("Player(Clone)") != null)
            {
                //get player and sides
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                GameObject sides = GameObject.FindGameObjectWithTag("Sides");
                
                //make dead body
                Instantiate(deadBody, player.transform.position, player.transform.rotation);
                //destroy player and sides and airborne
                Destroy(player);
                Destroy(sides);
               
            }
            

            wait += 1;
            
            if (wait >= duration)
            {
                SceneManager.LoadScene(gameObject.scene.name);
            }
        }

    }
}
