using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private SplitterController _splitterController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                Cube cube = hit.collider.GetComponent<Cube>();

                if (cube != null && _splitterController != null)
                    _splitterController.SplitCube(cube);

            }
        }
    }
}
