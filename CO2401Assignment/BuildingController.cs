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
        string historyState;

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
        
        /*if (state is "closed" or "out of hours" or "open" or "fire drill" or "fire alarm")
        {
            currentState = state;
            return true;
        }*/

        return false;
    }
}