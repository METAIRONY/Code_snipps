using System.IO;
using UnityEngine;

public class Missions : MonoBehaviour
{
    string missionsPath;

    public Mission[][] allMissions;

    public class Mission
    {
        public int pointsNeeded = 1;
        public int whatNeeded;

        public int hard;

        public string desc;
        public bool wasUsed = false;

        public Mission(StreamReader sr)
        {
            if (sr.Peek() == '/')
                sr.ReadLine();

            desc = sr.ReadLine();
            whatNeeded = int.Parse(sr.ReadLine());
            sr.ReadLine();
        }
    }

    void Initialize()
    {
        allMissions = new Mission[4][];

        allMissions[0] = new Mission[49]; //утро
        allMissions[1] = new Mission[66]; //день
        allMissions[2] = new Mission[66]; //вечер
        allMissions[3] = new Mission[53]; //ночь

        missionsPath = Application.dataPath + "/Files/Missions.txt";
        using (StreamReader sr = new StreamReader(missionsPath))
        {
            for (int i = 0; i < allMissions.Length; i++)
            {
                for (int j = 0; j < allMissions[i].Length; j++)
                    allMissions[i][j] = new Mission(sr);
            }
        }
    }

    void Start()
    {
        Initialize();    
    }
}
