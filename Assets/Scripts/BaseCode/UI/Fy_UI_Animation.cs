
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// 直接挂到GO上,loop animation适用
/// 常用在持续播放的button上
/// 挂上去就完了,再也找不到了,停不下来
/// </summary>
public class Fy_UI_Animation : MonoBehaviour
{

    public AnimationMode _mode;

    bool AutoPlay = true;

    private void OnEnable()
    {
        if (AutoPlay)
            Play();
    }
    Sequence sequence;
    private void OnDisable()
    {
        sequence.Pause();
        sequence.Kill();
    }
    public void Play()
    {
        switch (_mode)
        {
            case AnimationMode.Bounce:
                sequence = GetComponent<RectTransform>().Ani_LoopBounce(-1, 1F);
                break;
            case AnimationMode.Jump:
                sequence = GetComponent<RectTransform>().Ani_LoopJump(-1, 1F);
                break;
            case AnimationMode.JumpAndShake:
                sequence = GetComponent<RectTransform>().Ani_LoopJump_Shake(-1, 1F);
                break;
            default:
                break;
        }
    }
}
