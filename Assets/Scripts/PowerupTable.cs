using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class PowerupTable
{

    public class PowerupChance
    {
        public string PrefabName { get; private set; }
        public float Probability { get; private set; }

        public PowerupChance(string prefabName, float probability)
        {
            PrefabName = prefabName;
            Probability = probability;
        }
    }

    private static readonly List<string> lootTable = new List<string>();
    private static string NOTHING = "NOTHING";

    static PowerupTable()
    {
        //        AddDrop(NOTHING, 50);
        AddDrop("powerup-ball", 10);

    }

    private static void AddDrop(string prefabName, int chances)
    {
        for (int i = 0; i < chances; i++)
        {
            lootTable.Add(prefabName);
        }
    }

    public static Object AwardPowerup()
    {
        string prefabName = lootTable[Random.Range(0, lootTable.Count)];
        if (prefabName == NOTHING)
        {
            return null;
        }
        return Resources.Load(prefabName);
    }
}
