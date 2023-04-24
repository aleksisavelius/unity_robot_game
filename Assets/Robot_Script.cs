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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Robot movement
        RobotMovement();

        

    }
    private void RobotMovement()
    {


        // Update robot movement dir
        RobotMovementDir = transform.rotation.eulerAngles;

        // set movement for robot Fron and Back
        if (Input.GetKey(KeyCode.W) == true)
        {
            // Move forward
            transform.Translate(Vector3.up * MovementMultiplier , Space.Self);
        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            // Move backwards
            transform.Translate(Vector3.down * MovementMultiplier, Space.Self);
        }

        // read rotation input
        if (Input.GetKey(KeyCode.A) == true)
        {
            RobotMovementDir.z = TurningMultiplier;
            transform.Rotate(RobotMovementDir);
        }
        else if (Input.GetKey(KeyCode.D) == true)
        {
            RobotMovementDir.z = TurningMultiplier * (-1);
            transform.Rotate(RobotMovementDir);
        }
        

    }
}
