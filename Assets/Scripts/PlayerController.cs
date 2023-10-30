using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private Vector2 _movement;

    //Energy bar
    public float maxEnergy = 500f;
    public float currentEnergy;
    public EnergyBar energyBar;

    //distance bar
    public TextMeshProUGUI distanceProgrese;
    float distanceUnit = 0;
    
    //distance bar 2
    private float dirX;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        //Energy bar   
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
    }

     void Update()
    {
        //Movimiento
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        _movement = new Vector2(horizontalInput, verticalInput);

        //Energy bar
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DrainEnergy(50);
        }

        //distanceBar 2
        dirX = Input.GetAxisRaw("Horizontal") * speed;
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

    //Energy Bar
    public void DrainEnergy(int energyDrain)
    {
        currentEnergy -= energyDrain;
        energyBar.SetEnergy(currentEnergy);
    }

    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
        energyBar.SetEnergy(currentEnergy);
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
