using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UDPReceiver : MonoBehaviour
{
    public int portNum = 22222;

    static UdpClient udpClient;
    Thread thread;

    public Text displayText;
    public Transform[] Joints;
    private int count;
    private int total_waypoints;
    static bool bButtonPressed = false;

    private static float t = 0.0f; //starting value for the Lerp
    private double[] Base = new double[] { 210.24, 220.24, 252.24, 250.24, 218.24, 208.24, 247.24, 256.24, 209.24, 235.24 };
    private double[] Shoulder = new double[] { 311.85, 286.85, 293.85, 293.85, 293.85, 302.85, 290.85, 296.85, 323.85, 316.85 };
    private double[] Elbow = new double[] { 339.98, 337.98, 340.98, 348.98, 332.98, 334.98, 322.98, 358.98, 346.98, 275.98 };
    private double[] Wrist1 = new double[] { 264.79, 298.79, 279.78, 261.79, 299.79, 273.79, 281.79, 297.79, 265.79, 294.79 };
    private double[] Wrist2 = new double[] { 248.63, 199.63, 225.63, 236.63, 211.63, 214.63, 220.63, 220.63, 231.63, 224.63 };
    private double[] Wrist3 = new double[] { 34.91, 35.72, 35.88, 35.83, 45.83, 54.70, 34.71, 54.71, 45.70, 35.69 };
    private double[] EndEffector = new double[] { 42.91, 44.72, 54.88, 48.83, 54.83, 34.70, 64.71, 54.71, 34.70, 54.69 };

    private static double[] theta = new double[7];
    private static double[] prev_theta = new double[7];

    void Start()
    {
        count = 0;
        total_waypoints = 10;

        theta[0] = Base[count];
        theta[1] = Shoulder[count];
        theta[2] = Elbow[count];
        theta[3] = Wrist1[count];
        theta[4] = Wrist2[count];
        theta[5] = Wrist3[count];
        theta[6] = EndEffector[count];

        udpClient = new UdpClient(portNum);
        thread = new Thread(new ThreadStart(ThreadProc));
        thread.Start();
    }

    void OnApplicationQuit()
    {
        thread.Abort();
    }

    private static void ThreadProc()
    {
        while (true)
        {
            IPEndPoint remoteEP = null;
            byte[] data = udpClient.Receive(ref remoteEP);
            string message = Encoding.ASCII.GetString(data);
            Debug.Log("UDP Received: " + message);
            if (message == "1")
            {
                bButtonPressed = true;
            }

        }
    }

    void Update()
    {
        if (bButtonPressed)
        {
            bButtonPressed = false;

            t = 0.0f;
            count++;

            if (count == 10)
                count = 0;

            theta[0] = Base[count];
            theta[1] = Shoulder[count];
            theta[2] = Elbow[count];
            theta[3] = Wrist1[count];
            theta[4] = Wrist2[count];
            theta[5] = Wrist3[count];

            if (count == 0)
            {
                prev_theta[0] = Base[total_waypoints - 1];
                prev_theta[1] = Shoulder[total_waypoints - 1];
                prev_theta[2] = Elbow[total_waypoints - 1];
                prev_theta[3] = Wrist1[total_waypoints - 1];
                prev_theta[4] = Wrist2[total_waypoints - 1];
                prev_theta[5] = Wrist3[total_waypoints - 1];
            }
            else
            {
                prev_theta[0] = Base[count - 1];
                prev_theta[1] = Shoulder[count - 1];
                prev_theta[2] = Elbow[count - 1];
                prev_theta[3] = Wrist1[count - 1];
                prev_theta[4] = Wrist2[count - 1];
                prev_theta[5] = Wrist3[count - 1];
            }

            Debug.Log(count);
        }

        //INTERPOLATION :
        Joints[0].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta[0], (float)theta[0], t));
        Joints[1].transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle((float)prev_theta[1], (float)theta[1], t), 0);
        Joints[2].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta[2], (float)theta[2], t));
        Joints[3].transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle((float)prev_theta[3], (float)theta[3], t), 0);
        Joints[4].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta[4], (float)theta[4], t));
        Joints[5].transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle((float)prev_theta[5], (float)theta[5], t), 0);
        Joints[6].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta[6], (float)theta[6], t));

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
            t = 1.0f;
    }
}
