using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public TextMeshProUGUI textContent;

    void Start() {
        LevelDataStore.maxLevel = PlayerPrefs.GetInt("MaxLevel");
        LevelDataStore.maxEnemiesKilled = PlayerPrefs.GetInt("MaxEnemies");
        textContent.SetText("Highest Level Achieved: {0} \n\n\nMaximum Enemies Killed: {1}", 
            LevelDataStore.maxLevel, LevelDataStore.maxEnemiesKilled);
    }

    public void PlayGame() {
        LevelDataStore.currentLevel = 1;
        LevelDataStore.enemiesKilled = 0;
        LevelDataStore.playerDead = false;

        LevelDataStore.currentLevelMinGrounds = LevelDataStore.currentLevel + LevelDataStore.minGrounds;
        LevelDataStore.currentLevelMaxGrounds = LevelDataStore.currentLevel * 2 + LevelDataStore.minGrounds;

        SceneManager.LoadScene(2);
    }

    public void QuitGame() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
