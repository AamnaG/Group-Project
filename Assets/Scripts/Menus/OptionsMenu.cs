using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public PlayerController playerController;
    public void OnMouseSensitivityChange(float value)
    {
        // updates the sensitivity to the slider value
        playerController.mouseSensitivity = value;
    }

}

