using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pickUp : MonoBehaviour {

	public Text countText;
	private float count;


	void Start()
	{
		count = 0;
		SetCountText ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("PICK UP ERROR");
			Destroy (gameObject);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text =  count.ToString();

	}
}

