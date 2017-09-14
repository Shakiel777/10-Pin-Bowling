using UnityEngine;
using System.Collections;

public class ActionMaster {

    public enum Action { Tidy, Reset, EndTurn, EndGame};

    // private int[] bowls = new int[21];  // reminder - arrays start at zero not 1
    private int bowl = 1;

    public Action Bowl (int pins)
    {
        if(pins < 0 || pins > 10){throw new UnityException("Invalid pin count < 0 or > 10!");}

        if (pins == 10) // this is a strike
        {
            bowl += 2; // move to next frame
            return Action.EndTurn;
        }

        if (bowl % 2 != 0) // we are mid-frame (or last frame)
        {
            bowl += 1;  // bump frame to end of frame
            return Action.Tidy;
        }
        else if (bowl % 2 == 0) // we are at end of frame 
        {
            bowl += 1;
            return Action.EndTurn;
        }


        // refactor code from ugly and working to pretty and working!

        throw new UnityException("Not sure what action to return!");
    }
}
