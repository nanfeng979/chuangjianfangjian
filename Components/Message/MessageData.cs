public class MessageData
{
    public string type;
    public PlayerData playerData = new PlayerData();

}

public enum EMessageType {
    None,
    // 广播
    Broadcast,
    JoinRoom
}