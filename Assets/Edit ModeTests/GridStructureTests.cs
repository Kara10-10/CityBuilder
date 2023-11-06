using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTests
{
    private GridStructure structure;
   

    [OneTimeSetUp]
    public void Init()
    {
        structure = new GridStructure(3, 100, 100);
    }

    #region GridStructureTest
    
    // A Test behaves as an ordinary method
    [Test]

    public void CalculateGridPositionPasses()
    {
        //Arrange
        GridStructure structure = new GridStructure(3, 100, 100);
        Vector3 position = new Vector3(0, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual( Vector3.zero, returnPosition);
    }
    
    [Test]

    public void CalculateGridPositionFloatsPasses()
    {
        //Arrange
        GridStructure structure = new GridStructure(3, 100, 100);
        Vector3 position = new Vector3(2.9f, 0, 2.9f);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual( Vector3.zero, returnPosition);
    }
    
    [Test]

    public void CalculateGridPositionFail()
    {
        //Arrange
        GridStructure structure = new GridStructure(3, 100, 100);
        Vector3 position = new Vector3(3.1f, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreNotEqual( Vector3.zero, returnPosition);
    }
    public void GridStructureTestsSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator GridStructureTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    #endregion
}
