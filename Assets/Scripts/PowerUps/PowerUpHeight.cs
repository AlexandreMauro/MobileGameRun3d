using UnityEngine;

public class NewMonoBehaviourScript : PowerUpsBase
{
     [Header("Power Up Height")]    
     public float amountHeight = 2;   
    public float animationDuration = .1f;    
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;    
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
