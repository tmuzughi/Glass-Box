using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public GameObject player;
    public GameObject sides;
    // Start is called before the first frame update
    void Start()
    {
        //create player and sides
        Instantiate(player, transform.position, transform.rotation);
        Instantiate(sides, transform.position, transform.rotation);

        //become invisible
        SpriteRenderer me = gameObject.GetComponent<SpriteRenderer>();
        me.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
