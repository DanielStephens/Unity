using UnityEngine;

[RequireComponent(typeof(Camera))]
public class AspectAdjuster : MonoBehaviour {

    [SerializeField]
    private WidthHeightMerger maintainView = new WidthHeightMerger();

    [SerializeField]
    private VerticalGravity verticalGravity = new VerticalGravity();

    [SerializeField]
    private HorizontalGravity horizontalGravity = new HorizontalGravity();

    [SerializeField]
    private AspectRatio designAspectRatio;

    private Camera cam;

    private float designVerticalFieldOfView;

    private float designHorizontalFieldOfView;

    void Start () {
        cam = GetComponent<Camera>();
        designVerticalFieldOfView = cam.fieldOfView;
        designHorizontalFieldOfView = calcHorizontalFov(cam.fieldOfView, designAspectRatio.ratio());
    }

    public void OffsetCamera()
    {
        float currentAspect = cam.aspect;

        float maintainHeightFov = designVerticalFieldOfView;
        float maintainWidthFov = calcVerticalFov(designHorizontalFieldOfView, currentAspect);

        float fov = Mathf.Lerp(maintainWidthFov, maintainHeightFov, (maintainView.Merge + 1) / 2);

        float verticalRotation = verticalGravity.Gravity * (fov - designVerticalFieldOfView) / 2;
        float horizontalRotation = horizontalGravity.Gravity * (calcHorizontalFov(fov, currentAspect) - designHorizontalFieldOfView) / 2;

        Transform t = cam.transform;
        Quaternion rotation = (Quaternion.AngleAxis(verticalRotation, t.right)) * (Quaternion.AngleAxis(horizontalRotation, t.up));

        cam.fieldOfView = fov;
        t.rotation *= rotation;
    }

    private float calculateFovForConstantWidth()
    {
        return (cam.fieldOfView * designAspectRatio.ratio()) / cam.aspect;
    }

    private float calcVerticalFov(float horizontalFov, float aspectRatio)
    {
        float hFovInRads = horizontalFov * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }

    private float calcHorizontalFov(float verticalFov, float aspectRatio)
    {
        float vFovInRads = verticalFov * Mathf.Deg2Rad;
        float hFovInRads = 2 * Mathf.Atan(Mathf.Tan(vFovInRads / 2) * aspectRatio);
        return hFovInRads * Mathf.Rad2Deg;
    }

}
