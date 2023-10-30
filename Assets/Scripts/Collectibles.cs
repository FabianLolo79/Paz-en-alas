using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public static GameObject obj;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _animator.GetCurrentAnimatorStateInfo(0).IsTag("CanEat"))
        {
            _animator.SetTrigger("Eat");
            collision.SendMessageUpwards("AddEnergy", 100);
        }
    }
}
