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
    public bool changingLanes;

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
    public GameEvent eInteract;
    public GameEvent eHit;

    public int qteButtonsCount;
    public List<string> qteButtons;
    public float timeToPressQTE;
    public float qteTimer;

    public LayerMask laneLayers;
    public GameObject markerPrefab;
    public int currentMarkers;
    public List<GameObject> markers;

    public LayerMask boundaryLayer;

    //public Collider2D topCollider;
    //public Collider2D botCollider;

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
        gameData.currentMoveSpeed = gameData.baseMoveSpeed - (0.0125f * gameData.playerLane);

        if (!gameData.frozen)
        {
            if (changingLanes)
            {
                rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            }

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
        else
        {
            rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Walk()
    {
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (gameData.botControl)
                {
                    //Vector3 flip = transform.localScale;
                    //flip.x = flip.x * -inputActions.Gameplay.Horizontal.ReadValue<float>();
                    //transform.localScale = flip;
                    if (!changingLanes)
                    {
                        rigidBody.MovePosition(new Vector2(transform.position.x + (inputActions.Gameplay.Horizontal.ReadValue<float>() * gameData.currentMoveSpeed), transform.position.y));
                    }

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
    }

    void StopWalking()
    {
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (gameData.botControl)
                {
                    eStopWalking.Raise();
                }
            }
        }
    }

    void SpacePressed()
    {
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (gameData.botControl)
                {
                    eJump.Raise();
                }
                else
                {
                    eInteract.Raise();
                }
            }
        }
    }
    void Duck()
    {
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (gameData.botControl)
                {
                    if (walking)
                    {
                        eDuck.Raise();
                    }
                }
            }
        }
    }

    void SwitchPressed()
    {
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                gameData.quickTimeEvent = true;
                StartQuickTimeEvent();
            }
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

        for (int i = 0; i < qteButtonsCount; i++)
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
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (gameData.botControl)
                {
                    //rigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y + (inputActions.Gameplay.Vertical.ReadValue<float>() * gameData.laneDistance)));
                    //eSwitchedLanes.Raise();


                    float direction = inputActions.Gameplay.Vertical.ReadValue<float>();




                    if (gameData.playerLane == 0)
                    {
                        if (direction == 1)
                        {
                            StartCoroutine(SwitchedLanes(direction));
                        }
                    }
                    else if (gameData.playerLane == 7)
                    {
                        if (direction == -1)
                        {
                            StartCoroutine(SwitchedLanes(direction));
                        }
                    }
                    else
                    {
                        StartCoroutine(SwitchedLanes(direction));
                    }
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
    }

    IEnumerator SwitchedLanes(float direction)
    {
        changingLanes = true;
        walking = true;

        GetComponentInChildren<AnimationManager>().PlayAnimation("Goblin Walkcycle");

        //Vector2 newPos = transform.position;
        float currentLaneY = gameData.playerLane * gameData.laneDistance;
        float nextLaneY = (gameData.playerLane + direction) * gameData.laneDistance;

        for (float i = 0; i <= gameData.laneSwitchDuration; i += Time.fixedDeltaTime)
        {
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime);

            float newX = transform.position.x;
            float newY; /*= Mathf.Lerp(currentLaneY, nextLaneY, i / gameData.laneSwitchDuration);*/


            if (i / gameData.laneSwitchDuration >= 0.5)
            {
                RaycastHit2D wallInTheWay = Physics2D.Raycast(transform.position, new Vector2(0, direction), gameData.laneDistance, boundaryLayer);

                //RaycastHit2D nextToBoundary = Physics2D.Raycast(transform.position, new Vector2(-transform.localScale.x, 0).normalized, 4, boundaryLayer);

                if (!wallInTheWay)
                {

                    newY = Mathf.Lerp(currentLaneY, nextLaneY, i / gameData.laneSwitchDuration);

                    //if (!nextToBoundary)
                    //{
                    if (transform.localScale.x < 0)
                    {
                        newX += 0.075f;
                    }
                    else if (transform.localScale.x > 0)
                    {
                        newX -= 0.075f;
                    }
                    //}

                    if (i / gameData.laneSwitchDuration < 0.9f)
                    {
                        rigidBody.MovePosition(new Vector2(newX, newY));
                    }
                    else
                    {
                        rigidBody.MovePosition(new Vector2(newX, nextLaneY));
                    }
                }
                else
                {

                    newY = Mathf.Lerp(nextLaneY, currentLaneY, i / gameData.laneSwitchDuration);

                    //if (!nextToBoundary)
                    //{
                    if (transform.localScale.x < 0)
                    {
                        newX += 0.075f;
                    }
                    else if (transform.localScale.x > 0)
                    {
                        newX -= 0.075f;
                    }
                    //}

                    if (i / gameData.laneSwitchDuration < 0.9f)
                    {
                        rigidBody.MovePosition(new Vector2(newX, newY));
                    }
                    else
                    {
                        rigidBody.MovePosition(new Vector2(newX, currentLaneY));
                    }

                }

                eSwitchedLanes.Raise();

            }
            else
            {
                newY = Mathf.Lerp(currentLaneY, nextLaneY, i / gameData.laneSwitchDuration);

                if (transform.localScale.x < 0)
                {
                    newX += 0.075f;
                }
                else if (transform.localScale.x > 0)
                {
                    newX -= 0.075f;
                }

                rigidBody.MovePosition(new Vector2(newX, newY));

            }


        }

        changingLanes = false;
        walking = false;

    }

    void HorizontalPressed()
    {
        if (!gameData.frozen)
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
                        FlipX(inputActions.Gameplay.Horizontal.ReadValue<float>());
                        walking = true;
                    }

                }
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
                gameData.botControl = false;
                eTopControl.Raise();
            }
            else
            {
                gameData.botControl = true;
                eBotControl.Raise();
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
        if (!gameData.frozen)
        {
            if (!gameData.quickTimeEvent)
            {
                if (!gameData.botControl)
                {
                    currentMarkers = markers.Count;

                    Vector2 click = cam.ScreenToWorldPoint(inputActions.Gameplay.MousePosition.ReadValue<Vector2>());

                    Collider2D[] clickedOn = Physics2D.OverlapCircleAll(click, 0.2f);

                    if (clickedOn.Length > 0)
                    {
                        if (currentMarkers < gameData.maxMarkers)
                        {
                            foreach (Collider2D target in clickedOn)
                            {
                                if (target.gameObject.GetComponentInParent<ControlScript>() == null)
                                {
                                    foreach (Transform child in target.gameObject.transform)
                                    {
                                        if (child.name == "MarkSpot")
                                        {
                                            markers.Add(Instantiate(markerPrefab, child, false));
                                        }
                                    }
                                    //Transform spawnParent = target.gameObject.transform;
                                    //Debug.Log(spawnParent.GetChild(0).name);
                                    //markers.Add(Instantiate(markerPrefab, target.gameObject.transform, false));
                                    //markers.Add(Instantiate(markerPrefab, spawnParent.GetComponentInChildren<MarkSpot>().gameObject.transform, false));


                                }

                            }
                        }
                        else
                        {
                            foreach (Collider2D target in clickedOn)
                            {
                                if (target.gameObject.GetComponentInParent<ControlScript>() == null)
                                {

                                    foreach (Transform child in target.gameObject.transform)
                                    {
                                        if (child.name == "MarkSpot")
                                        {
                                            Destroy(markers[0], 0);
                                            markers.Remove(markers[0]);
                                            markers.Add(Instantiate(markerPrefab, child, false));
                                        }

                                    }
                                }
                            }
                        }
                        currentMarkers = markers.Count;


                    }
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
