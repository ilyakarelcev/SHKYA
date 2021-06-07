using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class ThrowArrow : MonoBehaviour {

    public Transform Line;
    public Transform Arrow;
    public Transform Circle;
    public float MaxLength = 2f;

    public void Setup(Vector3 position, Vector3 direction) {
        Vector3 maxDirection = direction * MaxLength;
        transform.position = position;
        Arrow.localPosition = maxDirection;
        Circle.localPosition = -maxDirection;
        Arrow.right = maxDirection;
        Line.right = maxDirection;
        Line.localScale = new Vector3(maxDirection.magnitude * 1f, Line.localScale.y, 1f);
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

}
