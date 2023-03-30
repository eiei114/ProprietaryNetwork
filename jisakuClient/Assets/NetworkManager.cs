using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);

        NetworkConfig.InitNetwork();
        NetworkConfig.ConnectToServer();
    }

    private void OnApplicationQuit()
    {
        NetworkConfig.DisconnectFromServer();
    }
}
