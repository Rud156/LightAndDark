using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataStore : MonoBehaviour {
    public static int maxLevel = 0;
    public static int currentLevel = 1;
    public static int maxEnemiesKilled = 0;
    public static int enemiesKilled = 0;

    public static bool playerBuffActive = false;

    public static int minGrounds = 5;

    public static int currentLevelMinGrounds = LevelDataStore.currentLevel + LevelDataStore.minGrounds;
    public static int currentLevelMaxGrounds = LevelDataStore.currentLevel * 2 + LevelDataStore.minGrounds;

    public static bool playerDead = false;

    public static float Constrain(float n, float low, float high) {
        return Mathf.Max(Mathf.Min(n, high), low);
    }

    public static float Map(float n, float start1, float stop1, float start2, float stop2) {
        float newval = (n - start1) / (stop1 - start1) * (stop2 - start2) + start2;
        if (start2 < stop2) {
            return LevelDataStore.Constrain(newval, start2, stop2);
        } else {
            return LevelDataStore.Constrain(newval, stop2, start2);
        }
    }
}
