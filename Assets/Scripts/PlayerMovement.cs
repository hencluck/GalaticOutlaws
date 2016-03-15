	using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {




	float speed = 6.0f;
	public float jump = 14.0f;
	int jumpcount = 0;

   

    void Update()
    { 
          
		if(Input.GetKey(KeyCode.D))
        {
			transform.Translate (Vector2.right*speed*Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
        }


		if (Input.GetKey (KeyCode.A))
        {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
        }


		if(Input.GetKeyDown(KeyCode.Space))
        {

			if( jumpcount < 2)
            {
			transform.Translate (Vector2.up*jump*Time.deltaTime);
				jumpcount = jumpcount + 1;
			}
	   }


   }

	void OnCollisionEnter2D(Collision2D col)
	{	
		if (col.gameObject.tag == "Ground") 
			Debug.Log ("Collision");
			jumpcount = 0;	


		if (col.transform.tag == "Moving Platform") {

			transform.parent = col.transform;

		}
    }

	void OnCollisionExit2D(Collision2D col)
	{


		if (col.transform.tag == "Moving Platform")
		{

			transform.parent = null;

		}


	}

}
