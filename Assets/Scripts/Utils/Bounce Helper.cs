using UnityEngine;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;


public class BounceHelper : MonoBehaviour
{
    [Header("Bounce Animation ")]
    public float ScaleDuration = .1f;
    public float ScaleBounceGeneral = 1.2f;
    public int vibrato = 10;
    public float strength = 1f;
    public Ease ease = Ease.OutBack;

    public Transform OriginalObject;
    public Vector3 originalScale;
   

    void Start() 
    {
        originalScale = new Vector3 (OriginalObject.localScale.x, OriginalObject.localScale.y, OriginalObject.localScale.z);    
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            BouncePowerUp();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            BounceBase();
        }
        
       
    }



    public void OriginalScale()
    {
        OriginalObject.transform.DOScale(originalScale,ScaleDuration).SetEase(ease);
    }
    public void BounceBase()
    {
        OriginalObject.transform.DOScale(ScaleBounceGeneral, ScaleDuration).SetLoops(1, LoopType.Yoyo).SetEase(ease).OnComplete(() => OriginalScale()); 
    }

    public void BouncePowerUp()
    {

        OriginalObject.transform.DOShakeScale(ScaleDuration, strength, vibrato).SetLoops(1, LoopType.Yoyo).SetEase(ease).OnComplete(() => OriginalScale());
       
       
        
        
    }
}

