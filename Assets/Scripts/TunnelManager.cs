using UnityEngine;

public class TunnelManager : MonoBehaviour
{

    private float startTime = 5f;
    private float coinFrequency = 1f;
    private float nameFrequency = 5f;
    private float carFrequency = 10f;

    [SerializeField] float ySpawnPos = 1;
    [SerializeField] float zSpawnPos = 1;

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject namePrefab;

    public GameObject Env;
    public static bool isEnvExist = true;

    float timeInSpace = 5f;
    void Start()
    {
        

        GameObject sphere = GameObject.FindGameObjectWithTag("Sphere");
        InvokeRepeating("carSpawner", 5f, 5f);
        InvokeRepeating("coinSpawner", 1f, 2f);
    }


    void carSpawner()
    {
        Vector3 pos = TakeRandomPosition();
        Debug.Log("Car Build");
        Instantiate(carPrefab, pos, Quaternion.identity);
    }

    void coinSpawner()
    {
        Vector3 pos = TakeRandomPosition();

       // for(int i =0 ; i < 2 ; i++)
          Instantiate(coinPrefab, pos, Quaternion.identity);

        //pos = TakeRandomPosition();
        //for (int i = 0; i < 2; i++)
           // Instantiate(coinPrefab, pos, Quaternion.identity);

    }

   /* void nameSpawner()
    {

    }*/
    Vector3 TakeRandomPosition()
    {
        return new Vector3(Random.RandomRange(-1,1),ySpawnPos,zSpawnPos);
    }

    public void EnviromentCreator()
    {
        if(!isEnvExist)
        {
            Instantiate(Env, transform.position, Quaternion.identity);
            isEnvExist = true;
           
        }
    }


    private void Update()
    {
        EnviromentCreator();
    }


}
