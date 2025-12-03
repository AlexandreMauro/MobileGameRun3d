using UnityEngine;

public class PowerUpCoins : PowerUpsBase
{
public float SizeAmaunt = 7f;

    protected override void StartPowerUP()
    {
        base.StartPowerUP();
        PlayerControll.Instance.ChanceCoinCollectSize(SizeAmaunt);
        PlayerControll.Instance.SetPowerUpText("Sugando...");
        
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerControll.Instance.ChanceCoinCollectSize(SizeAmaunt = 1f);
         PlayerControll.Instance.SetPowerUpText("");
        
    }



}
