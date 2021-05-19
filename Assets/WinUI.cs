using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class WinUI : UIPanelBase
{


    public override void Awake()
    {
        base.Awake();
        CloseBtn.onClick.AddListener(() =>
        {
            CloseBtn.GetComponent<Fy_UI_Animation>().enabled = false;
        });
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnComeIn()
    {
        CloseBtn.GetComponent<RectTransform>().ScaleBounceIn().OnComplete(() =>
        {
            CloseBtn.GetComponent<Fy_UI_Animation>().enabled = true;
        });
    }
}
