using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private Joystick _joystick;

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("DOWN  " + eventData.position);
        _joystick.OnDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("UP  " + eventData.position);
        _joystick.OnUp(eventData);
    }
}
