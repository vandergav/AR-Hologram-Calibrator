using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KukaJointAngles : MonoBehaviour
{
    public Transform[] Joints;
    private int count;

    private double[] Base = new double[] { 210.24, 220.24, 252.24, 250.24, 218.24, 208.24, 247.24, 256.24, 209.24, 235.24 };
    private double[] Shoulder = new double[] { 311.85, 286.85, 293.85, 293.85, 293.85, 302.85, 290.85, 296.85, 323.85, 316.85 };
    private double[] Elbow = new double[] { 339.98, 337.98, 340.98, 348.98, 332.98, 334.98, 322.98, 358.98, 346.98, 275.98 };
    private double[] Wrist1 = new double[] { 264.79, 298.79, 279.78, 261.79, 299.79, 273.79, 281.79, 297.79, 265.79, 294.79 };
    private double[] Wrist2 = new double[] { 248.63, 199.63, 225.63, 236.63, 211.63, 214.63, 220.63, 220.63, 231.63, 224.63 };
    private double[] Wrist3 = new double[] { 34.91, 35.72, 35.88, 35.83, 45.83, 54.70, 34.71, 54.71, 45.70, 35.69 };
    private double[] EndEffector = new double[] { 42.91, 44.72, 54.88, 48.83, 54.83, 34.70, 64.71, 54.71, 34.70, 54.69 };

    private static double[] theta = new double[7];    //angle of the joints
    private static double[] prev_theta = new double[7];

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
        theta[5] = Wrist3[count];
        theta[6] = EndEffector[count];


        x = 0.07f;
        y = -0.456f;
        z = -0.214f;
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

        if (Input.GetKey(KeyCode.T))
        {
            theta[2] += 1.0;
            Debug.Log(theta[2]);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            theta[2] -= 1.0;
            Debug.Log(theta[2]);
        }


        if (Input.GetKey(KeyCode.A))
        {
            theta[3] += 1.0;
            Debug.Log(theta[3]);
        }
        if (Input.GetKey(KeyCode.S))
        {
            theta[3] -= 1.0;
            Debug.Log(theta[3]);
        }

        if (Input.GetKey(KeyCode.D))
        {
            theta[4] += 1.0;
            Debug.Log(theta[4]);
        }
        if (Input.GetKey(KeyCode.F))
        {
            theta[4] -= 1.0;
            Debug.Log(theta[4]);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            theta[5] += 1.0;
            Debug.Log(theta[5]);
        }
        if (Input.GetKey(KeyCode.X))
        {
            theta[5] -= 1.0;
            Debug.Log(theta[5]);
        }

        if (Input.GetKey(KeyCode.C))
        {
            theta[6] += 1.0;
            Debug.Log(theta[6]);
        }
        if (Input.GetKey(KeyCode.V))
        {
            theta[6] -= 1.0;
            Debug.Log(theta[6]);
        }
        

        if (Input.GetKey(KeyCode.F1))
        {
            Debug.Log(theta[0] + ", " + theta[1] + ", " + theta[2] + ", " + theta[3] + ", " + theta[4] + ", " + theta[5] + ", " + theta[6]);
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
