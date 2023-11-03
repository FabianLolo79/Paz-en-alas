using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{

    Transform _targetPlayer;
    public float speed = 1;
    Transform _borderCheck;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        _borderCheck = animator.GetComponent<Dog>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 newPos = new Vector2(_targetPlayer.transform.position.x, animator.transform.position.y);
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);

        if (Physics2D.Raycast(_borderCheck.position, Vector2.down, 2) == false)
        {
            Debug.Log("acá debería parar");
            animator.SetBool("isWalking", false);
        }

        float distance = Vector2.Distance(_targetPlayer.position, animator.transform.position);
        if (distance < 0.5f)
        {
            Debug.Log("estás a menos de 0.5 unidad de la paloma y te ataca el perro");
            animator.SetBool("isAttaking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
