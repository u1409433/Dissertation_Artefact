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

    public Dictionary<Vector3, Vector3> DI_Results;

    // Use this for initialization
    void Start()
    {
        DI_Results = new Dictionary<Vector3,Vector3>();
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
        //DI_Results.Add(new Vector3(1,1,0),new Vector3();
    }
}
