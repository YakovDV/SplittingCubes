using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;

    public float SplitChance => _splitChance;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }

    public void SetNewStats(float chance, Vector3 scale)
    {
        _splitChance = chance;
        transform.localScale = scale;

        bool hasRenderer = TryGetComponent<Renderer>(out Renderer renderer);
    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }
}