using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider sensitivitySlider;

    public void SetMouseSensitivity(float sensitivity)
    {
        // sets sensitivity to the slider value
        FindObjectOfType<PlayerController>().mouseSensitivity = sensitivity;
    }
}

