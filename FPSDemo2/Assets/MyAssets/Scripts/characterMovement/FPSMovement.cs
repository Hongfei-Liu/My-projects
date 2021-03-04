using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    private Transform characterTransform;
    public float speed;
    public float gravity;
    public float jumpHeight;
    public Rigidbody characterRigidbody;
    private bool IsGrounded;

    private void Start()
    {
        characterTransform = transform;
    }
    private void FixedUpdate()
    {
        if(IsGrounded)
        {
            var tmp_Horizontal = Input.GetAxis("Horizontal");
            var tmp_vertical = Input.GetAxis("Vertical");

            var tmp_CurrentDirection = new Vector3(x: tmp_Horizontal, y: 0, z: tmp_vertical);
            tmp_CurrentDirection = characterTransform.TransformDirection(tmp_CurrentDirection); // from local space to world space
            tmp_CurrentDirection *= speed;

            var tmp_CurrentVelocity = characterRigidbody.velocity;
            var tmp_VelocityChange = tmp_CurrentDirection - tmp_CurrentVelocity;
            tmp_CurrentVelocity.y = 0;

            characterRigidbody.AddForce(tmp_VelocityChange, ForceMode.VelocityChange);

            if(Input.GetButtonDown("Jump"))
            {
                characterRigidbody.velocity = new Vector3(tmp_CurrentVelocity.x, y: CalculateJumpHeightSpeed(), tmp_CurrentVelocity.z);
            }
        }
        else
        {
            characterRigidbody.AddForce(new Vector3(x: 0, y: -gravity * Time.deltaTime * 10, z: 0));
        }
       
    }

    private float CalculateJumpHeightSpeed()
    {
        return Mathf.Sqrt(f: 2* gravity * jumpHeight);

    }    

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }
}
