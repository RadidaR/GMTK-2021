using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputScript : MonoBehaviour
{
    ActionMap inputActions;
    public InputData inputData;

    private void Awake()
    {
        inputActions = new ActionMap();

        //inputActions.BotGoblin.Left.performed += ctx => inputData.leftInput = inputActions.BotGoblin.Left.ReadValue<float>();
        //inputActions.BotGoblin.Left.canceled += ctx => inputData.leftInput = inputActions.BotGoblin.Left.ReadValue<float>();
        inputActions.Gameplay.Horizontal.performed += ctx => inputData.horizontalInput = inputActions.Gameplay.Horizontal.ReadValue<float>();
        inputActions.Gameplay.Horizontal.canceled += ctx => inputData.horizontalInput = inputActions.Gameplay.Horizontal.ReadValue<float>();
        
        inputActions.Gameplay.Vertical.performed += ctx => inputData.verticalInput = inputActions.Gameplay.Vertical.ReadValue<float>();
        inputActions.Gameplay.Vertical.canceled += ctx => inputData.verticalInput = inputActions.Gameplay.Vertical.ReadValue<float>();

        //inputActions.BotGoblin.Right.performed += ctx => inputData.rightInput = inputActions.BotGoblin.Right.ReadValue<float>();
        //inputActions.BotGoblin.Right.canceled += ctx => inputData.rightInput = inputActions.BotGoblin.Right.ReadValue<float>();

        //inputActions.BotGoblin.Up.performed += ctx => inputData.upInput = inputActions.BotGoblin.Up.ReadValue<float>();
        //inputActions.BotGoblin.Up.canceled += ctx => inputData.upInput = inputActions.BotGoblin.Up.ReadValue<float>();

        //inputActions.BotGoblin.Down.performed += ctx => inputData.downInput = inputActions.BotGoblin.Down.ReadValue<float>();
        //inputActions.BotGoblin.Down.canceled += ctx => inputData.downInput = inputActions.BotGoblin.Down.ReadValue<float>();

        inputActions.Gameplay.Space.performed += ctx => inputData.spaceInput = inputActions.Gameplay.Space.ReadValue<float>();
        inputActions.Gameplay.Space.canceled += ctx => inputData.spaceInput = inputActions.Gameplay.Space.ReadValue<float>();
        
        inputActions.Gameplay.SwitchControl.performed += ctx => inputData.switchInput = inputActions.Gameplay.SwitchControl.ReadValue<float>();
        inputActions.Gameplay.SwitchControl.canceled += ctx => inputData.switchInput = inputActions.Gameplay.SwitchControl.ReadValue<float>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}
