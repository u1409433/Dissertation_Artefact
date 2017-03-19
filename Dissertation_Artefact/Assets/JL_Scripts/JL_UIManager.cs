using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JL_UIManager : MonoBehaviour
{
    public GameObject UI_StartCanvas;
    public GameObject UI_ScenarioCanvas;
    public GameObject UI_InterimCanvas;
    public GameObject UI_InventoryCanvas;

    public Text UI_ScenarioText;
    public Text UI_TextA;
    public Text UI_TextB;
    public Text UI_TextC;

    public int Scenario = 0;
    public int IN_Level = 0;

    // Use this for initialization
    void Start()
    {

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
        UI_InventoryCanvas.SetActive(false);

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
            case "Inventory":
                UI_InventoryCanvas.SetActive(true);
                break;
        }
    }

    public void ChangeText(int IN_ScenarioNum)
    {
        switch (IN_ScenarioNum)
        {
            case 1:
                UI_ScenarioText.text = "From the darkness of the dungeon you can see three goblins sat aroud a campfire, chattering loudly. Each of them has a crude weapon lying nearby.\n\nThe party is currently concealed, and the small campfire's light does not reach the edge of the room, leaving a path around the edge steeped in darkness.\n\nWhat do you do?";
                UI_TextA.text = "Sneak past the goblins";
                UI_TextB.text = "Attack!";
                UI_TextC.text = "";
                break;
            case 2:
                UI_ScenarioText.text = "As you stand in the corridor, spiders suddenly descend from the ceiling in the next room - about half the size of a man, numbering about a dozen. Each of them has bright green poison dripping from its fangs.\n\nWho attacks first?";
                UI_TextA.text = "Get the Wizard to blast them with fire";
                UI_TextB.text = "Have the rogue pelt them with arrows";
                UI_TextC.text = "Have the knight lash out with his blade";
                break;
            case 3:
                UI_ScenarioText.text = "A door sits before you, nestled perfectly into the corridor, with a large keyhole inset. There has been no sign of an alternate route.\n\n How do you approach the door?";
                UI_TextA.text = "Have the Rogue play with the keyhole";
                UI_TextB.text = "Kick down the door";
                UI_TextC.text = "Twist the handle";
                break;
            case 4:
                UI_ScenarioText.text = "In the largest room of the dungeon thus far, you see a Giant Rat sat in the centre of the room. The Rat is the size of 3 men, with a tail almost half that. Knowing that to turn back now would be failure, the party presses on into the room, sparking the rat's interest. He begins to charge at the party, before leaping towards the group, forcing them to scatter.\n\nWhat should the party target first?";
                UI_TextA.text = "Attack the legs";
                UI_TextB.text = "Attack the tail";
                UI_TextC.text = "Attack the head";
                break;
        }
    }

    public void NextScenario()
    {
        IN_Level++;
        ChangeText(IN_Level);
    }

    public void AdvanceButton()
    {
        NextScenario();
    }
}
