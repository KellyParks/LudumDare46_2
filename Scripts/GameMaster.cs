using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;
    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform enemyPrefab;
    public Transform enemySpawnPoint;
    private bool isRespawning = false;

    private IEnumerator coroutine;

    private void Awake()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (player == null && enemy == null && !this.isRespawning)
        {
            StartCoroutine(RespawnAll());
        } else if(player == null && !this.isRespawning)
        {
            this.isRespawning = true;
            RespawnPlayer();
            this.isRespawning = false;
        }
    }

    IEnumerator RespawnAll()
    {
        isRespawning = true;
        yield return new WaitForSeconds(2);
        RespawnPlayer();
        RespawnEnemy();
        isRespawning = false;
    }

    public void RespawnPlayer()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void RespawnEnemy()
    {
        Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);
    }

    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
