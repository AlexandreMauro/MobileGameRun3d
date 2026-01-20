using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Bounce Animation")]
    public float ScaleDuration = .1f;
    public float ScaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;


    public void Update()
    {
         if(Input.GetKeyDown(KeyCode.S))
        {
            Bounce();
        }
    }

    public void Bounce()
    {
        transform.DOScale(ScaleBounce, ScaleDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        
    }
}
