using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class OrbitRenderer : MonoBehaviour
{
    
    public float radius = 10f;
    public int segments = 100;
    private LineRenderer line;
    public Planet planet;
    void Start()
    {
        planet = GetComponentInParent<Planet>();
        if (planet == null)
        {
            Debug.LogError("OrbitRenderer could not find Planet component in parent.");
            return;
        }
        if(planet.distanceFromSun == 0) planet.setDistanceFromSun();
        radius = planet.getDistanceFromSun();

        line = GetComponent<LineRenderer>();
        line.positionCount = segments;
        line.loop = true;

        DrawOrbit();
    }

    void OnValidate()
    {
        planet = GetComponentInParent<Planet>();
        if (planet == null) return;

        radius = planet.getDistanceFromSun();

        line = GetComponent<LineRenderer>();
        if (line == null) return;

        line.positionCount = segments;
        line.loop = true;

        DrawOrbit();
    }

    void DrawOrbit()
    {
        for (int i = 0; i < segments; i++)
        {
            float angle = (float)i / segments * Mathf.PI * 2f;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, z));
        }
    }
}