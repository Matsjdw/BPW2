using UnityEngine;

public class ParallaxMouse : MonoBehaviour
{
    public Transform[] layers;  // Array of background layers
    public float[] speeds;      // Array of speeds for each layer
    public float mouseSensitivity = 1f;

    private Vector3 previousMousePosition;

    private void Start()
    {
        previousMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        float mouseXDelta = (Input.mousePosition.x - previousMousePosition.x) * mouseSensitivity;

        for (int i = 0; i < layers.Length; i++)
        {
            // Calculate parallax movement based on mouse movement
            float parallax = mouseXDelta * speeds[i];

            // Calculate target position for the layer
            float targetX = layers[i].position.x + parallax;

            // Create a target position vector
            Vector3 targetPosition = new Vector3(targetX, layers[i].position.y, layers[i].position.z);

            // Move the layer towards the target position
            layers[i].position = Vector3.Lerp(layers[i].position, targetPosition, Time.deltaTime);
        }

        // Update the previous mouse position for the next frame
        previousMousePosition = Input.mousePosition;
    }
}
