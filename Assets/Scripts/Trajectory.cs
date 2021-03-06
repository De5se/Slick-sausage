using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private Transform startObject;

    Vector3 origin;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Show(Vector3 speed)
	{
        origin = startObject.position;
        Vector3[] points = new Vector3[15];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;

        }

        lineRenderer.SetPositions(points);
    }
    public void Hide()
    {
        lineRenderer.enabled = false;
    }

    public void ShowLine()
    {
        lineRenderer.enabled = true;
    }

}
