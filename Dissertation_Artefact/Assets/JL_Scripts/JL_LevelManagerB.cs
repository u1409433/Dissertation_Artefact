using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JL_LevelManagerB : MonoBehaviour
{
    public int IN_TacticScore;
    public int IN_KnightHP;
    public int IN_RogueHP;
    public int IN_WizardHP;

    public int IN_TotalScore;
    public int IN_Difficulty = 2;

    public Dictionary<Vector3, Vector3> DI_Results;

    // Use this for initialization
    void Start()
    {
        DI_Results = new Dictionary<Vector3, Vector3>();
        SetupDictionary();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AdaptiveDifficulty(int vtacscore)
    {
        if (IN_TacticScore <= 3)
        {
            if (IN_Difficulty > 1) IN_Difficulty--;
        }
        else if (IN_TacticScore > 3 && IN_TacticScore < 6)
        {
            //Do nothing to the score
        }
        else if (IN_TacticScore >= 7)
        {
            if (IN_Difficulty < 3) IN_Difficulty++;
        }
    }

    public void NextLevel()
    {
        IN_RogueHP = 10;
        IN_KnightHP = 10;
        IN_WizardHP = 10;
        AdaptiveDifficulty(IN_TacticScore);
    }

    public void ChoiceMade(Vector3 vV3_Choice)
    {

    }

    void SetupDictionary()
    {
        DI_Results.Add(new Vector3(1, 0, 0), new Vector3(1,3,0));
        DI_Results.Add(new Vector3(1, 0, 1), new Vector3(0,1,3));
        DI_Results.Add(new Vector3(1, 0, 2), new Vector3(3,1,0));
        DI_Results.Add(new Vector3(1, 1, 0), new Vector3(3,2,0));
        DI_Results.Add(new Vector3(1, 1, 1), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(1, 1, 2), new Vector3(0,2,1));
        DI_Results.Add(new Vector3(2, 2, 0), new Vector3(3,1,1));
        DI_Results.Add(new Vector3(2, 2, 1), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(2, 2, 2), new Vector3(1,4,0));
        DI_Results.Add(new Vector3(2, 3, 0), new Vector3(2,3,0));
        DI_Results.Add(new Vector3(2, 3, 1), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(2, 3, 2), new Vector3(0,2,1));
        DI_Results.Add(new Vector3(2, 4, 0), new Vector3(3,1,2));
        DI_Results.Add(new Vector3(2, 4, 1), new Vector3(3,3,0));
        DI_Results.Add(new Vector3(2, 4, 2), new Vector3(0,2,1));
        DI_Results.Add(new Vector3(2, 5, 0), new Vector3(1,3,1));
        DI_Results.Add(new Vector3(2, 5, 1), new Vector3(0,5,0));
        DI_Results.Add(new Vector3(2, 5, 2), new Vector3(0,2,2));
        DI_Results.Add(new Vector3(2, 6, 0), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(2, 6, 1), new Vector3(2,3,0));
        DI_Results.Add(new Vector3(1, 6, 2), new Vector3(3,1,1));
        DI_Results.Add(new Vector3(1, 7, 0), new Vector3(0,2,1));
        DI_Results.Add(new Vector3(1, 7, 1), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(1, 7, 2), new Vector3(0,3,0));
        DI_Results.Add(new Vector3(1, 8, 0), new Vector3(1,4,0));
        DI_Results.Add(new Vector3(1, 8, 1), new Vector3(1,2,1));
        DI_Results.Add(new Vector3(1, 8, 2), new Vector3(0,0,2));
        DI_Results.Add(new Vector3(1, 9, 0), new Vector3(3,3,0));
        DI_Results.Add(new Vector3(1, 9, 1), new Vector3(2,2,2));
        DI_Results.Add(new Vector3(1, 9, 2), new Vector3(0,3,1));
       DI_Results.Add(new Vector3(1, 10, 0), new Vector3(0,2,1));
       DI_Results.Add(new Vector3(1, 10, 1), new Vector3(2,4,0));
       DI_Results.Add(new Vector3(1, 10, 2), new Vector3(0,0,2));
       DI_Results.Add(new Vector3(1, 11, 0), new Vector3(0,0,2));
       DI_Results.Add(new Vector3(1, 11, 1), new Vector3(3,1,1));
       DI_Results.Add(new Vector3(1, 11, 2), new Vector3(3,2,0));
       DI_Results.Add(new Vector3(1, 12, 0), new Vector3(1,4,0));
       DI_Results.Add(new Vector3(1, 12, 1), new Vector3(0,2,1));
       DI_Results.Add(new Vector3(1, 12, 2), new Vector3(0,0,2));
       DI_Results.Add(new Vector3(1, 13, 0), new Vector3(0,4,1));
       DI_Results.Add(new Vector3(1, 13, 1), new Vector3(3,1,2));
       DI_Results.Add(new Vector3(1, 13, 2), new Vector3(3,3,0));
    }
}
