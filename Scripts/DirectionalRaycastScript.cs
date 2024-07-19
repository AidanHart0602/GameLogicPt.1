using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalRaycastScript : MonoBehaviour
{
    private Rigidbody _rigid;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 3f, Color.red);
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, Vector3.down, out _hit, 3f)) 
        {
            _rigid.isKinematic = true;
            _rigid.useGravity = false;
        }
    }
}
