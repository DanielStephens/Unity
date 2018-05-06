using UnityEngine;
using System.Collections;

[System.Serializable]
public class AspectRatio {

    [SerializeField]
    [Range(1, 100)]
    private int width = 1;

    [SerializeField]
    [Range(1, 100)]
    private int height = 1;

    public float ratio()
    {
        return (float)width / height;
    }

    public int Width { get { return width; } }

    public int Height { get { return height; } }

}
