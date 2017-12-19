using UnityEngine;

public class DestroyEnemy : MonoBehaviour {
    public GameObject explosion;
    public string enemyTagName = "Enemies";
    public string lightGroundTag = "LightGround";
    public string darkGroundTag = "DarkGround";

    private Store store;

    void Start() {
        store = gameObject.GetComponent<Store>();
    }


    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(enemyTagName))
            return;

        if (gameObject.layer == 13 && other.transform.parent.CompareTag(darkGroundTag)) {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(other.transform.parent.gameObject);

            store.EnemyKilled();
            float enemyScale = other.transform.localScale.x;
            float mappedCharge = LevelDataStore.Map(enemyScale, 0.5f, 1, 5, 15);
            store.IncrementChargeAmount(mappedCharge);

        } else if (gameObject.layer == 14 && other.transform.parent.CompareTag(lightGroundTag)) {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(other.transform.parent.gameObject);

            store.EnemyKilled();
            float enemyScale = other.transform.localScale.x;
            float mappedCharge = LevelDataStore.Map(enemyScale, 0.5f, 1, 10, 30);
            store.IncrementChargeAmount(mappedCharge);
        }
    }
}
