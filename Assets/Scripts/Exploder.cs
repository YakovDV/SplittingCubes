using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> cubes, Vector3 explosionCenter)
    {
        foreach (Rigidbody cube in cubes)
        {
            cube.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}
