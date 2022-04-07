using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    #region Variables
    private static GameManager instance;

    [Tooltip("Events Call From Method")]
    public UnityEvent onGameStart;
    public UnityEvent onGameEnd;

    [SerializeField]
    public PlayerMovementVariables playerMovementVariables;
    private GameState gameState = GameState.Stop;
    #endregion

    public enum GameState
    {
        Play,
        Stop
    }

    #region Unity Methods
    private void OnEnable()
    {
        onGameStart.AddListener(GameStateChangeOnStart);
        onGameEnd.AddListener(GameStateChangeOnEnd);
    }

    private void OnDisable()
    {
        onGameStart.RemoveListener(GameStateChangeOnStart);
        onGameEnd.RemoveListener(GameStateChangeOnEnd);
    }

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {

    }
    #endregion

    #region Public Methods
    public static GameManager GetSingleton()
    {
        return instance;
    }

    public void StartGame()
    {
        if (onGameEnd != null)
            onGameStart.Invoke();
    }

    public void StopGame()
    {
        if (onGameEnd != null)
            onGameEnd.Invoke();
    }

    public bool IsPlaying()
    {
        return gameState == GameState.Play;
    }

    #endregion

    #region Private Methods
    private void GameStateChangeOnStart()
    {
        gameState = GameState.Play;
    }

    private void GameStateChangeOnEnd()
    {
        gameState = GameState.Stop;
    }
    #endregion
}
