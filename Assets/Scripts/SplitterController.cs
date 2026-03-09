using System.Collections.Generic;
using UnityEngine;

public class SplitterController : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    public void SplitCube(Cube cube)
    {
        if (cube != null && _exploder != null && _spawner != null)
        {
            float chance = Random.value;

            if (chance <= cube.SplitChance)
            {
                List<Cube> newCubes = _spawner.Split(cube);
                _exploder.Explode(newCubes, cube.transform.position);
            }

            Destroy(cube.gameObject);
        }
    }
}