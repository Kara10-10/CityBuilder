using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;

    public IInputManager inputManager;
    public UIController uiController;
    public int width, length;
    public CameraMovement cameraMovement;

    private GridStructure grid;

    private int cellSize = 3;
    private bool buildingModeActive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraMovement.SetCameraLimits(0, width, 0, length);
        inputManager = FindObjectsOfType<MonoBehaviour>().OfType<IInputManager>().FirstOrDefault();
        grid = new GridStructure(cellSize,width,length);
        inputManager.AddListenerToPointerDownEvent(HandleInput);
        inputManager.AddListenerToOnPointerSecondChangeEvent(HandleInputCameraPan);
        inputManager.AddListenerToOnPointerSecondUpEvent(HandleInputCameraPanStop);
        uiController.AddListenerToOnBuildAreaHandlerEvent(StartPlacementMode);
        uiController.AddListenerToOnCancelActionHandlerEvent(CancleAction);
    }

    private void HandleInputCameraPanStop()
    {
        cameraMovement.StopCameraMovement();
    }

    private void HandleInputCameraPan(Vector3 position)
    {
        if (buildingModeActive == false)
        {
            cameraMovement.MoveCamera(position);
        }
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = grid.CalculateGridPosition(position);
        if(buildingModeActive && grid.IsCellTaken(gridPosition) == false)
            placementManager.CreateBuilding(gridPosition, grid);
            
    }

    private void StartPlacementMode()
    {
        buildingModeActive = true;
    }
    private void CancleAction()
    {
        buildingModeActive = false;
    }
}
