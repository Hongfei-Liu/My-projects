using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="FPS/FootStep Audio Data")]
public class FootStepAudio : ScriptableObject
{
    public List<FootstepAudio> FootstepAudios = new List<FootstepAudio>();
}

[System.Serializable]
public class FootstepAudio
{
    public string Tag;
    public List<AudioClip> AudioClips = new List<AudioClip>();
    public float Delay;
    public float SprintingDelay;
    public float CrouchingDelay;
}

