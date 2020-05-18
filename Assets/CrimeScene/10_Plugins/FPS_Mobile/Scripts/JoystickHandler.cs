using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JoystickHandler : MonoBehaviour
{

	public FixedJoystick moveJoystick;
	//public FixedButton jumpButton;
	public FixedTouchField TouchField;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var fps = GetComponent<RigidbodyFirstPersonController>();

        fps.runAxis = moveJoystick.inputVector;
        fps.mouseLook.LookAxis = TouchField.TouchDist;
    }
}
