using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class guardar : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public Button guardarNombre;

    void Start()
    {
        guardarNombre.onClick.AddListener(SubmitName);
    }

    void SubmitName()
    {
        PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        PlayerPrefs.Save();

        // Obtener informaci�n del jugador
        var playerInfo = ControladorPuntos.Instance.GetPlayerInfo();

        // Guardar el nombre en el ControladorPuntos
        ControladorPuntos.Instance.SetPlayerName(playerNameInput.text); // Corregir aqu�

        // Guardar informaci�n del jugador en la base de datos
        DBmongo.Instance.SaveScore(playerInfo);
    }
}