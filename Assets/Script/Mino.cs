using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mino : MonoBehaviour
{
    float Fall = 0;

    public GameObject BoomPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Gameover();
        moveMino();
    }

    void moveMino()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 0, 90);

            if (isBlockPos())
            {
                updateGame();
            }
                

            else
            {
                transform.Rotate(0, 0, -90);
            }
                
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (isBlockPos())
            {
                updateGame();
            }
                
            else
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);

            if (isBlockPos())
            {
                updateGame();
            }

            else
            {
                transform.position += new Vector3(-1, 0, 0);
            }
                
        }

        else if (Input.GetKeyDown(KeyCode.S)|| Input.GetKey(KeyCode.Space) || Time.time - Fall >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (isBlockPos())
            {
                updateGame();
            }
            else
            {
                transform.position += new Vector3(0, 1, 0);

                Game.deleteFullRows();

                FindObjectOfType<Random_block>().next();

                enabled = false;
            }

            Fall = Time.time;
        }
    }

    bool isBlockPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Game.round(child.position);

            if (!Game.isInBorder(v))
            {
                return false;
            }
                

            if (Game.bd[(int)v.x, (int)v.y] != null && Game.bd[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
                
        }
        return true;
    }

    void updateGame()
    {
        for (int y = 0; y < Game.bdH; y++)
        {
            for (int x = 0; x < Game.bdW; x++)
            {
                if (Game.bd[x, y] != null)
                {
                    if (Game.bd[x, y].parent == transform)
                    {
                        Game.bd[x, y] = null;
                    }
                }
            }
        }

        foreach (Transform child in transform)
        {
            Vector2 v = Game.round(child.position);
            Game.bd[(int)v.x, (int)v.y] = child;
        }
    }

    /*---GameOver---*/
    void Gameover()
    {
        int minonum = 0;

        for (int y = 0; y < Game.bdH; y++)
        {
            for (int x = 0; x < Game.bdW; x++)
            {
                if (Game.bd[x, y] != null)
                {
                    minonum++;
                    break;
                }
            }
        }

        if (minonum >= 20)
        {
            Debug.Log("Game Over");
            Instantiate(BoomPrefab, transform.position, transform.rotation);
           
            if (minonum >= 22)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Lose");
            }
        }
    }
    
}
