using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    

    void Start()
	{
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster> ();
		}
	}

    public Transform spawnPoint;
    public Transform playerPrefab;
    public Transform spawnPrefab;
    public int spawnDelay = 2;
	public Transform mainCamera;
	public Transform CameraRespawn;
	public GameObject Player;

  




    public IEnumerator RespawnPlayer()
    {
		
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        GameObject clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
        Destroy(clone, 3f);
		mainCamera.position = CameraRespawn.position;
		//Player.GetComponent<Player> ();
		//Player.Stats.init ();
	}
		




    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void KillEnemy(Enemy enemy)
    {
        gm._KillEnemy(enemy);

    }

    public void _KillEnemy(Enemy _enemy)
    {
        Instantiate(_enemy.deathParticles, _enemy.transform.position, Quaternion.identity);
        Destroy(_enemy.gameObject);
    }

}
