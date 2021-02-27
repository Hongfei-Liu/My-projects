using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVol : MonoBehaviour
{

    [SerializeField] private AudioMixer audioM;
    [SerializeField] private string nameParameter;
    private Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide = GetComponent<Slider>();
        float v = PlayerPrefs.GetFloat(nameParameter, 0); //0 = +0db
        SetVolume(v);

    }

    public void SetVolume(float vol)
    {
        //This function change thhe volume in the audiomixer
        audioM.SetFloat(nameParameter, vol);
        slide.value = vol;
        PlayerPrefs.SetFloat(nameParameter, vol);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
