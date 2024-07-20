using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    private Vector3 _pointerLocation;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_pointerLocation, transform.position);
        if(distance > 1) 
        {
            var direction = _pointerLocation - transform.position;
            direction.Normalize();
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }

    public void SelectedPosition(Vector3 newPos)
    {
        _pointerLocation = newPos;
    }
}