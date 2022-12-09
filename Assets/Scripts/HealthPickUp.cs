using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);

        if(transform.position.y < -5.67f)
        {
            Destroy(this.gameObject);
        }
    }
}
