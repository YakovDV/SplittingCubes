using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private Cube _prefab;
    [SerializeField] private ColorChanger _colorChanger;

    private int _scaleDivisor = 2;
    private int _chanceDivisor = 2;

    public List<Rigidbody> Spawn(Cube parent)
    {
        int splitCount = Random.Range(_minCubes, _maxCubes + 1);
        List<Rigidbody> childCubes = new();

        for (int i = 0; i < splitCount; i++)
        {
            Vector3 position = CalculatePosition(parent);

            Cube child = Instantiate(_prefab, position, Quaternion.identity);

            float newSplitChance = parent.SplitChance / _chanceDivisor;
            Vector3 newScale = parent.transform.localScale / _scaleDivisor;

            _colorChanger.ChangeColor(child);

            child.SetNewStats(newSplitChance, newScale);

            Rigidbody childRigidbody = child.Rigidbody;

            childCubes.Add(childRigidbody);
        }

        return childCubes;
    }

    public void RemoveCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private Vector3 CalculatePosition(Cube baseCube)
    {
        float positionOffsetX = Random.Range(-baseCube.transform.localScale.x, baseCube.transform.localScale.x);
        float positionOffsetZ = Random.Range(-baseCube.transform.localScale.z, baseCube.transform.localScale.z);

        Vector3 positionOffsetRandom = new(positionOffsetX, 0f, positionOffsetZ);

        Vector3 position = baseCube.transform.position + positionOffsetRandom;

        return position;
    }
}