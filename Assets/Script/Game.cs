using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int bdW = 12;
    public static int bdH = 25;
    public static Transform[,] bd = new Transform[bdW, bdH];


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static Vector2 round(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    public static bool isInBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < bdW && (int)pos.y >= 0);
    }

    public static void deleteRow(int y)
    {
        for (int x = 0; x < bdW; x++)
        {
            Destroy(bd[x, y].gameObject);
            bd[x, y] = null;
        }
    }

    public static void removeRow(int y)
    {
        for (int x = 0; x < bdW; x++)
        {
            if (bd[x, y] != null)
            {
                bd[x, y - 1] = bd[x, y];
                bd[x, y] = null;
                bd[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public static void removeRowsAll(int y)
    {
        for (int i = y; i < bdH; i++)
        {
            removeRow(i);
        }
            
    }

    public static bool isFull(int y)
    {
        for (int x = 0; x < bdW; x++)
        {
            if (bd[x, y] == null)
            {
                return false;
            }
                
        }
        return true;
    }

    public static void deleteFullRows()
    {
        for (int y = 0; y < bdH; y++)
        {
            if (isFull(y))
            {
                deleteRow(y);
                removeRowsAll(y + 1);
                y--;
            }
        }
    }

    
}
