using UnityEngine;

public class Key : MonoBehaviour, IInteract
{

    InteractableHelper interactableHelper;
    public MagnetField magnet;
    public bool flag = false;

    public void Interact ()
    {
        if (magnet == null)
        {
            Debug.LogWarning("На объекте Key не назначен MagnetField!");
            return;
        } 
        if (flag) TurnOff();
        else TurnOn();

        UpdateText();
    }

    void Start()
    {
        interactableHelper = GetComponent<InteractableHelper>();
    }

    public void TurnOn()
    {
        flag = true;
        magnet.TurnOn();
    }

    public void TurnOff()
    {
        flag = false;
        magnet.TurnOff();
    }

    void UpdateText()
    {
        interactableHelper.objectName = flag? "Ключ: ВКЛ" : "Ключ: ВЫКЛ";
    }

    // void Update()
    // {
    //     if (magnet == null)
    //     {
    //         Debug.LogWarning("На объекте Key не назначен MagnetField!");
    //         return;
    //     }

    //     if (flag) TurnOff();
    //     else TurnOn();

    //     UpdateText();
    // }
}