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
    public GameObject UI_LevelCompleteCanvas;
    public GameObject UI_FinishCanvas;

    public GameObject UI_Situation;
    public GameObject UI_AdvanceButton;
    public GameObject UI_AmuletStuff;
    public GameObject UI_UsedAmuletText;
    public Text UI_CurrentHolder;
    public Text UI_PotionsLeft;
    public Text UI_DifficultyText;

    public Text UI_LevelCompleteText;
    public GameObject UI_ProceedButton;

    public Text UI_ScenarioText;
    public Text UI_TextA;
    public Text UI_TextB;
    public Text UI_TextC;

    public Text KnightHP;
    public Text RogueHP;
    public Text WizardHP;

    public int IN_Scenario = 0;
    public int IN_Level = 0;
    public int IN_levelsCompleted = 0;

    public bool BL_LevelComplete = false;
    public bool BL_LifeLeft = true;

    public Dictionary<Vector3, string> DI_Responses;

    // Use this for initialization
    void Start()
    {
        SC_LevelManager = GameObject.Find("LevelManager").GetComponent<JL_LevelManager>();
        DI_Responses = new Dictionary<Vector3, string>();
        SetupDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        KnightHP.text = SC_LevelManager.IN_KnightHP.ToString();
        RogueHP.text = SC_LevelManager.IN_RogueHP.ToString();
        WizardHP.text = SC_LevelManager.IN_WizardHP.ToString();

        if (UI_InterimCanvas.activeInHierarchy)
        {
            switch (SC_LevelManager.IN_AmuletHolder)
            {
                case 0:
                    UI_CurrentHolder.text = "Current Holder: Knight";
                    break;
                case 1:
                    UI_CurrentHolder.text = "Current Holder: Rogue";
                    break;
                case 2:
                    UI_CurrentHolder.text = "Current Holder: Wizard";
                    break;
                case 3:
                    UI_CurrentHolder.text = "Current Holder: None";
                    break;
            }
        }

        foreach (GameObject LevelNum in GameObject.FindGameObjectsWithTag("LevelNumText"))
        {
            LevelNum.GetComponent<Text>().text = "Level " + IN_Level.ToString();
        }

        if (SC_LevelManager.BL_DDEnabled == false)
        {
            UI_DifficultyText.text = "";
        }
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


    public void NextScenario()
    {
        if (BL_LevelComplete)
        {
            IN_levelsCompleted++;
            if (IN_levelsCompleted == 3)
            {
                //UI_ScenarioCanvas.SetActive(false);
                //UI_FinishCanvas.SetActive(true);
                UI_ScenarioCanvas.SetActive(false);
                UI_LevelCompleteCanvas.SetActive(true);
                UI_ProceedButton.SetActive(false);
                UI_LevelCompleteText.text = "Thank you for participating in this test! Please inform the researcher if you wish to be notified of the results of this study.";
            }
            else
            {
                SC_LevelManager.NextLevel();
                IN_Level++;
                IN_Scenario++;
                BL_LevelComplete = false;
                ChangeText();
                UI_ScenarioCanvas.SetActive(false);
                UI_LevelCompleteCanvas.SetActive(true);
                UI_LevelCompleteText.text = "You have completed the level!\n\nYour heroes will rest and heal.\n\nPress proceed to delve further into the dungeon.";
            }

        }
        else
        {
            IN_Scenario++;
            ChangeText();
            UI_ScenarioCanvas.SetActive(false);
            UI_InterimCanvas.SetActive(true);
        }
    }

    public void Death()
    {
        if (BL_LifeLeft)
        {
            BL_LevelComplete = false;
            SC_LevelManager.NextLevel();
            IN_Level++;
            IN_Scenario = (IN_Level == 3) ? 6 : 10;
            ChangeText();
            UI_ScenarioCanvas.SetActive(false);
            UI_LevelCompleteCanvas.SetActive(true);
            UI_LevelCompleteText.text = "One of your heroes has fallen, but with luck you revive them and you have one more chance.\n\nYour heroes will rest and heal.\n\nPress proceed to delve further into the dungeon.";
        }
        else
        {
            UI_ScenarioCanvas.SetActive(false);
            UI_LevelCompleteCanvas.SetActive(true);
            UI_ProceedButton.SetActive(false);
            UI_LevelCompleteText.text = "Your heroes have fallen too many times to continue.\n\nThank you for participating in this test! Please inform the researcher if you wish to be notified of the results of this study.";
        }
    }

    public void ButtonA()
    {
        Vector3 Result = new Vector3(IN_Level, IN_Scenario, 0);
        SC_LevelManager.ChoiceMade(Result);
        if (SC_LevelManager.IN_KnightHP <= 0 || SC_LevelManager.IN_RogueHP <= 0 || SC_LevelManager.IN_WizardHP <= 0) ;
        else ChoiceMade(Result);
        //print("I chose: " + Result.ToString());
    }
    public void ButtonB()
    {
        Vector3 Result = new Vector3(IN_Level, IN_Scenario, 1);
        SC_LevelManager.ChoiceMade(Result);
        if (SC_LevelManager.IN_KnightHP <= 0 || SC_LevelManager.IN_RogueHP <= 0 || SC_LevelManager.IN_WizardHP <= 0) ;
        else ChoiceMade(Result);
        //print("I chose: " + Result.ToString());
    }
    public void ButtonC()
    {
        Vector3 Result = new Vector3(IN_Level, IN_Scenario, 2);
        SC_LevelManager.ChoiceMade(Result);
        if (SC_LevelManager.IN_KnightHP <= 0 || SC_LevelManager.IN_RogueHP <= 0 || SC_LevelManager.IN_WizardHP <= 0) ;
        else ChoiceMade(Result);
        //print("I chose: " + Result.ToString());
    }

    public void ChoiceMade(Vector3 vV3_Choice)
    {
        UI_ScenarioText.text = DI_Responses[vV3_Choice];
        UI_Situation.SetActive(false);
        UI_AdvanceButton.SetActive(true);

    }

    public void AdvanceButton()
    {
        NextScenario();
        UI_AdvanceButton.SetActive(false);
        UI_Situation.SetActive(true);
    }

    public void ProceedButton()
    {
        UI_ScenarioCanvas.SetActive(true);
        UI_InterimCanvas.SetActive(false);
    }

    public void LevelCompleteProceed()
    {
        UI_ScenarioCanvas.SetActive(true);
        UI_LevelCompleteCanvas.SetActive(false);
    }

    public void BeginButton()
    {
        UI_StartCanvas.SetActive(false);
        UI_ScenarioCanvas.SetActive(true);
        NextScenario();
    }

    public void KnightPotion()
    {
        if (SC_LevelManager.IN_PotionsLeft > 0 && SC_LevelManager.IN_KnightHP < 10)
        {
            SC_LevelManager.IN_KnightHP += 3;
            SC_LevelManager.IN_PotionsLeft--;
            UI_PotionsLeft.text = SC_LevelManager.IN_PotionsLeft.ToString();
            SC_LevelManager.HPCheck();
            SC_LevelManager.IN_TacticScore++;
        }
    }
    public void RoguePotion()
    {
        if (SC_LevelManager.IN_PotionsLeft > 0 && SC_LevelManager.IN_RogueHP < 10)
        {
            SC_LevelManager.IN_RogueHP += 3;
            SC_LevelManager.IN_PotionsLeft--;
            UI_PotionsLeft.text = SC_LevelManager.IN_PotionsLeft.ToString();
            SC_LevelManager.HPCheck();
            SC_LevelManager.IN_TacticScore++;
        }
    }
    public void WizardPotion()
    {
        if (SC_LevelManager.IN_PotionsLeft > 0 && SC_LevelManager.IN_WizardHP < 10)
        {
            SC_LevelManager.IN_WizardHP += 3;
            SC_LevelManager.IN_PotionsLeft--;
            UI_PotionsLeft.text = SC_LevelManager.IN_PotionsLeft.ToString();
            SC_LevelManager.HPCheck();
            SC_LevelManager.IN_TacticScore++;
        }
    }

    public void KnightAmulet()
    {
        SC_LevelManager.IN_AmuletHolder = 0;
    }
    public void RogueAmulet()
    {
        SC_LevelManager.IN_AmuletHolder = 1;
    }
    public void WizardAmulet()
    {
        SC_LevelManager.IN_AmuletHolder = 2;
    }

    public void AmuletUsed()
    {
        UI_AmuletStuff.SetActive(false);
        UI_UsedAmuletText.SetActive(true);
    }


    public void ChangeText()
    {
        if (SC_LevelManager.BL_SetA)
        {
            switch (IN_Scenario)
            {
                case 0:
                    UI_ScenarioText.text = "From the darkness of the dungeon you can see three goblins sat around a campfire, chattering loudly. Each of them has a crude weapon lying nearby.\n\nThe party is currently concealed, and the small campfire's light does not reach the edge of the room, leaving a path around the edge steeped in darkness.\n\nWhat do you do?";
                    UI_TextA.text = "Sneak past the goblins";
                    UI_TextB.text = "Attack!";
                    UI_TextC.text = "Use a battlecry to try and scare the goblins";
                    break;
                case 1:
                    UI_ScenarioText.text = "As you stand in the corridor, spiders suddenly descend from the ceiling in the next room - about half the size of a man, numbering about a dozen. Each of them has bright green poison dripping from its fangs.\n\nWho attacks first?";
                    UI_TextA.text = "Get the Wizard to blast them with fire";
                    UI_TextB.text = "Have the rogue pelt them with arrows";
                    UI_TextC.text = "Have the knight lash out with his blade";
                    BL_LevelComplete = true;
                    break;
                case 2:
                    UI_ScenarioText.text = "A door sits before you, nestled perfectly into the corridor, with a large keyhole inset. There has been no sign of an alternate route.\n\n How do you approach the door?";
                    UI_TextA.text = "Have the Rogue play with the keyhole";
                    UI_TextB.text = "Kick down the door";
                    UI_TextC.text = "Twist the handle";
                    break;
                case 3:
                    UI_ScenarioText.text = "A Skeleton Guard stands in the centre of the corridor, completely immobised, his gaze fixed on the opposing wall.";
                    UI_TextA.text = "Sneak towards the guard, and attempt to get a surprise attack";
                    UI_TextB.text = "Charge at him head on";
                    UI_TextC.text = "Pretend you think he is inanimate";
                    break;
                case 4:
                    UI_ScenarioText.text = "You walk into a large room, which is completely bare save for the burning sconses on the walls.";
                    UI_TextA.text = "Proceed through the room slowly, checking for traps";
                    UI_TextB.text = "Rest in the room";
                    UI_TextC.text = "Walk on through";
                    break;
                case 5:
                    UI_ScenarioText.text = "In the largest room of the dungeon thus far, you see a Giant Rat sat in the centre of the room. The Rat is the size of 3 men, with a tail almost half that. Knowing that to turn back now would be failure, the party presses on into the room, sparking the rat's interest. He begins to charge at the party, before leaping towards the group, forcing them to scatter.\n\nWhat should the party target first?";
                    UI_TextA.text = "Attack the legs";
                    UI_TextB.text = "Attack the tail";
                    UI_TextC.text = "Attack the head";
                    BL_LevelComplete = true;
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
                    UI_ScenarioText.text = "In this stone walled room you see a man in necromancer's robes, hunched over a table, chanting. aroud the room are various body parts and a single reanimated skeleton.";
                    UI_TextA.text = "Have the Rogue sneak up and attack him";
                    UI_TextB.text = "Have the Knight charge at him";
                    UI_TextC.text = "Cast a silence spell on the necromancer";
                    break;
                case 9:
                    UI_ScenarioText.text = "At the end of this twisting dungeon lies one of the greatest foes of an adventuring party - A Cave Troll. The Wizard has many spells at his disposal to attempt to defeat the creature - whilst the others act as a distraction, which will he use?";
                    UI_TextA.text = "A Fireball Spell";
                    UI_TextB.text = "An acid pool";
                    UI_TextC.text = "A freeze spell";
                    BL_LevelComplete = true;
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
                    UI_ScenarioText.text = "In the final room is a great Wyrm, coiling around itself. As soon as you enter the room it detects you, and spins to face you. No matter how you orient yourselves it keeps its body behind its head, protecting is underside. You must hit part of its head.";
                    UI_TextA.text = "Go for the tounge that is flicking in and out of the mouth";
                    UI_TextB.text = "Slash at the nose, easily within reach";
                    UI_TextC.text = "Go for the eyes, in the hopes of blinding it";
                    BL_LevelComplete = true;
                    break;
            }
        }
        else
        {
            switch (IN_Scenario)
            {
                case 0:
                    UI_ScenarioText.text = "Entering into the dungeon, the first thing you see in the initial room is a dwarven forge room, complete with dwarves, all armed to the teeth and looking angry.";
                    UI_TextA.text = "Blast them with fire";
                    UI_TextB.text = "Head in to close quarters combat";
                    UI_TextC.text = "Try to ask them for help";
                    break;
                case 1:
                    UI_ScenarioText.text = "Rogue mages fill the next room, each one with glowing runes etched into their skin. How will you engage them?";
                    UI_TextA.text = "Fight from afar";
                    UI_TextB.text = "Get up close and personal";
                    UI_TextC.text = "Shoot fire at the alchemy table";
                    BL_LevelComplete = true;
                    break;
                case 2:
                    UI_ScenarioText.text = "The ghosts of a long-dead adventuring party, not too dissimilar to your own, haunt the cavernous hall that sprawls before you. How will you deal with these incorporeal foes?";
                    UI_TextA.text = "Magically enchant all weapons so they can hit ghosts";
                    UI_TextB.text = "Cast a lightning spell";
                    UI_TextC.text = "Cast a blizzard spell";
                    break;
                case 3:
                    UI_ScenarioText.text = "A berzerker guards a small shrine in a tight room with not a lot of space. As soon as he sees you he begins to become agitated, making frantic movements with his axes.";
                    UI_TextA.text = "Try to talk him down";
                    UI_TextB.text = "Shoot an arrow";
                    UI_TextC.text = "Cast a magic missile at him";
                    break;
                case 4:
                    UI_ScenarioText.text = "A flame Elemental sits in the centre of a burning room, revelling in the fire as it dances around the room. Upon seeing you, it stops and begins to whip up and inferno inside itself, preparing for combat.\n\nWhat do you do to fight this fiery foe?";
                    UI_TextA.text = "Cast a Frost Bolt";
                    UI_TextB.text = "Shoot an Arrow";
                    UI_TextC.text = "Swing a sword";
                    break;
                case 5:
                    UI_ScenarioText.text = "The stench of the room hits you as you walk in, and it is obvious that the Goblin Chief that resides here has done so for quite some time. Bones litter the floor. A hulking figure in comparison to a regular goblin, has has armour and a large axe. Which part of him do you focus on?";
                    UI_TextA.text = "Focus on hitting the head";
                    UI_TextB.text = "Swing at his legs";
                    UI_TextC.text = "Try to hit his chest";
                    BL_LevelComplete = true;
                    break;
                case 6:
                    UI_ScenarioText.text = "The cave you have entered that crosses the dungeon is the home to a pack of wolves. As you stand in the maw of the cave, they begin to snarl and attempt to circle the party.";
                    UI_TextA.text = "Split focus evenly amongst the wolves";
                    UI_TextB.text = "Focus on killing one at a time";
                    UI_TextC.text = "Create a ruckus to scare them";
                    break;
                case 7:
                    UI_ScenarioText.text = "You come across a man in templar armour, but he reeks of foul magic and his eyes are red. How will you tackle this evil creature?";
                    UI_TextA.text = "Use Holy Magic";
                    UI_TextB.text = "Use Fire Magic";
                    UI_TextC.text = "Just hit him";
                    break;
                case 8:
                    UI_ScenarioText.text = "You come across a chest, lying open on a dais. there is no other furnishings in the room, and the chest glimmers inside.";
                    UI_TextA.text = "Reach in and grab the amulet you see";
                    UI_TextB.text = "Leave it alone";
                    UI_TextC.text = "Close the lid";
                    break;
                case 9:
                    UI_ScenarioText.text = "Malice lingers in the air as you step across the threshold into the final room. A massive humanoid with dark black wings stands from a desk in the corner. A lesser demon stands before you. What will you target first?";
                    UI_TextA.text = "Its' wings";
                    UI_TextB.text = "The head";
                    UI_TextC.text = "The arms";
                    BL_LevelComplete = true;
                    break;
                case 10:
                    UI_ScenarioText.text = "Zombies shamble around the room, filling the air with their groans. Whilst relatively simple to fight individually, there are quite a number here. What will you dispatch them with?";
                    UI_TextA.text = "Slice and Dice";
                    UI_TextB.text = "Pelt them with arrows ";
                    UI_TextC.text = "Cone of fire";
                    break;
                case 11:
                    UI_ScenarioText.text = "You come across the lair of cultists that are preparing a dark ritual to the chanting of a foul priest";
                    UI_TextA.text = "Attack the outer circle first";
                    UI_TextB.text = "Attack the inner circle first";
                    UI_TextC.text = "Attack the leader first";
                    break;
                case 12:
                    UI_ScenarioText.text = "A large, acidic slime blocks your path. You cannot progress past it, and any attempt to step over it will be met with a sticky end. How will you deal with it?";
                    UI_TextA.text = "Electrocute it";
                    UI_TextB.text = "Swing a sword at it";
                    UI_TextC.text = "Freeze it";
                    break;
                case 13:
                    UI_ScenarioText.text = "In the final room, a large Mintaur dominates the space, which is large enough to house him comfortably. He fights with 3 distinct, but simple, attacks. When is the time to strike?";
                    UI_TextA.text = "As he is charging";
                    UI_TextB.text = "After he slams his fists to the ground";
                    UI_TextC.text = "When he swings his axe";
                    BL_LevelComplete = true;
                    break;
            }
        }

    }


    //Dictionary Setup
    public void SetupDictionary()
    {
        DI_Responses.Clear();
        bool tSetA = GameObject.Find("LevelManager").GetComponent<JL_LevelManager>().BL_SetA;
        if (tSetA)
        {
            DI_Responses.Add(new Vector3(1, 0, 0), "The goblins have highly sensitive hearing, so although you are hidden they hear the armour of the knight, and pounce. the knight takes a blow to his side, before recovering and cleaving the remaining goblins in half.\n\nKnight - 4 HP");
            DI_Responses.Add(new Vector3(1, 0, 1), "The goblins fall almost before they are aware of your presence, and no injuries are sustained.");
            DI_Responses.Add(new Vector3(1, 0, 2), "The goblins panic briefly, giving you time to prepare your attack, but they still get a single hit off onto the wizard.\n\nWizard -2 HP");
            DI_Responses.Add(new Vector3(1, 1, 0), "Fire is a spider's bane, and they fall quickly to the flames.");
            DI_Responses.Add(new Vector3(1, 1, 1), "The Rogue struggles to find his mark on the skittering targets, and they quickly reach the party, with the wizard taking a few nasty bites.\n\n Wizard -5 HP");
            DI_Responses.Add(new Vector3(1, 1, 2), "The knight strides forward with his sword in hand, slashing away at spiders, dealing with them easily, however not before everyone in the part takes a few scrapes.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(2, 2, 0), "The Rogue attempts to jimmy the lock, but in doing so sets off the trap. It is however aimed at head height, meaning that the ensuing ball of fire only singes the Rogue's shoulder\n\nRogue -3 HP");
            DI_Responses.Add(new Vector3(2, 2, 1), "The Knight's boot makes quick work of the door, and after a few blows it crashes inwards, and the fireball trap that guarded the door simply goes off harmlessly on the floor.");
            DI_Responses.Add(new Vector3(2, 2, 2), "The handle turns and the trap guarding the door goes off, blasting fire into the Rogue's face.\n\nRogue -4 HP");
            DI_Responses.Add(new Vector3(2, 3, 0), "The Guard turns at the last second and lashes out at the Rogue, turning the sneak attack around, before he gets crushed by the Knight's blade.\n\nRogue -4 HP");
            DI_Responses.Add(new Vector3(2, 3, 1), "The Guard turns and attempts to block the charge but the sheer force of a charging Knight sends his bones across the floor, but his sword managed to dig into the Knight's shoulder.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(2, 3, 2), "At the very last second the Knight lashes out with his shield, staggering the skeleton and allowing the Rogue to destroy it.");
            DI_Responses.Add(new Vector3(2, 4, 0), "You start to feel ill as you slowly search the room, which reveals vents in the walls and floor - Poison Gas! You rush out of the room to get away.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(2, 4, 1), "It is not long before the entire party is awake in a bout of sickness, you realise the room is filled with a light poison gas, and that should you have fallen deeply asleep you might have died.\n\nAll Party Members -4 HP");
            DI_Responses.Add(new Vector3(2, 4, 2), "You walk through the room, wondering if there was ever anything in that room.");
            DI_Responses.Add(new Vector3(2, 5, 0), "The party takes some damage slashing at the rats legs immobilises it, and it cannot reach you with its arms or teeth to do any further damage\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(2, 5, 1), "Trying to damage the rat from near its tail proves challenging, and it sweeps its tail to knock the knight off his feet.\n\n Knight -5 HP");
            DI_Responses.Add(new Vector3(2, 5, 2), "Getting close to the crushing jaws of a giant rat was a grave mistake - as it uses them to take a large chunk out of the knight, armour and all.\n\n Knight -7 HP");
            DI_Responses.Add(new Vector3(3, 6, 0), "The Kobold shrieks as the arrow flies towards him, alerting the other kobolds. They watch him fall, before preparing their weapons. The fight is not difficult but a few injuries are sustained.\n\nWizard -4 HP");
            DI_Responses.Add(new Vector3(3, 6, 1), "The bolt instantly fries the kobold, and the other scouts turn around to investigate the noise. Whilst they are doing so you charge into battle.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(3, 6, 2), "You charge into battle over the top of the scout, trampling him and moving swiftly into combat. The Kobold Scouts fall quickly.");
            DI_Responses.Add(new Vector3(3, 7, 0), "The bears wake as you run past, and catch you before you make it out of the cave.\n\nAll Party Members -5 HP");
            DI_Responses.Add(new Vector3(3, 7, 1), "Fortunately, the bears stay asleep as you creep past.");
            DI_Responses.Add(new Vector3(3, 7, 2), "The surprise of being attacked as they sleep puts the bears at a great disadvantage, but they still put up a great fight.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(3, 8, 0), "The Rogue slices his throat, and he instantly dies, his evil minions along with him.");
            DI_Responses.Add(new Vector3(3, 8, 1), "The Knight makes it to the Necromancer but the skeleton nearby lunges, digging his blade deep into the Knight's armour. However as soon as the Necromancer dies the skeleton falls as well.\n\nKnight -5 HP");
            DI_Responses.Add(new Vector3(3, 8, 2), "The silenced necromancer can do nothing more than wield his dagger, and dispatching him and his guard are easy enough.\n\nRogue -3 HP");
            DI_Responses.Add(new Vector3(3, 9, 0), "The cave troll falls to the floor in a ball of flame, but distracting him wounded the Knight.\n\nKnight -4 HP");
            DI_Responses.Add(new Vector3(3, 9, 1), "The acid pool is bigger than expected, meaning everyone in the room suffers some minor burns, but due to its weakness to the substance the troll melts into the pool swiftly.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(3, 9, 2), "The freeze spell has little effect on the troll, and it takes the party a long time to bring him down. He gets a solid hit on the Rogue, knocking him against the wall.\n\nRogue -6 HP");
            DI_Responses.Add(new Vector3(4, 10, 0), "A bright lines shines, casting away all shadows and forcing the snakes to the edges of the room.");
            DI_Responses.Add(new Vector3(4, 10, 1), "The fireball sears a large number of snakes, however there are many so it takes a few attempts to remove them all.\n\nRogue -4 HP");
            DI_Responses.Add(new Vector3(4, 10, 2), "The snakes are everywhere, and running is difficult. Although you make it to the other side of the room, everyone has sustained injuries.\n\nAll Party Members -3 HP");
            DI_Responses.Add(new Vector3(4, 11, 0), "'Oh no, I'm afraid that won't be possible.' Says the leader, before the assassins spring into attack. You manage to fight them off, but the Wizard took a nasty cut.\n\nWizard -5 HP");
            DI_Responses.Add(new Vector3(4, 11, 1), "You try to surprise them, but as assassins their reactions are honed, and they are ready to fight almost immediately.\n\nAll Party Members -3 HP");
            DI_Responses.Add(new Vector3(4, 11, 2), "They fall for the ruse, and as they come over to detain you the Knight and Rogue take two of them down quickly. The final puts up a fight but is no match for the party.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(4, 12, 0), "Attacking the leader proved almost futile, as he is the hardiest there, and his wounds immediately begin to heal due to the healer's magic. You struggle to fight the entire group, but eventually emerge victorious.\n\nAll Party Members -4 HP");
            DI_Responses.Add(new Vector3(4, 12, 1), "Removing the healer means that the rest are significantly more scared of entering combat, and thus dispatching the rest is easy, however the Yuan-Ti mage does blast the Knight.\n\nKnight -4 HP");
            DI_Responses.Add(new Vector3(4, 12, 2), "The mage falls immediately, but the leader still stands to avenge him, with a healer in tow. This makes taking the brute down, but there is no ranged fire support for him so it is not too bad.\n\nRogue -6 HP");
            DI_Responses.Add(new Vector3(4, 13, 0), "The tongue proves very difficult to hit, and in fact knocks the wizard down, allowing the fangs to plunge into his chest. This allows the rogue to stab through the roof of the mouth into the skull, ending the Wyrm.\n\nWizard -6 HP");
            DI_Responses.Add(new Vector3(4, 13, 1), "The nose is an easy target and relatively safe, but it seems that the Wyrm is not too bothered by being hit there. Causing enough damage to slay it requires time, and the Knight sustains injuries whilst in combat.\n\nKnight -4 HP");
            DI_Responses.Add(new Vector3(4, 13, 2), "The snake's eyes are it's weakness, and as soon as it snaps the Rogue and Knight split either side, stabbing both eyes. It recoils, but without vision it accidentally reveals its underbelly, allowing the party to swiftly finish it.\n\nAll Party Members -2 HP");
        }
        else
        {
            DI_Responses.Add(new Vector3(1, 0, 0), "Dwarves are resistant to fire, thus the spell does little more than anger them further.\n\nRogue -4 HP");
            DI_Responses.Add(new Vector3(1, 0, 1), "Although they look tough, without their armour their size hinders them and there is little damage sustained.\n\nKnight -2 HP");
            DI_Responses.Add(new Vector3(1, 0, 2), "They are not the negotiating type, and do not hesistate to tell you so. Although diplomcy failed, nobody gained an upper hand so the fight is equal.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(1, 1, 0), "Fighting from a distance is exactly what the mages want, and their spells do serious damage to the entire party before they can be brought down by arrow and spell.\n\nAll Party Members -3 HP");
            DI_Responses.Add(new Vector3(1, 1, 1), "Getting close prevents a lot of the mages from focusing, disrupting their spellcasting and preventing any real damage.");
            DI_Responses.Add(new Vector3(1, 1, 2), "Destroying the alchemy set in an explosion deals with all of the mages, but the Knight was stood a little bit too close and so also took some of the blast.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(2, 2, 0), "Enchanting your weapons means you can now harm the ghosts, but they are still quite agile, causing damage with their chilling touch.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(2, 2, 1), "Casting Lightning causes all of the ghosts' forms to shift before finally dissapearing in a cloud of energy, releasing their forms.");
            DI_Responses.Add(new Vector3(2, 2, 2), "Ghosts are naturally cold, and so the ice spell doesn't affect them, and by the time the Wizard beguns to utter magic missile spells, the Rogue has taken severe injuries.\n\nRogue -5 HP");
            DI_Responses.Add(new Vector3(2, 3, 0), "Berzerkers are known for being able to go into a trance-like state, and he is able to completely ignore all words you say. Faster than anyone expected, he is upon your wizard.\n\nWizard -4 HP");
            DI_Responses.Add(new Vector3(2, 3, 1), "The arrow lands square in his chest, and before he can begin moving again another has followed, and he falls to the floor with a groan.");
            DI_Responses.Add(new Vector3(2, 3, 2), "The missile hits his chest, charring his front and he falls backwards. However when you approach the body to make sure he is dead, he uses a final burst of energy to hurt the Knight.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(2, 4, 0), "The frost bolt drives into the Elemental, causing it to writhe and explode. The residual heat does some damage, but the party is mostly unscathed.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(2, 4, 1), "Firing arrows at the Elemental does almost nothing, and the Knight having to wait for the arrows to stop before he can engage means the Elemental can get close and spew fire over the party before being taken down.\n\nAll Party Members -3 HP");
            DI_Responses.Add(new Vector3(2, 4, 2), "Hitting the Elemental with a blade makes it too hot to hold almost immediately, but the distraction was enough for the wizard to bolt the Elemental, defeating it.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(2, 5, 0), "The goblin chief is accustomed to this tactic, and blocks high often, but you are able to get a single blade through his defence, spelling his end.\n\n Rogue -4 HP");
            DI_Responses.Add(new Vector3(2, 5, 1), "Going for his legs proves fruitless, as he traps the Knights' blade beneath one foot before kicking with the other. Whilst impressive, this allows the Wizard an opportunity to strike.\n\nKnight -6 HP");
            DI_Responses.Add(new Vector3(2, 5, 2), "You swing at his chest at the same time he goes for an overhead attack, the blow crumples him immediately.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(3, 6, 0), "Splitting evenly means the wolves go down quickly, as each individually is not that challenging");
            DI_Responses.Add(new Vector3(3, 6, 1), "Focusing on a single wolf at a time means they are dispatched very fast, but some are allowed to flank and hit the wizard.\n\nWizard -4 HP");
            DI_Responses.Add(new Vector3(3, 6, 2), "Creating loud sounds only causes the wolves to pause, meaning they do not all attack at once.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(3, 7, 0), "The prayer causes the evil templar to recoil, but it hisses and lunges forward, tackling the knight before being struck down by the Rogue.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(3, 7, 1), "Fire causes the creature to shriek and fall to the ground. A vampire, it would seem.");
            DI_Responses.Add(new Vector3(3, 7, 2), "The creature's unnatural strength reveals that it is indeed a vampire. The following battle is tough, even with it outnumbered.\n\nKnight -4 HP");
            DI_Responses.Add(new Vector3(3, 8, 0), "Within a second of the hand being inside, the Mimic slams itself shut, trapping the Rogue's hand inside. The Knight smashes it swiftly, but the treasure inside was just an illusion.\n\nRogue -5 HP");
            DI_Responses.Add(new Vector3(3, 8, 1), "Leaving it, you turn around, only for the Mimic to leap forward, scraping the Rogue as it brushes past his shoulder. It is not a tough creature to kill, but still did some damage.\n\nRogue -3 HP");
            DI_Responses.Add(new Vector3(3, 8, 2), "Slamming the lid shut stuns the Mimic momentarily, causing the party to realise what it truly is and deal with it quickly.");
            DI_Responses.Add(new Vector3(3, 9, 0), "The Demon's wings are primarily for show in this underground dungeon, so he is not hindered greatly, which leads him to deal a great deal of damage before he is struck down.\n\nAll Party Members -4 HP");
            DI_Responses.Add(new Vector3(3, 9, 1), "The head is a good place to focus, as the demon is confident his head is out of reach and ignores the rogue in favour of hitting the wizard. The Rogue's agility swiftly proves him wrong.\n\nWizard -3 HP");
            DI_Responses.Add(new Vector3(3, 9, 2), "The hands are where his claws are, and removing the arms deals with this problem. However being on the business end of Demon Claws causes the Knight to take a big hit.\n\nKnight -4 HP");
            DI_Responses.Add(new Vector3(4, 10, 0), "The classic zombie removal method, this does come at a slight cost to the Knight, however.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(4, 10, 1), "The Zombies ignore any pain that might be caused by arrows, and continue to lumber towards the party.\n\nWizard -5 HP");
            DI_Responses.Add(new Vector3(4, 10, 2), "The cone of flame quickly removes any chance of the undead returning any more.");
            DI_Responses.Add(new Vector3(4, 11, 0), "By moving from outer circle, to inner circle you remove all cultists without the other breaking trance, until the dark priest awoke to a room devoid of his followers and you looming over him.");
            DI_Responses.Add(new Vector3(4, 11, 1), "Breaking the inner circle causes the outer circle to also wake, meaning you have to deal with a few angry cultists.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(4, 11, 2), "Attacking the leader of the ritual breaks it, leaving you to fight an entire room of angered cultists.\n\nAll Party Members -3 HP");
            DI_Responses.Add(new Vector3(4, 12, 0), "Electricity does nothing to a slime, and whilst you try to take advantage of a nonexistant stun period, it severely injurs the Rogue\n\nRogue -5 HP");
            DI_Responses.Add(new Vector3(4, 12, 1), "Hitting it with a blade does little to the slime, and slightly damages the blade but this it to switch focus to the Knight, allowing the wizard to blast it apart with magic.\n\nKnight -3 HP");
            DI_Responses.Add(new Vector3(4, 12, 2), "A frozen slime can do nothing, and shattering it is simple.");
            DI_Responses.Add(new Vector3(4, 13, 0), "The Minotaur cannot change direction when charging, so dodging and hitting him as he stomps past works well, but whilst wearing down his endurance the Knight takes a big knock.\n\nKnight -5 HP");
            DI_Responses.Add(new Vector3(4, 13, 1), "He slams his fists, opening up a window to hit many parts of his body. Taking advantage of this, the party does not take too much damage.\n\nAll Party Members -2 HP");
            DI_Responses.Add(new Vector3(4, 13, 2), "The axe is deadly, and looking for an opening is tough. Even grazes do massive damage to the party, and it is a well placed strike from the Rogue that finally ends the beast.\n\nAll Party Members -4 HP");
        }
    }
}
