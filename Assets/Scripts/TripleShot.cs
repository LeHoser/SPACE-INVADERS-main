using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5.0f;

    private void Awake()
    {

    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.down * _moveSpeed *Time.deltaTime);

        if(transform.position.y < -5.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
