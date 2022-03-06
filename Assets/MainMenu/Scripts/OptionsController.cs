using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private void Start()
    {
        AudioListener.volume = slider.value;
    }
    public void VolumeSliderChanged(Slider slider)
    {
        float volume = slider.value;
        AudioListener.volume = volume;
    }
}
