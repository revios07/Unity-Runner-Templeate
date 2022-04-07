using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Referances")]
    [SerializeField]
    private Transform _forwardMovementParent;
    [SerializeField]
    private Transform _horizontalMovementChild;

    #region Class Refs
    [Tooltip("GameManager")]
    private GameManager _gameManager;
    [Tooltip("Handler")]
    private InputHandler _inputHandler;
    #endregion

    private void Start()
    {
        _inputHandler = GameObject.FindObjectOfType<InputHandler>();
        _gameManager = GameManager.GetSingleton();
    }

    private void FixedUpdate()
    {
        if (!_gameManager.IsPlaying())
            return;

        //Forward Movement
        _forwardMovementParent.Translate(_forwardMovementParent.forward * _gameManager.playerMovementVariables.forwardSpeed * Time.fixedDeltaTime);

        //Horizontal Movement
        _horizontalMovementChild.localPosition += (Vector3.right * _inputHandler._xInput * Time.fixedDeltaTime);
    }
}
