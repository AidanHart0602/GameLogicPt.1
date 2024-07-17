using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private RayInputs _input;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject _sphere;
    // Start is called before the first frame update
    void Start()
    {
        _input = new RayInputs();
        _input.Mouse.Enable();
        _input.Mouse.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        Ray rayOrigin = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayOrigin, out hit))
        {
            var objectHit = GetComponent<MeshRenderer>();
            if(objectHit.GetComponent<MeshRenderer>() != null)
            {
                switch (hit.collider.tag)
                {
                    case "Cube":
                        Debug.Log("Left click activated");
                        hit.collider.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
                        break;
                    case "InstantiatePlane":
                        Instantiate(_sphere, hit.point, Quaternion.identity);
                        break;
                    default:
                        Debug.Log("Not a cube");
                        break;
                }
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}