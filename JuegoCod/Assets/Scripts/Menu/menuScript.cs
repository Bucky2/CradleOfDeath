using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
        public void irReglas(string NombreReglas)
    {
        SceneManager.LoadScene(NombreReglas);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Aqui se cierra el juego");
    }
}
