using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotSelection : MonoBehaviour
{

	public TMP_Dropdown dropdownRoboselc;
    public GameObject ur5;
    public GameObject kukaR820;
	public GameObject img_ur5;
	public GameObject img_kukaR820;
	public GameObject inputAngles_ur5;
	public GameObject inputAngles_kukaR820;

    // Update is called once per frame
    void Update()
    {
        switch(dropdownRoboselc.value)
        {
            case 0:
                ur5.SetActive(false);
                kukaR820.SetActive(false);
				img_ur5.SetActive(false);
                img_kukaR820.SetActive(false);
				inputAngles_ur5.SetActive(false);
				inputAngles_kukaR820.SetActive(false);
                
                break;
            case 1:
                ur5.SetActive(true);
                kukaR820.SetActive(false);
                img_ur5.SetActive(true);
                img_kukaR820.SetActive(false);
				inputAngles_ur5.SetActive(true);
				inputAngles_kukaR820.SetActive(false);

                break;
            case 2:
                kukaR820.SetActive(true);
                ur5.SetActive(false);
				img_kukaR820.SetActive(true);
                img_ur5.SetActive(false);
				inputAngles_ur5.SetActive(false);
				inputAngles_kukaR820.SetActive(true);

                break;


        }  
    }
}
