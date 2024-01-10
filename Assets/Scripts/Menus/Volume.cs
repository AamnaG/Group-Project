using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();

        volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", backgroundMusic.volume);
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float volume)
    {
        backgroundMusic.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
