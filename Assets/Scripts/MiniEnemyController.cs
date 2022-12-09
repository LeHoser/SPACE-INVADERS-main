using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 3.0f;
    [SerializeField] private float _rotateSpeed = 10.0f;

    public GameObject miniEnemy;
    public GameObject player;

    [SerializeField] private TripleShot _trishot;
    [SerializeField] private HealthPickUp _healthPickUp;
    [SerializeField] private bool _spawnHealthPickUp;
    public bool _spawnTriShot;
    public bool _trishotPickedUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateEnemyMovement();
    }

    void CalculateEnemyMovement()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime, Space.World);

        Vector3 randomX = new Vector3(Random.Range(-9.13f, 10.37f), 10f, 0);
        if (transform.position.y < -5.6f)
        {
            transform.position = randomX;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Laser laser = GetComponent<Laser>();

            int spawnNumber = 10;
            int randomChance = Random.Range(1, 11);

            int healthSpawnNumber = 15;
            int healthSpawnChance = Random.Range(1, 16);

            if (spawnNumber > randomChance)
            {
                _spawnTriShot = false;
            }

            else if (spawnNumber == randomChance && _trishotPickedUp == false)
            {
                _spawnTriShot = true;
            }

            else if (spawnNumber == randomChance && _trishotPickedUp == true)
            {
                _spawnTriShot = false;
            }

            if (_spawnTriShot == true && _trishotPickedUp == true)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Ondeath();
            }

            else if (_spawnTriShot == true && _trishotPickedUp == false)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(_trishot, spawnPosition, Quaternion.identity);
                Ondeath();
            }

            else if (_spawnTriShot == false)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Ondeath();
            }

            if (healthSpawnNumber == healthSpawnChance)
            {
                Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Instantiate(_healthPickUp, spawnPosition, Quaternion.identity);
                Ondeath();
            }
            else if (healthSpawnNumber > healthSpawnChance)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                Ondeath();
            }
        }

        if (other.CompareTag("Player"))
        {
            PlayerController player = GetComponent<PlayerController>();

            if (player != null)
            {
                player.Damage();
            }
            other.transform.GetComponent<PlayerController>().Damage();

            Destroy(this.gameObject);
        }
    }

    public void Ondeath()
    {
        PlayerController.PointsOnKill(5);
    }
}
