using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Image healthBar;

    [SerializeField]
    float spawnDelay = 3f;
    [SerializeField]
    float spawnDelayDecrement = 0.1f;

    void Start()
    {
        StartCoroutine(InstantiateEnemyCoroutine());
    }

    private IEnumerator InstantiateEnemyCoroutine()
    {
        while (true)
        {
            CreateEnemy();
            yield return new WaitForSeconds(spawnDelay);

            DecrementSpawnDelay();
        }
    }

    void CreateEnemy()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 location = new Vector3(6.5f, 0.6f, 0f);
            Instantiate(enemy, location, Quaternion.identity);
        }
    }

    void DecrementSpawnDelay()
    {
        spawnDelay -= spawnDelayDecrement;
        spawnDelay = Mathf.Max(0.5f, spawnDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soldier")
        {
            healthBar.fillAmount -= 0.1f;
        }
    }
}


