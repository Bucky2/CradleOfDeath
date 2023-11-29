using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuGameOver : MonoBehaviour
{
    public void RestartLevel()
    {
         // Reiniciar puntosNivel a 0
        ControladorPuntos.Instance.puntosNivel = 0;

        Time.timeScale = 1f;
        // Obtener el índice del nivel actual
        int levelSceneIndex = 1;
        SceneManager.LoadScene(levelSceneIndex);

        // Cargar el nivel actual
        
    }
        public void salirMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
        public void Terminar(string NombreNivel)
    {
        // Guardar la puntuación antes de cambiar de nivel
        PlayerPrefs.SetInt("PuntosAcumulados", ControladorPuntos.Instance.puntosNivel);
        
        // Cargar el siguiente nivel
        SceneManager.LoadScene(NombreNivel);
        Time.timeScale = 1f;
    }

}
