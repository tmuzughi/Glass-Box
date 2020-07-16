using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        setGravity script = player.GetComponent<setGravity>();
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);

        int dir = script.direction;
        if (dir == 1 || dir == 3)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController script = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (script.speedForce < -.002f || script.speedForce > .002f)
        {
            script.speedForce = -(script.speedForce / 2f);
        }
        else
        {
            script.speedForce = 0;
        }
            
        
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
    }


}
