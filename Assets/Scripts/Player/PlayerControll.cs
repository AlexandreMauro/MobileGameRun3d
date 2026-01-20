using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Core.Singelton;
using UnityEngine.Video;
using DG.Tweening;

public class PlayerControll : Singelton<PlayerControll>
{
[Header("Player Status")]
    //publics
    public float speed = 2f;
    public float LerpSpeed = 1.5f;
    public string ObstacleTag = "Obstacle";
    public string EndLineTag = "EndLine";

[Header("Objects references")]
    public GameObject FinishPainel;
    public TextMeshPro  UITextPowerUpText;
    public Transform target;
    public GameObject CoinCollector;

[Header("Animator Manager")]
    public AnimatorManager animatorManager;
   public BounceHelper bounceHelper;

    //privates
    private bool _CanRun;
    private Vector3 _Dir;
    private float _CurrentSpeed;
    private Vector3 _StartPosition;
    private bool _Invencible;
    private float _baseSpeedAnimation = 7;

   
    public void Start()
    {   ResetPosition();
        ResetSpeed();
        FinishPainel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(!_CanRun) return;

        _Dir = target.position;
        _Dir.y = transform.position.y;
        _Dir.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _Dir, LerpSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * _CurrentSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ObstacleTag)
        {
           if(!_Invencible) 
           {
            EndScreenObstacle(AnimatorManager.Animationtype.DEAD);
           }    

        }else if(collision.gameObject.tag == EndLineTag)
        {
            EndScreeneNDlINE();
        }
    }

    #region  Animation methods
    
    
    #endregion
    #region Start and stop run methods


    public void Start_Run()
    {
        _CanRun = true;
        animatorManager.Play(AnimatorManager.Animationtype.WALK, _CurrentSpeed  /_baseSpeedAnimation);
    }

    private void Stop_Run()
    {
        _CanRun = false;
        
    }

     private void EndScreeneNDlINE(AnimatorManager.Animationtype animationtype = AnimatorManager.Animationtype.IDLE )
    {
        animatorManager.Play(animationtype);
        FinishPainel.SetActive(true);
        Stop_Run();
        
    }

    private void EndScreenObstacle(AnimatorManager.Animationtype animationtype = AnimatorManager.Animationtype.IDLE )
    {
        animatorManager.Play(animationtype);
        FinishPainel.SetActive(true);
        Stop_Run();
        Invoke(nameof(MoveBack), 0.1f);
    }

    private void MoveBack()
    {
        transform.DOMoveZ(transform.position.z -.6f, 0.7f).SetEase(Ease.OutBack);
    }

    #endregion

#region Reset methods
    public void ResetPosition()
    {
        _StartPosition = transform.position;
    }

     public void Reset_Height(float AnimationDuration)
     {
        /*ar p = transform.position;
        p.y = _StartPosition.y;
        transform.position = p;*/
        transform.DOMoveY(_StartPosition.y, AnimationDuration).SetEase(Ease.OutBack);
    }
    public void ResetSpeed()
    {
        _CurrentSpeed = speed;
    }
    
    public void SetPowerUpText(string s)
    {
        UITextPowerUpText.text = s;
    }
#endregion

#region Power ups methods


    public void PowerUpSpeedUp(float f)
    {
        _CurrentSpeed = f;
    }
    public void SetInvencible(bool b)
    {
        _Invencible = b;
    }

    public void ChangeHeight(float AmauntHeight, float duration, float animationDuration, Ease ease)
    {
       /* var p = transform.position;
        p.y = _StartPosition.y + AmauntHeight;
        transform.position = p;*/

        transform.DOMoveY(_StartPosition.y + AmauntHeight, duration).SetEase(ease);
        Invoke(nameof(Reset_Height),duration);
    }

    public void ChanceCoinCollectSize(float Amaunt)
    {
        CoinCollector.transform.localScale = Vector3.one * Amaunt;
    }
    #endregion

    
}
