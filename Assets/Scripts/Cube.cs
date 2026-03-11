using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float ExposionRadius => _explosionRadius;
    public float ExposionForce => _explosionForce;
    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public void SetNewStats(float chance, Vector3 scale)
    {
        _splitChance = chance;
        transform.localScale = scale;
    }
}