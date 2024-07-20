using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerScript : MonoBehaviour
{
    private RayInputs _input;
    private Cube _cube;
    // Start is called before the first frame update
    void Start()
    {
        _cube = FindObjectOfType<Cube>();
        if (_cube == null)
        {
            Debug.Log("_player is null in the Pointer script");
        }
        _input = new RayInputs();
        _input.Mouse.Enable();
        _input.Mouse.Interact.performed += Interact_performed;
    }
    private void Interact_performed(InputAction.CallbackContext obj)
    {
        RaycastHit _hitInfo;
        Ray origin = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(origin, out _hitInfo))
        {
            if(_hitInfo.collider.tag == "Floor") 
            {
                _cube.SelectedPosition(_hitInfo.point);
            }
        }
    }
}
