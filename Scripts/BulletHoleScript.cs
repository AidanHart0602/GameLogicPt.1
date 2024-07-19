using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletHoleScript : MonoBehaviour
{
    private RayInputs _input;
    [SerializeField]
    private Camera _cam;
    [SerializeField]
    private GameObject _hole;
    // Start is called before the first frame update
    void Start()
    {
        _input = new RayInputs();
        _input.Mouse.Enable();
        _input.Mouse.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RaycastHit _hitInfo;
        
        Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(origin, out _hitInfo))
        {
            Instantiate(_hole, _hitInfo.point, Quaternion.LookRotation(_hitInfo.normal));
        }
    }
    void Update()
    {
        // Update is called once per frame
    }
}