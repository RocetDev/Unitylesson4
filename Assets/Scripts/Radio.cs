using UnityEngine;

public class Radio : MonoBehaviour, IInteract
{
    private InteractableHelper interactableHelper;
    public AudioSource audioSource;

    void Start()
    {
        interactableHelper = GetComponent<InteractableHelper>();
    }
    
    void UpdateText()
    {
        interactableHelper.objectName = audioSource.isPlaying? "Радио: ВКЛ" : "Радио: ВЫКЛ";
    }

    public void Interact()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }

        UpdateText();
    }
}
