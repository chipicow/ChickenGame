using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickensList : MonoBehaviour
{
    #region Singleton
    public static ChickensList instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public string ZoneDescription;
    public GameObject chickenPrefab;
    public GameObject playerObject;
    public GameObject leftHunter;
    public GameObject rightHunter;
    private List<GameObject> ChickenList = new List<GameObject>();
    private Component rigthHunterMovementComponent;
    private Component leftHunterMovementComponent;
    private int ChickenWave;
    private float Radius;
    private Vector3 center;
    private int ChickenCount;
    void Start()
    {
        center = transform.position;
        Radius = 5f;
        ChickenWave = 0;
        ChickenCount = 3;
    }

    void Update()
    {
        if (ChickenList.Count == 0)
        {
            //new wave
            ChickenWave++;
            if (ChickenWave % 3 == 0)
            {
                ChickenCount++;
                leftHunter.GetComponent<HuntersMovement>().HunterSpeed -= 5f;
                rightHunter.GetComponent<HuntersMovement>().HunterSpeed += 5f;
            }

            for (int i = 0; i < ChickenCount; i++)
            {
                CreateAChicken();
            }
        }

    }

    public void CreateAChicken()
    {
        CreateChicken(chickenPrefab);
    }
    void CreateChicken(GameObject chicken)
    {
        Vector3 pos;
        do
        {
            pos = RandomCircle(center, Radius);
        } while (Vector3.Distance(playerObject.transform.position, transform.position) < 1f);

        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        var clone = (GameObject)Instantiate(Resources.Load(chicken.gameObject.name), pos, rot);
        clone.name = clone.name.Substring(0, clone.name.Length - 7);
        ChickenList.Add(clone);
    }

    public void KillChicken(GameObject chicken)
    {
        ChickenList.Remove(chicken);
        Destroy(chicken);
    }

    //Creating Chicken inside map
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }


}
