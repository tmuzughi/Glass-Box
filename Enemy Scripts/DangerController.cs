using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            GameObject spawn = GameObject.FindGameObjectWithTag("Respawn");
            PlayerDeath script = spawn.GetComponent<PlayerDeath>();
            script.timeToDie = true;
        }
    }
}
