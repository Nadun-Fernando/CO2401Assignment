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

    //level 1 test cases 
    
    /*
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

    [Test]
    public void Check_if_ID_passed_through_constructor_converts_to_lowercase_if_uppercase()
    {
        //Arrange
        var idLowerCase = "asdfg";
        var idUpperCase = "ASDFG";
        _buildingController = new BuildingController(idUpperCase);
        
        //Act
        var result2 = _buildingController.GetBuildingID();

        //Assert
        Assert.AreEqual(result2, idLowerCase);
        
    }

    [Test]
    public void Check_SetBuildingID_functionality()
    {
        //Arrange
        var initialID = "qwerty";
        var finalID = "asdf";
        _buildingController = new BuildingController(initialID);

        //Act
        _buildingController.SetBuildingID(finalID);
        var result3 = _buildingController.GetBuildingID();

        //Assert
        Assert.AreEqual(result3, finalID);
    }

    [Test]
    public void Check_if_setBuildingID_changes_uppercase_to_lowercase()
    {
        //Arrange
        var initialID = "QWERTY";
        var finalIDUpperCase = "ASDF";
        var finalIDLowerCase = "asdf";
        _buildingController = new BuildingController(initialID);
        
        //Act
        _buildingController.SetBuildingID(finalIDUpperCase);
        var result4 = _buildingController.GetBuildingID();

        //Assert
        Assert.AreEqual(result4, finalIDLowerCase);
    }

    [Test]
    public void Check_if_it_accepts_numbers_and_special_characters()
    {
        //Arrange
        var id = "asd12%^";
        _buildingController = new BuildingController(id);
        
        //Act
        var result5 = _buildingController.GetBuildingID();

        //Assert
        Assert.AreEqual(result5, id);
    }

    [Test]
    public void Check_if_constructor_initially_sets_currentState_to_outOfHours()
    {
        //Arrange
        var id = "asdf";
        var state = "out of hours";
        _buildingController = new BuildingController(id);
        
        //Act
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result, state);
    }

    [Test]
    public void Check_if_SetState_functionality()
    {
        //Arrange
        var changedState = "open";
        _buildingController = new BuildingController("asdf");
        
        //Act
        _buildingController.SetCurrentState(changedState);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result, changedState);
    }

    [Test]
    public void Check_if_invalid_state_Set()
    {
        //Arrange
        var changedState = "invalid";
        _buildingController = new BuildingController("asdf");
        
        //Act
        _buildingController.SetCurrentState(changedState);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result, changedState);
    }
    */
    
    //level 2 test cases

    /*[Test]
    public void Check_state_change_from_closed_to_outOfHours()
    {
        //Arrange
        var stateChange = "out of hours";
        _buildingController = new BuildingController("asds","closed");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_open_to_outOfHours() 
    {
        //Arrange
        var stateChange = "out of hours";
        _buildingController = new BuildingController("asds","open");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_outOfHours_to_closed()
    {
        //Arrange
        var stateChange = "closed";
        _buildingController = new BuildingController("asds","out of hours");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_outOfHours_to_open()
    {
        //Arrange
        var stateChange = "open";
        _buildingController = new BuildingController("asds","out of hours");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_open_to_closed()
    {
        //Arrange
        var stateChange = "closed";
        _buildingController = new BuildingController("asds","open");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_closed_to_fireDrill()
    {
        //Arrange
        var stateChange = "fire drill";
        _buildingController = new BuildingController("asds","closed");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_state_change_from_open_to_fireAlarm()
    {
        //Arrange
        var stateChange = "fire alarm";
        _buildingController = new BuildingController("asds","open");
        
        //Act
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,stateChange);
    }
    
    [Test]
    public void Check_constructor_accepts_fireAlarm()
    {
        //Arrange
        var state = "fire alarm";
        _buildingController = new BuildingController("asds",state);
        
        //Act
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,state);
    }
    [Test]
    public void Check_state_change_from_fireDrill_to_fireAlarm()
    {
        //Arrange
        var stateChange1 = "fire alarm";
        var stateChange2 = "fire drill";
        _buildingController = new BuildingController("asds","open");

        //Act
        _buildingController.SetCurrentState(stateChange2);
        _buildingController.SetCurrentState(stateChange1);
        var result = _buildingController.GetCurrentState();

        //Assert
        Assert.AreEqual(result,stateChange1);
    }

    [Test]
    public void Check_state_change_from_fireAlarm_to_new_state()
    {
        //Arrange
        var stateChange = "open";
        _buildingController = new BuildingController("asdf", "open");

        //Act
        _buildingController.SetCurrentState("fire alarm");
        _buildingController.SetCurrentState(stateChange);
        var result = _buildingController.GetCurrentState();

        //Assert
        Assert.AreEqual(result,stateChange);
    }

    [Test]
    public void Check_change_state_to_same_state()
    {
        //Arrange
        var newState = "open";
        _buildingController = new BuildingController("asdf", "open");

        //Act
        _buildingController.SetCurrentState(newState);
        var result = _buildingController.GetCurrentState();

        //Assert
        Assert.AreEqual(result,newState);
    }
    */
    
    //level 3 test cases
    
}