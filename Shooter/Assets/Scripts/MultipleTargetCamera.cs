using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public Camera camera;

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;

        camera.orthographicSize = 
    }

    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;
        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.5f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.5f;
        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        camera.orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);
    }
}
