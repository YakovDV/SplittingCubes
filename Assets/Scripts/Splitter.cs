using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.CubeHit += SplitCube;
    }

    public void SplitCube(Cube cube)
    {
        if (cube != null && _exploder != null && _spawner != null)
        {
            float chance = Random.value;

            if (chance <= cube.SplitChance)
            {
                List<Rigidbody> newCubes = _spawner.Spawn(cube);
                _exploder.Explode(cube, newCubes);
            }
            else
            {
                _exploder.Explode(cube);
            }

            _spawner.RemoveCube(cube);
        }
    }

    private void OnDisable()
    {
        _raycaster.CubeHit -= SplitCube;
    }
}