using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private Cube _prefab;
    [SerializeField] private ColorRandomizer _colorRandomizer;

    private int _divisor = 2;

    public List<Cube> Split(Cube parent)
    {
        int splitCount = Random.Range(_minCubes, _maxCubes + 1);
        List<Cube> childCubes = new List<Cube>();

        for (int i = 0; i < splitCount; i++)
        {
            float positionOffsetX = Random.Range(-parent.transform.localScale.x, parent.transform.localScale.x);
            float positionOffsetZ = Random.Range(-parent.transform.localScale.z, parent.transform.localScale.z);

            Vector3 positionOffsetRandom = new Vector3(positionOffsetX, 0f, positionOffsetZ);

            Vector3 position = parent.transform.position + positionOffsetRandom;

            Cube child = Instantiate(_prefab, position, Quaternion.identity);

            child.transform.localScale = parent.transform.localScale / _divisor;
            child.SetSplitChance(parent.SplitChance / _divisor);

            if (_colorRandomizer != null)
            {
                _colorRandomizer.SetColor(child);
            }

            childCubes.Add(child);
        }

        return childCubes;
    }
}