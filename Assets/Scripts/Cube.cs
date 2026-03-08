using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance = 1f;

    public float SplitChance => _splitChance;

    public void SetSplitChance(float chance)
    {
        _splitChance = chance;
    }
}