using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class ControlScript : MonoBehaviour
{
    ActionMap inputActions;

    Rigidbody2D rigidBody;

    public Camera cam;

    public GameData gameData;
    //public InputData inputData;
    public bool walking;

    public GameEvent eJump;
    public GameEvent eDuck;
    public GameEvent eSwitchedLanes;
    public GameEvent eQTEStarted;
    public GameEvent eQTEButtonPressed;
    public GameEvent eWrongButtonPressed;
    public GameEvent eTopControl;
    public GameEvent eBotControl;
    public GameEvent eMoving;
    public GameEvent eStopWalking;

    public int qteButtonsCount;
    public List<string> qteButtons;
    public float timeToPressQTE;
    public float qteTimer;

    public LayerMask laneLayers;
    public GameObject markerPrefab;
    public int currentMarkers;
    public List<GameObject> markers;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        inputActions = new ActionMap();

        inputActions.Gameplay.Horizontal.performed += ctx => HorizontalPressed();
        inputActions.Gameplay.Horizontal.performed += ctx => eMoving.Raise();
        inputActions.Gameplay.Horizontal.canceled += ctx => walking = false;
        inputActions.Gameplay.Horizontal.canceled += ctx => StopWalking();

        //inputActions.Gameplay.Vertical.performed += ctx => SwitchLanes();
        inputActions.Gameplay.Vertical.performed += ctx => VerticalPressed();

        inputActions.Gameplay.Space.performed += ctx => SpacePressed();

        inputActions.Gameplay.Duck.performed += ctx => Duck();

        inputActions.Gameplay.SwitchControl.performed += ctx => SwitchPressed();

        inputActions.Gameplay.Enter.performed += ctx => EnterPressed();

        inputActions.Gameplay.Mark.performed += ctx => Clicked();
    }

    private void FixedUpdate()
    {
        if (gameData.quickTimeEvent)
        {
            if (qteTimer > 0)
            {
                qteTimer -= Time.fixedDeltaTime;
            }
            else if (qteTimer <= 0)
            {
                qteTimer = 0;
                StartQuickTimeEvent();
            }
        }

        if (gameData.botControl)
        {
            if (walking)
            {
                Walk();
            }            
        }
    }

    void Walk()
    {
        if (!gameData.quickTimeEvent)
        {
            if (gameData.botControl)
            {
                //Vector3 flip = transform.localScale;
                //flip.x = flip.x * -inputActions.Gameplay.Horizontal.ReadValue<float>();
                //transform.localScale = flip;

                rigidBody.MovePosition(new Vector2(transform.position.x + (inputActions.Gameplay.Horizontal.ReadValue<float>() * gameData.moveSpeed), transform.position.y));

                //if (inputActions.Gameplay.Horizontal.ReadValue<float>() == 0)
                //{
                //    StopWalking();
                //}
                //else 
                //{
                //    //eWalk.Raise();
                //}
            }
        }
    }

    void StopWalking()
    {
        eStopWalking.Raise();
    }

    void SpacePressed()
    {
        if (!gameData.quickTimeEvent)
        {
            if (gameData.botControl)
            {
                eJump.Raise();
            }
        }
    }
    void Duck()
    {
        if (!gameData.quickTimeEvent)
        {
            if (gameData.botControl)
            {
                eDuck.Raise();
            }
        }
    }

    void SwitchPressed()
    {
        if (!gameData.quickTimeEvent)
        {
            gameData.quickTimeEvent = true;
            StartQuickTimeEvent();
        }
    }

    void EnterPressed()
    {
        if (gameData.quickTimeEvent)
        {
            qteButtons.Clear();
            gameData.quickTimeEvent = false;
        }
    }

    void StartQuickTimeEvent()
    {
        eQTEStarted.Raise();

        List<string> sequence = new List<string>();

        for (int i=0; i < qteButtonsCount; i++)
        {
            int button = Random.Range(1, 5);
            if (button == 1)
            {
                string left = "Left";
                sequence.Add(left);
            }
            
            if (button == 2)
            {
                string right = "Right";
                sequence.Add(right);
            }
            
            if (button == 3)
            {
                string up = "Up";
                sequence.Add(up);
            }
            
            if (button == 4)
            {
                string down = "Down";
                sequence.Add(down);
            }
        }

        qteButtons = sequence;
        qteTimer = timeToPressQTE;
    }

    void VerticalPressed()
    {
        if (!gameData.quickTimeEvent)
        {
            if (gameData.botControl)
            {
                rigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y + (inputActions.Gameplay.Vertical.ReadValue<float>() * gameData.laneDistance)));
                //eSwitchedLanes.Raise();
                StartCoroutine(SwitchedLanes());
            }
        }
        else
        {
            string direction;
            if (inputActions.Gameplay.Vertical.ReadValue<float>() == -1)
            {
                direction = "Down";
            }
            else if (inputActions.Gameplay.Vertical.ReadValue<float>() == 1)
            {
                direction = "Up";
            }
            else
            {
                direction = null;
            }

            if (direction == qteButtons[0])
            {
                QuickTimeButtonPressed();
            }
            else
            {
                WrongButtonPressed();
            }
        }
    }

    IEnumerator SwitchedLanes()
    {
        yield return new WaitForSecondsRealtime(0.125f);
        eSwitchedLanes.Raise();
    }

    void HorizontalPressed()
    {
        if (gameData.quickTimeEvent)
        {
            //Debug.Log("Switching");
            string direction;
            if (inputActions.Gameplay.Horizontal.ReadValue<float>() == -1)
            {
                direction = "Left";
            }
            else if (inputActions.Gameplay.Horizontal.ReadValue<float>() == 1)
            {
                direction = "Right";
            }
            else
            {
                direction = null;
            }
            //Debug.Log(direction + " direction");
            //Debug.Log(switchButtons[0] + " switch Button");


            if (direction == qteButtons[0])
            {
                QuickTimeButtonPressed();
            }
            else
            {
                WrongButtonPressed();
            }
        }
        else
        {
            if (gameData.botControl)
            {
                if (inputActions.Gameplay.Horizontal.ReadValue<float>() != 0)
                {
                    eMoving.Raise();
                    FlipX(inputActions.Gameplay.Horizontal.ReadValue<float>());
                }

                walking = true;
            }
        }

    }

    void FlipX(float newScale)
    {
        Vector2 scale = transform.localScale;

        if (newScale < 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (newScale > 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    void QuickTimeButtonPressed()
    {
        //Debug.Log("Right button");
        qteButtons.Remove(qteButtons[0]);
        eQTEButtonPressed.Raise();
        qteTimer = timeToPressQTE;

        if (qteButtons.Count == 0)
        {
            gameData.quickTimeEvent = false;

            if (gameData.botControl)
            {
                eTopControl.Raise();
                gameData.botControl = false;
            }
            else
            {
                eBotControl.Raise();
                gameData.botControl = true;
            }
        }
    }

    void WrongButtonPressed()
    {
        qteButtons.Clear();
        eWrongButtonPressed.Raise();
        StartQuickTimeEvent();
    }

    void Clicked()
    {
        if (!gameData.quickTimeEvent)
        {
            if (!gameData.botControl)
            {
                currentMarkers = markers.Count;

                Vector2 click = cam.ScreenToWorldPoint(inputActions.Gameplay.MousePosition.ReadValue<Vector2>());

                Collider2D[] clickedOn = Physics2D.OverlapCircleAll(click, 1);

                if (clickedOn.Length > 0)
                {
                    if (currentMarkers < gameData.maxMarkers)
                    {
                        foreach (Collider2D target in clickedOn)
                        {
                            if (target.gameObject.GetComponentInParent<ControlScript>() == null)
                            {
                                Debug.Log("Here");
                                markers.Add(Instantiate(markerPrefab, target.gameObject.transform, false));

                            }

                        }
                    }
                    currentMarkers = markers.Count;


                }
            }
        }
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
