using UnityEngine;
using System.Collections;

[System.Serializable]
public class WidthHeightMerger {

    [SerializeField]
    [Range(-1f, 1f)]
    private float merge = 0f;

    public float Merge
    {
        get { return merge; }
        set { merge = value; }
    }

}
