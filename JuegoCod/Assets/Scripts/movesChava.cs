using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesChava : MonoBehaviour
{
    public GameObject Player;
    public bool isMoving;
    public bool isRunning;
    public float moveSpeed = 3.8f;
    public float runSpeed = 15.1f;
    public float rotationSpeed = 150f;

    void Update()
    {

        if (Pistola.isAiming == false) {

        float horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        float verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * (isRunning ? runSpeed : moveSpeed);

        Player.transform.Rotate(0, horizontalMove, 0);
        Player.transform.Translate(0, 0, verticalMove);

        isMoving = (Mathf.Abs(horizontalMove) > 0 || Mathf.Abs(verticalMove) > 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isMoving)
        {
            if (Input.GetButton("SKey"))
            {
                Player.GetComponent<Animator>().Play("walkBack");
            }
            else
            {
                Player.GetComponent<Animator>().Play(isRunning ? "run" : "walk");
            }
        }
        else
        {
            Player.GetComponent<Animator>().Play("Idle");
        }
     }
  }
}
