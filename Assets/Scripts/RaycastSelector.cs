using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSelector : MonoBehaviour
{
    
    public Text text;
    public float rayDistance = 5f;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.Log("Смотрим");
        if (Physics.Raycast(ray, out hit, rayDistance))
        {   
            Debug.Log("Получаем контакт");
            InteractableHelper obj = hit.collider.GetComponent<InteractableHelper>();

            Debug.Log($"Есть ли объект? ---> {obj == null}");

            if (obj != null)
            {   
                Debug.Log($"Искомый объект: -----> {obj.objectName}");
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
