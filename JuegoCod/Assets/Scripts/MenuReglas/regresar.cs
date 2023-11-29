using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class regresar : MonoBehaviour
{
        public void regresarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
}
