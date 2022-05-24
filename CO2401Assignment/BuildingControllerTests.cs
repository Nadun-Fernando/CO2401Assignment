using NSubstitute;
using NUnit.Framework;

namespace CO2401Assignment;

[TestFixture]
public class BuildingControllerTests
{

    private IDoorManager _doorManager;
    private IEmailService _emailService;
    private IFireAlarmManager _fireAlarmManager;
    private ILightManager _lightManager;
    private IWebService _webService;

    private BuildingController _buildingController;

    [SetUp]
    public void Setup()
    {
        _doorManager = Substitute.For<IDoorManager>();
        _emailService = Substitute.For<IEmailService>();
        _lightManager = Substitute.For<ILightManager>();
        _fireAlarmManager = Substitute.For<IFireAlarmManager>();
        _webService = Substitute.For<IWebService>();

        

    }

    [Test]
    public void Check_if_ID_passed_to_through_Constructor()
    {
        //Arrange
        var iD = "sdfkjljkl";
        _buildingController = new BuildingController(iD);
        
        //Act
        var result1 = _buildingController.GetBuildingID();

        //Assert
        Assert.AreEqual(result1, iD);

    }
}