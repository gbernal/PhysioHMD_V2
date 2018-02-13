using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class UdpSend : MonoBehaviour {
    private string IP;
    public int port;

    // "connection" things
    IPEndPoint remoteEndPoint;
    UdpClient client;

    // Use this for initialization
    void Start () {

        IP = "localhost"; //get your local ip address
        port = 8051; //some un-used port


        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

        // status
        print("Sending to " + IP + " : " + port);

    }
	
	// Update is called once per frame
	void Update () {
        // string message to send
        String msg = "hello";
        sendString(msg);

    }

    private void sendString(string msg)
    {
        try {


            // encode string to UTF8-coded bytes
            byte[] data = Encoding.UTF8.GetBytes(msg);

            // send the data
            client.Send(data, data.Length, remoteEndPoint);

        } catch (Exception err)
        {
            print(err.ToString());
        }
    }
}
