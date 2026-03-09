using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ExplodeAssistant _explodeAssistant;

    public void Explode(Vector3 explosionCenter, List<Rigidbody> cubes = null)
    {
        if (cubes == null)
        {
            cubes = _explodeAssistant.GetExplodableObjects(explosionCenter);
        }

        float explosionRadius = _explodeAssistant.ExposionRadius;

        foreach (Rigidbody cube in cubes)
        {
            float force = _explodeAssistant.CalculateExlosionStats(explosionCenter, cube.transform.position, cube.transform.localScale, out explosionRadius);

            cube.AddExplosionForce(force, explosionCenter, explosionRadius);
        }
    }
}