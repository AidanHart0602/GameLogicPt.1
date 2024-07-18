using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class LayerMaskScript : MonoBehaviour
{
    private RayInputs _input;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private LayerMask _mask;
    // Start is called before the first frame update
    void Start()
    {
        _input = new RayInputs();
        _input.Mouse.Enable();
        _input.Mouse.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
      
        RaycastHit rayInfo;
        Ray origin = _cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(origin, out rayInfo, Mathf.Infinity, _mask)) 
        {
            rayInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
