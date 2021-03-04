using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterControllerMovement : MonoBehaviour
{

    private CharacterController characterController;
    public Animator characterAnimator;

    private Vector3 movementDirection;
    private Transform characterTransform;
    private float velocity;

    private bool IsCrouching;

    private float originHeight;
    public float SprintingSpeed;
    public float WalkMoveSpeed;
    public float SprintingSpeedWhenCrouching;
    public float WalkSpeedWhenCrouching;
    public float Gravity = 9.8f;
    public float jumpHeight;
    public float crouchHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //characterAnimator = GetComponentInChildren<Animator>();
        characterTransform = transform;
        
        originHeight = characterController.height;
    }

    // Update is called once per frame
    void Update()
    {

       float tmp_CurrentSpeed = WalkMoveSpeed;
       if (characterController.isGrounded)
       {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_Vertical = Input.GetAxis("Vertical");
            movementDirection = characterTransform.TransformDirection(new Vector3(x: tmp_Horizontal, y: 0, z: tmp_Vertical));

            if (Input.GetButtonDown("Jump"))
            {
                movementDirection.y = jumpHeight;
            }

            //if(Input.GetKey(KeyCode.LeftShift))
            //{
            //    tmp_CurrentSpeed = SprintingSpeed;
            //}
            //else
            //{
            //    tmp_CurrentSpeed = WalkMoveSpeed;
            //}

            if(Input.GetKeyDown(KeyCode.C))
            {
                var tmp_CurrentHeight = IsCrouching ? originHeight : crouchHeight;
                StartCoroutine(DoCrouch(tmp_CurrentHeight));
                IsCrouching = !IsCrouching;
            }
            
            if(IsCrouching)
            {
                tmp_CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeedWhenCrouching : WalkSpeedWhenCrouching;
            }
            else
            {
                tmp_CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? SprintingSpeed : WalkMoveSpeed;
            }

            var tmp_Velocity = characterController.velocity;
            tmp_Velocity.y = 0;
            velocity = tmp_Velocity.magnitude;
            characterAnimator.SetFloat("Velocity", velocity,0.25f,Time.deltaTime);

            //velocity = characterController.velocity.magnitude;//length of velocity
            //characterAnimator.SetFloat("Velocity",velocity);
            
           
            //characterController.SimpleMove(speed: movementDirection * MoveSpeed * Time.deltaTime);
       }
        movementDirection.y -= Gravity * Time.deltaTime;
        characterController.Move(motion: tmp_CurrentSpeed * movementDirection * Time.deltaTime);

    }

    private IEnumerator DoCrouch(float _target)
    {
        while(Mathf.Abs(f:characterController.height -_target)> 0.1f)
        {
            float tmp_CurrentHeight = 0;
            yield return null;
            characterController.height = 
                Mathf.SmoothDamp(current: characterController.height, target: _target, 
                currentVelocity: ref tmp_CurrentHeight, smoothTime: Time.deltaTime * 5);
        }
    }

    internal void SetUpAnimator(Animator _animator)
    {
        characterAnimator = _animator;
    }
}
