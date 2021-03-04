using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairUI : MonoBehaviour
{
    public RectTransform reticle;

    public float size;
    public float maxSize;

    private float currentSize;
    public CharacterController characterController;

    private void Update()
    {
        bool tmp_IsMoving = characterController.velocity.magnitude > 0;
        if(tmp_IsMoving)
        {
            currentSize = Mathf.Lerp(currentSize, maxSize, Time.deltaTime * 5);
        }
        else
        {
            currentSize = Mathf.Lerp(currentSize, size, Time.deltaTime * 5);
        }
        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

}
