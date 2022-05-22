using System;

namespace CO2401Assignment;

public class BuildingController
{
    private string buildingID;
    private string currentState;

    public BuildingController(string id)
    {
        buildingID = id.ToLower();
        currentState = "out of hours";
    }

    public BuildingController(string buildingId, string startState)
    {
        buildingID = buildingId.ToLower();
        
        if (startState is "closed" or "open" or "out of hours")
        {
            currentState = startState.ToLower();
        }
        else
        {
            throw new ArgumentException(
                "Argument Exception: BuildingController can only be initialised to the following states 'open', 'closed', 'out of hours'");
        }
        
    }

    public string GetBuildingID()
    {
        return buildingID;
    }
    
    public void SetBuildingID(string id)
    {
        buildingID = id.ToLower();
    }

    public string GetCurrentState()
    {
        return currentState;
    }

    public bool SetCurrentState(string state)
    {
        string historyState = "";

        if (currentState == "closed" && state is "out of hours")
        {
            currentState = state;
        }
        else if (currentState == "out of hours" && state is "closed" or "open")
        {
            currentState = state;
        } 
        else if (currentState == "open" && state is "out of hours")
        {
            currentState = state;
        }
        else if (currentState is "closed" or "out of hours" or "open" && state is "fire drill" or "fire alarm")
        {
            historyState = currentState;
            currentState = state;
        }
        else if (currentState is "fire drill" or "fire alarm" && state is "closed" or "out of hours" or "open" )
        {
            currentState = historyState;
            SetCurrentState(state);
        }
        
        /*if (state is "closed" or "out of hours" or "open" or "fire drill" or "fire alarm")
        {
            currentState = state;
            return true;
        }*/

        return true;
    }
}