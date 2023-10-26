using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _timeBetweenShoots;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {   
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenShoots);
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
