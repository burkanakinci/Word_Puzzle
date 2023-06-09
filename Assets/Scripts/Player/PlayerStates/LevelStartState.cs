using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartState : IState
{
    private Player m_Player;
    public LevelStartState(Player _player)
    {
        m_Player = _player;
    }

    public void Enter()
    {
        GameManager.Instance.UIManager.OnLevelStart();
        GameManager.Instance.LevelManager.OnLevelStart();
    }
    public void Exit()
    {
        GameManager.Instance.LevelManager.OnExitGameplay();
    }
}
