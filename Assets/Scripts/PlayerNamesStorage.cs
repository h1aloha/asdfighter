using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNamesStorage : MonoBehaviour
{
    public string player1Name;
    public string player2Name;

    public TextMeshProUGUI Player1InputField;
    public TextMeshProUGUI Player2InputField;

    public static PlayerNamesStorage instance;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        player1Name = Player1InputField.text;

        player2Name = Player2InputField.text;
    }
}
