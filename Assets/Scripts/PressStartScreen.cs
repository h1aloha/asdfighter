using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PressStartScreen : MonoBehaviour
{
    public GameObject buttonContainer;
    public float blinkInterval = 0.5f;

    private TextMeshProUGUI pressStartText;
    private bool hasStarted;

    private void Start()
    {
        if (PlayerPrefs.GetInt("HasStarted", 0) == 1)
        {
            Destroy(buttonContainer);
            hasStarted = true; // Marcar como comenzado si ya se ha iniciado antes
        }
        else
        {
            hasStarted = false;
            buttonContainer.SetActive(true);
            pressStartText = buttonContainer.GetComponentInChildren<TextMeshProUGUI>();
            if (pressStartText != null)
                StartCoroutine(BlinkText());
        }
    }

    private void Update()
    {
        if (!hasStarted && Input.anyKeyDown)
        {
            hasStarted = true;
            PlayerPrefs.SetInt("HasStarted", 1);
            PlayerPrefs.Save();
            Destroy(buttonContainer);
        }
    }

    private IEnumerator BlinkText()
    {
        while (!hasStarted)
        {
            if (pressStartText != null)
                pressStartText.enabled = !pressStartText.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
        if (pressStartText != null)
            pressStartText.enabled = true;
    }

    private void OnApplicationQuit()
    {
        ResetHasStarted();
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            ResetHasStarted();
        }
    }

    private void ResetHasStarted()
    {
        PlayerPrefs.SetInt("HasStarted", 0);
        PlayerPrefs.Save();
    }
}
