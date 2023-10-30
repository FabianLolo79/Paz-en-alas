using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _movement;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(horizontalInput, verticalInput);
    }

    private void FixedUpdate()
    {
        float horizontalVelocity = _movement.normalized.x * speed;
        float verticalVelocity = _movement.normalized.y * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, verticalVelocity);
    }

    private void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("Walk", _movement != Vector2.zero);
    }

    //private void OnCollisionEnter2D()
    //{
    //    if ()
    //    {
    //        Destroy(gameObject);
    //    }

    //}
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
