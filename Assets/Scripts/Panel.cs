using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    [SerializeField]private ModelData characterData;

    // Start is called before the first frame update
    void Start()
    {
        if(characterData != null)
        {
            ModelController.onDanceSwitch?.Invoke(characterData.characterDanceState); // 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
