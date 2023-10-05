using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesChava : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            isMoving = true;
            Player.GetComponent<Animator>().Play("walk");
            horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150; 
            verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4;
            Player.transform.Rotate(0, horizontalMove, 0);
            Player.transform.Translate(0, 0, verticalMove);

        }
        else
        {
            isMoving = false;
            Player.GetComponent<Animator>().Play("Idle");
        }
    }
}
