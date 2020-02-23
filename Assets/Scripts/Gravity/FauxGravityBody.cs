using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public int radius;
    public LayerMask mask;
    private FauxGravityAttractor attractor;
    private Transform myTransform;
    private CharacterController charCtrl;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }

    GameObject getClosestPlanet()
    {
        GameObject closest_planet = null;
        Vector3 origin = transform.position;
        float min_dist = float.MaxValue;
        float hit_dist = 0;

        var hits = Physics.SphereCastAll(origin, radius, transform.forward);
        if (hits.Length > 0)
        {
            foreach(var hit in hits) {
                if (hit.transform.gameObject.layer != 8)
                    continue;
                hit_dist = Vector3.Distance(transform.position, hit.transform.position);
                if (min_dist > hit_dist) {
                    min_dist = hit_dist;
                    closest_planet = hit.transform.gameObject;
                }
            }
            return closest_planet;
        }
        return(null);
    }

    void Update()
    {
        var closest_planet = getClosestPlanet();
        FauxGravityAttractor closest_planet_attractor;
        if (closest_planet != null)
            closest_planet_attractor = closest_planet.GetComponent<FauxGravityAttractor>();
        else {
            attractor = null;
            return;
        }
        if (attractor != closest_planet_attractor)
            attractor = closest_planet_attractor;
        if (attractor != null)
            attractor.Attract(myTransform);  
    }
}
