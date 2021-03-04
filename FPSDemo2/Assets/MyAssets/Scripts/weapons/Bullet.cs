using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.weapons
{
    public class Bullet : MonoBehaviour
    {
        public float bulletSpeed;
        private Transform bulletTransform;
        private Vector3 prevPosition;
        public GameObject ImpactPrefab;
        public ImpactAudioData ImpactAudioData;
        //public GameObject bulletHolePrefeb;


        private void Start()
        {
            bulletTransform = transform;
            prevPosition = bulletTransform.position;

        }

        private void Update()
        {

            //effects when bullet hits wall
            prevPosition = bulletTransform.position;
            bulletTransform.Translate(0, 0, bulletSpeed * Time.deltaTime);
            


            if (Physics.Raycast(prevPosition, (bulletTransform.position - prevPosition).normalized,
                out RaycastHit tmp_Hit, (bulletTransform.position - prevPosition).magnitude))
            {
                
                GameObject tmp_bulletEffect = Instantiate(ImpactPrefab, tmp_Hit.point,
                Quaternion.LookRotation(tmp_Hit.normal, Vector3.up));

                //GameObject tmp_bulletHole = Instantiate(bulletHolePrefeb, tmp_Hit.point,
                //Quaternion.LookRotation(tmp_Hit.normal, Vector3.forward));

                //Destroy(tmp_bulletHole, 3f);
                Destroy(tmp_bulletEffect, 3f);

                
                //Hit audio
                //Find which audio should be played by using tag
                var tmp_TagWithAudio = ImpactAudioData.impactTagsWithAudios.Find((tmp_AudioData) =>
                {
                     return tmp_AudioData.Tag.Equals(tmp_Hit.collider.tag);
                });
                if (tmp_TagWithAudio == null) return;
                int tmp_length = tmp_TagWithAudio.ImpactAudioClips.Count;
                AudioClip tmp_AudioClip = tmp_TagWithAudio.ImpactAudioClips[Random.Range(0, tmp_length)];
                AudioSource.PlayClipAtPoint(tmp_AudioClip, tmp_Hit.point);
            


            }

           



        }

    }
    
}
