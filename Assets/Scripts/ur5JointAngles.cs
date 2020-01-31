using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ur5JointAngles : MonoBehaviour
{
	public Transform ur5_XYZ; //base
	public Transform[] ur5Joints; //inspector input
    public int[] jur5Orientation; //inspector input
    private static double[] theta_ur5 = new double[6];
    private static double[] prev_theta_ur5 = new double[6];

	private float x, y, z; //translation of base
	private float x_rot_ur5;

	private static float t = 0.0f;

	//public Transform[] KukaJoints;
    //public int[] jKukaOrientation;
	//private static double[] prev_theta_kuka;
    //private static double[] theta_kuka;

	public GameObject ur5;
    //public GameObject kukaR820;
	public GameObject ANGLES;
	public GameObject XYZ;

	public Text[] a_text;
	public Text[] xyz_text;
	public Text x_rot_text;

	public class UR_5RobotData
	{
		public float[] angle = new float[6];
	}

	/*public class KUKARobotData
    {
        public float[] angle = new float[7];
    }*/

	public void UR_5Parser(List<double> a)
	{
		Debug.Log("Starting Angles Received");

		for (int i = 0; i < ur5Joints.Length; i++)
		{ 
			prev_theta_ur5[i] = theta_ur5[i];
			theta_ur5[i] = a[i];
		}
	}

	public void ShowDataGUI(double[] theta_ur5) 
	{
		a_text = ANGLES.GetComponentsInChildren<Text> ();
		for (int i = 0; i < ur5Joints.Length; i++)
		{ 
			a_text[i].text = theta_ur5[i].ToString() + "°";
		}

		xyz_text = XYZ.GetComponentsInChildren<Text> ();
		xyz_text[0].text = ur5_XYZ.transform.localPosition.x.ToString();
		xyz_text[1].text = ur5_XYZ.transform.localPosition.y.ToString();
		xyz_text[2].text = ur5_XYZ.transform.localPosition.z.ToString();

		x_rot_text.text = x_rot_ur5.ToString() + "°";
	}

	public void TareXYZ ()
	{
		x = 0;
		y = 0;
		z = 0;
		ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
	}

	public void angleUpdate() 
		{
			for (int i = 0; i < ur5Joints.Length; i++)
			{
				switch (jur5Orientation[i])
				{
					case 0:
						ur5Joints[i].transform.localEulerAngles = new Vector3(Mathf.LerpAngle((float)prev_theta_ur5[i], (float)theta_ur5[i], t), 0, 0);
						break;
					case 1:
						ur5Joints[i].transform.localEulerAngles = new Vector3(0, Mathf.LerpAngle((float)prev_theta_ur5[i], (float)theta_ur5[i], t), 0);
						break;
					case 2:
						ur5Joints[i].transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle((float)prev_theta_ur5[i], (float)theta_ur5[i], t));
						break;
				}
			}
			t += 0.5f * Time.deltaTime;

			if (t > 1.0f)
			{
				t = 1.0f;
			}
		}

	void Update () 
	{
		//for xyz translation 
		if (Input.GetKey(KeyCode.Keypad4))
        {
            x += 0.005f;
            Debug.Log(x);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            x -= 0.005f;
            Debug.Log(x);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }

		if (Input.GetKey(KeyCode.Keypad5))
        {
            y += 0.005f;
            Debug.Log(y);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            y -= 0.005f;
            Debug.Log(y);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }

		if (Input.GetKey(KeyCode.Keypad6))
        {
            z += 0.005f;
            Debug.Log(z);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {
            z -= 0.005f;
            Debug.Log(z);
            ur5_XYZ.transform.localPosition = new Vector3(x, y, z);
        }

		//for x rotation
		if (Input.GetKey(KeyCode.KeypadPlus))
        {
            x_rot_ur5 += 0.1f;
            Debug.Log(x_rot_ur5);
            ur5_XYZ.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(0, x_rot_ur5, t), 0, 0);
        }
		if (Input.GetKey(KeyCode.KeypadMinus))
        {
            x_rot_ur5 -= 0.1f;
            Debug.Log(x_rot_ur5);
            ur5_XYZ.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(0, x_rot_ur5, t), 0, 0);
        }

		//for joint angle rotation
		if (Input.GetKey(KeyCode.Q))
        {
            theta_ur5[0] += 0.5;
            Debug.Log(theta_ur5[0]);
        }
        if (Input.GetKey(KeyCode.W))
        {
            theta_ur5[0] -= 0.5;
            Debug.Log(theta_ur5[0]);
        }

        if (Input.GetKey(KeyCode.E))
        {
            theta_ur5[1] += 0.5;
            Debug.Log(theta_ur5[1]);
        }
        if (Input.GetKey(KeyCode.R))
        {
           theta_ur5[1] -= 0.5;
            Debug.Log(theta_ur5[1]);
        }

        if (Input.GetKey(KeyCode.A))
        {
            theta_ur5[2] += 0.5;
            Debug.Log(theta_ur5[2]);
        }
        if (Input.GetKey(KeyCode.S))
        {
            theta_ur5[2] -= 0.5;
            Debug.Log(theta_ur5[2]);
        }

        if (Input.GetKey(KeyCode.D))
        {
            theta_ur5[3] += 0.5;
            Debug.Log(theta_ur5[3]);
        }
        if (Input.GetKey(KeyCode.F))
        {
            theta_ur5[3] -= 0.5;
            Debug.Log(theta_ur5[3]);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            theta_ur5[4] += 0.5;
            Debug.Log(theta_ur5[4]);
        }
        if (Input.GetKey(KeyCode.X))
        {
            theta_ur5[4] -= 0.5;
            Debug.Log(theta_ur5[4]);
        }

        if (Input.GetKey(KeyCode.C))
        {
            theta_ur5[5] += 0.5;
            Debug.Log(theta_ur5[5]);
        }
        if (Input.GetKey(KeyCode.V))
        {
            theta_ur5[5] -= 0.5;
            Debug.Log(theta_ur5[5]);
        }

        /*if (Input.GetKey(KeyCode.F1))
        {
            Debug.Log(theta_ur5[0] + ", " + theta_ur5[1] + ", " + theta_ur5[2] + ", " + theta_ur5[3] + ", " + theta_ur5[4]);
        }*/

		angleUpdate();
		ShowDataGUI(theta_ur5); 
	}
}	