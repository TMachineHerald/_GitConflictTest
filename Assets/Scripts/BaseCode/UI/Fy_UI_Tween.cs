using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


/// <summary>
///  to注意
/// </summary>
namespace DG.Tweening
{

    public enum AnimationMode
    {
        Bounce,
        Jump,
        JumpAndShake,
    }

    /// <summary>
    /// ^这是一组动画链,每一个都返回Sequence
    /// </summary>
    public static class Fy_UI_BtnTween
    {

        public static Sequence ScaleBounceIn(this RectTransform _TS)
        {
            Vector2 _initAnchoredPos = _TS.anchoredPosition;
            float initY = _initAnchoredPos.y;
            _TS.gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            _TS.localScale = Vector3.zero;


            // return null;
            sequence.Append(_TS.DOScale(Vector3.one * 1.3F, 0.5F)).SetEase(Ease.InCubic)
                        .Append(_TS.DOScale(Vector3.one * 1F, 0.3F)).SetEase(Ease.InCubic)
                    ;

            return sequence;
        }

        public static Sequence ScaleBounceIn_L(this RectTransform _TS)
        {
            Vector2 _initAnchoredPos = _TS.anchoredPosition;
            float initY = _initAnchoredPos.y;
            _TS.gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            _TS.localScale = Vector3.zero;


            // return null;
            sequence.Append(_TS.DOScale(Vector3.one * 1.3F, 0.25F)).SetEase(Ease.InCubic)
                        // .Append(_TS.DOScale(Vector3.one * 0.9F, 0.25F)).SetEase(Ease.InCubic)
                        .Append(_TS.DOScale(Vector3.one * 1F, 0.3F)).SetEase(Ease.InCubic)
                    ;

            return sequence;
        }


        /// <summary>
        /// 跳动动画
        /// </summary>
        /// <param name="_RT"></param>
        /// <param name="_Loops"></param>
        /// <param name="_Strength"></param>
        /// <returns></returns>
        public static Sequence Ani_LoopBounce(this RectTransform _RT, int _Loops = -1, float _Strength = 1)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.
                     //step1
                     Append(_RT.DOScaleX(0.9F / _Strength, 0.25F))
                    .Join(_RT.DOScaleY(1.2F * _Strength, 0.25F))
                    .Append(_RT.DOScaleX(1.1F, 0.25F).SetEase(Ease.OutBack))
                    .Join(_RT.DOScaleY(0.95F, 0.25F).SetEase(Ease.OutBack))

                    //step2
                    .Append(_RT.DOScaleX(0.9F / _Strength, 0.3F))
                    .Join(_RT.DOScaleY(1.2F * _Strength, 0.3F))
                    .Append(_RT.DOScaleX(1.1F, 0.3F).SetEase(Ease.OutBack))
                    .Join(_RT.DOScaleY(0.95F, 0.3F).SetEase(Ease.OutBack))

                    //step3
                    .Append(_RT.DOScaleX(1F, 0.2F))
                    .Join(_RT.DOScaleY(1F, 0.2F))

                    //endtime
                    .AppendInterval(0.7F)
            ;

            sequence.onComplete += () =>
            {
                _RT.localScale = Vector3.one;
            };
            sequence.SetLoops(_Loops);
            return sequence;
        }

        public static Sequence Ani_LoopJump(this RectTransform _RT, int _Loops = -1, float _Strength = 1)
        {
            float _BasePositionY = _RT.localPosition.y;
            float _Hight = Screen.height * 0.05F + _BasePositionY;
            float _Width = Screen.width * 0.1F;

            Sequence sequence = DOTween.Sequence();
            sequence.
                     //step1
                     Append(_RT.DOLocalMoveY(_Hight, 0.25F).SetEase(Ease.OutCubic))
                    // .Join(_GO.DOScale(1.1F, 0.25F))
                    .Append(_RT.DOLocalMoveY(_BasePositionY, 0.25F).SetEase(Ease.InCubic))
                    // .Join(_GO.DOScale(1F, 0.25F).SetEase(Ease.OutBack))
                    //step2
                    .Append(_RT.DOLocalMoveY(_Hight, 0.25F).SetEase(Ease.OutCubic))
                    // .Join(_GO.DOScale(1.1F, 0.25F))
                    .Append(_RT.DOLocalMoveY(_BasePositionY, 0.25F).SetEase(Ease.InCubic))
                    // .Join(_GO.DOScale(1F, 0.25F).SetEase(Ease.OutBack))
                    //endtime
                    .AppendInterval(0.7F)
            ;

            sequence.onComplete += () =>
            {
                _RT.localScale = Vector3.one;
            };
            sequence.SetLoops(_Loops);
            return sequence;
        }


