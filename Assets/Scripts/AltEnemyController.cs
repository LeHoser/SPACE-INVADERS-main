using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltEnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _rotateSpeed = 10.0f;

    [SerializeField] private GameObject _altEnemy;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _miniEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        SpawnManager spawnManager = GetComponent<SpawnManager>();
        PlayerController PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateEnemyMovement();
    }

    void CalculateEnemyMovement()
    {
        //transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime); Causes enemy to veer off in random direction :(

        Vector3 direction = new Vector3(0, -1 * _enemySpeed, 0) * Time.deltaTime;
        transform.Translate(direction);

        Vector3 randomX = new Vector3(Random.Range(-9.13f, 10.37f), 10f, 0);
        if (transform.position.y < -5.6f)
        {
            transform.position = randomX;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            PlayerController player = GetComponent<PlayerController>();

            if (player != null)
            {
                player.Damage();
            }
            other.transform.GetComponent<PlayerController>().Damage();
        }

        if(other.CompareTag("Laser"))
        {
            Laser laser = GetComponent<Laser>();

            Debug.Log("Laser hit");
            Destroy(other.gameObject);
            Vector3 spawnPosition = new Vector3(transform.position.x + 3.0f, transform.position.y, 0);
            Vector3 otherSpawnPosition = new Vector3(transform.position.x + -3.0f, transform.position.y, 0);
            GameObject newEnemy = Instantiate(_miniEnemy, spawnPosition, Quaternion.identity);
            GameObject otherNewEnemy = Instantiate(_miniEnemy, otherSpawnPosition, Quaternion.identity);
            Destroy(this.gameObject);
            Ondeath();
        }
    }

    public void Ondeath()
    {
        PlayerController.PointsOnKill(15);
    }
}
