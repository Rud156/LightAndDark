using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour {
    public float decreaseMultiplier = 14;
    public float startHealth = 100;
    public Image healthBar;
    public GameObject healthEffect;
    public float heightFromTop = 0.5f;

    public GameObject playerCanvas;
    public GameObject playerDeathEffect;
    public Material lightMaterial;
    public Material darkMaterial;

    private int playerColor;
    private float currentHealth;

    void Start() {
        currentHealth = startHealth;
    }

    void Update() {
        if (LevelDataStore.playerDead)
            return;

        if (currentHealth < 0 || gameObject.transform.position.y < -10) {
            LevelDataStore.playerDead = true;
            gameObject.GetComponent<ForwardBack>().enabled = false;
            gameObject.GetComponent<Jump>().enabled = false;
            gameObject.GetComponent<ChangeMaterial>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            playerCanvas.SetActive(false);
            StartCoroutine(ActivateChangeLevel());
        }
        if (currentHealth < 0) {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            GameObject deathEffect = Instantiate(playerDeathEffect, gameObject.transform.position, playerDeathEffect.transform.rotation);
            if (playerColor == 13)
                deathEffect.GetComponent<Renderer>().material = lightMaterial;
            else
                deathEffect.GetComponent<Renderer>().material = darkMaterial;
        }
    }

    public void SetPlayerColor(int color) {
        playerColor = color;
    }

    public void DecreasePlayerHealth(float amount) {
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / startHealth;
    }

    public void IncreasePlayerHealth(float amount) {
        currentHealth = currentHealth + amount > 100 ? 100 : currentHealth + amount;
        healthBar.fillAmount = currentHealth / startHealth;

        Vector3 spawnPoint = gameObject.transform.position;

        GameObject health = Instantiate(healthEffect, 
                                new Vector3(spawnPoint.x, spawnPoint.y - heightFromTop, spawnPoint.z),
                                healthEffect.transform.rotation
                            ) as GameObject;
        health.transform.parent = gameObject.transform;
    }

    IEnumerator ActivateChangeLevel() {
        yield return new WaitForSeconds(3);
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel() {
        float fadeTime = gameObject.GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(2);
    }
}