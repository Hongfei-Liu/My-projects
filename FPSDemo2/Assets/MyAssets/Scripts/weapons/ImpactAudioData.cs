using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.weapons
{
    [CreateAssetMenu(menuName ="FPS/Impact audio Data")]
    public class ImpactAudioData:ScriptableObject
    {
        public List<ImpactTagsWithAudio> impactTagsWithAudios;
    }

    [System.Serializable]
    public class ImpactTagsWithAudio
    {
        public string Tag;
        public List<AudioClip> ImpactAudioClips;
    }

}
