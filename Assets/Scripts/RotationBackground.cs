using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBackground : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void Update()
    {
        this.transform.Rotate(0, 0, rotateSpeed, Space.World);
    }
}
