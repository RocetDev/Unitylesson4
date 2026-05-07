using UnityEngine;

public class DoorInteract : MonoBehaviour, IInteract
{
    
    public Animator animator;
    private InteractableHelper interactableHelper;
    private bool isOpen = false;

    void Start()
    {
        interactableHelper = GetComponent<InteractableHelper>();
    }

    public void Interact()
    {
        isOpen = !isOpen;
        animator.SetBool("IsOpen", isOpen);
        UpdateText();
    }


    void UpdateText()
    {
        interactableHelper.objectName = isOpen? "Закрыть" : "Открыть";
    }
}
