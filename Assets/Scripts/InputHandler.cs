using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _splitter.SplitCube();
        }
    }
}