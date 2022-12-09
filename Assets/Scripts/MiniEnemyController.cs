using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemyController : MonoBehaviour
{
    [SerializeField] private float _enemySpeed = 3.0f;

    public GameObject miniEnemy;
    public GameObject player;

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
            Destroy(this.gameObject);
        }

        if (other.CompareTag("Laser"))
        {
            Laser laser = GetComponent<Laser>();

            Debug.Log("Laser hit");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Ondeath();
        }
    }

    public void Ondeath()
    {
        PlayerController.PointsOnKill(5);
    }
}
