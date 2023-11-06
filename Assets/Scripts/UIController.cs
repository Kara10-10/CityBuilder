using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private Action OnBuildAreaHandler;
    private Action OnCancelActionHandler;
    public Button buildResidentalAreaBtn;
    public Button cancelActionAreaBtn; 
    public GameObject cancelActionAreaPanel; 
    
    // Start is called before the first frame update
    void Start()
    {
        cancelActionAreaPanel.SetActive(false);
        buildResidentalAreaBtn.onClick.AddListener(OnBuildAreaCallBack);
        cancelActionAreaBtn.onClick.AddListener(OnCancelActionCallBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBuildAreaCallBack()
    {
        cancelActionAreaPanel.SetActive(true);
        OnBuildAreaHandler?.Invoke();
    }

    private void OnCancelActionCallBack()
    {
        cancelActionAreaPanel.SetActive(false);
        OnCancelActionHandler?.Invoke();
    }
    
    public void AddListenerToOnBuildAreaHandlerEvent(Action listener) 
    {
        OnBuildAreaHandler += listener;
    }
    public void RemoveListenerToOnBuildAreaHandlerEvent(Action listener)
    {
        OnBuildAreaHandler -= listener;
    }
    public void AddListenerToOnCancelActionHandlerEvent(Action listener)
    {
        OnCancelActionHandler += listener;
    }
    public void RemoveListenerToOnCancelActionHandlerEvent(Action listener)
    {
        OnCancelActionHandler -= listener;
    }
}
