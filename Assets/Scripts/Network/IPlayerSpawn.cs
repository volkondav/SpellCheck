using Mirror;

interface IPlayerSpawn
{
    public void OnCreateCharacter(NetworkConnectionToClient connection, PosMessage message);
    public void ActivatePlayerSpawn();
}
