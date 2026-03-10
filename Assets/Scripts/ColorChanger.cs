using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Cube cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();

        renderer.material.color = Random.ColorHSV();
    }
}