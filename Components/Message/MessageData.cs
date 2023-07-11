public class MessageData
{
    public string messageType;
    public PlayerData playerData = new PlayerData();

}

public enum EMessageType {
    None,
    // 广播
    Broadcast,
    JoinRoom
}