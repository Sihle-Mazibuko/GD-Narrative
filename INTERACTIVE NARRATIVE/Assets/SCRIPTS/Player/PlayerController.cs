using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float minStopDistance;
    [SerializeField] float maxPickUpDistance;

    Vector2 move;
    Vector2 targetPos;
    bool isMovingToClue;

    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", move.x);
        anim.SetFloat("Vertical", move.y);
        anim.SetFloat("Speed", move.magnitude);

        CheckForClueItems();
        //MoveTowardsClickedPoint();
    }

    void FixedUpdate()
    {
        if (isMovingToClue)
        {
            Vector2 direction = (targetPos - rb.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(rb.position, targetPos) < minStopDistance)
            {
                isMovingToClue = false;
                move = Vector2.zero;
            }
        }
        else
        {
            move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void PickUpClueItem()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Clues"));

        if (hit.collider != null)
        {
            ClueItems clueItem = hit.collider.GetComponent<ClueItems>();
            if (clueItem != null)
            {
                clueItem.gameObject.SetActive(false);
                Debug.Log($"Picked up {clueItem.clueItemName}");

                CluePopUp popup = FindObjectOfType<CluePopUp>();
                if (popup != null)
                {
                    popup.ShowPopUp("New clue found!");
                }
                else
                {
                    Debug.Log("CluePopup object not found!");
                }
            }
        }
    }


    void CheckForClueItems()
    {
        float circleRadius = 3;

        Vector2[] directions = {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right,
        new Vector2(1, 1).normalized,
        new Vector2(1, -1).normalized,
        new Vector2(-1, 1).normalized,
        new Vector2(-1, -1).normalized
    };

        foreach (Vector2 dir in directions)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, circleRadius, dir, maxPickUpDistance, LayerMask.GetMask("Clues"));

            Debug.DrawRay(transform.position, dir * circleRadius, Color.gray);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Clue"))
                {
                    Debug.DrawRay(transform.position, dir * circleRadius, Color.green);

                    Debug.Log($"Circle cast hit: {hit.collider.name} at {hit.point}");

                    if (Input.GetMouseButtonDown(1))
                    {
                        PickUpClueItem();
                    }
                }
                else
                {
                    Debug.Log($"Circle cast hit something other than a clue: {hit.collider.name} at {hit.point}");
                }
            }
            else
            {
            }
        }
    }


    //void MoveTowardsClickedPoint()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

    //        if (hit.collider != null)
    //        {
    //            targetPos = hit.point;
    //            isMovingToClue = true;
    //        }
    //    }
    //}



}
