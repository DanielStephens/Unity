using UnityEngine;
using System.Collections;

[System.Serializable]
public class VerticalGravity {

    [SerializeField]
    [Range(-1f, 1f)]
    private float gravity = 0f;

    public float Gravity
    {
        get { return gravity; }
        set { gravity = value; }
    }

}
