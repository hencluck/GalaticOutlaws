using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



    [System.Serializable]
	public class PlayerStats
    {

        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void init()
        {
            curHealth = maxHealth;

        }

    }


    public PlayerStats Stats = new PlayerStats();

    //public int fallBoundary = -20;

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
		Stats.init();
        if(statusIndicator == null)
        {
            Debug.LogError("status indicator not found");
           
        }
        else
        {
            statusIndicator.SetHealth(Stats.curHealth , Stats.maxHealth);
        }
    }

//    void Update()
 //   {
   //     if(transform.position.y <= fallBoundary)
 //       {
 //           DamagePlayer(999999999);
  //      }
//    }

    public void DamagePlayer(int damage) {

        Stats.curHealth -= damage;

        if(Stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }

       statusIndicator.SetHealth(Stats.curHealth, Stats.maxHealth);
    }
}
