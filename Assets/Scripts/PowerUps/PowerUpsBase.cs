using UnityEngine;

public class PowerUpsBase : ItensCollectablesBase
{
    [Header("PowerUP Config")]
    public float duration;



    protected override void Collected()
    {
        base.Collected();
        StartPowerUP();
        HideItem();
    }
    protected virtual void StartPowerUP()
    {
        
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        
    }
}
