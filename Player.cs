using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum MoveDirection { Left, Right };


    public MoveDirection moveDirection = MoveDirection.Right;

    public bool isMove = false;
    public bool isLoss = false;
    public bool isShowHowToPlay = false;

    public float stopSpeed = 0.2f;
    public float movingSpeed = 10f;
    public float TurnSpeed = 10f;

    public static int currentScore = 0;
    public int scoreForEachTurn = 15;

    public float timeBeforeShowingHowToPlay;
    public bool removeAllData = false;
    public LayerMask turnLayer;
    public LayerMask lossLayer;
    public float distanceToTurn = 7;
    public float distanceToLoss = 10;
    private int nextAngle = 0;
    private Licence licence;

    public static bool isStart = false;
    public static Player player;

    void Awake()
    {
        player = this;

        if (removeAllData)
            PlayerPrefs.DeleteAll();

        Time.timeScale = 0;

        isMove = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;

        if (!Data.IsShowedHowToPlay())
            StartCoroutine(WaitAndShowHowToPlay());

        licence = GetComponent<Licence>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!licence.IsLicensed())
            return;
        
        MovingPlayer();

        TurnAround();

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, nextAngle, 0)), TurnSpeed * Time.deltaTime);
        
        if (CheckLoss(moveDirection))
            SetLoss();
        
    }

    public void AddScore()
    {
        currentScore += scoreForEachTurn;
    }

    bool TurnAround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceToTurn, turnLayer))
        {
            if (hit.collider != null)
            {
                if (moveDirection == MoveDirection.Right)
                {
                    nextAngle += 90;
                }

                if (moveDirection == MoveDirection.Left)
                {
                    nextAngle -= 90;
                }

                Destroy(hit.collider.gameObject);
            }
        }

        return false;
    }

    public void RemoveHowToPlay()
    {
        ControlUI.controlUI.howToPlayPanel.SetActive(false);
        isMove = true;
        isShowHowToPlay = false;
    }

    IEnumerator WaitAndShowHowToPlay()
    {
        yield return new WaitForSeconds(timeBeforeShowingHowToPlay);

        ControlUI.controlUI.howToPlayPanel.SetActive(true);
        isMove = false;
        isShowHowToPlay = true;
    }

    void MovingPlayer()
    {
        if (isMove)
        {
            if (isLoss)
            {
                movingSpeed = Mathf.Clamp(movingSpeed - stopSpeed * Time.deltaTime, 0, movingSpeed);
            }

            transform.position += transform.forward * movingSpeed * Time.deltaTime;
        }
    }

    bool CheckLoss(MoveDirection direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distanceToLoss, lossLayer))
        {
            if (hit.collider != null)
            {
                return true;
            }
        }
        return false;
    }

    void SetLoss()
    {
        if (!isLoss)
        {
            AudioManager.audioManager.IsLose();
            ControlUI.controlUI.LoseGame();

            StartCoroutine(WaitAndSetTimeZero());
            isLoss = true;
        }
    }

    IEnumerator WaitAndSetTimeZero()
    {
        yield return new WaitForSeconds(3);

        isMove = false;
    }
}
