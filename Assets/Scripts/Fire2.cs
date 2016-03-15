using UnityEngine;
using System.Collections;

public class Fire2 : MonoBehaviour {

    public float speed;
    public Player player;



    // Use this for initialization
    void Start()
    {


        player = FindObjectOfType<Player>();

        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }

        GetComponent<Rigidbody>().velocity = transform.up * speed;

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
