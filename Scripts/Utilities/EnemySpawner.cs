using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemiesCount = 1;
    public GameObject enemyReference;
    private GameObject _spawnedEnemy;
    private int enemiesDead;
    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            _spawnedEnemy = Instantiate(enemyReference);
            _spawnedEnemy.transform.position = gameObject.transform.position;
            _spawnedEnemy.GetComponentInChildren<Timer>().SetTime(Random.Range(2, 5));
            _spawnedEnemy.GetComponent<EnemyObject>().accelerationScale = Random.Range(1, 1.7f);
            // You Win Screen + Button Restart + Keyboard Restart + acceleration random
            yield return new WaitForSeconds(1f);
        }
    }
    
    void Start()
    {
        enemiesDead = 0;
        StartCoroutine(SpawnEnemies());
    }
    
    void Update()
    {
        if (enemiesDead == enemiesCount)
        {
            GameObject.Find("UIManager").GetComponent<UIManager>().Complete(true);
        }
    }

    public void KillEnemy()
    {
        ++enemiesDead;
    }
}
