using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Data/Game")]
public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    //public bool tutorialCompleted;
    public int startingHealth;
    public int currentHealth;

    public bool botControl;
    public bool quickTimeEvent;
    public bool invincible;
    public bool hurt;
    public bool frozen;

    public float hurtDuration;

    public int numberOfLanes;

    public float markerDuration;
    public float maxMarkers;
    
    public float moveSpeed;
    public float laneDistance;
    public float laneSwitchDuration;

    public int playerLane;

    void ResetGameplayValues()
    {
        quickTimeEvent = false;
        botControl = true;
        invincible = false;
        hurt = false;
        frozen = false;
        //tutorialCompleted = false;

    }
    public void OnAfterDeserialize()
    {
        ResetGameplayValues();
    }

    public void OnBeforeSerialize()
    {

    }
}
