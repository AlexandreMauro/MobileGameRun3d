using UnityEngine;

public class PowerUpInvecible : PowerUpsBase
{

    
   
   protected override void StartPowerUP()
    {
        base.StartPowerUP();
        PlayerControll.Instance.SetPowerUpText("INVENCIBLE");
        PlayerControll.Instance.SetInvencible(true);
    }
    protected override void EndPowerUp()    
    {        
        base.EndPowerUp();        
        PlayerControll.Instance.SetInvencible(false);        
        PlayerControll.Instance.SetPowerUpText("");    
    }
}
