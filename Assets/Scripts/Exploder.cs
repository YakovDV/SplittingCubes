using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Cube> cubes, Vector3 explosionCenter)
    {
        foreach (Cube cube in cubes)
        {
            Rigidbody cubeExplodable = cube.GetComponent<Rigidbody>();

            cubeExplodable.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}
