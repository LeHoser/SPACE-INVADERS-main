using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;

    public bool playerHasTriShot;

    private bool _stopSpawning;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        _stopSpawning = false;
        playerHasTriShot = false;
    }

    private void Update()
    {
        if(playerHasTriShot == true)
        {
            _enemyPrefab.GetComponent<EnemyController>().TrishotAcquired();
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            if(playerHasTriShot == true)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-9.13f, 10.37f), 11.73f, 0);
                GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                yield return new WaitForSeconds(0.9f);
                _enemyPrefab.GetComponent<EnemyController>()._trishotPickedUp = true;
            }

            else
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-9.13f, 10.37f), 11.73f, 0);
                GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.transform.parent = _enemyContainer.transform;
                yield return new WaitForSeconds(1.2f);
            }
        }
    }
}
