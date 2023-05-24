using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ExampleClass : MonoBehaviour
{
// #if UNITY_EDITOR 
//     [MenuItem("Example/Example1", false, 100)]
// #endif

    public static void Example1() {
        print("Example/Example1");
    }

// #if UNITY_EDITOR 
//     [MenuItem("Example/Example2", false, 100)]
// #endif
//     public static void Example2() {
//         print("Example/Example2");
//     }
}
