using UnityEngine;

public class TargetFrameRate : MonoBehaviour {

    [SerializeField] private int _targetFrameRate = 60;

    void Start() {
#if UNITY_EDITOR
        Application.targetFrameRate = _targetFrameRate;
#endif
    }


}
