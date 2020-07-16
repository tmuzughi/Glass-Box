using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneController : MonoBehaviour
{
    public GameObject wall;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        


        GameObject player = GameObject.FindGameObjectWithTag("Player");
        setGravity script = player.GetComponent<setGravity>();
        int dir = script.direction;
        if (dir == 0)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y - .25f, player.transform.position.z);
        }
        else if (dir == 1)
        {
            transform.position = new Vector3(player.transform.position.x + .25f, player.transform.position.y, player.transform.position.z);
        }
        else if (dir == 2)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + .25f, player.transform.position.z);
        }
        else if (dir == 3)
        {
            transform.position = new Vector3(player.transform.position.x - .25f, player.transform.position.y, player.transform.position.z);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Wall")
        Destroy(gameObject);
        
    }
}
