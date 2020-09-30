using System.IO;
using UnityEngine;

public class Agents : MonoBehaviour
{
    string agentsPath;

    public Agent[] allAgents;

    public class Parameter
    {
        public int value;
        public string name;

        public Parameter(int value, string name)
        {
            this.name = name;
            this.value = value;
        }
    }

    public class Agent
    {
        public string name;
        public string desc;
        public int slotIndx;
        public bool wasUsed;

        public Parameter[] paramset;
        public int defaultPoints;
        
        public Agent(StreamReader sr)
        {
            name = sr.ReadLine();
            desc = sr.ReadLine();

            paramset = new Parameter[4]
            {
                new Parameter(int.Parse(sr.ReadLine()), "ОД"),
                new Parameter(int.Parse(sr.ReadLine()), "Убеждение"),
                new Parameter(int.Parse(sr.ReadLine()), "Бой"),
                new Parameter(int.Parse(sr.ReadLine()), "Шпионаж")
            };

            defaultPoints = paramset[0].value;
            sr.ReadLine();
        }
    }

    public void Initialize()
    {
        allAgents = new Agent[10];
        agentsPath = Application.dataPath + "/Files/Agents.txt";

        using (StreamReader sr = new StreamReader(agentsPath))
        {
            for (int i = 0; i < allAgents.Length; i++)
                allAgents[i] = new Agent(sr);            
        }
    }

    void Start()
    {
        Initialize();
    }
}
