﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

    public enum Action { Tidy, Reset, EndTurn, EndGame};


    private int[] bowls = new int[21];  // reminder - arrays start at zero not 1
    private int bowl = 1;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster am = new ActionMaster();
        Action currentAction = new Action();

        foreach (int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }

    private Action Bowl (int pins) // TODO - make private
    {
        if(pins < 0 || pins > 10){throw new UnityException("Invalid pin count < 0 or > 10!");}

        bowls[bowl - 1] = pins;

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        // handle tenth frame
        if (bowl == 19 && pins == 10)
        {
            bowl++;
            return Action.Reset;
        }
        else if(bowl == 20)
        {
            bowl++;
            if (bowls[19-1]== 10 && bowls[20-1] != 10)
            {
                return Action.Tidy;
            }
            else if ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0)
            {
                return Action.Reset;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            }
            else
            {
                return Action.EndGame;
            }
        }

        if (bowl % 2 != 0) // first bowl of frame
        {
            if (pins == 10)
            {
                bowl += 2; // move to next frame
                return Action.EndTurn;
            }else
            {
                bowl += 1;
                return Action.Tidy;
            }
        }
        else if (bowl % 2 == 0) // second bowl of frame
        {
            bowl += 1;
            return Action.EndTurn;
        }


        // refactor code from ugly and working to pretty and working!

        throw new UnityException("Not sure what action to return!");
    }
    private bool Bowl21Awarded()
    {
        // Remeber arrays start counting at zero
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }
}
