using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    //[SerializeField] private float speed;

    [SerializeField] private Transform player;

    private bool _isFacingLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = Vector2.MoveTowards(transform.position, player.position,speed * Time.deltaTime );

        bool _isPlayerLeft = transform.position.x > player.transform.position.x;
        Flip(_isPlayerLeft);
    }

    private void Flip(bool isPlayerLeft)
    {
        if ((_isFacingLeft && !isPlayerLeft) || (!_isFacingLeft && isPlayerLeft))
        {
            _isFacingLeft = !_isFacingLeft;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

}
