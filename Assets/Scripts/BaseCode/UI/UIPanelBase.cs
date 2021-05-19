using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor;

public class UIPanelBase : MonoBehaviour
{
    [SerializeField]
    public Button CloseBtn = null;
    public virtual void Awake()
    {
        if (CloseBtn == null)
        {
            throw new ArgumentException("未指定的Close Btn");
        }
        CloseBtn.onClick.AddListener(() =>
                       {
                           CloseBtn.interactable = false;
                           GetComponent<RectTransform>().CenterDisappearOut();
                       });
    }
    void Start()
    {

    }

    private void OnEnable()
    {
        CloseBtn.interactable = true;
    }

}
