using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Rigidbody _rigidbody;

    public float ExposionRadius => _explosionRadius;
    public float ExposionForce => _explosionForce;
    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetNewStats(float chance, Vector3 scale)
    {
        _splitChance = chance;
        transform.localScale = scale;
    }
}