using System;
using UnityEngine;

public class TouchController : MonoBehaviour
{
   public Vector3 PastPositionMouse;
   public float velocity = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - PastPositionMouse.x);    
        }
         PastPositionMouse = Input.mousePosition;
    }

    public void Move(float speed)
    {
        transform.position += Vector3.right * speed * Time.deltaTime *velocity ;
    }
}
