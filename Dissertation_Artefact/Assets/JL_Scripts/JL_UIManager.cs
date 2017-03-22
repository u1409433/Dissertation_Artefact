using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JL_UIManager : MonoBehaviour
{
    private JL_LevelManager SC_LevelManager;

    public GameObject UI_StartCanvas;
    public GameObject UI_ScenarioCanvas;
    public GameObject UI_InterimCanvas;

    public Text UI_ScenarioText;
    public Text UI_TextA;
    public Text UI_TextB;
    public Text UI_TextC;

    public int IN_Scenario = 0;
    public int IN_Level = 0;

    public bool BL_LevelComplete = false;

    public Dictionary<Vector3, string> DI_Responses;

    // Use this for initialization
    void Start()
    {
        SC_LevelManager = GameObject.Find("LevelManager").GetComponent<JL_LevelManager>();
        DI_Responses = new Dictionary<Vector3, string>();
        InitialiseDictionary();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeUI(string ST_UIToOpen)
    {
        UI_StartCanvas.SetActive(false);
        UI_ScenarioCanvas.SetActive(false);
        UI_InterimCanvas.SetActive(false);

        switch (ST_UIToOpen)
        {
            case "Start":
                UI_StartCanvas.SetActive(true);
                break;
            case "Scenario":
                UI_ScenarioCanvas.SetActive(true);
                break;
            case "Interim":
                UI_InterimCanvas.SetActive(true);
                break;
        }
    }

    public void ChangeText()
    {
        switch (IN_Scenario)
        {
            case 0:
                UI_ScenarioText.text = "From the darkness of the dungeon you can see three goblins sat aroud a campfire, chattering loudly. Each of them has a crude weapon lying nearby.\n\nThe party is currently concealed, and the small campfire's light does not reach the edge of the room, leaving a path around the edge steeped in darkness.\n\nWhat do you do?";
                UI_TextA.text = "Sneak past the goblins";
                UI_TextB.text = "Attack!";
                UI_TextC.text = "";
                break;
            case 1:
                UI_ScenarioText.text = "As you stand in the corridor, spiders suddenly descend from the ceiling in the next room - about half the size of a man, numbering about a dozen. Each of them has bright green poison dripping from its fangs.\n\nWho attacks first?";
                UI_TextA.text = "Get the Wizard to blast them with fire";
                UI_TextB.text = "Have the rogue pelt them with arrows";
                UI_TextC.text = "Have the knight lash out with his blade";
                break;
            case 2:
                UI_ScenarioText.text = "A door sits before you, nestled perfectly into the corridor, with a large keyhole inset. There has been no sign of an alternate route.\n\n How do you approach the door?";
                UI_TextA.text = "Have the Rogue play with the keyhole";
                UI_TextB.text = "Kick down the door";
                UI_TextC.text = "Twist the handle";
                break;
            case 3:
                UI_ScenarioText.text = "A Skeleton Guard stands in the centre of the corridor, completely immobise, his gaze affixed on the wall in front of him.";
                UI_TextA.text = "Sneak towards the guard, and attempt to get a surprise attack";
                UI_TextB.text = "Charge at him head on";
                UI_TextC.text = "Pretend you think he is inanimate";
                BL_LevelComplete = true;
                break;
            case 4:
                UI_ScenarioText.text = "You walk into a large room, which is completely bare save for the burning sconses on the walls.";
                UI_TextA.text = "Walk on through";
                UI_TextB.text = "Rest in the room";
                UI_TextC.text = "Proceed through the room slowly, checking for traps";
                break;
            case 5:
                UI_ScenarioText.text = "In the largest room of the dungeon thus far, you see a Giant Rat sat in the centre of the room. The Rat is the size of 3 men, with a tail almost half that. Knowing that to turn back now would be failure, the party presses on into the room, sparking the rat's interest. He begins to charge at the party, before leaping towards the group, forcing them to scatter.\n\nWhat should the party target first?";
                UI_TextA.text = "Attack the legs";
                UI_TextB.text = "Attack the tail";
                UI_TextC.text = "Attack the head";
                break;
            case 6:
                UI_ScenarioText.text = "As you begin your journey again, you turn a corner in the wide corridor you are following and see the backs of a Kobold scouting party.\n\nOne that had fallen slightly behind notices you and locks eyes momentarily.";
                UI_TextA.text = "Loose and arrow at it";
                UI_TextB.text = "Cast a magic missile at it";
                UI_TextC.text = "Bull rush him and the scouting party";
                break;
            case 7:
                UI_ScenarioText.text = "You are in part of the dungeon that is a network of ancient caves being used to extend the dungeon's reach. In this particular cave, there is a family of bears, sleeping.";
                UI_TextA.text = "Run past";
                UI_TextB.text = "Sneak past";
                UI_TextC.text = "Attack the bears";
                break;
            case 8:
                UI_ScenarioText.text = "In this stone walled room you see a man in necromancer's robes, hunched over a table, chanting. aroud the room are farious body parts and a single reanimated skeleton.";
                UI_TextA.text = "Have the Rogue sneak up and attack him";
                UI_TextB.text = "Have the Knight charge at him";
                UI_TextC.text = "Cast a silence spell on the necromancer";
                break;
            case 9:
                UI_ScenarioText.text = "At the end of this twisting dungeon lies one of the greatest foes of an adventuring party - A Cave Troll. The Wizard has many spells at his disposal to attempt to defeat the creature - whilst the others act as a distraction, which will he use?";
                UI_TextA.text = "A Fireball Spell";
                UI_TextB.text = "An acid pool";
                UI_TextC.text = "A freeze spell";
                break;
            case 10:
                UI_ScenarioText.text = "Across the floor of the room slither countless snakes. A variety of colours all moving prevent you from being able to distinguish a particular breed. How will you advance through the room?";
                UI_TextA.text = "Cast illuminate";
                UI_TextB.text = "Throw a fireball";
                UI_TextC.text = "Run for it, slicing as you go";
                break;
            case 11:
                UI_ScenarioText.text = "You come into what appears to be a holdout, with plans on tables and a hitlist on the wall. Three elves look at you and scowl 'You shouldn't be here' says on of them menacingly.\n\n'Now I have to make sure you don't tell anyone else about our little hideout.'\n\n What will you do?";
                UI_TextA.text = "Tell them you don't want to fight and will not reveal their secret";
                UI_TextB.text = "Launch a quick offensive";
                UI_TextC.text = "Pretend to surrender";
                break;
            case 12:
                UI_ScenarioText.text = "Tired of dealing with snakes and liars, you come across a room filled with a creature representing the best of both - Yuan-Ti. Half-Man, Half-Snake, 6 of them fill the room.\n\nThere is clearly three distinct figures whom you could target first.";
                UI_TextA.text = "Fire at the leader first";
                UI_TextB.text = "Fire at the healer first";
                UI_TextC.text = "Fire at the mage first";
                break;
            case 13:
                UI_ScenarioText.text = "Wyrm";
                UI_TextA.text = "";
                UI_TextB.text = "";
                UI_TextC.text = "";
                break;
        }
    }

    public void NextScenario()
    {
        if (BL_LevelComplete)
        {
            SC_LevelManager.NextLevel();
        }
        else
        {
            IN_Scenario++;
            ChangeText();
            UI_ScenarioCanvas.SetActive(false);
            UI_InterimCanvas.SetActive(true);
        }
    }

    public void ButtonA()
    {
        ChoiceMade(new Vector3(IN_Level, IN_Scenario, 0));
        SC_LevelManager.ChoiceMade(new Vector3(IN_Level, IN_Scenario, 0));
    }
    public void ButtonB()
    {

    }
    public void ButtonC()
    {

    }

    public void ChoiceMade(Vector3 vV3_Choice)
    {
        UI_ScenarioText.text = DI_Responses[vV3_Choice];
    }

    public void AdvanceButton()
    {
        NextScenario();
    }

    public void ProceedButton()
    {
        UI_ScenarioCanvas.SetActive(true);
        UI_InterimCanvas.SetActive(false);
    }

    public void KnightPotion()
    {
        SC_LevelManager.IN_KnightHP += 3;
    }
    public void RoguePotion()
    {
        SC_LevelManager.IN_RogueHP += 3;
    }
    public void WizardPotion()
    {
        SC_LevelManager.IN_WizardHP += 3;
    }


    //Dictionary Setup
    void InitialiseDictionary()
    {
        DI_Responses.Add(new Vector3(1, 0, 0), "The goblins have highly sensitive hearing, so although you are hidden they hear the armour of the knight, and pounce. the knight takes a blow to his side, before recovering and cleaving the remaining goblins in half.");
        DI_Responses.Add(new Vector3(1, 0, 1), "The goblins fall almost before they are aware of your presence, and no injuries are sustained.");
        DI_Responses.Add(new Vector3(1, 0, 2), "");
        DI_Responses.Add(new Vector3(1, 1, 0), "");
        DI_Responses.Add(new Vector3(1, 1, 1), "");
        DI_Responses.Add(new Vector3(1, 1, 2), "");
        DI_Responses.Add(new Vector3(1, 2, 0), "");
        DI_Responses.Add(new Vector3(1, 2, 1), "");
        DI_Responses.Add(new Vector3(1, 2, 2), "");
        DI_Responses.Add(new Vector3(1, 3, 0), "");
        DI_Responses.Add(new Vector3(1, 3, 1), "");
        DI_Responses.Add(new Vector3(1, 3, 2), "");
    }
}
