using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollectablesBase : MonoBehaviour
{
    public string PlayerTag = "Player";
    public GameObject GrafhicItem;
    public ParticleSystem ParticleSystem;

    [Header("Sounds")]
    public AudioSource audioSource;

    private void Awake()
    {
        //if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
        //if (audioSource != null) audioSource.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(PlayerTag))
        {

            Collected();
        }
    }

   
    protected virtual void  Collected()
    {
      
    }

    protected virtual void OnCollected()
    {
        

    }

    public void HideItem()
    {
          if (GrafhicItem != null) GrafhicItem.SetActive(false);
    }

}
