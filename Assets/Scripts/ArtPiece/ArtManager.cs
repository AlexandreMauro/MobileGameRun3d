using System.Collections.Generic;
using UnityEngine;
using Core.Singelton;
public class ArtManager : Singelton<ArtManager>
{
   public enum ArtType
    {
        Type_01,
        Type_02,
        Type_03
    }

    public List<ArtSetup> ArtSetups;

    public ArtSetup GetComponentbyType(ArtType artType)
    {
       return  ArtSetups.Find(i=> i.artype == artType);
         
        
    }
}

[System.Serializable]
public class ArtSetup 
{
    public ArtManager.ArtType artype;
    public GameObject ArtPiece;
}