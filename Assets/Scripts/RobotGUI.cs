using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotGUI : MonoBehaviour
{
    public Button moveButton;
    public Text displayText;
    public Transform[] Joints;
    private int count;
    private static float t = 0.0f; //starting value for the Lerp
    private bool bButtonPressed = false;
    private int total_waypoints;

    private double[] Base = new double[] { 259.24, 269.24, 301.24, 300.24, 268.24, 258.24, 297.24, 306.24, 259.24, 285.24 };
    private double[] Shoulder = new double[] { 112.85, 86.85, 93.85, 93.85, 93.85, 102.85, 90.85, 96.85, 123.85, 116.85 };
    private double[] Elbow = new double[] { 181.98, 187.98, 190.98, 218.98, 212.98, 184.98, 212.98, 158.98, 146.98, 175.98 };
    private double[] Wrist1 = new double[] { 208.79, 238.79, 219.78, 211.79, 149.79, 173.79, 221.79, 237.79, 205.79, 234.79 };
    private double[] Wrist2 = new double[] { 145.63, 99.63, 125.63, 136.63, 111.63, 114.63, 120.63, 120.63, 131.63, 124.63 };
    private double[] Wrist3 = new double[] { 354.91, 354.72, 354.88, 354.83, 354.83, 354.70, 354.71, 354.71, 354.70, 354.69 };


    private static double[] theta = new double[6];
    private static double[] prev_theta = new double[6];

    // Start is called before the first frame update
    void Start()
    {
        moveButton.onClick.AddListener(TaskButtonClicked);

        count = 0;
        total_waypoints = 10;

        theta[0] = prev_theta[0] = Base[count];
        theta[1] = prev_theta[1] = Shoulder[count];
        theta[2] = prev_theta[2] = Elbow[count];
        theta[3] = prev_theta[3] = Wrist1[count];
        theta[4] = prev_theta[4] = Wrist2[count];

    }

    void TaskButtonClicked()
    {
        displayText.text = "Moving to Waypoint " + (count+1);
        bButtonPressed = true;
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
                prev_theta[0] = Base[count - 1];
                prev_theta[1] = Shoulder[count - 1];
                prev_theta[2] = Elbow[count - 1];
                prev_theta[3] = Wrist1[count - 1];
                prev_theta[4] = Wrist2[count - 1];
            }

            Debug.Log(count);
        }

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
