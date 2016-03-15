using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

    public float fireRate = 0;
    public float Damage = 10;
    public Transform GunFirePoint;
    public GameObject Bullet;


    float timeToFire = 0;
    



	// Use this for initialization
	void Awake () {

        GunFirePoint = transform.FindChild("FirePoint");

        if (GunFirePoint == null) {
            Debug.LogError("No Fire Point");
        }
	
	}
	
	// Update is called once per frame
	void Update () {

      

        if (fireRate > 0)
        {
          
            if (Input.GetButtonDown("Attack") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        else {

            if (Input.GetButtonDown("Attack"))
            {
                Shoot();
            }

        }

    }

    void Shoot() {

        Debug.LogError("test");
        Instantiate(Bullet, GunFirePoint.position, GunFirePoint.rotation);

    }
}
