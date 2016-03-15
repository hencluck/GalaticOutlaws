using UnityEngine;
using System.Collections;

public class cameraMoveUp : MonoBehaviour {

    float camSpeed = 5.7f;
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
            mCamera.transform.Translate(Vector2.up * camSpeed * Time.deltaTime);
        }

    }
}
