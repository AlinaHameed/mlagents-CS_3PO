using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 200f;
	float moveSpeed = 25f;
	Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
	}

	void CheckKey()
	{
		// Walk animation control
    if (Input.GetKey(KeyCode.W))
    {
        anim.SetBool("Walk_Anim", true); // Set walk animation to true when W key is pressed
        MoveForward(); // Move the robot forward
    }
    else if (Input.GetKeyUp(KeyCode.W))
    {
        anim.SetBool("Walk_Anim", false); // Set walk animation to false when W key is released
    }
    // Backwards movement control
    else if (Input.GetKey(KeyCode.S))
    {
        anim.SetBool("Walk_Anim", true); // Set walk animation to true when S key is pressed
        MoveBackward(); // Move the robot backward
    }
    else if (Input.GetKeyUp(KeyCode.S))
    {
        anim.SetBool("Walk_Anim", false); // Set walk animation to false when S key is released
    }


        // Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            rot.y -= rotSpeed * Time.deltaTime; // Rotate left when A key is pressed
        }

        // Rotate Right
        if (Input.GetKey(KeyCode.D))
        {
            rot.y += rotSpeed * Time.deltaTime; // Rotate right when D key is pressed
        }

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
				MoveForward();
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

	    void MoveForward()
    {
        Vector3 forwardDirection = transform.forward; // Get the forward direction of the robot
        transform.position += forwardDirection * moveSpeed * Time.deltaTime; // Move the robot forward
    }

	void MoveBackward()
    {
        Vector3 backwardDirection = -transform.forward; // Get the backward direction of the robot
        transform.position += backwardDirection * moveSpeed * Time.deltaTime; // Move the robot backward
		
	}

}
