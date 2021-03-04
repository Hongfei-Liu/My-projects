using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerFootStepLisenner : MonoBehaviour
{
    public FootStepAudio FootStepAudio;
    public AudioSource FootStepAudioSource;

    private CharacterController characterController;
    public Transform footStepTransform;

    private float nextPlayTime;
    public LayerMask layerMask;

    public enum State 
    {
        Idle,
        Walk,
        Springting,
        Crouch,
        Other
    }

    public State characterState;


    //1-- character movement or large behavior
    //2-- use Physic API to check character's movemnet

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if(characterController.isGrounded)
        {
            if(characterController.velocity.normalized.magnitude >= 0.1f)//character is moving
            {
                nextPlayTime += Time.deltaTime;

                if(characterController.velocity.magnitude >= 4.1f)
                {
                    characterState = State.Springting;
                }
                else if(characterController.velocity.magnitude >= 2.1f && characterController.velocity.magnitude < 4.1f)
                {
                    characterState = State.Walk;
                }
                else if(characterController.velocity.magnitude >= 0.1f && characterController.velocity.magnitude <= 2f)
                {
                    characterState = State.Crouch;
                }
                else
                {
                    characterState = State.Idle;
                }


                //track foot step
                bool tmp_IsHit = Physics.Linecast(footStepTransform.position,
                    Vector3.down * (characterController.height / 2 + characterController.skinWidth + characterController.center.y), 
                    out RaycastHit hitInfo, layerMask);

                if(tmp_IsHit)
                {
                    foreach(var tmp_AudioElement in FootStepAudio.FootstepAudios)
                    {
                        if (hitInfo.collider.CompareTag(tmp_AudioElement.Tag))
                        {
                            float tmp_Delay = 0;
                            switch (characterState)
                            {
                                case State.Idle:
                                    tmp_Delay = float.MaxValue;
                                    break;
                                case State.Walk:
                                    tmp_Delay = tmp_AudioElement.Delay;
                                    break;
                                case State.Springting:
                                    tmp_Delay = tmp_AudioElement.SprintingDelay;
                                    break;
                                case State.Crouch:
                                    tmp_Delay = tmp_AudioElement.CrouchingDelay;
                                    break;
                                   
                            }


                            // time delay of each foot step
                            if(nextPlayTime >= tmp_Delay)
                            {
                                int tmp_AudioCount = tmp_AudioElement.AudioClips.Count;
                                int tmp_AduioIndex = UnityEngine.Random.Range(0, tmp_AudioCount);
                                AudioClip tmp_FootStepAudioClip = tmp_AudioElement.AudioClips[tmp_AduioIndex];
                                FootStepAudioSource.clip = tmp_FootStepAudioClip;
                                FootStepAudioSource.Play();
                                nextPlayTime = 0;
                                break;
                            }

                           
                        }
                    }
                   
                }
            }
        }
    }
}
