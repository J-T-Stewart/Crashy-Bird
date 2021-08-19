using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

    private Button button;
    private GameManager gameManager;

    public string difficulty;

    void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty() {
        gameManager.difficulty = difficulty;
        gameManager.GameStart();
    }
}
