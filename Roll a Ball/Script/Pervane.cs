using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pervane : MonoBehaviour
{
    public float _rotationSpeed;
    private void LateUpdate()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime,0);
    }
}
