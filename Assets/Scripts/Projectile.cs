using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _player;
    private Rigidbody2D _rigidBody; 


    private void Awake()
    {
        _player = FindObjectOfType<Player>().transform;
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        LaunchProjectile();
    }

    //Función para lanzar projectil
    private void LaunchProjectile()
    {
        Vector2 directionToPlayer = (_player.position - transform.position).normalized;
        _rigidBody.velocity = directionToPlayer * _speed;
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }

}
