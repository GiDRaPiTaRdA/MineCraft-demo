using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Dictionary<Vector3, GameObject> blocks;

    public static Dictionary<Vector3, GameObject> Blocks => blocks ?? (blocks = new Dictionary<Vector3, GameObject>());

    public static GameObject InitiateBlockObject(GameObject prefab, Vector3 origin)
    {
        GameObject gameObj = null;

        if (!Blocks.ContainsKey(origin))
        {
            gameObj = Instantiate(prefab, origin, Quaternion.identity);

            GameManager.Blocks.Add(origin, gameObj);

        }

        return gameObj;
    }

    public static void DestroyBlockObject(Vector3 origin)
    {
        if (Blocks.ContainsKey(origin))
        {
            GameObject gm = Blocks[origin];

            Blocks.Remove(origin);

            Destroy(gm);
        }
    }
    public static void DestroyBlockObject(GameObject gameObject) =>
        DestroyBlockObject(gameObject.transform.position);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
