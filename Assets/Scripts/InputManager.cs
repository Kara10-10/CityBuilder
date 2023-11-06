 using System.Collections;
using System.Collections.Generic;
 using PlasticGui.WebApi.Responses;
 using UnityEngine;
using UnityEngine.EventSystems;
 using System;

public class InputManager : MonoBehaviour, IInputManager
{
    private Action<Vector3> OnPointerSecondChangeHandler;
  
    private Action<Vector3> OnPointerDownHandler;
    private Action OnPointerSecondUpHandler;
    private Action<Vector3> OnPointerChangeHandler;
    private Action OnPointerUpHandler;
    public LayerMask mouseInputMask;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetPointerPosition();
        GetPanningPointer();
    }

    private void GetPointerPosition()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var position = GetMousePosition();
            if (position.HasValue)
                {
                    OnPointerDownHandler?.Invoke(position.Value);
                    position = null;
                }
        }

        if (Input.GetMouseButton(0))
        {
            var position = GetMousePosition();
            if (position.HasValue)
            {
                OnPointerChangeHandler?.Invoke(position.Value);
                position = null;
            }
        }
    }

    private Vector3? GetMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3? position = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask)) ;
        {
            position = hit.point - transform.position;
        }
        return position;
    }

    private void GetPanningPointer()
    {
        if (Input.GetMouseButton(1))
        {
            var position = Input.mousePosition;
            OnPointerSecondChangeHandler?.Invoke(position);
        }

        if (Input.GetMouseButtonUp(1))
        {
            OnPointerSecondUpHandler?.Invoke();
        }
    }

    public void AddListenerToPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler += listener;
    }

    public void AddListenerToPointerUpEvent(Action listener)
    {
        OnPointerUpHandler += listener;
    }

    public void AddListenerToPointerChangeEvent(Action<Vector3> listener)
    {
        OnPointerChangeHandler += listener;
    }

    public void RemoveListenerToPointerDownEvent(Action<Vector3> listener)
    {
        OnPointerDownHandler -= listener;
    }
    
    public void AddListenerToOnPointerSecondChangeEvent(Action<Vector3> listener)
    {
        OnPointerSecondChangeHandler += listener;
    }

    public void RemoveListenerToOnPointerSecondChangeEvent(Action<Vector3> listener)
    {
        OnPointerSecondChangeHandler -= listener;
    }
    
    public void AddListenerToOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler += listener;
    }

    public void RemoveListenerToOnPointerSecondUpEvent(Action listener)
    {
        OnPointerSecondUpHandler -= listener;
    }

    public void RemoveListenerToPointerUpEvent(Action listener)
    {
        OnPointerUpHandler -= listener;
    }

    public void RemoveListenerToPointerChangeEvent(Action<Vector3> listener)
    {
        OnPointerChangeHandler -= listener;
    }
}
