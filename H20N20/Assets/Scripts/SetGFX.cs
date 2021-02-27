using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SetGFX : MonoBehaviour
{
    public Text txtGFX; 
    public string[] GFXNames; 

    public void SetGfx(float val)
    {
        Slider slide = GetComponent<Slider>();
        int v = (int)Mathf.Floor(val);
        slide.value = val;
        QualitySettings.SetQualityLevel(v, true);
        txtGFX.text = GFXNames[v];
    }

    // Start is called before the first frame update
    void Start()
    {
        GFXNames = QualitySettings.names; 
        Slider slide = GetComponent<Slider>();
        float v = QualitySettings.GetQualityLevel(); 
        slide.value = v; 
        txtGFX.text = GFXNames[(int)v];
    }

    // Update is called once per frame
    void Update()
    {

    }
}
