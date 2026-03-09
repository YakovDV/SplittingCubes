using System;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAssistant : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float ExposionRadius => _explosionRadius;
    public float ExposionForce => _explosionForce;

    public List<Rigidbody> GetExplodableObjects(Vector3 center)
    {
        Collider[] hits = Physics.OverlapSphere(center, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }

    public float CalculateExlosionStats(Vector3 center, Vector3 position, Vector3 scale, out float radius)
    {
        float distance = Convert.ToSingle(Math.Sqrt((Math.Pow((center.x - position.x), 2)
    + (Math.Pow((center.y - position.y), 2))
    + (Math.Pow((center.z - position.z), 2)))));

        float sizeModificator = 1f / scale.magnitude;

        float force = _explosionForce;

        if (distance != 0)
        {
            force = _explosionForce / distance * sizeModificator;
        }

        radius = _explosionRadius * sizeModificator;

        return force;
    }
}