using UnityEngine;

[CreateAssetMenu(fileName = "Game Data", menuName = "Data/Game")]
public class GameData : ScriptableObject, ISerializationCallbackReceiver
{
    //public bool tutorialCompleted;
    public int startingLife;
    public int currentLife;

    public bool botControl;
    public bool quickTimeEvent;
    public bool invincible;
    public bool hurt;
    public bool frozen;

    public float hurtDuration;

    public int numberOfLanes;

    public float markerDuration;
    public float maxMarkers;

    public float baseMoveSpeed;
    public float currentMoveSpeed;
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
