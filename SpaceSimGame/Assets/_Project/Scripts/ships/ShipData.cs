using System.Collections.Generic;
using UnityEngine;

public class ShipData : MonoBehaviour
{
    public float OrbitDistance {get;set;} = 15f;
    public float ApproachSpeed {get;set;} = 10f;
    
    public Transform Target {get;set;} = null;   // Selected target
    private List<Transform> Targets {get;set;} = new();    // Targets


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearTargets()
    {
        Targets.Clear();
    }

}
