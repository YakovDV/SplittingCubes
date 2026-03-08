using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private Cube _prefab;
    [SerializeField] private ColorRandomizer _colorRandomizer;
    [SerializeField] private Exploder _exploder;

    private int _decreaser = 2;
    private List<Rigidbody> _cubesToExplode = new List<Rigidbody>();

    private void OnMouseDown()
    {
        float chance = Random.value;

        if (chance <= _prefab.SplitChance)
        {
            int splitCount = Random.Range(_minCubes, _maxCubes + 1);

            for (int i = 0; i < splitCount; i++)
            {
                float positionOffsetX = Random.Range(-_prefab.transform.localScale.x, _prefab.transform.localScale.x);
                float positionOffsetZ = Random.Range(-_prefab.transform.localScale.z, _prefab.transform.localScale.z);

                Vector3 positionOffsetRandom = new Vector3(positionOffsetX, _prefab.transform.position.y, positionOffsetZ);

                Vector3 position = _prefab.transform.position + positionOffsetRandom;

                Cube child = Instantiate(_prefab, position, Quaternion.identity);

                child.transform.localScale = _prefab.transform.localScale / _decreaser;
                child.SetSplitChance(_prefab.SplitChance / 2);

                _colorRandomizer.SetColor(child);
                _cubesToExplode.Add(child.GetComponent<Rigidbody>());
            }

            _exploder.Explode(_cubesToExplode, _prefab);
        }

        Destroy(gameObject);
    }
}
