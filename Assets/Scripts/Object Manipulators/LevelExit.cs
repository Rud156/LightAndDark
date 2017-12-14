using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelExit : MonoBehaviour {

    public void SaveAndDisplayLoadingScene(int enemies) {
        LevelDataStore.currentLevel = LevelDataStore.currentLevel + 1;
        LevelDataStore.enemiesKilled = enemies;

        if (enemies > LevelDataStore.maxEnemiesKilled)
            LevelDataStore.maxEnemiesKilled = enemies;
        if (LevelDataStore.currentLevel > LevelDataStore.maxLevel)
            LevelDataStore.maxLevel = LevelDataStore.currentLevel;
        
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel() {
        float fadeTime = gameObject.GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }

    void OnTriggerEnter(Collider other) {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        int totalEnemies = other.GetComponent<DestroyEnemy>().destroyedEnemyCount;
        other.GetComponent<ForwardBack>().enabled = false;
        other.GetComponent<Jump>().enabled = false;
        other.GetComponent<ChangeMaterial>().enabled = false;
        target.velocity = Vector3.zero;

        SaveAndDisplayLoadingScene(totalEnemies);
    }
}
