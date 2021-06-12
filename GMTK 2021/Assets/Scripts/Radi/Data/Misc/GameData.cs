using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Data/Game")]
public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    public bool botControl;
    public bool quickTimeEvent;
    
    public float moveSpeed;
    public float laneDistance;

    void ResetGameplayValues()
    {
        quickTimeEvent = false;
        botControl = true;
    }
    public void OnAfterDeserialize()
    {
        ResetGameplayValues();
    }

    public void OnBeforeSerialize()
    {

    }
}