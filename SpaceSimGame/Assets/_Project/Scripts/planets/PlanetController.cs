using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float orbitSpeed;   // degrees per second
    public Vector3 orbitAxis = Vector3.up;

    public Planet planet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        planet = GetComponent<Planet>();
        planet.setDistanceFromSun();
        if(planet != null && planet.getDistanceFromSun() != 0)
        {
            orbitSpeed = 100f / planet.getDistanceFromSun();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}
