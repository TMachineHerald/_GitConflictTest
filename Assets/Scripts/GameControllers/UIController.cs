using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIController应该作为游戏UI系统的整体事件统筹系统,而非面面俱到,把一堆逻辑写进这里
/// </summary>
public class UIController : MonoSingleton<UIController>
{
    [SerializeField]
    public panelBase newPanel;


    private void Awake()
    {

    }

    private void Start()
    {
        LevelController.Instance.E_LevelRefresh += () =>
        {

        };

    }

    void OnPanel()
    {

    }


    public void CallUI()
    {

    }
}

public class panelBase
{

}
