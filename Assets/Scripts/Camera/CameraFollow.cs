using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _cameraOffset;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("PlayerHorizontal").transform;
    }

    private void Start()
    {
        _cameraOffset = transform.position - _playerTransform.position;
    }

    //Follow Player
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + _cameraOffset, 5f * Time.fixedDeltaTime);
    }
}
