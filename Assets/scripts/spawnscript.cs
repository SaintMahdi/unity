using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject cloud;
    public float spawanRate = 3;
    private float timer = 0;
    public float heightOffset = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloudSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawanRate)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                timer += Time.deltaTime * 2;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        else
        {
            cloudSpawner();
            timer = 0;
        }

    }
    private void cloudSpawner()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
