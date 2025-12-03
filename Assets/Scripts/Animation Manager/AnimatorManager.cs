using System;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{ 
    
    public Animator animator;
    public List<AnimationSetups> animationSetups;
    public enum Animationtype    
    {
        IDLE,
        WALK,
        DEAD
    }

    public void Play(Animationtype Type, float currentspeedFactor = 1f)
    {
        foreach( var animation in animationSetups)
        {
            if(animation.Types== Type)
            {
                animator.SetTrigger(animation.nameAnimation);
                animator.speed = animation.speed * currentspeedFactor;
                break;
            }
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(Animationtype.IDLE);

        }
         if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(Animationtype.WALK);
            
        }
         if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(Animationtype.DEAD);
            
        }
    }



}

[System.Serializable]
public class AnimationSetups
{
    public AnimatorManager.Animationtype Types;
    public string nameAnimation;
    public float speed =1f;
    }