using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class PostProcessManager : MonoBehaviour
{
    public PostProcessProfile[] profiles;
    public TMP_Dropdown profileDropdown;

    private PostProcessVolume currentVolume;
    private static PostProcessManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Encuentra o crea el PostProcessVolume en la escena
        SetUpPostProcessVolume();
       
        AplicarPerfilGuardado();

        // Configurar el dropdown para reflejar el perfil guardado, si el dropdown está presente
        if (profileDropdown != null)
        {
            int savedProfileIndex = PlayerPrefs.GetInt("SelectedProfileIndex", 0);
            profileDropdown.value = savedProfileIndex;
            profileDropdown.onValueChanged.AddListener(CambiarPerfil);
        }
    }

    private void SetUpPostProcessVolume()
    {
        currentVolume = FindObjectOfType<PostProcessVolume>();
        if (currentVolume == null)
        {
            GameObject volumeGameObject = new GameObject("PostProcessVolume");
            currentVolume = volumeGameObject.AddComponent<PostProcessVolume>();
            currentVolume.isGlobal = true;
            DontDestroyOnLoad(volumeGameObject);  // Asegurar que el PostProcessVolume persiste entre escenas
        }
    }

    public void CambiarPerfil(int profileIndex)
    {
        if (profileIndex >= 0 && profileIndex < profiles.Length)
        {
            AplicarPerfil(profiles[profileIndex]);
            
            PlayerPrefs.SetInt("SelectedProfileIndex", profileIndex);
        }
        else
        {
            Debug.LogWarning("Índice de perfil fuera de rango");
        }
    }

    private void AplicarPerfil(PostProcessProfile profile)
    {
        if (currentVolume != null)
        {
            currentVolume.profile = profile;
        }
    }

    public void AplicarPerfilGuardado()
    {
        int profileIndex = PlayerPrefs.GetInt("SelectedProfileIndex", 0);
        if (profileIndex >= 0 && profileIndex < profiles.Length)
        {
            AplicarPerfil(profiles[profileIndex]);
        }
        else
        {
            Debug.LogWarning("Índice de perfil guardado fuera de rango, aplicando perfil por defecto");
            AplicarPerfil(profiles[0]); // Aplicar perfil por defecto
        }
    }
}
