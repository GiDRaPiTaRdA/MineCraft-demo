using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePlain : MonoBehaviour
{

    public int sizeX;
    public int sizeY;
    public int sizeZ;

    public GameObject[] blocks;

    public float terHeight;
    public float terDetail;

    private int seed;

    // Use this for initialization
    void Start()
    {
        this.seed = Random.Range(100000, 9999999);

        for (int x = 0; x < this.sizeX; x++)
        {

            for (int z = 0; z < this.sizeZ; z++)
            {
                int maxY = (int)(Mathf.PerlinNoise((x / 2 + this.seed) / this.terDetail, (z / 2 + this.seed) / this.terDetail) * this.terHeight);

                for (int y = 0; y <= maxY; y++)
                {
                    GameObject gameObj;

                    //Grass
                    if(y == maxY) 
                        gameObj = GameManager.InitiateBlockObject(this.blocks[0], new Vector3(x, y, z));
                    //Dirt
                    else if (y == maxY-1)
                    {
                        gameObj = GameManager.InitiateBlockObject(this.blocks[1], new Vector3(x, y, z));
                    }
                    else if (y > maxY-5)
                    {
                        gameObj = GameManager.InitiateBlockObject(Random.Range(1, y - (maxY-1))==1 ? this.blocks[1] : this.blocks[2], new Vector3(x, y, z));
                    }
                    else
                        gameObj = GameManager.InitiateBlockObject(this.blocks[2], new Vector3(x, y, z));

                    if(gameObj!=null)
                        gameObj.transform.parent = this.gameObject.transform;
                }
            }
        }
    }
}
