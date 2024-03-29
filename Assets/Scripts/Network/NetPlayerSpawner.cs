using Mirror;
using UnityEngine;

public class NetPlayerSpawner : NetworkBehaviour, IPlayerSpawn
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform[] spawnPoints;
    [SyncVar] private int nextIndex;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if(isClientOnly)
        {

        }
    }

    public void OnCreateCharacter(NetworkConnectionToClient connection, PosMessage message)
    {
        Vector3 spawnPosition = spawnPoints[nextIndex].position;
        GameObject playerPrefab = playerPrefabs[nextIndex];
        nextIndex++;
        GameObject playerInstance = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(connection, playerInstance);
    }

    public void ActivatePlayerSpawn()
    {
        Vector3 spawnPosition = spawnPoints[nextIndex].position;
        PosMessage msg = new PosMessage() { vector2 = spawnPosition }; // нужно только чтобы сервер
                                                                       // запустил метод OnCreateCharecter, сам вектор бесполезен
        NetworkClient.Send(msg);
    }
}
