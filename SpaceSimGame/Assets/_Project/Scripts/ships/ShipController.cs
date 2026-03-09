using UnityEngine;

[RequireComponent(typeof(ShipData))]
public class ShipController : MonoBehaviour
{
    public float OrbitSpeed {get;set;} = 10f;

    private ShipData data;

    private enum ShipState
    {
        Idle,
        Approaching,
        Orbiting
    }

    private ShipState state = ShipState.Idle;

    void Start()
    {
        data = GetComponent<ShipData>();
    }

    void Update()   // State based logic
    {
        if (data.Target == null) return;

        switch (state)
        {
            case ShipState.Approaching:
                DoApproach();
                break;

            case ShipState.Orbiting:
                DoOrbit();
                break;
        }
    }

    public void ApproachTarget()    // Sets ship state from ui command to approach
    {
        state = ShipState.Approaching;
    }

    public void OrbitTarget()       // If in orbit range set state to orbit, else set state to approach
    {
        if (data.Target == null) return;

        Vector3 direction = (transform.position - data.Target.position).normalized;
        Vector3 orbitPoint = data.Target.position + direction * data.OrbitDistance;

        float distanceToOrbit = Vector3.Distance(transform.position, orbitPoint);

        if (distanceToOrbit > 1f)
        {
            state = ShipState.Approaching;
        }
        else
        {
            state = ShipState.Orbiting;
        }
    }

    public void Stop()              // Sets ship state from ui command
    {
        state = ShipState.Idle;
    }

    private void DoApproach()       // Approach target. Keeps ship facing direction of approach
    {
        Vector3 directionFromTarget = (transform.position - data.Target.position).normalized;
        Vector3 orbitPoint = data.Target.position + directionFromTarget * data.OrbitDistance;

        Vector3 moveDirection = (orbitPoint - transform.position).normalized;

        transform.position += moveDirection * data.ApproachSpeed * Time.deltaTime;

        transform.forward = moveDirection;

        float distance = Vector3.Distance(transform.position, orbitPoint);

        if (distance < 0.5f)
        {
            state = ShipState.Orbiting;
        }
    }

    private void DoOrbit()          // Orbit target. Keeps ship facing direction of approach
    {
        Transform target = data.Target;

        transform.RotateAround(
            target.position,
            Vector3.up,
            OrbitSpeed * Time.deltaTime
        );

        Vector3 direction = transform.position - target.position;
        Vector3 tangent = Vector3.Cross(Vector3.up, direction).normalized;

        transform.forward = tangent;
    }
    
}