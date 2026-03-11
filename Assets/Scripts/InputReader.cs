using UnityEngine;
using System;

public class InputReader : MonoBehaviour
{
    [SerializeField] private int _button = 0;
    public event Action<Vector3> ButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_button))
        {
            Vector3 position = Input.mousePosition;
            ButtonClicked?.Invoke(position);
        }
    }
}