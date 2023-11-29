using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class submitResultados : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Button guardarNombreButton;
    public Button submitButton;

    void Start()
    {
        guardarNombreButton.onClick.AddListener(GuardarNombre);
        submitButton.onClick.AddListener(EnviarResultados);
    }

    void GuardarNombre()
    {
        // Guardar el nombre en PlayerPrefs para recuperarlo después
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        PlayerPrefs.Save();

        // Obtener información del jugador
        var playerInfo = ControladorPuntos.Instance.GetPlayerInfo();

        // Guardar el nombre en el ControladorPuntos
        ControladorPuntos.Instance.SetPlayerName(playerNameInput.text);

        // Guardar información del jugador en la base de datos
        DBmongo.Instance.SaveScore(playerInfo);
    }

    void EnviarResultados()
    {
        // Guardar el nombre en PlayerPrefs para recuperarlo después
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        PlayerPrefs.Save();

        // Obtener información del jugador
        var playerInfo = ControladorPuntos.Instance.GetPlayerInfo();

        // Guardar información del jugador en la base de datos
        DBmongo.Instance.SaveScore(playerInfo);

        // Reiniciar el valor del nombre y los puntos
        ControladorPuntos.Instance.ResetPlayerInfo();

        // Redireccionar a la escena "menu"
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
}