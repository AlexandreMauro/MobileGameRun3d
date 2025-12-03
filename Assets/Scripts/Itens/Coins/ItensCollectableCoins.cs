using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class ItensCollectableCoins : ItensCollectablesBase
{
    public Collider Collider;
    public bool Collect = false;
    public float Lerp ;
    public float minDistance;   
   
   
   /*private void Start()
    {
        CoinsAimationMnanager.Instance.CoinsAimationMnanager(this);
   }*/

    protected override void Collected()
    {
        base.Collected();
        OnCollected();
    }


    protected override void OnCollected()
    {
        base.OnCollected();
          Collider.enabled = false;        
          Collect = true;        
          //PlayerControll.Instance.Bounce();
    }

    private void Update()
    {
       if(Collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerControll.Instance.transform.position, Lerp * Time.deltaTime);
            
            if(Vector3.Distance(transform.position, PlayerControll.Instance.transform.position)< minDistance)
            {
                  HideItem();
                  Destroy(this.gameObject);
            }
        }
    }

}
