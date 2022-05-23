namespace CO2401Assignment;

public interface IDoorManager
{
    string GetStatus();
    bool OpenDoor(int doorID);
    bool LockDoor(int doorID);
    bool OpenAllDoors();
    bool LockAllDoors();

}