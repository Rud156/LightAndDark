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
    public Slider chargeSlider;
    public float lerpRate = 0.7f;
    public GameObject playerDeathEffect;
    public Material lightMaterial;
    public Material darkMaterial;

    public GameObject meteorShowerObject;

    public GameObject enterText;

    public AudioSource audioSource;
    public AudioClip healthSound;
    public AudioClip playerDeathSound;
    public AudioClip enemyKilledSound;
    public AudioClip powerUpSound;
    public AudioClip warningSound;

    private int playerColor;
    private float currentHealth;
    private float chargeAmount;
    private int destroyedEnemyCount;
    private int powerUpType;
    // 0 - Nothing, 1 - Shield, 2 - Major Power

    private bool meteorShower;
    private float endingGroundPosition;
    private float midPoint;
    private bool meteorShowerSpawned;

    void Start() {
        currentHealth = startHealth;
        chargeAmount = 0;
        destroyedEnemyCount = 0;
        powerUpType = 0;

        meteorShowerSpawned = false;
        meteorShower = Random.value <= LevelDataStore.currentLevel / 10 ? true : false;
        endingGroundPosition = GameObject.Find("Ending Ground(Clone)").transform.position.z;
        midPoint = endingGroundPosition / 2;
    }

    void Update() {

        float fillAmount = healthBar.fillAmount;
        if(fillAmount <= 0.5)
        {
            Color color = Color.Lerp(Color.red, Color.yellow, fillAmount);
            healthBar.color = color;
        }
        else
        {
            Color color = Color.Lerp(Color.yellow, Color.green, fillAmount);
            healthBar.color = color;
        }

        if (gameObject.transform.position.z >= midPoint && !meteorShowerSpawned && meteorShower) {
            meteorShowerSpawned = true;
            GameObject meteors = Instantiate(
                                     meteorShowerObject, 
                                     new Vector3(
                                         gameObject.transform.position.x, 
                                         10,
                                         gameObject.transform.position.z
                                     ),
                                     meteorShowerObject.transform.rotation
                                 );
            meteors.transform.parent = gameObject.transform;
            meteors.GetComponent<MeteorShower>().SetPlayer(gameObject);
            audioSource.clip = warningSound;
            audioSource.Play();
        }
        
        float mappedCharge = LevelDataStore.Map(chargeAmount, 0, 100, 0, 1);
        chargeSlider.value = Mathf.Lerp(chargeSlider.value, mappedCharge, lerpRate * Time.deltaTime);


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

            audioSource.clip = playerDeathSound;
            audioSource.Play();

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

    public void IncrementChargeAmount(float amount) {
        chargeAmount = chargeAmount + amount > 100 ? 100 : chargeAmount + amount;
        if (chargeAmount >= 50)
            enterText.SetActive(true);
    }

    public void DecrementChargeAmount(float amount) {
        chargeAmount = chargeAmount - amount < 0 ? 0 : chargeAmount - amount;
        if (chargeAmount < 50)
            enterText.SetActive(false);
    }

    public float GetChargeAmount() {
        return chargeAmount;
    }

    public void EnemyKilled() {
        audioSource.clip = enemyKilledSound;
        audioSource.Play();
        destroyedEnemyCount += 1;
    }

    public int GetEnemyCount() {
        return destroyedEnemyCount;
    }

    public void SetPlayerColor(int color) {
        playerColor = color;
    }

    public int GetPlayerColor() {
        return playerColor;
    }

    public void SetPowerUpType(int type) {
        audioSource.clip = powerUpSound;
        audioSource.Play();
        LevelDataStore.playerBuffActive = true;
        powerUpType = type;
    }

    public void UnsetPowerUpType(int type) {
        if (type == powerUpType) {
            powerUpType = 0;
            LevelDataStore.playerBuffActive = false;
        }
    }

    public void DecreasePlayerHealth(float amount) {
        if (LevelDataStore.playerBuffActive)
            return;
        
        currentHealth -= amount;
        healthBar.fillAmount = currentHealth / startHealth;
    }

    public void IncreasePlayerHealth(float amount) {
        audioSource.clip = healthSound;
        audioSource.Play();
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