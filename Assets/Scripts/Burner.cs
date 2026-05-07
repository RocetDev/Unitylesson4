using UnityEngine;

public class Burner : MonoBehaviour, IInteract
{
    
    public ParticleSystem ps;
    private InteractableHelper interactableHelper;
    private bool flag = false;

    void Start()
    {
        interactableHelper = GetComponent<InteractableHelper>();
    }

    void UpdateText()
    {
        interactableHelper.objectName = flag? "Горелка: ВКЛ" : "Горелка: ВЫКЛ";
    }

    public void Interact()
    {
        flag = !flag;
        Effect();
        UpdateText();
    }

    public void Effect()
    {   
        if (flag)
        {
           ps.Play(); 
        }
        else
        {
            ps.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        
    }
}
