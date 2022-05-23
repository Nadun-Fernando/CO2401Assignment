namespace CO2401Assignment;

public interface ILightManager
{
    string GetStatus();

    void SetLight(bool isOn, int lightID);

    void SetAllLight(bool isOn);


}