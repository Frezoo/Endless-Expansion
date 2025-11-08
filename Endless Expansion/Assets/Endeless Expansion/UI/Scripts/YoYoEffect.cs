using UnityEngine;
using DG.Tweening;
public class YoYoEffect : MonoBehaviour
{
    
    [Header("Настройки анимации")]
    [SerializeField] private float angle = 7f;
    [SerializeField] private float duration = 0.08f;
    
    void Awake()
    {
        transform.DORotate(Vector3.forward * angle, duration, RotateMode.LocalAxisAdd).SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
