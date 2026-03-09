using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public void SetColor(Cube gameObject)
    {
        if (gameObject != null)
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            renderer.material.color = Random.ColorHSV();
        }
    }
}
