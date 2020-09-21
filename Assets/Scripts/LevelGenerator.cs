using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    bool IsOutsidePiece(int x, int y)
    {
        // Bounds Check
        if(x >= 0 && x <= 12 && y >= 0 && y <= 13)
        {
            return levelMap[x,y] == 1 || levelMap[x,y] == 2;
        }
        return false;
    }

    bool IsInsidePiece(int x, int y)
    {
        // Bounds Check
        if(x >= 0 && x <= 12 && y >= 0 && y <= 13)
        {
            return levelMap[x,y] == 3 || levelMap[x,y] == 4;
        }
        return false;
    }

    Quaternion GetInsideWallRotation(int x, int y)
    {
        // We are out of the bounds of the map array, just return the default
        if(x < 0 || x > 12 || y < 0 | y > 13 )
        {
            return Quaternion.identity;
        }
        // If we are in the top or bottom row we should be horizontal
        if(x == 0 || x == 13)
        {
            return Quaternion.Euler(0f, 0f, 90f);
            // return new Quaternion(0,0,90,0);
        }
        // If we are in the furthest left or right row we should be vertical
        if(y == 0 || y == 12)
        {
            return Quaternion.identity;
        }
        // If the pieces to the left and right are outside pieces we should be horizontal
        if(IsInsidePiece(x, y-1) && IsInsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 90f); 
        }
        return Quaternion.identity;
    }

    Quaternion GetOutsideWallRotation(int x, int y)
    {
        // We are out of the bounds of the map array, just return the default
        if(x < 0 || x > 12 || y < 0 | y > 13 )
        {
            return Quaternion.identity;
        }
        // If we are in the top or bottom row we should be horizontal
        if(x == 0 || x == 13)
        {
            return Quaternion.Euler(0f, 0f, 90f);
            // return new Quaternion(0,0,90,0);
        }
        // If we are in the furthest left or right row we should be vertical
        if(y == 0 || y == 12)
        {
            return Quaternion.identity;
        }
        // If the pieces to the left and right are outside pieces we should be horizontal
        if(IsOutsidePiece(x, y-1) && IsOutsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 90f); 
        }
        return Quaternion.identity;
    }

    Quaternion GetInsideCornerRotation(int x, int y)
    {
        // We are out of the bounds of the map array, just return the default.
        if(x < 0 || x > 12 || y < 0 | y > 13 )
        {
            return Quaternion.identity;
        }

        if(IsInsidePiece(x+1, y) && IsInsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 0f); 
        }
        if(IsInsidePiece(x-1, y) && IsInsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 90f); 
        }
        if(IsInsidePiece(x-1, y) && IsInsidePiece(x, y-1))
        {
            return Quaternion.Euler(0f, 0f, 180f); 
        }
        if(IsInsidePiece(x+1, y) && IsInsidePiece(x, y-1))
        {
            return Quaternion.Euler(0f, 0f, 270f); 
        }
        return Quaternion.identity;
    }

    Quaternion GetOutsideCornerRotation(int x, int y)
    {
        // We are out of the bounds of the map array, just return the default.
        if(x < 0 || x > 12 || y < 0 | y > 13 )
        {
            return Quaternion.identity;
        }

        if(IsOutsidePiece(x+1, y) && IsOutsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 0f); 
        }
        if(IsOutsidePiece(x-1, y) && IsOutsidePiece(x, y+1))
        {
            return Quaternion.Euler(0f, 0f, 90f); 
        }
        if(IsOutsidePiece(x-1, y) && IsOutsidePiece(x, y-1))
        {
            return Quaternion.Euler(0f, 0f, 180f); 
        }
        if(IsOutsidePiece(x+1, y) && IsOutsidePiece(x, y-1))
        {
            return Quaternion.Euler(0f, 0f, 270f); 
        }
        return Quaternion.identity;
    }

    Quaternion GetTJunctionRotation(int x, int y)
    {
        // We are out of the bounds of the map array, just return the default.
        if(x < 0 || x > 12 || y < 0 | y > 13 )
        {
            return Quaternion.identity;
        }
        return Quaternion.identity;
    }

    void DrawMap(float TopLeftXPosition, float TopLeftYPosition, float XCellOffset, float YCellOffset)
    {
        for(int x = 0; x < 13; x++)
        {
            for(int y = 0; y < 14; y++)
            {
                float SpawnYPosition = TopLeftYPosition + (x * YCellOffset);
                float SpawnXPosition = TopLeftXPosition + (y * XCellOffset);
                Vector2 SpawnPosition = new Vector2(SpawnXPosition, SpawnYPosition);
                Quaternion SpawnRotation = Quaternion.identity;
                int mapValue = levelMap[x,y];
                switch(mapValue)
                {
                    case 0:
                        break;
                    case 1:
                        SpawnRotation = GetOutsideCornerRotation(x, y);
                        Instantiate(OutsideCorner, SpawnPosition, SpawnRotation);
                        break;
                    case 2:
                        SpawnRotation = GetOutsideWallRotation(x, y);
                        Instantiate(OutsideWall, SpawnPosition, SpawnRotation);
                        break;
                    case 3:
                        SpawnRotation = GetInsideCornerRotation(x, y);
                        Instantiate(InsideCorner, SpawnPosition, SpawnRotation);
                        break;
                    case 4:
                        SpawnRotation = GetInsideWallRotation(x, y);
                        Instantiate(InsideWall, SpawnPosition, SpawnRotation);
                        break;
                    case 5:
                        Instantiate(StandardPellet, SpawnPosition, Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(PowerPellet, SpawnPosition, Quaternion.identity);
                        break;
                    case 7:
                        SpawnRotation = GetTJunctionRotation(x, y);
                        Instantiate(TJunction, SpawnPosition, SpawnRotation);
                        break;
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawMap(-12f, 8f, 0.8f, -0.8f);
        DrawMap(9.6f, 8f, -0.8f, -0.8f);
        DrawMap(-12f, -12.8f, 0.8f, 0.8f);
        DrawMap(9.6f, -12.8f, -0.8f, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    [SerializeField]
    Object OutsideCorner;

    [SerializeField]
    Object OutsideWall;

    [SerializeField]
    Object InsideCorner;

    [SerializeField]
    Object InsideWall;

    [SerializeField]
    Object StandardPellet;

    [SerializeField]
    Object PowerPellet;

    [SerializeField]
    Object TJunction;
}
