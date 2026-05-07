using System.Linq;
using UnityEditor.SearchService;
using UnityEngine;

public class RadioInteract : MonoBehaviour, IInteract
{
    private IInteract[] objs;
    void Start()
    {
        objs = GetComponents<IInteract>().Where(c => c != this).ToArray();
    }

    
    public void Interact()
    {   
        
        foreach(IInteract obj in objs)
        {
            obj.Interact();
        }
    }
}
