using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StateUIController : MonoSingleton<StateUIController>
{
    [SerializeField]
    GameObject WinUI;


    public void CallUI()
    {

    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            OnWin();
        }
    }

    public void OnWin()
    {
        WinUI.GetComponent<WinUI>().CloseBtn.gameObject.SetActive(false);
        WinUI.GetComponent<RectTransform>().ScaleBounceIn_L().OnComplete(() =>
        {
            WinUI.GetComponent<WinUI>().OnComeIn();
        });
    }
}
