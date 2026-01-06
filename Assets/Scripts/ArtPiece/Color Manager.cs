using System.Collections.Generic;
using UnityEngine;
using Core.Singelton;

public class ColorManager : Singelton<ColorManager>
{
   public List<Material> materials;
   public List<ColorSetup> colorSetups;

   public void ChangeColorByType(ArtManager.ArtType artType)
    {
      var setup = colorSetups.Find(i=> i.artype == artType);
        for(int i = 0; i< materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.color[i]);
        }
    }
}




[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artype;
    public List<Color> color;
}
