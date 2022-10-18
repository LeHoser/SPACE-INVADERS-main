using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveSpeed = 0.5f;
        Vector3 direction = new Vector3(0, -1 * _moveSpeed * Time.deltaTime, 0);
        transform.Translate(direction);

        if(transform.position.y < -5.67f)
        {
            Destroy(this.gameObject);
        }
    }
}
