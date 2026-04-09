using UnityEngine;
using UnityEngine.PlayerLoop;

public class InteractableHelper : MonoBehaviour
{
     public string objectName = "Неизвестный объект";
     public bool grab = false;
     public bool socket = false;

     public GameObject Grab()
     {
          return gameObject;
     }

     public void Socket(GameObject obj)
     {
          obj.transform.position = gameObject.transform.position;
          obj.transform.rotation = gameObject.transform.rotation;
          obj.SetActive(true);
          //Instantiate(obj, gameObject.transform.position, gameObject.transform.rotation);
     }
}
