using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //uI
using UnityEngine.Audio;    //Audio

public class AudioMixerColtroller : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;             //private ������ �͵��� �ν����� â���� ��������

    [SerializeField] private Slider MusicMasterSlider;          //UI Slider
    [SerializeField] private Slider MusicBGMSlider;
    [SerializeField] private Slider MusicSFXSlider;

    //�����̴� Minvalue �� 0.001

    private void Awake()
    {
        MusicMasterSlider.onValueChanged.AddListener(SetMasterVolume);      //UI slider�� ���� ���� �Ǿ��� ��� SetMasterVolume �Լ��� ȣ��.
        MusicBGMSlider.onValueChanged.AddListener(SetBGMVolume);
        MusicSFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);            //���������� 0 ~ 2 <- Mathf.Log10(volume) * 20
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);               //���������� 0 ~ 2 <- Mathf.Log10(volume) * 20
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);                //���������� 0 ~ 2 <- Mathf.Log10(volume) * 20
    }

}
