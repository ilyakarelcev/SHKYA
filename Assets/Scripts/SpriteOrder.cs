using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class SpriteOrder : MonoBehaviour
{

    public Transform Parent;
    public SpriteRenderer[] AllSprites;
    public List<SpriteRenderer> SortedSprites;

    [ContextMenu("GetAllSprites")]
    public void GetAllSprites() {
        AllSprites = Parent.GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Application.isPlaying) return;
        SortedSprites = AllSprites.ToList().OrderBy(x => x.transform.position.z).ToList();
        for (int i = 0; i < SortedSprites.Count; i++)
        {
            SortedSprites[i].sortingOrder = SortedSprites.Count - i;
        }
    }
}
