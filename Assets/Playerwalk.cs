using UnityEngine;
using System.Collections;

public class Playerwalk : MonoBehaviour {

	public float speed = 10f;
	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRaduis = 0.2f;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	
		anim = GetComponent<Animator> ();

			}


	// Update is called once per frame
	void Update () {

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRaduis, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));	



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

	}


	void OnCollisionEnter2D(Collision2D col)
	{	

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
