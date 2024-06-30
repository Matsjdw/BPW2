using UnityEngine;
using UnityEngine.UI;

public class VFXController : MonoBehaviour
{
    public ParticleSystem vfx;  // Drag and drop your VFX Particle System into this field in the Unity Editor
    public Button startButton;  // Drag and drop your Button into this field in the Unity Editor

    private void Start()
    {
        // Ensure the button has a Click event assigned
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartVFX);
        }
        else
        {
            Debug.LogError("Please assign the Button for starting the VFX in the Unity Editor.");
        }
    }

    private void StartVFX()
    {
        // Check if the VFX Particle System is assigned
        if (vfx != null)
        {
            // Play the VFX
            vfx.Play();
        }
        else
        {
            Debug.LogError("Please assign the VFX Particle System in the Unity Editor.");
        }
    }
}
