using UnityEngine;

    [CreateAssetMenu(fileName = "Input Data", menuName = "Data/Input")]
public class InputData : ScriptableObject, ISerializationCallbackReceiver
{
    public float horizontalInput;
    public float verticalInput;
    public float spaceInput;
    public float switchInput;
    public float enterInput; 
    public float clickInput; 

    public void ResetValues()
    {
        horizontalInput = 0;
        verticalInput = 0;
        spaceInput = 0;
        switchInput = 0;
        enterInput = 0;
        clickInput = 0;
    }

    public void OnAfterDeserialize()
    {
        ResetValues();
    }

    public void OnBeforeSerialize()
    {
    }
}


