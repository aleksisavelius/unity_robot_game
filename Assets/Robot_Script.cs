using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Robot_Script : MonoBehaviour
{
    // set references
    public Rigidbody2D MyRigidbody2;
    public Animator RobotAnimator;

    // Robot movement variables
    public float MovementMultiplier;
    public float TurningMultiplier;
    private Vector3 RobotMovementDir;

    // robot action variables
    private bool RobotIsGripping;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Robot movement
        RobotMovement();

        // Robot gripping actions
        RobtGrip();

    }
    private void RobtGrip() {

        // set movement
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            // update variable
            //RobotIsGripping = true;

            // Set Animation
            //RobotAnimator.SetBool("RobotGripping", true);

            Debug.Log(" Gripping pressed");

            RobotAnimator.Play("Robot_GripAnimation");

        }
        else
        {

                
                // update variable
                RobotIsGripping = false;

                // Set Animation
                //RobotAnimator.SetBool("RobotGripping", false)

        }
        
    }

    private void RobotMovement()
    {
        // Update robot movement dir
        RobotMovementDir = transform.rotation.eulerAngles;

        // set movement for robot Fron and Back
        if (Input.GetKey(KeyCode.W) == true && RobotIsGripping == false)
        {
            // Move forward
            transform.Translate(Vector3.up * (MovementMultiplier * Time.deltaTime), Space.Self);

            // Set Animation
            RobotAnimator.SetBool("RobotIsMoving", true);
        }
        else if (Input.GetKey(KeyCode.S) == true && RobotIsGripping == false)
        {
            // Move backwards
            transform.Translate(Vector3.down * (MovementMultiplier * Time.deltaTime), Space.Self);

            // Set Animation
            RobotAnimator.SetBool("RobotIsMoving", true);

        }
        else
        {
            // Set Animation
            RobotAnimator.SetBool("RobotIsMoving", false);
        }


        // read rotation input
        if (Input.GetKey(KeyCode.A) == true && RobotIsGripping == false)
        {
            // Set rotation
            RobotMovementDir.z = TurningMultiplier * Time.deltaTime;
            transform.Rotate(RobotMovementDir);

            
        }
        else if (Input.GetKey(KeyCode.D) == true && RobotIsGripping == false)
        {
            RobotMovementDir.z = TurningMultiplier * (-1) * Time.deltaTime;
            transform.Rotate(RobotMovementDir);
        }
        

    }
}
