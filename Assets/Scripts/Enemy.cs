using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


    [System.Serializable]
    public class EnemyStats
    {

        public int maxHealth = 100;
        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public int damage = 10;

        public void init()
        {
            curHealth = maxHealth;

        }

    }
    public Transform deathParticles;
    public EnemyStats Stats = new EnemyStats();

 

    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {

        Stats.init();

        if(statusIndicator != null)
        {
            statusIndicator.SetHealth(Stats.curHealth, Stats.maxHealth);
        }

        if(deathParticles == null)
        {
            Debug.LogError("no death particles found");
        }

    }

    void OnCollisionEnter2D(Collision2D _colInfo)
    {
        Debug.LogError("collison made");
        Player _player = _colInfo.collider.GetComponent<Player>();
        if (_player != null)
        {
            Debug.LogError("did 10 damage");
            _player.DamagePlayer(Stats.damage);
            DamageEnemy(999999);

        }
    }

    public void DamageEnemy(int damage)
    {

        Stats.curHealth -= damage;

        if (Stats.curHealth <= 0)
        {
            GameMaster.KillEnemy(this);
        }

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(Stats.curHealth, Stats.maxHealth);
        }
    }


}
