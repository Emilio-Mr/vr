using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class UDPclient : MonoBehaviour
{
    public GameObject leftController, rightController;
    Socket s;
    IPEndPoint ipep;
    byte[] msg;


    // Start is called before the first frame update
    void Start()
    {
        s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        ipep = new IPEndPoint(IPAddress.Parse("192.168.1.40"), 8888);
    }

    // Update is called once per frame
    void Update()
    {
        leftController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        rightController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        byte[] buff = new byte[sizeof(float) * 6];
        Buffer.BlockCopy(BitConverter.GetBytes(leftController.transform.localPosition.x), 0, buff, 0 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(leftController.transform.localPosition.y), 0, buff, 1 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(leftController.transform.localPosition.z), 0, buff, 2 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(rightController.transform.localPosition.x), 0, buff, 3 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(rightController.transform.localPosition.y), 0, buff, 4 * sizeof(float), sizeof(float));
        Buffer.BlockCopy(BitConverter.GetBytes(rightController.transform.localPosition.z), 0, buff, 5 * sizeof(float), sizeof(float));

        s.SendTo(buff, ipep);
    }

    void Destroy()
    {
        s.Close();
    }
}
