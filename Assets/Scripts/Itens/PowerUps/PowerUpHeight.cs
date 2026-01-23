using UnityEngine;
using DG.Tweening;
using System.Collections;
public class NewMonoBehaviourScript : PowerUpsBase
{
     [Header("Power Up Height")]    
     public float amountHeight = 2;   
    public float animationDuration = .1f;    
    protected override void StartPowerUP()    
    {       
         base.StartPowerUP();        
         PlayerControll.Instance.ChangeHeight(amountHeight, duration, animationDuration, ease);
         PlayerControll.Instance.SetPowerUpText("Flying");    
         
    }
    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.Reset_Height(animationDuration);
        PlayerControll.Instance.SetPowerUpText("");
    }

}
