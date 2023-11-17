using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public static bool isAiming = false;
    public GameObject Player;
    public float horizontalMove;

    public bool isFiring = false;
    public float fireRate = 0.5f;

    // Referencia al script disparador
    private disparador DisparadorScript;

    // Asigna la referencia al script disparador en el inicio
    void Start()
    {
        DisparadorScript = FindObjectOfType<disparador>();
        if (DisparadorScript == null)
        {
            Debug.LogError("El script disparador no está asignado en Pistola.cs");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            Player.GetComponent<Animator>().Play("aim");
        }
        if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }

        if (isAiming == true)
        {
            if (Input.GetButton("Horizontal"))
            {
                horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                Player.transform.Rotate(0, horizontalMove, 0);
            }
            if (Input.GetMouseButtonDown(0) && isFiring == false)
            {
                isFiring = true;
                StartCoroutine(FiringWeapon());
            }
        }
    }

    IEnumerator FiringWeapon()
    {
        if (DisparadorScript != null)
        {
            DisparadorScript.Disparar();
        }
        else
        {
            // Utiliza print en lugar de Debug.LogError para imprimir mensajes en la consola de Unity
            print("El script disparador no está asignado en Pistola.cs");
        }

        Player.GetComponent<Animator>().Play("fire");
        yield return new WaitForSeconds(fireRate);
        Player.GetComponent<Animator>().Play("aim");
        isFiring = false;
    }

}