        /// <summary>
        /// [BUTTON]这个动画放在UI上可以根据改Pivot来改变振动效果 (即改变旋转位置) 建议-1
        /// </summary>
        /// <param name="_RT"></param>
        /// <param name="_Loops"></param>
        /// <param name="_Strength"></param>
        /// <returns></returns>
        public static Sequence Ani_LoopJump_Shake(this RectTransform _RT, int _Loops = -1, float _Strength = 1)
        {
            float _BasePositionY = _RT.localPosition.y;
            float _Hight = Screen.height * 0.03F + _BasePositionY;
            float _Width = Screen.width * 0.1F;

            int _Angle = 8;

            Sequence sequence = DOTween.Sequence();
            sequence.

                     //step1 risea
                     Append(_RT.DOLocalMoveY(_Hight, 0.1F).SetEase(Ease.Linear))
                     .Join(_RT.DOLocalRotate(Vector3.forward * -_Angle, 0.1F).SetEase(Ease.Linear))
                    //step2 shakeansform.DOLocalRotate(Vector3.forward * _Angle, 0.1F).SetEase(Ease.Linear))

                    .Append(_RT.DOLocalRotate(Vector3.forward * _Angle, 0.1F).SetEase(Ease.Linear))
                    .Append(_RT.DOLocalRotate(Vector3.forward * -_Angle, 0.1F).SetEase(Ease.Linear))
                    .Append(_RT.DOLocalRotate(Vector3.forward * _Angle, 0.1F).SetEase(Ease.Linear))
                    .Append(_RT.DOLocalRotate(Vector3.forward * -_Angle, 0.1F).SetEase(Ease.Linear))
                    .Append(_RT.DOLocalRotate(Vector3.forward * _Angle, 0.1F).SetEase(Ease.Linear))
                    .Append(_RT.DOLocalRotate(Vector3.forward * -_Angle, 0.1F).SetEase(Ease.Linear))

                    .Append(_RT.DOLocalRotate(Vector3.zero, 0.1F).SetEase(Ease.Linear))

                    .Append(_RT.DOLocalMoveY(_BasePositionY, 0.2F).SetEase(Ease.Linear))
                    .AppendInterval(0.7F)
            ;

            sequence.onComplete += () =>
                {
                    _RT.localScale = Vector3.one;
                };
            sequence.SetLoops(_Loops);
            return sequence;
        }

    }



    public static class Fy_Ui_BgTween
    {
        /// <summary>
        /// 进场  此方法依赖于你的UI中心点Pivot在画布中心0.5,0.5 ,从top掉下来,有弹性
        /// 建议失败用
        /// </summary>
        public static Sequence DownBounceIn(this RectTransform _TS)
        {
            Vector2 _initAnchoredPos = _TS.anchoredPosition;
            float initY = _initAnchoredPos.y;
            _TS.gameObject.SetActive(true);
            Sequence sequence = DOTween.Sequence();
            _TS.anchoredPosition += Vector2.up * Screen.height;


            // return null;
            sequence.Append(_TS.DOAnchorPosY(initY, 0.2F)).SetEase(Ease.Linear)
                    .Append(_TS.DOLocalMoveY(initY + Screen.height * 0.2F, 0.06F)).SetEase(Ease.OutCubic)

                    .Append(_TS.DOLocalMoveY(initY + 0F * Screen.height, 0.1F)).SetEase(Ease.InCubic)
                    .Append(_TS.DOLocalMoveY(initY + 0.1F * Screen.height, 0.1F)).SetEase(Ease.OutCubic)
                    .Append(_TS.DOLocalMoveY(initY + 0F * Screen.height, 0.1F)).SetEase(Ease.InCubic)
                    ;

            return sequence;
        }

        /// <summary>
        /// 进场  此方法依赖于你的UI中心点Pivot在画布中心0.5,0.5
        /// 从中心出现
        /// </summary>
        public static Sequence CenterAppearIn(this RectTransform _RT)
        {

            Vector2 _Pos = _RT.anchoredPosition;
            Sequence sequence = DOTween.Sequence();
            _RT.localScale = Vector3.one * 0.1F;
            // Debug.Log(_GO.position);
            sequence.Append(_RT.DOScale(1, 0.3F)).SetEase(Ease.Linear)
                    ;
            return sequence;
        }

        /// <summary>
        /// 默认执行完毕隐藏panel
        /// </summary>
        /// <param name="_RT"></param>
        /// <returns></returns>
        public static Sequence CenterDisappearOut(this RectTransform _RT)
        {
            Sequence sequence = DOTween.Sequence();

            _RT.localScale = Vector3.one;
            Debug.Log(_RT.position);

            sequence.Append(_RT.DOScale(1.3F, 0.1F)).SetEase(Ease.Linear)
                    .Append(_RT.DOScale(0.1F, 0.3F)).SetEase(Ease.Linear)
                    ;
            sequence.onComplete += () =>
            {
                _RT.localScale = Vector3.one;
                _RT.gameObject.SetActive(false);
            };

            return sequence;
        }
    }
}



