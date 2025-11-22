using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControle : MonoBehaviour
{
    private Camera _camera;
    public Transform alvo;

    public float suavizar = 0.125f;

    //quanto menor mais zoom
    public float zoom = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographic = true;
        _camera.orthographicSize = zoom;
    }

    void LateUpdate()
    {
        if (alvo == null) return;

        Vector3 novapos = new(alvo.position.x, alvo.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, novapos, suavizar);
        
    }
}
