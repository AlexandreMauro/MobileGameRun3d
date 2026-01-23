using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System;

public class PowerUpsBase : ItensCollectablesBase
{
    [Header("PowerUP Config")]
    public float duration;
    [Header("PowerUp Animation")]
    public float ScaleDuration = .1f;
    public float DelayBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    void Start()
    {
       BouncePowerUpStartCall();
        
    }
    protected override void Collected()
    {
        base.Collected();
        StartPowerUP();
        HideItem(); 
        OnCollected();  
    }

    protected override void OnCollected()
    {
        base.OnCollected();
        PlayerControll.Instance.bounceHelper.BouncePowerUp();
    }
    protected virtual void StartPowerUP()
    {
        
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
    
    }

     #region  Animation methods
    public void BouncePowerUpStartCall()
    {
        StartCoroutine(BouncePowerUpStart());
    }

    public IEnumerator BouncePowerUpStart()
    {
        transform.localScale = Vector3.zero;
        yield return null;
        
        transform.DOScale(1f, ScaleDuration).SetEase(ease);
        yield return new WaitForSeconds (DelayBetweenPieces);
    }
    
    #endregion

   
}
