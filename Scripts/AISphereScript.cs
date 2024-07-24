using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AISphereScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _wayPoints;
    private NavMeshAgent _agent;
    private bool _reverse = false;
    private int _counter;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agent.destination = _wayPoints[_counter].transform.position;
        }
    }

    void Update()
    {
        if (_agent.remainingDistance < .4)
        {
            if (_reverse == false)
            {
                Normal();
            }
            else if (_reverse == true)
            {
                Reverse();
            }
            _agent.destination = _wayPoints[_counter].transform.position;
        }
    }

    void Normal()
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
}