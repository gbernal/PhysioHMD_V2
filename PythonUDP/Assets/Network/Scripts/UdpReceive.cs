using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class UdpReceive : MonoBehaviour {

    // read Thread
    Thread readThread;

    // udpclient object
    UdpClient client;
    
    // port number
    public int port = 6789;

    // storage variable for the UDP packets
    public string lastReceivedPacket = "";
    string previousPacket = "";

    bool messageChanged = false;



    void Start()
    {
        // create a thread for reading UDP messages
        readThread = new Thread(new ThreadStart(ReceiveData));
        readThread.IsBackground = true;
        readThread.Start();
        
    }


    void Update()
    {

        //code for creating the 4 boxes 
   
        //if the message has changed and the user is over a box with the mouse cursor
        // then modify the 4 boxes with the new coordiantes and scale
        if (messageChanged)
        {
        
            parseData(lastReceivedPacket);
            messageChanged = false;
        }


    }

    // Unity Application Quit Function
    void OnApplicationQuit()
    {
        stopThread();
    }

    // Stop reading UDP messages
    private void stopThread()
    {
        if (readThread.IsAlive)
        {
            readThread.Abort();
        }
        client.Close();
    }

    // receive thread function
    private void ReceiveData()
    {
        client = new UdpClient(port);

        while (true)
        {
            try
            {
                // receive bytes
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);

                // decode UTF8-coded bytes to text format
                string text = Encoding.UTF8.GetString(data);

                // show received message
                print(">> " + text);

                // store new message as latest message
                previousPacket = lastReceivedPacket;
                lastReceivedPacket = text;
                if (lastReceivedPacket != previousPacket)
                    messageChanged = true;



            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    //parse the string message from Grasshopper into coordiantes and dimensions for the 4 boxes
    private void parseData(string msg)
    {

        try
        {
            string[] data = msg.Split(';');
            for (int i = 0; i < 4; i++)
            {
                //example code was sending transformation data ie scale vector and coordinate 
                //TODO change this to my type of data
                string[] strScales = data[i].Split(',');
                string[] strCoords = data[i + 4].Split(',');
            }
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }
}
