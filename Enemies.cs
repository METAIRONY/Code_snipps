using System.IO;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    string enemiesPath;

    public Enemy[] allEnemies;

    public Sprite[] enemiesSprites;

    public class Enemy
    {
        public string name;
        public string desc;

        public int howManyTroops;
        public int battlePlaceIndx;

        public bool wasOpened;

        public Enemy(StreamReader sr)
        {
            name = sr.ReadLine();
            desc = sr.ReadLine();
            sr.ReadLine();
        }
    }

    void Initialize()
    {
        allEnemies = new Enemy[3];

        enemiesPath = Application.dataPath + "/Files/Enemies.txt";

        using (StreamReader sr = new StreamReader(enemiesPath))
        {
            for (int i = 0; i < allEnemies.Length; i++)
                allEnemies[i] = new Enemy(sr);            
        }
    }

    void Start()
    {
        Initialize();
    }
}
