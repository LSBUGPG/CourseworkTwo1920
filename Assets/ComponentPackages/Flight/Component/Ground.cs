using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public FlightControl flight;
    public float scale = 0.01f;
    Material material;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        material = new Material(renderer.material);
        renderer.material = material;
    }

    void Update()
    {
        Vector4 tiling = material.GetVector("_MainTex_ST");
        tiling.w = Time.time * flight.maxSpeed * scale;
        material.SetVector("_MainTex_ST", tiling);
    }

    void OnDestroy()
    {
        Destroy(material);
    }
}
