using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // GameManager를 만드는이유 : 게임 진행 규칙들을 관리하기 위해 만든 매니저
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverUI;


    public void GameOver()
    {
        PauseGame();
        PopUpGameOverUI();
    }

    public void ContinueGame()
    {
        ReleasePauseGame();
        HideGameOverUI();
        Player.instance.RecoverHP();
    }

    private void Awake()
    {
        instance = this;
    }

    private void PopUpGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    private void HideGameOverUI()
    {
        _gameOverUI.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ReleasePauseGame()
    {
        Time.timeScale = 1f;
    }
}
