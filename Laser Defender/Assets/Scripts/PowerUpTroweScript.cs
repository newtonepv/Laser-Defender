using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTroweScript : MonoBehaviour
{
    [SerializeField] float mooveSpeed;
    private float[] yBounds;
    private float[] xBounds;
    [SerializeField] float trimX;
    [SerializeField] float trimY;
    private Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        SetBounds();
        moveDirection = new Vector2(1, 0);
    }
    void SetBounds()
    {
        Camera mainCam = Camera.main;
        Vector2 minPoint = mainCam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPoint = mainCam.ViewportToWorldPoint(new Vector2(1, 1));
        yBounds = new float[] { minPoint.y + trimY, maxPoint.y - trimY };
        xBounds = new float[] { minPoint.x + trimX, maxPoint.x - trimX };
    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        MoveOrNot();
    }

    void MoveOrNot()
    {
        float dt = Time.fixedDeltaTime;

        Vector2 delta = moveDirection * mooveSpeed * dt;

        Vector2 newPos = transform.position + new Vector3(delta.x, delta.y, 0);

        if (newPos.x <= xBounds[0] || newPos.x >= xBounds[1])
        {
            newPos.x = transform.position.x;
            moveDirection *= -1;
        }
        transform.position = newPos;
    }
    public void GetMoveInput(Vector2 movement)
    {
        moveDirection = movement;

    }
}
