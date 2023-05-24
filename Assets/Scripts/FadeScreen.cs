using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
  public Image Image;
  public static FadeScreen Instance;

  private void Awake()
  {
    if (Instance == null)
      Instance = this;
    else
      Destroy(gameObject);
  }

  private void Start() => Image.enabled = false;

  public void StartFade(float fadeTime) => StartCoroutine(FadeAnimation(fadeTime));

  IEnumerator FadeAnimation(float fadeTime)
  {
    Image.enabled = true;

    for (float f = 0; f < 1; f += Time.deltaTime / fadeTime)
    {
      Image.color = new Color(0, 0, 0, f);
      yield return null;
    }

    for (float f = 1; f > 0; f -= Time.deltaTime / fadeTime)
    {
      Image.color = new Color(0, 0, 0, f);
      yield return null;
    }

    Image.enabled = false;
  }
}