using UnityEngine;
using DG.Tweening;
using System.Collections;
public class CreateObjectAnimation : MonoBehaviour
{
    [Header("Bounce Settings")]
    public Ease ease = Ease.OutBack;
    public float delay = 1f;
    public float ScaleTimeDuration = .1f;
    public Transform OriginalScaleObject;


    private Vector3 _TargetObject;



    public void Start()
    {
        OriginalScale();
        ScaleZero();
        BounceStartCall();
    }

    public void OriginalScale()
    {
      _TargetObject = OriginalScaleObject.localScale; 
    }
    public void ScaleZero()
    {
        OriginalScaleObject.transform.localScale = Vector3.zero;
    }

    public void BounceStartCall()
    {
        StartCoroutine(BouncePlayerStart());
    }

    public IEnumerator BouncePlayerStart()
    {
       OriginalScaleObject.transform.DOScale(_TargetObject, ScaleTimeDuration).SetEase(ease);
        yield return new WaitForSeconds (delay);
    }

}
