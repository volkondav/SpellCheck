using Mirror;
using UnityEngine;

public class NetManager : NetworkManager
{
    [SerializeField] private NetPlayerSpawner netPlayerSpawner;
    //private bool playerSpawned;
    //private bool playerConnected;

    public override void Awake()
    {
        base.Awake();
        IPlayerSpawn netPlayerSpawner = GetComponent<NetPlayerSpawner>(); // Я захотел использовать интерфейс, чтобы попрактиковаться в архитектуре
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<PosMessage>(netPlayerSpawner.OnCreateCharacter); // обработчик сетевого сообщения:
                                                                      // указываем, какой struct должен прийти на сервер, чтобы выполнился свапн
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        //playerConnected = true;
    }

    // скорее всего не потребуется
    public override void Update()
    {
        base.Update();
        //if (Input.GetKeyDown(KeyCode.KeypadEnter) && !playerSpawned && playerConnected)
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            netPlayerSpawner.ActivatePlayerSpawn();
        }
    }
}

public struct PosMessage : NetworkMessage //наследуемся от интерфейса NetworkMessage, чтобы система поняла какие данные упаковывать
{
    public Vector2 vector2;
}