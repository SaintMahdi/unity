using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deadZone = -45f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.left * (moveSpeed * 2) * Time.deltaTime;
        }
        else
        {
            transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
        }



        if (transform.position.x < deadZone)
        {
            Debug.Log("cloud deleted");
            Destroy(gameObject);
        }
    }
}
