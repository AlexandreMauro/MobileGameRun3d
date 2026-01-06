using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class LevelPieceSetup : ScriptableObject
{
    public ArtManager.ArtType artTYPE;
    [Header("Type of Pieces")]
    public List<LevelPieceBase> Pieces;
    public List<LevelPieceBase> PieceStart;
    public List<LevelPieceBase> PieceEnd;
    
    [Header("Pieces Number")]
    public int StartPiecesNumber = 3;
    public int PiecesNumber = 5;
    public int EndPiecesNumber = 1;


}
