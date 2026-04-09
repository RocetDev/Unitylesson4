using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RaycastSelector : MonoBehaviour
{
    public InputActionAsset inputAsset;
    private InputActionMap inputMap;
    private InputAction interactAction;

    public Text text;
    public float rayDistance = 5f;
    public Transform raycastPoint;

    private GameObject keepObject = null;

    public void SetupInputAsset(InputActionAsset inputAsset)
    {
        this.inputAsset = inputAsset;
        InitInput();
    }

    void InitInput()
    {
        inputMap = inputAsset.FindActionMap("Player");
        interactAction = inputMap.FindAction("Interact");
    }

    void Update()
    {
        if (interactAction == null && inputAsset != null)
        {
            InitInput();
            return;
        }

        Ray ray = new Ray(raycastPoint.position, raycastPoint.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance))
        {   
            InteractableHelper obj = hit.collider.GetComponent<InteractableHelper>();

            
            if (obj != null)
            {
                // obj.TryGetComponent<IInteract>(out var d) && 
                if(interactAction.WasPressedThisFrame())
                {
                    if(obj.grab)
                    {   
                        keepObject = obj.Grab();
                        keepObject.SetActive(false);
                    }
                    else if(obj.socket && keepObject != null)
                    {
                        obj.Socket(keepObject);
                        keepObject = null;
                    }
                    else if(obj.TryGetComponent<IInteract>(out var d))
                    {
                        d.Interact();
                    }
                }
                
                text.text = obj.objectName;
            }
            else
            {
                text.text = "";
            }
        }
        else
        {
            text.text = "";
        }
    }
}