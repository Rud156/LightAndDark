using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour {

    public Text levelMessageText;
    public Text levelDataText;

    // Use this for initialization
    void Start() {
        LevelDataStore.playerBuffActive = false;

        PlayerPrefs.SetInt("MaxLevel", LevelDataStore.maxLevel);
        PlayerPrefs.SetInt("MaxEnemies", LevelDataStore.maxEnemiesKilled);

        if (LevelDataStore.playerDead) {
            levelMessageText.text = "You Died. Returning Home";
            levelDataText.text = "";
            StartCoroutine(LoadNewScene(0));
        } else {
            levelMessageText.text = "Loading Level " + LevelDataStore.currentLevel.ToString() + " ...";
            levelDataText.text = "Enemies Killed: " +
            LevelDataStore.enemiesKilled.ToString() + "\n" +
            "Max Enemies Killed: " + LevelDataStore.maxEnemiesKilled.ToString();
            StartCoroutine(LoadNewScene(1));
        }
    }

    IEnumerator LoadNewScene(int sceneNumber) {
        yield return new WaitForSeconds(3);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneNumber);
        while (!async.isDone)
            yield return null;
    }
}
