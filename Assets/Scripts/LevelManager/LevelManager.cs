using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
   public Transform LevelContainer; 
   public List<GameObject> Levels;
   public List<LevelPieceSetup> LevelPieceSetup;

    [Header("ArtPieces Animation")]
    public float ScaleDuration = .1f;
    public float DelayBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;
   
   [SerializeField]private List<LevelPieceBase> _SpawnedPieces = new List<LevelPieceBase>();
   private GameObject _currentLevel;
   private LevelPieceSetup _currentpice;
   [SerializeField] private int _Index;

   

    private void Start()
    {
        //NextLevelSpawn();
        CreateLevelPieces();
    }

    private void NextLevelSpawn()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _Index++;
        } 
        
         if(_Index >= Levels.Count)
        {
            ResetLevel();
        }

        _currentLevel = Instantiate(Levels[_Index], LevelContainer);
        _currentLevel.transform.localPosition = Vector3.zero;
      
    }

    private void ResetLevel()
    {
        _Index = 0;
    }





    private void CreateLevelPieces()
    {
        ClearSpawnedPieces();

    if(_currentpice != null)
        {
            _Index++;

        }
        if(_Index >= LevelPieceSetup.Count)
        {
            ResetLevel();
        }

        _currentpice = LevelPieceSetup[_Index];
            
            for (int i= 0; i < _currentpice.StartPiecesNumber; i++)
            {
                CreatePieces(_currentpice.PieceStart);
            }
       
            for (int i= 0; i < _currentpice.PiecesNumber; i++)
            {
                CreatePieces(_currentpice.Pieces);
            }
    
    
            for (int i= 0; i < _currentpice.EndPiecesNumber; i++)
            {
                CreatePieces(_currentpice.PieceEnd);
            }

        StartCoroutine(SpawnedPiecebyTime());        
    }

    IEnumerator SpawnedPiecebyTime()
    {
        foreach( var p in _SpawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }
        yield return null;

        for(int i =0; i<_SpawnedPieces.Count; i++)
        {
            _SpawnedPieces[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(DelayBetweenPieces);
        }
    
    CoinAnimatorManager.Instance.StartAnimation();

    }

    private void ClearSpawnedPieces()

    {
        for(int i = _SpawnedPieces.Count -1 ; i >= 0; i--)
        {
            Destroy(_SpawnedPieces[i].gameObject);
           
        }
         _SpawnedPieces.Clear();
        
    }

    private void CreatePieces(List<LevelPieceBase> List)
    {
        var piece = List[Random.Range(0,  List.Count)];
        var spawnedPiece = Instantiate(piece, LevelContainer);

        
            
        if(_SpawnedPieces.Count > 0)
        {
        var LastPiece =  _SpawnedPieces[_SpawnedPieces.Count -1];
    
         spawnedPiece.transform.position = LastPiece.EndPoint.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }
        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePieceArt(ArtManager.Instance.GetComponentbyType(_currentpice.artTYPE).ArtPiece);
        }
    
        ColorManager.Instance.ChangeColorByType(_currentpice.artTYPE);
        
        _SpawnedPieces.Add(spawnedPiece);
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
          CreateLevelPieces();
        }
    }

}
