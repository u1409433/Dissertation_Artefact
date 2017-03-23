﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JL_UIManagerB : MonoBehaviour
{
    private JL_LevelManagerB SC_LevelManager;

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
        SC_LevelManager = GameObject.Find("LevelManager").GetComponent<JL_LevelManagerB>();
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
                UI_ScenarioText.text = "A flame atronach sits in the centre of a burning room, revelling in the fire as it dances around the room. Upon seeing you, it stops and begins to whip up and inferno inside itself, preparing for combat.\n\nWhat do you do to fight this fiery foe?";
                UI_TextA.text = "Cast a Frost Bolt";
                UI_TextB.text = "Shoot an Arrow";
                UI_TextC.text = "Swing a sword";
                break;
            case 5:
                UI_ScenarioText.text = "The stench of the room hits you as you walk in, and it is obvious that the Goblin Chief that resides here has done so for quite some time. Bones litter the floor. A hulking figure in comparison to a regular goblin, has has armour and a large axe. Which part of him do you focus on?";
                UI_TextA.text = "Focus on hitting the head";
                UI_TextB.text = "Try to hit the midriff";
                UI_TextC.text = "Swing at his legs";
                break;
            case 6:
                UI_ScenarioText.text = "The cave you have entered that crosses the dungeon is the home to a pack of wolves. As you stnad in the maw of the cave, they begin to snarl and attempt to circle the party.";
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
        DI_Responses.Add(new Vector3(1, 0, 0), "Dwarves are resistant to fire, thus the spell does little more than anger them further.\n\nRogue -3 HP");
        DI_Responses.Add(new Vector3(1, 0, 1), "Although they look tough, without their armour their size hinders them and there is little damage sustained.\n\nKnight -1 HP");
        DI_Responses.Add(new Vector3(1, 0, 2), "They are not the negotiating type, and do not hesistate to tell you so. Although diplomcy failed, nobody gained an upper hand so the fight is equal.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(1, 1, 0), "Fighting from a distance is exactly what the mages want, and their spells do serious damage to the entire party before they can be brought down by arrow and spell.\n\nAll Party Members -2 HP");
        DI_Responses.Add(new Vector3(1, 1, 1), "Getting close prevents a lot of the mages from focusing, disrupting their spellcasting and preventing any real damage.");
        DI_Responses.Add(new Vector3(1, 1, 2), "Destroying the alchemy set in an explosion deals with all of the mages, but the Knight was stood a little bit too close and so also took some of the blast.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(2, 2, 0), "Enchanting your weapons means you can now harm the ghosts, but they are still quite agile, causing damage with their chilling touch.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(2, 2, 1), "Casting Lightning causes all of the ghosts' forms to shift before finally dissapearing in a cloud of energy, releasing their forms.");
        DI_Responses.Add(new Vector3(2, 2, 2), "Ghosts are naturally cold, and so the ice spell doesn't affect them, and by the time the Wizard beguns to utter magic missile spells, the Rogue has taken severe injuries.\n\nRogue -4 HP");
        DI_Responses.Add(new Vector3(2, 3, 0), "Berzerkers are known for being able to go into a trance-like state, and he is able to completely ignore all words you say. Faster than anyone expected, he is upon your wizard.\n\nWizard -3 HP");
        DI_Responses.Add(new Vector3(2, 3, 1), "The arrow lands square in his chest, and before he can begin moving again another has followed, and he falls to the floor with a groan.");
        DI_Responses.Add(new Vector3(2, 3, 2), "The missile hits his chest, charring his front and he falls backwards. However when you approach the body to make sure he is dead, he uses a final burst of energy to hurt the Knight.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(2, 4, 0), "The frost bolt drives into the atronach, causing it to writhe and explode. The residual heat does some damage, but the party is mostly unscathed.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(2, 4, 1), "Firing arrows at the atronach does almost nothing, and the Knight having to wait for the arrows to stop before he can engage means the atronach can get close and spew fire over the party before being taken down.\n\nAll Party Members -3 HP");
        DI_Responses.Add(new Vector3(2, 4, 2), "Hitting the atronach with a blade makes it too hot to hold almost immediately, but the distraction was enough for the wizard to bolt the atronach, defeating it.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(2, 5, 0), "The goblin chief is accustomed to this tactic, and blocks high often, but you are able to get a single blade through his defence, spelling his end.\n\n Rogue -3 HP");
        DI_Responses.Add(new Vector3(2, 5, 1), "Going for his legs proves fruitless, as he traps the Knights' blade beneath one foot before kicking with the other. Whilst impressive, this allows the Wizard an opportunity to strike.\n\nKnight -5 HP");
        DI_Responses.Add(new Vector3(2, 5, 2), "Swinging at his chest at the same time he goes for an overhead attack, the blow crumples him immediately.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(2, 6, 0), "Splitting evenly means the wolves go down quickly, as each individually is not that challenging");
        DI_Responses.Add(new Vector3(2, 6, 1), "Focusing on a single wolf at a time means they are dispatched very fast, but some are allowed to flank and hit the wizard.\n\nWizard -3 HP");
        DI_Responses.Add(new Vector3(1, 6, 2), "Creating loud sounds only causes the wolves to pause, meaning they do not all attack at once.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(1, 7, 0), "The prayer causes the evil templar to recoil, but it hisses and lunges forward, tackling the knight before being struck down by the Rogue.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(1, 7, 1), "Fire causes the creature to shriek and fall to the ground. A vampire, it would seem.");
        DI_Responses.Add(new Vector3(1, 7, 2), "The creature's unnatural strength reveals that it is indeed a vampire. The following battle is tough, even with it outnumbered.\n\nKnight -3 HP");
        DI_Responses.Add(new Vector3(1, 8, 0), "Within a second of the hand being inside, the Mimic slams itself shut, trapping the Rogue's hand inside. The Knight smashes it swiftly, but the treasure inside was just an illusion.\n\nRogue -4 HP");
        DI_Responses.Add(new Vector3(1, 8, 1), "Leaving it, you turn around, only for the Mimic to leap forward, scraping the Rogue as it brushes past his shoulder. It is not a tough creature to kill, but still did some damage.\n\nRogue -2 HP");
        DI_Responses.Add(new Vector3(1, 8, 2), "Slamming the lid shut stuns the Mimic momentarily, causing the party to realise what it truly was and deal with it quickly.");
        DI_Responses.Add(new Vector3(1, 9, 0), "The Demon's wings are primarily for show in this underground dungeon, so he is not hindered greatly, which leads him to deal a great deal of damage before he is struck down.\n\nAll Party Members -3 HP");
        DI_Responses.Add(new Vector3(1, 9, 1), "The head is a good place to focus, as the demon is confident his head is out of reach and ignores the rogue in favour of hitting the wizard. The Rogue's agility swiftly proves him wrong.\n\nWizard -2 HP");
        DI_Responses.Add(new Vector3(1, 9, 2), "The hands are where his claws are, and removing the arms deals with this problem. However being on the business end of Demon Claws causes the Knight to take a big hit.\n\nKnight -3 HP");
        DI_Responses.Add(new Vector3(1, 10, 0), "The classic zombie removal method, this does come at a slight cost to the Knight, however.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(1, 10, 1), "The Zombies ignore any pain that might be caused by arrows, and continue to lumber towards the party.\n\nWizard -4 HP");
        DI_Responses.Add(new Vector3(1, 10, 2), "The cone of flame quickly removes any chance of the undead returning any more.");
        DI_Responses.Add(new Vector3(1, 11, 0), "By moving from outer circle, to inner circle you remove all cultists without the other breaking trance, until the dark priest awoke to a room devoid of his followers and you looming over him.");
        DI_Responses.Add(new Vector3(1, 11, 1), "Breaking the inner circle causes the outer circle to also wake, meaning you have to deal with a few angry cultists.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(1, 11, 2), "Attacking the leader of the ritual breaks it, leaving you to fight an entire room of angered cultists.\n\nAll Party Members -2HP");
        DI_Responses.Add(new Vector3(1, 12, 0), "Electricity does nothing to a slime, and whilst you try to take advantage of a nonexistant stun period, it severely injurs the Rogue\n\nRogue -4 HP");
        DI_Responses.Add(new Vector3(1, 12, 1), "Hitting it with a blade does little to the slime, and slightly damages the blade but this it to switch focus to the Knight, allowing the wizard to blast it apart with magic.\n\nKnight -2 HP");
        DI_Responses.Add(new Vector3(1, 12, 2), "A frozen slime can do nothing, and shattering it is simple.");
        DI_Responses.Add(new Vector3(1, 13, 0), "The Minotaur cannot change direction when charging, so dodging and hitting him as he stomps past works well, but whilst wearing down his endurance the Knight takes a big knock.\n\nKnight -4 HP");
        DI_Responses.Add(new Vector3(1, 13, 1), "He slams his fists, opening up a window to hit many parts of his body. Taking advantage of this, the party does not take too much damage.\n\nAll Party Members -1 HP");
        DI_Responses.Add(new Vector3(1, 13, 2), "The axe is deadly, and looking for an opening is tough. Even grazes do massive damage to the party, and it is a well placed strike from the Rogue that finally ends the beast.\n\nAll Party Members -3 HP");
    }
}