using System;
using UnityEngine;

public interface IInputManager
{
    void AddListenerToPointerDownEvent(Action<Vector3> listener);
    void AddListenerToPointerUpEvent(Action listener);
    void AddListenerToPointerChangeEvent(Action<Vector3> listener);
    void RemoveListenerToPointerDownEvent(Action<Vector3> listener);
    void AddListenerToOnPointerSecondChangeEvent(Action<Vector3> listener);
    void RemoveListenerToOnPointerSecondChangeEvent(Action<Vector3> listener);
    void AddListenerToOnPointerSecondUpEvent(Action listener);
    void RemoveListenerToOnPointerSecondUpEvent(Action listener);
    void RemoveListenerToPointerUpEvent(Action listener);
    void RemoveListenerToPointerChangeEvent(Action<Vector3> listener);

}
