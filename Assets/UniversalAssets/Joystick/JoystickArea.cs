using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private Joystick _joystick;

    public void OnPointerDown(PointerEventData eventData) {
        _joystick.OnDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        _joystick.OnUp(eventData);
    }
}
