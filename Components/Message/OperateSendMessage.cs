using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine;

public class OperateSendMessage : MonoBehaviour
{
    public static OperateSendMessage Instance;
    private TcpClient client;
    private NetworkStream stream;
    private byte[] buffer = new byte[1024];
    private string serverIP = "127.0.0.1"; // 服务器IP地址
    private int serverPort = 8888; // 服务器端口号

    void Start()
    {
        if(Instance == null) {
            Instance = this;
        }

        ConnectToServer();
    }

    private void ConnectToServer()
    {
        try
        {
            client = new TcpClient();
            client.Connect(serverIP, serverPort);
            stream = client.GetStream();

            // 开始接收服务器消息的线程
            Thread receiveThread = new Thread(ReceiveMessage_);
            receiveThread.Start();
        }
        catch (Exception e)
        {
            Debug.Log("无法连接到服务器：" + e.Message);
        }
    }

    private void ReceiveMessage_()
    {
        while (true)
        {
            try
            {
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                // 处理接收到的消息
                OperationReceiveData(ref message);
            }
            catch(ObjectDisposedException e){
                Debug.Log("断开连接：" + e.Message);
                break;
            }
            catch (Exception e)
            {
                Debug.Log("接收消息错误：" + e.Message);
            }
        }
    }

    private void OperationReceiveData(ref string receive_message) {
        ReceiveMessage.Instance.ReceiveMessage_(JsonConvert.DeserializeObject<MessageData>(receive_message));
    }

    public void SendMessage_(string send_message)
    {
        Debug.Log("打印发送出去的消息：" + send_message);
        byte[] data = Encoding.UTF8.GetBytes(send_message);
        stream.Write(data, 0, data.Length);
        stream.Flush();
    }

    private void OnDestroy()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }
}
