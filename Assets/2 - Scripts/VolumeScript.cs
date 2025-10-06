using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider BGMSlider;

    private void Update()
    {
        masterMixer.SetFloat("MasterVolume", masterSlider.value);
        masterMixer.SetFloat("SFXVolume", SFXSlider.value);
        masterMixer.SetFloat("BGMVolume", BGMSlider.value);
    }
}
