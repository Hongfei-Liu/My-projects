using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpring : MonoBehaviour
{
    public Vector2 minRecoilRange;
    public Vector2 maxRecoilRange;

    public float Frequence = 25;
    public float Damp = 15;

    private CameraSpringUtility cameraSpringUtility;
    private Transform cameraSpringTransform;

    private void Start()
    {
        cameraSpringUtility = new CameraSpringUtility(Frequence, Damp);
        cameraSpringTransform = transform;
    }

    private void Update()
    {
        cameraSpringUtility.UpdateSpring(Time.deltaTime, Vector3.zero);
        cameraSpringTransform.localRotation = Quaternion.Slerp(cameraSpringTransform.localRotation,
            Quaternion.Euler(cameraSpringUtility.Values),
            Time.deltaTime * 10);
    }

    public void StartCameraSpring()
    {
        cameraSpringUtility.Values = new Vector3(x: 0,
            y: UnityEngine.Random.Range(minRecoilRange.x, maxRecoilRange.x),
            z: UnityEngine.Random.Range(minRecoilRange.y, maxRecoilRange.y));
    }

}
