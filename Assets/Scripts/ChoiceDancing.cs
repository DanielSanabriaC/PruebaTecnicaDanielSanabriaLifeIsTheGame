using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static ModelController;

public class ChoiceDancing : MonoBehaviour
{


    [SerializeField] private Button HouseButton;
    [SerializeField] private Button MacarenaButton;
    [SerializeField] private Button HipHopButton;
    [SerializeField] private Button sceneTwoButton;

    [SerializeField] private ModelData characterData;

    private void Awake()
    {
        HouseButton.onClick.AddListener(() => { setDanceStateFromButton(DanceCondition.House); });     // setDanceStateFromButton cambiar este nombre
        MacarenaButton.onClick.AddListener(() => { setDanceStateFromButton(DanceCondition.Macarena); });
        HipHopButton.onClick.AddListener(() => { setDanceStateFromButton(DanceCondition.HipHop); });
        ModelController.onDanceSwitch?.Invoke(DanceCondition.Idle);
        sceneTwoButton.interactable = false;
        sceneTwoButton.onClick.AddListener(SceneTwoButton);

    }


    private void setDanceStateFromButton(DanceCondition newState)
    {
        sceneTwoButton.interactable = true;
       characterData.characterDanceState = newState;
        ModelController.onDanceSwitch?.Invoke(newState);
    }

    private void SceneTwoButton()
    {
        SceneManager.LoadScene(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
