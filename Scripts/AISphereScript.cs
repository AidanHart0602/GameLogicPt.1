using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AISphereScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] _wayPoints;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _agent.destination = _wayPoints[Random.Range(0, 6)].transform.position;
        }
    }
}
