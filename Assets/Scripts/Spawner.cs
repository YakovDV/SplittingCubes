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

            child = GenerateCubeStats(parent, child);

            childCubes.Add(child.Rigidbody);
        }

        return childCubes;
    }

    public void RemoveCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }

    private Vector3 CalculatePosition(Cube cube)
    {
        float positionOffsetX = Random.Range(-cube.transform.localScale.x, cube.transform.localScale.x);
        float positionOffsetZ = Random.Range(-cube.transform.localScale.z, cube.transform.localScale.z);

        Vector3 positionOffsetRandom = new(positionOffsetX, 0f, positionOffsetZ);

        Vector3 position = cube.transform.position + positionOffsetRandom;

        return position;
    }

    private Cube GenerateCubeStats(Cube parent, Cube child)
    {
        float newSplitChance = parent.SplitChance / _chanceDivisor;
        Vector3 newScale = parent.transform.localScale / _scaleDivisor;

        _colorChanger.ChangeColor(child);

        child.SetNewStats(newSplitChance, newScale);

        return child;
    }
}