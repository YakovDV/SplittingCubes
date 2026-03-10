using UnityEngine;
using UnityEngine.Events;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Cube _cube;

    public event UnityAction<Cube> CubeHit;

    private void OnEnable()
    {
        _inputReader.ButtonClicked += SearchCube;
    }

    public void SearchCube(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);

        Cube cube = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cube = hit.collider.GetComponent<Cube>();

            if (cube != null)
            {
                CubeHit?.Invoke(cube);
            }
        }
    }

    private void OnDisable()
    {
        _inputReader.ButtonClicked -= SearchCube;
    }
}
