using UnityEngine;
using Core.Singelton;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using DG.Tweening;

public class CoinAnimatorManager : Singelton<CoinAnimatorManager>
{
    [Header("ArtPieces Animation")]
    public float ScaleDuration = .1f;
    public float DelayBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    public List <ItensCollectableCoins> Itens;

    private void OnValidate()
    {
        newList();
    }
   
   public void newList()
    {
        Itens = new List<ItensCollectableCoins>();  
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
           StartAnimation();
        }

    }


     public void register(ItensCollectableCoins i)
    {
        if(!Itens.Contains(i))
        {
            Itens.Add(i); 
            i.transform.localScale = Vector3.zero;   
        }
        
        
    }

    public void StartAnimation()
    {
         StartCoroutine(SpawnedPiecebyTime());
    }
     IEnumerator SpawnedPiecebyTime()
    {
        foreach( var p in Itens)
        {
            p.transform.localScale = Vector3.zero;
        }
        Sort();
        yield return null;

        for(int i =0; i<Itens.Count; i++)
        {
            Itens[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(DelayBetweenPieces);
        }
        
    }

    public void Sort()
    {
        Itens = Itens.OrderBy(i => Vector3.Distance(PlayerControll.Instance.transform.position, i.transform.position)).ToList(); 
    }
}