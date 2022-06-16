using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModelController : MonoBehaviour
{

    public enum DanceCondition
    {
        Idle,
        House,
        Macarena,
        HipHop
    }


    [SerializeField] private Animator characterAnimator;

    public static Action<DanceCondition> onDanceSwitch;

    private void OnEnable()
    {
           
    onDanceSwitch += DanceSwitch;
    }
    private void OnDisable()
    {
    onDanceSwitch -= DanceSwitch;
    }


    private void DanceSwitch(DanceCondition newDanceSwitch) => characterAnimator.SetTrigger(newDanceSwitch.ToString());

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
