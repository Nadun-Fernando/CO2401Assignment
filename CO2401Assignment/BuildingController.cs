using System;

namespace CO2401Assignment;

public class BuildingController
{
    private string buildingID;
    private string currentState;

    private ILightManager iLightManager;
    private IFireAlarmManager iFireAlarmManager;
    private IDoorManager iDoorManager;
    private IWebService iWebService;
    private IEmailService iEmailService;
    

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

    public BuildingController(string id, ILightManager iLightManager, IFireAlarmManager iFireAlarmManager,
        IDoorManager iDoorManager, IWebService iWebService, IEmailService iEmailService)
    {
        buildingID = id.ToLower();
        currentState = "out of hours";

        this.iLightManager = iLightManager;
        this.iFireAlarmManager = iFireAlarmManager;
        this.iDoorManager = iDoorManager;
        this.iWebService = iWebService;
        this.iEmailService = iEmailService;
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
        
        
        //level 02 requirements 
        if (currentState == "closed" && state is "out of hours")
        {
            currentState = state;
        }
        else if (currentState == "out of hours" && state is "closed" or "open")
        {
            if (state is "open")
            {
                if (!iDoorManager.OpenAllDoors())
                {
                    return false;
                }
                else
                {
                    currentState = state;
                }
            }
            
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
            if (historyState is "open")
            {
                if (!iDoorManager.OpenAllDoors())
                {
                    return false;
                }
                else
                {
                    currentState = historyState;
                }
            }
            else
            {
                currentState = historyState;
            }
            
            SetCurrentState(state);
        }
       
        
        //level 01 requirements 
        /*if (state is "closed" or "out of hours" or "open" or "fire drill" or "fire alarm")
        {
            currentState = state;
            return true;
        }*/

        return true;
    }
    
    //level 03 requirements
    public string GetStatusReport()
    {
        string lightStatus = iLightManager.GetStatus();
        string doorStatus = iDoorManager.GetStatus();
        string fireAlarmStatus = iFireAlarmManager.GetStatus();
        
        return lightStatus + doorStatus + fireAlarmStatus;
    }
}