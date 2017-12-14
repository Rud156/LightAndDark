using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataStore : MonoBehaviour {
    public static int maxLevel = 0;
    public static int currentLevel = 1;
    public static int maxEnemiesKilled = 0;
    public static int enemiesKilled = 0;

    public static int minGrounds = 5;

    public static int currentLevelMinGrounds = LevelDataStore.currentLevel + LevelDataStore.minGrounds;
    public static int currentLevelMaxGrounds = LevelDataStore.currentLevel * 2 + LevelDataStore.minGrounds;

    public static bool playerDead = false;
}
