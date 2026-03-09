using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float radius = 1000f;
    public float gravity = 9.8f;
    public float rotationSpeed = 3f;
    public float distanceFromSun;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setDistanceFromSun();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    void OnValidate()
    {
        setDistanceFromSun();
    }

    public void setDistanceFromSun()
    {
        distanceFromSun = new Vector2(transform.position.x, transform.position.z).magnitude;
    }

    public float getDistanceFromSun()
    {
        return distanceFromSun;
    }
}
