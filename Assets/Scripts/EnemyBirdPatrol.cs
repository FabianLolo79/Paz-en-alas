using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyBirdPatrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] waypoints;

    public bool isWaiting;
    public int currentWaypoint;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, 
                                                    speed * Time.deltaTime);
        } else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint ++;

        if(currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
        Flip();
    }

    void Flip()
    {
        if(transform.position.x > waypoints[currentWaypoint].position.x)
        {
            _spriteRenderer.flipX = true;
        } else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
