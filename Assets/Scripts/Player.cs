using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _movement;
    private bool _isGrounded;

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

        //Is grounded?
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
        _animator.SetBool("IsGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
