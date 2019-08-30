﻿
using UnityEngine;

public class scr_CameraFollow : MonoBehaviour
{
    public Transform target;
    [Range(0.0f, 1f)]
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private GameObject playerPrefab;

    private void Start()
    {

    }

    void LateUpdate()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
    }
}
