public class PlayerData
{
    public string playerStatus;
    public string playerName;
}

public enum PlayerStatus
{
    None,
    JoinRoom,
    WaitToSit,
    Ready,
    Play,
}