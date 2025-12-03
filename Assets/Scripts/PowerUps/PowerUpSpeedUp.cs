using UnityEngine;

public class PowerUpSpeedUp : PowerUpsBase
{

    public float AmauntSpeedUp ;
   
   protected override void StartPowerUP()
    {
        base.StartPowerUP();
        PlayerControll.Instance.PowerUpSpeedUp(AmauntSpeedUp);
        PlayerControll.Instance.SetPowerUpText("Speed Up");
    }
    protected override void EndPowerUp()    
    {        
        base.EndPowerUp();        
        PlayerControll.Instance.ResetSpeed();        
        PlayerControll.Instance.SetPowerUpText("");    
    }
}
