using UnityEngine;

public class TargetFrameRate : MonoBehaviour {

#if UNITY_EDITOR
    [SerializeField] private int _targetFrameRate = 60;
    void Start() {
        Application.targetFrameRate = _targetFrameRate;
    }
#endif

}
