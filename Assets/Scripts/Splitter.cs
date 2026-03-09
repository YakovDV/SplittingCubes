using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    public void SplitCube()
    {
        Cube cube = _raycaster.SearchCube();

        if (cube != null && _exploder != null && _spawner != null)
        {
            float chance = Random.value;

            if (chance <= cube.SplitChance)
            {
                List<Rigidbody> newCubes = _spawner.Spawn(cube);
                _exploder.Explode(cube.transform.position, newCubes);
            }

            _exploder.Explode(cube.transform.position);
            Destroy(cube.gameObject);
        }
    }
}
