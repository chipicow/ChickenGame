using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    #region Singleton
    public static GameController instance;

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
    public GameObject dogPrefab;
    public GameObject spawnerPrefab;
    public DeathMenu deathMenu;

    private List<GameObject> ChickenList = new List<GameObject>();
    private ShootingManager rigthHunterShooting;
    private ShootingManager leftHunterShooting;
    private HuntersMovement rigthHunterMovement;
    private HuntersMovement leftHunterMovement;



    public int ChickenWave { get; private set; }
    private float Radius;
    private Vector3 center;
    private int ChickenCount;
    private int numberOfDogs;
    void Start()
    {
        center = transform.position;
        Radius = 5f;
        ChickenWave = 0;
        ChickenCount = 3;
        rigthHunterShooting = rightHunter.GetComponent<ShootingManager>();
        leftHunterShooting = leftHunter.GetComponent<ShootingManager>();
        rigthHunterMovement = rightHunter.GetComponent<HuntersMovement>();
        leftHunterMovement = leftHunter.GetComponent<HuntersMovement>();
    }

    void Update()
    {
        if (ChickenList.Count == 0)
        {
            //New Wave
            ChickenWave++;
            if (ChickenWave % 3 == 0)
            {
                ChickenCount++;
                if (rigthHunterShooting.HunterFireCooldown >= 1.1f)
                {
                    rigthHunterShooting.HunterFireCooldown -= 0.1f;
                    leftHunterShooting.HunterFireCooldown -= 0.1f;
                }
                if (rigthHunterMovement.HunterSpeed >= 1.1f)
                {
                    rigthHunterMovement.HunterSpeed -= 0.1f;
                    leftHunterMovement.HunterSpeed -= 0.1f;
                }
            }

            if (ChickenWave % 10 == 0)
            {
                numberOfDogs++;
            }


            for (int i = 0; i < ChickenCount; i++)
            {
                CreateAChicken();
            }

            CreateDogs(numberOfDogs);
        }

    }

    public void CreateAChicken()
    {
        CreateChicken(chickenPrefab);
    }
    void CreateChicken(GameObject chicken)
    {
        Vector3 pos = RandomCircle(center, Radius);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
        var clone = (GameObject)Instantiate(Resources.Load(chicken.gameObject.name), pos, rot);
        clone.name = clone.name.Substring(0, clone.name.Length - 7);
        ChickenList.Add(clone);
    }

    public void KillChicken(GameObject chicken)
    {
        Destroy(chicken);
        ChickenList.Remove(chicken);
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

    void CreateDogs(int i)
    {
        List<string> positions = new List<string>() { "top", "bottom", "left", "right" };
        for (int j = 0; j < i; j++)
        {
            if (positions.Count == 0)
                return;
            int dogPosition = Random.Range(1, positions.Count);
            switch (positions[dogPosition])
            {
                case "top":
                    dogPrefab.transform.position = new Vector3(0, dogPrefab.transform.position.y, 5.5f);
                    spawnerPrefab.transform.position = new Vector3(0, spawnerPrefab.transform.position.y, 5.5f);
                    StartCoroutine(SpawnDog(positions, dogPosition));
                    break;
                case "bottom":
                    dogPrefab.transform.position = new Vector3(0, dogPrefab.transform.position.y, -5.5f);
                    spawnerPrefab.transform.position = new Vector3(0, spawnerPrefab.transform.position.y, -5.5f);
                    StartCoroutine(SpawnDog(positions, dogPosition));
                    break;
                case "left":
                    dogPrefab.transform.position = new Vector3(-5.5f, dogPrefab.transform.position.y, 0);
                    spawnerPrefab.transform.position = new Vector3(-5.5f, dogPrefab.transform.position.y, 0);
                    StartCoroutine(SpawnDog(positions, dogPosition));
                    break;
                case "right":
                    dogPrefab.transform.position = new Vector3(5.5f, dogPrefab.transform.position.y, 0);
                    spawnerPrefab.transform.position = new Vector3(5.5f, dogPrefab.transform.position.y, 0);
                    StartCoroutine(SpawnDog(positions, dogPosition));
                    break;
            }
        }

    }




    IEnumerator SpawnDog(List<string> positions, int dogPosition)
    {
        var dogWarning = (GameObject)Instantiate(Resources.Load(spawnerPrefab.name));
        yield return new WaitForSeconds(0.5f);
        Destroy(dogWarning);
        var clone = (GameObject)Instantiate(Resources.Load(dogPrefab.name));
        clone.name = clone.name.Substring(0, clone.name.Length - 7);
        positions.RemoveAt(dogPosition);
    }

    public void PlayerDied()
    {
        if (ChickenWave > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", ChickenWave);
        }
        Destroy(playerObject);
        deathMenu.OnDeathMenu();

    }
}
