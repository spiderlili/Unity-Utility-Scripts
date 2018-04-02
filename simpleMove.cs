using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMove : MonoBehaviour {

    public KeyCode upKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode downKey = KeyCode.S;

    public KeyCode upKeyAlt = KeyCode.UpArrow;
    public KeyCode leftKeyAlt = KeyCode.LeftArrow;
    public KeyCode rightKeyAlt = KeyCode.RightArrow;
    public KeyCode downKeyAlt = KeyCode.DownArrow;

    float rotateSpeed = 1;
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt))
        {
            //rotate the game board forwards
            transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt))
        {
            //rotate the game board forwards
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(upKey) || Input.GetKey(upKeyAlt))
        {
            //rotate the game board forwards
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(downKey) || Input.GetKey(downKeyAlt))
        {
            //rotate the game board forwards
            transform.Rotate(Vector3.right, rotateSpeed * Time.deltaTime);
        }
    }
}
