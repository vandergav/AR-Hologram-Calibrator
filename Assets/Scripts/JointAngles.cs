using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointAngles : MonoBehaviour
{
    public Transform[] Joints;
    private int count;

    // Do not delete. Original Angles from UR5
    //private double[] Base        = new double[] { -31.74 , -39.90 , -40.70 , -73.42 , -73.37 , -29.49 , -72.61 , -72.52 , -21.26 , -53.11 };
    //private double[] Shoulder    = new double[] { -114.85, -95.38 , -88.04 , -95.28 , -95.42 , -103.51, -93.64 , -93.74 , -121.69, -115.35};
    //private double[] Elbow       = new double[] { -87.02 , -121.08, -96.70 , -97.26 , -126.61, -93.08 , -118.99, -70.88 , -58.74 , -86.32 };
    //private double[] Wrist1      = new double[] { -209.79, -152.13, -251.88, -225.74, -218.48, -172.41, -231.50, -244.78, -209.01, -249.78};
    //private double[] Wrist2      = new double[] { -53.37 , -24.12 , -27.99 , -28.17 , -44.45 , -30.77 , -30.77 , -30.80 , -28.39 , -51.81 };
    //private double[] Wrist3      = new double[] { 354.91 , 354.72 , 354.88 , 354.83 , 354.83 , 354.70 , 354.71 , 354.71 , 354.70 , 354.69 };

    //private double[] Base       = new double[] { 99.24, 100.24, 122.70, 115.18, 89.37, 90.49, 142.61, 142.52, 91.26, 120.11 };
    //private double[] Shoulder   = new double[] { 105.85, 87.38, 90.04, 90.04, 93.42, 103.51, 90.64, 93.74, 120.69, 112.35 };
    //private double[] Elbow      = new double[] { 180.98, 188.08, 192.70, 232.01, 217.61, 186.13, 207.99, 157.88, 152.74, 178.32 };
    //private double[] Wrist1     = new double[] { 221.79, 242.14, 232.88, 187.18, 155.48, 180.41, 227.50, 264.78, 219.01, 226.78 };
    //private double[] Wrist2     = new double[] { 135.63, 108.21, 111.99, 111.17, 103.45, 115.77, 115.77, 115.80, 113.39, 136.81 };
    //private double[] Wrist3     = new double[] { 354.91, 354.72, 354.88, 354.83, 354.83, 354.70, 354.71, 354.71, 354.70, 354.69 };
    //260.24,105.85,176.98,422.79,350.63,354.91

    private double[] Base       = new double[] { 259.24, 269.24, 301.24, 300.24, 268.24, 258.24, 297.24, 306.24, 259.24, 285.24 };
    private double[] Shoulder   = new double[] { 112.85,  86.85,  93.85,  93.85,  93.85, 102.85,  90.85,  96.85, 123.85, 116.85 };
    private double[] Elbow      = new double[] { 181.98, 187.98, 190.98, 218.98, 212.98, 184.98, 212.98, 158.98, 146.98, 175.98 };
    private double[] Wrist1     = new double[] { 208.79, 238.79, 219.78, 211.79, 149.79, 173.79, 221.79, 237.79, 205.79, 234.79 };
    private double[] Wrist2     = new double[] { 145.63,  99.63, 125.63, 136.63, 111.63, 114.63, 120.63, 120.63, 131.63, 124.63 };
    private double[] Wrist3     = new double[] { 354.91, 354.72, 354.88, 354.83, 354.83, 354.70, 354.71, 354.71, 354.70, 354.69 };
    
    private static double[] theta = new double[6];    //angle of the joints
    private static double[] prev_theta = new double[6];

    private float x, y, z;
    private int total_waypoints;
    private static float t = 0.0f; //starting value for the Lerp

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        total_waypoints = 10;

        theta[0] = Base[count];
        theta[1] = Shoulder[count];
        theta[2] = Elbow[count];
        theta[3] = Wrist1[count];
        theta[4] = Wrist2[count];

        //x = 0.07f;
        //y = -0.456f;
        //z = -0.214f;

		x = 0f;
        y = 0f;
        z = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y -= 0.1f;
            Debug.Log(y);
            Joints[0].transform.position = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            y += 0.1f;
            Debug.Log(y);
            Joints[0].transform.position = new Vector3(x, y, z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= 0.1f;
            Debug.Log(x);
            Joints[0].transform.position = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += 0.1f;
            Debug.Log(x);
            Joints[0].transform.position = new Vector3(x, y, z);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            theta[0] += 1.0;
            Debug.Log(theta[0]);
        }
        if (Input.GetKey(KeyCode.W))
        {
            theta[0] -= 1.0;
            Debug.Log(theta[0]);
        }

        if (Input.GetKey(KeyCode.E))
        {
            theta[1] += 1.0;
            Debug.Log(theta[1]);
        }
        if (Input.GetKey(KeyCode.R))
        {
            theta[1] -= 1.0;
            Debug.Log(theta[1]);
        }

        if (Input.GetKey(KeyCode.A))
        {
            theta[2] += 1.0;
            Debug.Log(theta[2]);
        }
        if (Input.GetKey(KeyCode.S))
        {
            theta[2] -= 1.0;
            Debug.Log(theta[2]);
        }

        if (Input.GetKey(KeyCode.D))
        {
            theta[3] += 1.0;
            Debug.Log(theta[3]);
        }
        if (Input.GetKey(KeyCode.F))
        {
            theta[3] -= 1.0;
            Debug.Log(theta[3]);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            theta[4] += 1.0;
            Debug.Log(theta[4]);
        }
        if (Input.GetKey(KeyCode.X))
        {
            theta[4] -= 1.0;
            Debug.Log(theta[4]);
        }

        if (Input.GetKey(KeyCode.C))
        {
            theta[5] += 1.0;
            Debug.Log(theta[5]);
        }
        if (Input.GetKey(KeyCode.V))
        {
            theta[5] -= 1.0;
            Debug.Log(theta[5]);
        }

        if (Input.GetKey(KeyCode.F1))
        {
            Debug.Log(theta[0] + ", " + theta[1] + ", " + theta[2] + ", " + theta[3] + ", " + theta[4]);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            t = 0.0f;
            count++;

            if (count == 10)
                count = 0;

            theta[0] = Base[count];
            theta[1] = Shoulder[count];
            theta[2] = Elbow[count];
            theta[3] = Wrist1[count];
            theta[4] = Wrist2[count];

            if (count == 0)
            {
                prev_theta[0] = Base[total_waypoints - 1];
                prev_theta[1] = Shoulder[total_waypoints - 1];
                prev_theta[2] = Elbow[total_waypoints - 1];
                prev_theta[3] = Wrist1[total_waypoints - 1];
                prev_theta[4] = Wrist2[total_waypoints - 1];
            }
            else
            {
                prev_theta[0] = Base[count-1];
                prev_theta[1] = Shoulder[count-1];
                prev_theta[2] = Elbow[count-1];
                prev_theta[3] = Wrist1[count-1];
                prev_theta[4] = Wrist2[count-1];
            }

            Debug.Log(count);
        }


        //if (!double.IsNaN(theta[0]))
        //    Joints[0].transform.localEulerAngles = new Vector3(0, 0, (float)theta[0]);
        //if (!double.IsNaN(theta[1]))
        //    Joints[1].transform.localEulerAngles = new Vector3((float)theta[1], 0, 0);
        //if (!double.IsNaN(theta[2]))
        //    Joints[2].transform.localEulerAngles = new Vector3((float)theta[2], 0, 0);
        //if (!double.IsNaN(theta[3]))
        //    Joints[3].transform.localEulerAngles = new Vector3((float)theta[3], 0, 0);
        //if (!double.IsNaN(theta[4]))
        //    Joints[4].transform.localEulerAngles = new Vector3((float)theta[4], 270, 270);
        //if (!double.IsNaN(theta[5]))
        //    Joints[5].transform.localEulerAngles = new Vector3(0, 0, (float)theta[5]);


        //INTERPOLATION :
        Joints[0].transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle((float)prev_theta[0], (float)theta[0], t), 0);
        Joints[1].transform.localEulerAngles = new Vector3(Mathf.LerpAngle((float)prev_theta[1], (float)theta[1], t), 0, 0);
        Joints[2].transform.localEulerAngles = new Vector3(Mathf.LerpAngle((float)prev_theta[2], (float)theta[2], t), 0, 0);
        Joints[3].transform.localEulerAngles = new Vector3(Mathf.LerpAngle((float)prev_theta[3], (float)theta[3], t), 0, 0);
        Joints[4].transform.localEulerAngles = new Vector3(Mathf.LerpAngle((float)prev_theta[4], (float)theta[4], t), 270, 270);
        Joints[5].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta[5], (float)theta[5], t));

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
            t = 1.0f;


    }
}
