using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesChava : MonoBehaviour
{
    public GameObject Player;
    public bool isMoving;
    public float horizontalMove;
    public float verticalMove;


    void Update()
    {

           
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
