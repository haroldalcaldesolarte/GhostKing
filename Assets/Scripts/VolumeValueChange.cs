using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour
{

    public Slider mainSlider;

    private void Start()
    {
        mainSlider.value = GameManager.Instance.getVolume();
    }

    public void SetVolume(float vol)
    {
        GameManager.Instance.SetVolume(mainSlider.value);
    }
}
