using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GameScenePostProcessing : MonoBehaviour
{
    private void Start()
    {
        PostProcessManager postProcessingManager = FindObjectOfType<PostProcessManager>();
        if (postProcessingManager != null)
        {
            postProcessingManager.AplicarPerfilGuardado();
        }
        else
        {
            Debug.LogWarning("PostProcessingManager no encontrado en la escena.");
        }
    }
}
