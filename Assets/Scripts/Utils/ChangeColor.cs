using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(MeshRenderer))]
public class ChangeColor : MonoBehaviour
{
    public MeshRenderer meshRender;
    public float duration = 1f;
    public Color StartColor= Color.white;
    private Color _TargetColor;

    private void OnValidate() 
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
         _TargetColor = meshRender.materials[0].GetColor("_Color");
         Change_Color();
    }
    public void Change_Color()
    {
        meshRender.materials[0].SetColor("_Color", StartColor);
        meshRender.materials[0].DOColor(_TargetColor, "_Color", duration);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Change_Color();
        }
    }
}
