using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFinal : MonoBehaviour
{
        public Canvas canvasFin;

    public void terminarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }

    private void OnTriggerEnter(Collider other)
    {
      

        if (other.CompareTag("Player"))
        {
            if (canvasFin != null)
            {
                canvasFin.gameObject.SetActive(true);

                // Pausar el juego al activar el Canvas
                Time.timeScale = 0f;
            }
        }
    }
    

}
