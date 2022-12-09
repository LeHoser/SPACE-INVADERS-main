using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject _alternateEnemy;

    public bool playerHasTriShot;

    private bool _stopSpawning;

    void Start()
    {
        StartCoroutine(BasicEnemySpawn());
        //AlternateEnemySpawn();
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

    IEnumerator BasicEnemySpawn()
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

            Vector3 spawnAltEnemy = new Vector3(Random.Range(-9.13f, 10.37f), 11.73f, 0);
            GameObject newAltEnemy = Instantiate(_alternateEnemy, spawnAltEnemy, Quaternion.identity);
            newAltEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(3.0f);
        }

    }

    /*IEnumerator AlternateEnemySpawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-9.13f, 10.37f), 11.73f, 0);
        GameObject newEnemy = Instantiate(_alternateEnemy, spawnPosition, Quaternion.identity);
        newEnemy.transform.parent = _enemyContainer.transform;
        yield return new WaitForSeconds(3f);
    }*/
}
