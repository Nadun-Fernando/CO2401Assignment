using System;
using System.Data;
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
    
    //level 2 test cases

    [Test]
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
    
    //level 3 test cases
    
    [Test]
    public void Check_return_Statements_for_GetStatusReport()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _lightManager.GetStatus().Returns("Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        _fireAlarmManager.GetStatus().Returns("FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        _doorManager.GetStatus().Returns("Doors,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        //Act
        var result = _buildingController.GetStatusReport();

        //Assert
        Assert.AreEqual(result,"Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,Doors,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
    }

    [Test]
    public void return_statement_of_lightManagerClass()
    {
        //Arrange
        _lightManager.GetStatus().Returns("Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        
        //Act
        var result = _lightManager.GetStatus();
        
        //Assert
        Assert.AreEqual(result,"Lights,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        
    }

    [Test]
    public void return_statement_of_doorManagerClass()
    {
        //Arrange
        _doorManager.GetStatus().Returns("Doors,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        
        //Act
        var result = _doorManager.GetStatus();
        
        //Assert
        Assert.AreEqual(result,"Doors,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        
    }

    [Test]
    public void return_statement_of_fireAlarmManageerClass()
    {
        //Arrange
        _fireAlarmManager.GetStatus().Returns("FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
        
        //Act
        var result = _fireAlarmManager.GetStatus();
        
        //Assert
        Assert.AreEqual(result,"FireAlarm,OK,OK,FAULT,OK,OK,OK,OK,FAULT,OK,OK,");
    }

    [Test]
    public void SetCurrentState_to_open_while_openAllDoors_returns_false()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _doorManager.OpenAllDoors().Returns(false);

        //Act
        var result = _buildingController.SetCurrentState("open");
        
        //Assert
        Assert.AreEqual(result,false);
    }

    [Test]
    public void SetCurrentState_to_open_while_openAllDoors_returns_true()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _doorManager.OpenAllDoors().Returns(true);
        
        //Act
        _buildingController.SetCurrentState("open");
        var result = _buildingController.GetCurrentState();
        
        //Assert
        Assert.AreEqual(result,"open");
    }
    */

    //level 4 test cases

    [Test]
    public void SetCurrentState_moved_to_closed_state_with_lockAllDoors_returning_true()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _doorManager.LockAllDoors().Returns(true);

        //Act
        _buildingController.SetCurrentState("closed");

        //Assert
        _doorManager.Received().LockAllDoors();
    }

    [Test]
    public void test_when_state_changed_to_fireAlarm_and_log_is_made()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _doorManager.OpenAllDoors().Returns(true);

        //Act
        _buildingController.SetCurrentState("fire alarm");

        //Assert
        _webService.Received().LogFireAlarm("fire alarm");
    }

    [Test]
    public void fault_in_lights()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _lightManager.GetStatus().Returns("FAULT");
        _doorManager.GetStatus().Returns("OK");
        _fireAlarmManager.GetStatus().Returns("OK");

        //Act
        _buildingController.GetStatusReport();
        
        //Assert
        _webService.LogEngineerRequired("Lights,");
    }
    
    [Test]
    public void fault_in_two_interfaces()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);
        _lightManager.GetStatus().Returns("FAULT");
        _doorManager.GetStatus().Returns("FAULT");
        _fireAlarmManager.GetStatus().Returns("OK");

        //Act
        _buildingController.GetStatusReport();
        
        //Assert
        _webService.LogEngineerRequired("Lights,Doors,");
    }
    
    [Test]
    public void if_exception_thrown_when_fire_alarm_state_called()
    {
        //Arrange
        _buildingController = new BuildingController("asdf", _lightManager, _fireAlarmManager, _doorManager,
            _webService, _emailService);

        //Act
        _buildingController.SetCurrentState("fire alarm").Returns(x => { throw new Exception("error"); });

        //Assert
        _emailService.Received().SendMail("smartbuilding@uclan.ac.uk", "failed to log alarm", "error");

    }
}