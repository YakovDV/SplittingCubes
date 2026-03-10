using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void Explode(Cube cube, List<Rigidbody> cubesToExplode = null)
    {
        float sizeModificator = 1f / cube.transform.localScale.magnitude;
        float force = cube.ExposionForce * sizeModificator;
        float radius = cube.ExposionRadius * sizeModificator;

        Vector3 center = cube.transform.position;

        if (cubesToExplode == null)
        {
            cubesToExplode = GetExplodableObjects(center, radius);
        }

        foreach (Rigidbody cubeToExplode in cubesToExplode)
        {
            cubeToExplode.AddExplosionForce(force, center, radius);
        }
    }

    public List<Rigidbody> GetExplodableObjects(Vector3 center, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(center, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}