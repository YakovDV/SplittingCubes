using UnityEngine;

public class ColorRandomizer : MonoBehaviour
{
    public void SetColor(Cube gameObject)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
