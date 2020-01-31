using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class AngleInputReceiver : MonoBehaviour
{
	public InputField inputfieldOne;
	public InputField inputfieldTwo;
	public InputField inputfieldThree;
	public InputField inputfieldFour;
	public InputField inputfieldFive;
	public InputField inputfieldSix;

	private double angleOne;
	private double angleTwo;
	private double angleThree;
	private double angleFour;
	private double angleFive;
	private double angleSix;

	private List<double> UR5_angles = new List<double>(6);
	public GameObject ur5JointAnglesGO; //from ur5JointAngles.cs; add in inspector
	ur5JointAngles ur5JointAngles_script;

	public void GetAngles() 
	{
		double angleOne = Convert.ToDouble(inputfieldOne.text);
		double angleTwo = Convert.ToDouble(inputfieldTwo.text);
		double angleThree = Convert.ToDouble(inputfieldThree.text);
		double angleFour = Convert.ToDouble(inputfieldFour.text);
		double angleFive = Convert.ToDouble(inputfieldFive.text);
		double angleSix = Convert.ToDouble(inputfieldSix.text);

		UR5_angles.Add(angleOne);
		UR5_angles.Add(angleTwo);
		UR5_angles.Add(angleThree);
		UR5_angles.Add(angleFour);
		UR5_angles.Add(angleFive);
		UR5_angles.Add(angleSix);

		foreach (double i in UR5_angles)
		{
			Debug.Log(i);
	    }

		ur5JointAngles_script = ur5JointAnglesGO.GetComponent<ur5JointAngles>(); //get script attached to component to use its method
		ur5JointAngles_script.UR_5Parser(UR5_angles); //pass in native variable into that method
	}

}

