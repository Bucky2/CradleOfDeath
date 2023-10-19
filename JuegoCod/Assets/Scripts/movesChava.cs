using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesChava : MonoBehaviour
{
    public GameObject Player;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;
    public bool isRunning;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;

            if (Input.GetButton("SKey"))
            {
                Player.GetComponent<Animator>().Play("walkBack");
            }
            else
            {
                if (isRunning)
                {
                    Player.GetComponent<Animator>().Play("run");
                }
                else
                {
                    Player.GetComponent<Animator>().Play("walk");
                }
            }
        }
        else
        {
            isMoving = false;
            Player.GetComponent<Animator>().Play("Idle");
        }

        if (!isRunning)
        {
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 3.8f;
        }
        else
        {
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 15.1f;
        }

        horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
        Player.transform.Rotate(0, horizontalMove, 0);
        Player.transform.Translate(0, 0, verticalMove);
    }
}

