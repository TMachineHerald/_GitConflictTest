using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.UI;

public class VibratorBtnUI : MonoBehaviour
{
    public Button btn;
    public Image btnImg;
    public Sprite vibratorOnSprite;
    public Sprite vibratorOffSprite;

    private bool _isFirstLoad;


    private void Awake()
    {
        btn = GetComponent<Button>();
        btnImg = GetComponent<Image>();
        
        if (VibratorManager.IsiPadOriPod())
        {
            gameObject.SetActive(false);
        }
        else
        {
            btn.GetComponent<Button>().onClick.AddListener(OnClick);
            _isFirstLoad = true;
        }
    }

    private void Start()
    {
        if (!_isFirstLoad)
            return;
        _isFirstLoad = false;
        VibratorManager.BindEvent(UpdateInfo);
    }

    private void OnClick()
    {
        VibratorManager.Switch();
        VibratorManager.Trigger(HapticTypes.Selection);
    }

    private void UpdateInfo(bool isVibratorEnable)
    {
        btnImg.sprite = null;
        btnImg.sprite = isVibratorEnable ? vibratorOnSprite : vibratorOffSprite;
    }
}