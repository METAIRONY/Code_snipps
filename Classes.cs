using UnityEngine;
using UnityEngine.UI;

public class Classes : MonoBehaviour
{
    public class Slot
    {
        public GameObject main;
        public Image img;
        public Image bar;
        public Text name;
        public Text attention;

        public int agentIndx;

        public Slot(string parent, int i)
        {
            main = GameObject.Find("Canvas").transform.Find(parent + "/Slot" + i).gameObject;
            img = main.transform.Find("Image").GetComponent<Image>();

            if (main.transform.Find("Pointbar") != null)
                bar = main.transform.Find("Pointbar").GetComponent<Image>();

            if (main.transform.Find("Name") != null)
                name = main.transform.Find("Name").GetComponent<Text>();
            if (main.transform.Find("Внимание") != null)
                attention = main.transform.Find("Внимание").GetComponent<Text>();
        }
        
        public void SetData(Sprite img, Sprite bar = null, string name = null)
        {
            this.img.sprite = img;

            if (bar != null)
                this.bar.sprite = bar;

            if (name != null)
                this.name.text = name;
        }

        public void Deactivate()
        {
            img.gameObject.SetActive(false);

            if (bar != null)
                bar.gameObject.SetActive(false);

            if (name != null)
                name.gameObject.SetActive(false);

            if (attention != null)
                attention.gameObject.SetActive(false);
        }

        public void Activate()
        {
            img.gameObject.SetActive(true);

            if (bar != null)
                bar.gameObject.SetActive(true);

            if (name != null)
                name.gameObject.SetActive(true);
        }

        public void Block()
        {
            main.GetComponent<Button>().image.color = main.GetComponent<Button>().colors.pressedColor;
            img.color = main.GetComponent<Button>().colors.pressedColor;
            main.GetComponent<SelectAgentsClick>().enabled = false;
        }

        public void UnBlock()
        {
            main.GetComponent<Button>().image.color = main.GetComponent<Button>().colors.normalColor;
            img.color = main.GetComponent<Button>().colors.normalColor;
            main.GetComponent<SelectAgentsClick>().enabled = true;
        }
    }

    public class WindowWithSlots
    {
        public GameObject main;
        public Text desc;

        public Slot[] slots;

        public int[] slotsSelectedIndxs;

        public WindowWithSlots(string name, string slotsParent, int howManySlots)
        {
            main = GameObject.Find("Canvas").transform.Find(name).gameObject;
            if (main.transform.Find("Description") != null)
                desc = main.transform.Find("Description").GetComponent<Text>();
            
            slotsSelectedIndxs = new int[howManySlots];

            slots = new Slot[howManySlots];
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new Slot(name + slotsParent, i);
                slotsSelectedIndxs[i] = -1;
            }
        }
    }

    public class BattleWindow
    {
        public GameObject main;

        public GameObject[] buttons;

        public Image image0;
        public Image image1;

        public Text side0;
        public Text side1;
        public Text desc0;
        public Text desc1;
        public Text desc2;

        public int howManyTroops;

        public BattleWindow()
        {
            main = GameObject.Find("Canvas").transform.Find("BattleWindow").gameObject;

            buttons = new GameObject[3];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new GameObject();
                buttons[i] = main.transform.Find("Button" + i).gameObject;
            }

            image0 = main.transform.Find("Image0").GetComponent<Image>();
            image1 = main.transform.Find("Image1").GetComponent<Image>();

            side0 = main.transform.Find("Side0").GetComponent<Text>();
            side1 = main.transform.Find("Side1").GetComponent<Text>();
            desc0 = main.transform.Find("Description0").GetComponent<Text>();
            desc1 = main.transform.Find("Description1").GetComponent<Text>();
            desc2 = main.transform.Find("Description2").GetComponent<Text>();
        }
    }

    public class SomeWindow
    {
        public GameObject main;
        public Image img;
        public Text desc0;
        public Text desc1;

        public SomeWindow(string name)
        {
            main = GameObject.Find("Canvas").transform.Find(name).gameObject;
            img = main.transform.Find("Image").GetComponent<Image>();
            desc0 = main.transform.Find("Description0").GetComponent<Text>();
            if (main.transform.Find("Description1") != null)
                desc1 = main.transform.Find("Description1").GetComponent<Text>();
        }
    }

    public class Day
    {
        public Phase[] phases;

        public int[] invasionsInDay;
        public int[] riotsInDay;

        public Day(int phCount1, int phCount2, int phCount3, int phCount4, int invCount, int rioCount)
        {
            phases = new Phase[4]
            {
                new Phase(phCount1),
                new Phase(phCount2),
                new Phase(phCount3),
                new Phase(phCount4)
            };
            invasionsInDay = new int[invCount];
            riotsInDay = new int[rioCount];
        }
    }
    public class Phase
    {
        public int[] missionsInPhase;
        public bool wasEmpty;

        public Phase(int phaseCount)
        {
            missionsInPhase = new int[phaseCount];
            wasEmpty = false;
        }
    }

    public class City
    {
        public GameObject riotIcon;
        public GameObject riotFinal;
        public GameObject flag;

        public int missionIndx;
        public int riotIndx;

        public bool wasRiotOpened;

        public City(int i)
        {
            riotIcon = GameObject.Find("City" + i).transform.Find("Riot").gameObject;
            riotFinal = GameObject.Find("City" + i).transform.Find("RiotFinal").gameObject;
            flag = GameObject.Find("City" + i).transform.Find("Flag").gameObject;
        }
    }

    public class Arrow
    {
        public GameObject main;

        public int invasionIndx;
        public bool wasOpened;

        public Arrow(string arrowName, int i)
        {
            main = GameObject.Find("Arrows").transform.Find(arrowName + i).gameObject;
        }
    }

    public class Riot
    {
        public int hard;
        public int whatNeeded1;
        public int whatNeeded2;

        public Riot(int hard)
        {
            this.hard = hard;
        }
    }

    public class BattlePlace
    {
        public string name;
        public float[] coeffSet;

        public BattlePlace(float k0, float k1, float k2, string name)
        {
            this.name = name;
            coeffSet = new float[3]
            {
                k0, //attack
                k1, //defence
                k2 //flanks
            };
        }
    }
}
