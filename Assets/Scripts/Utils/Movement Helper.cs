using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using System.Collections;

public class MovementHelper : MonoBehaviour
{
   public List<Transform> transforms;
   public float duration = 1f;

   [SerializeField]
    private int _index = 0;

    private void Start()
    {
        
        StartCoroutine(StartMovment());
    }
    IEnumerator StartMovment()
    {
        float time = 0;
        while(true)
        {
            var currentposition = transform.position;
            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentposition, transforms[_index].position, time / duration);
                time += Time.deltaTime;
                
                yield return null;
            }

            
        if(time >= duration)   
            {
                time = 0;
                _index ++;
            }

        if(_index >= transforms.Count) _index=0;

            yield return null;
        }
       
    }

    public void StartPosition() {
        transform.position = transforms[_index].position;
    }
}
