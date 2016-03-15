using UnityEngine;
using System.Collections;

public class cameraMoveDown : MonoBehaviour {

    float camSpeed = 15f;
    public GameObject mCamera;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {



    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            mCamera.transform.Translate(Vector2.down * camSpeed * Time.deltaTime);
        }

    }
}
