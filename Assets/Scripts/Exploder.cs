using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> objects, Cube explodingObject)
    {
        foreach (Rigidbody explodableObjects in objects)
            explodableObjects.AddExplosionForce(_explosionForce, explodingObject.transform.position, _explosionRadius);
    }
}
