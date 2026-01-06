using Unity.VisualScripting;
using UnityEngine;

public class ArtPiece : MonoBehaviour
{
    public GameObject CurentArtPiece;

    public void ChangePieceArt(GameObject piece)
    {
        if(CurentArtPiece != null) Destroy(CurentArtPiece);

        CurentArtPiece = Instantiate(piece, transform);
        CurentArtPiece.transform.localPosition = Vector3.zero;
    }

    
}
