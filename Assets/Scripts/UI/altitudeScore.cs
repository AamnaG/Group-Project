using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class altitudeScore : MonoBehaviour
{
    public Transform player; // put player game object in this in the editor
    public TextMeshProUGUI altitudeText; // altitude text element on the scene

    void Update()
    {
        if (player != null && altitudeText != null)
        {
            float altitude = player.position.y; // sets text to the players height
            altitudeText.text = "Altitude: " + altitude.ToString("F2") + " meters"; // puts the altitude into text
        }
    }
}
