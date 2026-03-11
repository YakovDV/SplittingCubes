using UnityEngine;
using System;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Cube _cube;

    public event Action<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.ButtonClicked += SearchCube;
    }

    private void OnDisable()
    {
        _inputReader.ButtonClicked -= SearchCube;
    }

    public void SearchCube(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                CubeHit?.Invoke(cube);
        }
    }
}