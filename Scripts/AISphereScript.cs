using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class AISphereScript : MonoBehaviour
{
    private SphereControls _input;
    private enum AIStates
    {
        Walking,
        Jumping,
        Attack
    }
    [SerializeField]
    private AIStates _currentState;
    private bool _attacking = true;
    private bool _jumping = true;
    [SerializeField]
    private GameObject[] _wayPoints;
    private NavMeshAgent _agent;
    private bool _reverse = false;
    private int _counter;
    void Start()
    {
        _input = new SphereControls();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agent.destination = _wayPoints[_counter].transform.position;
        }
        _input.Controls.Enable();
        _input.Controls.Jump.performed += Jump_performed;
        _input.Controls.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if(_agent.remainingDistance > .5)
        {
            _currentState = AIStates.Attack;
        }
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        _currentState = AIStates.Jumping;   
    }

    void Update()
    {
        switch (_currentState)
        {
            case AIStates.Walking:
                SphereMovement();
                Debug.Log("Walking");
                break;
            case AIStates.Jumping:
                if(_jumping == true)
                {
                    StartCoroutine(Jumping());
                }
                Debug.Log("Jumping");
                break;
            case AIStates.Attack:
                if(_attacking == true)
                {
                    StartCoroutine(AttackCoroutine());
                }
                Debug.Log("Attacking");
                break;
        }
    }

    void SphereMovement()
    {
        if (_agent.remainingDistance < .5f)
        {
            if (_reverse == false)
            {
                Forward();
            }
            else if (_reverse == true)
            {
                Reverse();
            }
            _agent.destination = _wayPoints[_counter].transform.position;
        }
    }

    void Forward()
    {
        if (_counter == _wayPoints.Length - 1)
        {
            _reverse = true;
            _counter--;
        }
        else
        {
            _counter++;
        }
    }
    void Reverse()
    {
        if (_counter == 0)
        {
            _reverse = false;
            _counter++;
        }
        else
        {
            _counter--;
        }
    }
    IEnumerator Jumping()
    {
        _jumping = false;
        _agent.isStopped = true;
        yield return new WaitForSeconds(.5f);
        _agent.isStopped = false;
        _jumping = true;
        _currentState = AIStates.Walking;
    }
    
    IEnumerator AttackCoroutine()
    {
        _agent.isStopped = true;
        _attacking = false;
        yield return new WaitForSeconds(3.0f);
        _agent.isStopped = false;
        _attacking = true;
        _currentState = AIStates.Walking;
    }
}