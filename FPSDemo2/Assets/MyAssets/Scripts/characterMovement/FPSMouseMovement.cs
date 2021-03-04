using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseMovement : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField]private Transform characterTransform;
    private Vector3 cameraRotation;
    public float MouseSensitivity;
    public Vector2 MaxMinAngle;

    //Recoil functions
    public AnimationCurve RecoilCurve;
    public Vector2 RecoilRange;

    public float recoilFadeOutTime = 0.3f;
    private float currentRecoilTime;
    private Vector2 currentRecoil;

    //Camera Spring
    private CameraSpring cameraSpring;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = transform;
        cameraSpring = GetComponentInChildren<CameraSpring>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotating behavior
        var tmp_MouseX = Input.GetAxis("Mouse X");
        var tmp_MouseY = Input.GetAxis("Mouse Y");
        //control movement
        cameraRotation.y += tmp_MouseX * MouseSensitivity;
        cameraRotation.x -= tmp_MouseY * MouseSensitivity;

        //recoil movement
        CalculateRecoilOffset();
        cameraRotation.y += currentRecoil.y;
        cameraRotation.x -= currentRecoil.x;
       
        
        //limation of angle

        cameraRotation.x = Mathf.Clamp(value: cameraRotation.x, min: MaxMinAngle.x, max: MaxMinAngle.y);
        cameraTransform.rotation = Quaternion.Euler(x: cameraRotation.x, y: cameraRotation.y, z: 0);
        characterTransform.rotation = Quaternion.Euler(x: cameraRotation.x, cameraRotation.y, z: 0);

    }

    private void CalculateRecoilOffset()
    {
        currentRecoilTime += Time.deltaTime;
        float tmp_RecoilFraction = currentRecoilTime / recoilFadeOutTime;
        float tmp_Recoilvalue = RecoilCurve.Evaluate(tmp_RecoilFraction);//time
        currentRecoil = Vector2.Lerp(Vector2.zero, currentRecoil, tmp_Recoilvalue);
    }

    public void FiringForTest()
    {
        currentRecoil += RecoilRange;
        cameraSpring.StartCameraSpring();
        currentRecoilTime = 0;
    }
}
