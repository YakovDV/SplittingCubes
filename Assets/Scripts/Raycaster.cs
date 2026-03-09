using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Splitter _splitterController;

    public Cube SearchCube()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Cube cube = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.TryGetComponent<Cube>(out cube);
        }

        return cube;
    }
}
