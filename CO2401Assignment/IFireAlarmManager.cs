namespace CO2401Assignment;

public interface IFireAlarmManager
{
    string GetStatus();
    void SetAlarm(bool isActive);
}