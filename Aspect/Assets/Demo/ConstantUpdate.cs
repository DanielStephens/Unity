using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AspectAdjuster))]
public class ConstantUpdate : MonoBehaviour {

    private AspectAdjuster aspectAdjuster;

    private Transform t;

    void Start () {
        aspectAdjuster = GetComponent<AspectAdjuster>();
        t = transform;
	}
	
	void Update () {
        t.rotation = Quaternion.identity;
        aspectAdjuster.OffsetCamera();
	}
}
