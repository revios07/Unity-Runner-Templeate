using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float _xInput { get; private set; }

    [SerializeField]
    [Range(0f,10f)]
    private float _xInputClamp = 1f;

    private void Start()
    {
        _xInput = 0f;
    }

    private void Update()
    {
        if (!GameManager.GetSingleton().IsPlaying())
            return;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
        {
            _xInput += Input.GetTouch(0).deltaPosition.x * Time.deltaTime;
            _xInput = Mathf.Clamp(_xInput, -_xInputClamp, +_xInputClamp);
        }
        else
        {
            _xInput = Mathf.Lerp(_xInput, 0f, 5f * Time.deltaTime);
        }
    }
}
