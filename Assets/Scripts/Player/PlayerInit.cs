using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInit : MonoBehaviour
{
    public InputActionAsset PlayerAsset;

    public GameObject PlayerPrebuf;
    private Transform SpawnPosition;
    

    void Start()
    {
        SpawnPosition = GetComponent<Transform>();
        GameObject player = Instantiate(PlayerPrebuf, SpawnPosition.position, SpawnPosition.rotation);
    
        MovePlayer movePlayer = player.GetComponent<MovePlayer>();
        movePlayer.SetupInputAsset(PlayerAsset);

        MouseLook mouseLook = player.GetComponent<MouseLook>();
        mouseLook.SetupInputAsset(PlayerAsset);
    }


}
