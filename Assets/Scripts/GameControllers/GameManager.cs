using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    BeforeStart,
    Normal,
    Win,
    lost,
}
public class GameManager : MonoSingleton<GameManager>
{
    public GameState GameState = GameState.BeforeStart;

    private void Start()
    {
        //设置游戏为正常状态
        LevelController.Instance.E_LevelRefresh += () =>
        {
            GameState = GameState.Normal;
        };
    }
}
