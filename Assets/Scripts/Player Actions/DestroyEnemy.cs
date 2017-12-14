using UnityEngine;

public class DestroyEnemy : MonoBehaviour {
    public GameObject explosion;
    public string enemyTagName = "Enemies";
    public string lightGroundTag = "LightGround";
    public string darkGroundTag = "DarkGround";

    [HideInInspector]
    public int destroyedEnemyCount = 0;

    void OnTriggerEnter(Collider other) {
        if (!other.CompareTag(enemyTagName))
            return;

        if (gameObject.layer == 13 && other.transform.parent.CompareTag(darkGroundTag)) {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(other.transform.parent.gameObject);
            destroyedEnemyCount += 1;
        } else if (gameObject.layer == 14 && other.transform.parent.CompareTag(lightGroundTag)) {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(other.transform.parent.gameObject);
            destroyedEnemyCount += 1;
        }
    }
}
