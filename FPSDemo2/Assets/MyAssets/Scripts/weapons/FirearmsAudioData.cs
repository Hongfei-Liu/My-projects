using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.weapons
{
    [CreateAssetMenu(menuName ="FPS/Firearms Audio Data")]
    public class FirearmsAudioData: ScriptableObject //序列化class并保存到Unity Asset中
    {
        public AudioClip ShootingAudio;
        public AudioClip ReloadLeft;
        public AudioClip ReloadOutOf;
    }
}
