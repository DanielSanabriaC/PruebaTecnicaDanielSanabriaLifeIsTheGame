using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ModelController;

[CreateAssetMenu(fileName = "New Character Data", menuName = "Daniel Sanabria/Model Data", order = 1)]
[Serializable]

public class ModelData : ScriptableObject
{

    [Header("ModelData")]
    public DanceCondition characterDanceState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
