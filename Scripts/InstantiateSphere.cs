using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InstantiateSphere : MonoBehaviour
{
    [SerializeField]
    private Camera _cam;
    private RayInputs _input;
    [SerializeField]
    private GameObject _sphere;
    
    // Start is called before the first frame update
    void Start()
    {
        _input = new RayInputs();
        _input.Mouse.Enable();
        _input.Mouse.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RaycastHit hitInfo;
        Ray origin = _cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(origin, out hitInfo))
        {
            if(hitInfo.collider.tag == "InstantiatePlane")
            {
                Debug.Log("Hit " + hitInfo.collider.name);
                Instantiate(_sphere, hitInfo.point, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
