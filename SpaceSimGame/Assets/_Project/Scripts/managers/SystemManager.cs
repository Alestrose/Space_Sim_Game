using UnityEngine;

public class SystemManager : MonoBehaviour
{
    [System.Serializable]
    public class PlanetData
    {
        public Transform planet;
        public float distanceFromSun;
    }

    public PlanetData[] planets;

    public float orbitSpeedMultiplier = 50f;

    void Start()
    {
        foreach (PlanetData p in planets)
        {
            if (p.planet == null) continue;

            // Set planet position on X axis relative to sun
            p.planet.position = new Vector3(p.distanceFromSun, 0f, 0f);

            // Set orbit speed based on distance
            PlanetController controller = p.planet.GetComponent<PlanetController>();

            if (controller != null)
            {
                controller.orbitSpeed = orbitSpeedMultiplier / p.distanceFromSun;
            }
        }
    }
}