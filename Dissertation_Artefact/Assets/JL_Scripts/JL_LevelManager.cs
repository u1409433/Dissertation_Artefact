using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JL_LevelManager : MonoBehaviour
{
    public int IN_TacticScore;
    public int IN_KnightHP;
    public int IN_RogueHP;
    public int IN_WizardHP;

    public int IN_TotalScore;
    public int IN_Difficulty = 2;

    public bool BL_AmuletActive = true;
    public int IN_AmuletHolder = 3; //Begin at 3 as that is everyone
    public int IN_PotionsLeft = 3;

    public bool BL_SetA = true;

    public Dictionary<Vector3, Vector3> DI_Results;

    private JL_UIManager SC_UIManager;

    // Use this for initialization
    void Start()
    {
        SC_UIManager = GameObject.Find("UIManager").GetComponent<JL_UIManager>();
        DI_Results = new Dictionary<Vector3, Vector3>();
        SetupDictionary();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AdaptiveDifficulty(int vtacscore)
    {
        if (SC_UIManager.IN_Level == 1)
        {
            if (IN_TacticScore <= 1)
            {
                if (IN_Difficulty > -1) IN_Difficulty--;
            }
            else if (IN_TacticScore == 2)
            {
                //Do nothing to the difficulty
            }
            else if (IN_TacticScore >= 3)
            {
                if (IN_Difficulty < 1) IN_Difficulty++;
            }
        }
        else
        {
            if (IN_TacticScore <= 3)
            {
                if (IN_Difficulty > -1) IN_Difficulty--;
            }
            else if (IN_TacticScore > 3 && IN_TacticScore < 6)
            {
                //Do nothing to the difficulty
            }
            else if (IN_TacticScore >= 6)
            {
                if (IN_Difficulty < 1) IN_Difficulty++;
            }
        }
    }

    public void NextLevel()
    {
        IN_RogueHP = 10;
        IN_KnightHP = 10;
        IN_WizardHP = 10;
        AdaptiveDifficulty(IN_TacticScore);
    }

    public void HPCheck()
    {
        if (IN_KnightHP > 10) IN_KnightHP = 10;
        if (IN_RogueHP > 10) IN_RogueHP = 10;
        if (IN_WizardHP > 10) IN_WizardHP = 10;
    }

    public void ChoiceMade(Vector3 vV3_Choice)
    {
        
        Vector3 V3_Result = DI_Results[vV3_Choice];
        print("The Result is: " + V3_Result.ToString());

        bool tBL_AmuletUsed = false;
        int tIN_Char = (int)V3_Result.x;
        if (V3_Result.x + V3_Result.y == 0)
        {
            //Do nothing if the result is (0,0,z)
        }
        else
        {
            int tIN_Damage = (int)V3_Result.y + IN_Difficulty;
            switch (tIN_Char)
            {
                case 0:
                    if (IN_AmuletHolder == 0) tBL_AmuletUsed = true;
                    else IN_KnightHP -= tIN_Damage;
                    break;
                case 1:
                    if (IN_AmuletHolder == 1) tBL_AmuletUsed = true;
                    else IN_RogueHP -= tIN_Damage;
                    break;
                case 2:
                    if (IN_AmuletHolder == 2) tBL_AmuletUsed = true;
                    else IN_WizardHP -= tIN_Damage;
                    break;
                case 3:
                    if (IN_AmuletHolder == 0)
                    {
                        tBL_AmuletUsed = true;
                        IN_RogueHP -= tIN_Damage;
                        IN_WizardHP -= tIN_Damage;
                    }
                    else if (IN_AmuletHolder == 1)
                    {
                        tBL_AmuletUsed = true;
                        IN_KnightHP -= tIN_Damage;
                        IN_WizardHP -= tIN_Damage;
                    }
                    else if (IN_AmuletHolder == 2)
                    {
                        tBL_AmuletUsed = true;
                        IN_KnightHP -= tIN_Damage;
                        IN_RogueHP -= tIN_Damage;
                    }
                    else
                    {
                        IN_KnightHP -= tIN_Damage;
                        IN_RogueHP -= tIN_Damage;
                        IN_WizardHP -= tIN_Damage;
                    }
                    break;
            }
        }        

        IN_TacticScore += (int)V3_Result.z;

        if (tBL_AmuletUsed)
        {
            BL_AmuletActive = false;
            SC_UIManager.AmuletUsed();
            IN_AmuletHolder = 3;
        }
    }

    void SetupDictionary()
    {
        if (BL_SetA)
        {
            DI_Results.Add(new Vector3(1, 0, 0), new Vector3(0,3,0));
            DI_Results.Add(new Vector3(1, 0, 1), new Vector3(0,0,1));
            DI_Results.Add(new Vector3(1, 0, 2), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(1, 1, 0), new Vector3(2,5,0));
            DI_Results.Add(new Vector3(1, 1, 1), new Vector3(0,1,1));
            DI_Results.Add(new Vector3(1, 1, 2), new Vector3(1,2,1));
            DI_Results.Add(new Vector3(2, 2, 0), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(2, 2, 1), new Vector3(1,3,0));
            DI_Results.Add(new Vector3(2, 2, 2), new Vector3(3,2,2));
            DI_Results.Add(new Vector3(2, 3, 0), new Vector3(0,4,1));
            DI_Results.Add(new Vector3(2, 3, 1), new Vector3(0,6,1));
            DI_Results.Add(new Vector3(2, 3, 2), new Vector3(1,3,0));
            DI_Results.Add(new Vector3(2, 4, 0), new Vector3(0,2,1));
            DI_Results.Add(new Vector3(2, 4, 1), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(2, 4, 2), new Vector3(3,1,2));
            DI_Results.Add(new Vector3(2, 5, 0), new Vector3(3,2,1));
            DI_Results.Add(new Vector3(2, 5, 1), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(2, 5, 2), new Vector3(2,3,0));
            DI_Results.Add(new Vector3(3, 6, 0), new Vector3(3,2,1));
            DI_Results.Add(new Vector3(3, 6, 1), new Vector3(3,1,2));
            DI_Results.Add(new Vector3(3, 6, 2), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(3, 7, 0), new Vector3(0,4,0));
            DI_Results.Add(new Vector3(3, 7, 1), new Vector3(1,2,2));
            DI_Results.Add(new Vector3(3, 7, 2), new Vector3(3,4,0));
            DI_Results.Add(new Vector3(3, 8, 0), new Vector3(0,0,2));
            DI_Results.Add(new Vector3(3, 8, 1), new Vector3(3,1,1));
            DI_Results.Add(new Vector3(3, 8, 2), new Vector3(0,3,2));
            DI_Results.Add(new Vector3(3, 9, 0), new Vector3(3,1,2));
            DI_Results.Add(new Vector3(3, 9, 1), new Vector3(1,5,0));
            DI_Results.Add(new Vector3(3, 9, 2), new Vector3(0,0,2));
           DI_Results.Add(new Vector3(4, 10, 0), new Vector3(1,3,2));
           DI_Results.Add(new Vector3(4, 10, 1), new Vector3(3,2,1));
           DI_Results.Add(new Vector3(4, 10, 2), new Vector3(2,4,0));
           DI_Results.Add(new Vector3(4, 11, 0), new Vector3(3,2,1));
           DI_Results.Add(new Vector3(4, 11, 1), new Vector3(0,2,2));
           DI_Results.Add(new Vector3(4, 11, 2), new Vector3(3,3,0));
           DI_Results.Add(new Vector3(4, 12, 0), new Vector3(0,3,0));
           DI_Results.Add(new Vector3(4, 12, 1), new Vector3(0,3,2));
           DI_Results.Add(new Vector3(4, 12, 2), new Vector3(1,5,1));
           DI_Results.Add(new Vector3(4, 13, 0), new Vector3(2,6,0));
           DI_Results.Add(new Vector3(4, 13, 1), new Vector3(0,3,1));
           DI_Results.Add(new Vector3(4, 13, 2), new Vector3(3,2,2));
        }
        else
        {
            DI_Results.Add(new Vector3(1, 0, 0), new Vector3(1, 3, 0));
            DI_Results.Add(new Vector3(1, 0, 1), new Vector3(0, 1, 3));
            DI_Results.Add(new Vector3(1, 0, 2), new Vector3(3, 1, 0));
            DI_Results.Add(new Vector3(1, 1, 0), new Vector3(3, 2, 0));
            DI_Results.Add(new Vector3(1, 1, 1), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(1, 1, 2), new Vector3(0, 2, 1));
            DI_Results.Add(new Vector3(2, 2, 0), new Vector3(3, 1, 1));
            DI_Results.Add(new Vector3(2, 2, 1), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(2, 2, 2), new Vector3(1, 4, 0));
            DI_Results.Add(new Vector3(2, 3, 0), new Vector3(2, 3, 0));
            DI_Results.Add(new Vector3(2, 3, 1), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(2, 3, 2), new Vector3(0, 2, 1));
            DI_Results.Add(new Vector3(2, 4, 0), new Vector3(3, 1, 2));
            DI_Results.Add(new Vector3(2, 4, 1), new Vector3(3, 3, 0));
            DI_Results.Add(new Vector3(2, 4, 2), new Vector3(0, 2, 1));
            DI_Results.Add(new Vector3(2, 5, 0), new Vector3(1, 3, 1));
            DI_Results.Add(new Vector3(2, 5, 1), new Vector3(0, 5, 0));
            DI_Results.Add(new Vector3(2, 5, 2), new Vector3(0, 2, 2));
            DI_Results.Add(new Vector3(3, 6, 0), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(3, 6, 1), new Vector3(2, 3, 0));
            DI_Results.Add(new Vector3(3, 6, 2), new Vector3(3, 1, 1));
            DI_Results.Add(new Vector3(3, 7, 0), new Vector3(0, 2, 1));
            DI_Results.Add(new Vector3(3, 7, 1), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(3, 7, 2), new Vector3(0, 3, 0));
            DI_Results.Add(new Vector3(3, 8, 0), new Vector3(1, 4, 0));
            DI_Results.Add(new Vector3(3, 8, 1), new Vector3(1, 2, 1));
            DI_Results.Add(new Vector3(3, 8, 2), new Vector3(0, 0, 2));
            DI_Results.Add(new Vector3(3, 9, 0), new Vector3(3, 3, 0));
            DI_Results.Add(new Vector3(3, 9, 1), new Vector3(2, 2, 2));
            DI_Results.Add(new Vector3(3, 9, 2), new Vector3(0, 3, 1));
           DI_Results.Add(new Vector3(4, 10, 0), new Vector3(0, 2, 1));
           DI_Results.Add(new Vector3(4, 10, 1), new Vector3(2, 4, 0));
           DI_Results.Add(new Vector3(4, 10, 2), new Vector3(0, 0, 2));
           DI_Results.Add(new Vector3(4, 11, 0), new Vector3(0, 0, 2));
           DI_Results.Add(new Vector3(4, 11, 1), new Vector3(3, 1, 1));
           DI_Results.Add(new Vector3(4, 11, 2), new Vector3(3, 2, 0));
           DI_Results.Add(new Vector3(4, 12, 0), new Vector3(1, 4, 0));
           DI_Results.Add(new Vector3(4, 12, 1), new Vector3(0, 2, 1));
           DI_Results.Add(new Vector3(4, 12, 2), new Vector3(0, 0, 2));
           DI_Results.Add(new Vector3(4, 13, 0), new Vector3(0, 4, 1));
           DI_Results.Add(new Vector3(4, 13, 1), new Vector3(3, 1, 2));
           DI_Results.Add(new Vector3(4, 13, 2), new Vector3(3, 3, 0));
        }
        SC_UIManager.SetupDictionary();
    }
}
