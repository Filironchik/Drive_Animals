//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Tilemaps;

//public enum Directions {up, right, down, left};

//public class PlayerControler : MonoBehaviour
//{
//    [SerializeField] private float speed, cor;


//    [SerializeField] private GameObject Players;
//    [SerializeField] private Vector3 PlayerPosition, PlayerNewPosition;

//    [SerializeField] private TileBase TileWall, tileDirections;
//    [SerializeField] private TileBase Tile;

//    [SerializeField] private Vector3Int TilePosition, TileNewPosition;
//    [SerializeField] private Tilemap map;

//    [SerializeField] private Directions Direction;

//    [SerializeField] private bool finish = false;

//    [SerializeField]
//    private TileBase
//       DirectionTileTop, DirectionTileRight, DirectionTileDown, DirectionTileLeft;

//    private void Start()
//    {
//        PositionPlayer();
//        PlayerNewPosition = PlayerPosition;
//        PlayerNewPosition.y++;
//    }

//    //узнаём мировые и тайловые координаты игрока
//    private void PositionPlayer()
//    {
//        PlayerPosition = Players.transform.position;
//        TilePosition = (Vector3Int)map.WorldToCell(PlayerPosition);
//    }

//    //узнаём на каком тайле находится игрок
//    private void FileTypeDefinition(Vector3Int position)
//    {
//        Tile = map.GetTile(position);
//    }

//    private void DirectionMovement(Directions direction)
//    {
//        Direction = direction;
//    }


//    private void CheckingPath(Vector3Int position)
//    {
//        if (Direction == Directions.up)
//        {
//            position.y = position.y + 1;
//            FileTypeDefinition(position);
//            if (!(Tile == TileWall))
//            {
//                DirectionMovement(Directions.up);
//            } else 
//            {
//                position.y = position.y - 1;
//                position.x = position.x - 1;
//                FileTypeDefinition(position);
//                if (!(Tile == TileWall))
//                {
//                    DirectionMovement(Directions.left);
//                }
//                else
//                { 
//                    //position.x = position.x + 2;
//                    DirectionMovement(Directions.right);
//                }
//            }
//        }
//        if (Direction == Directions.right) 
//        {
//            position.x = position.x + 1;
//            FileTypeDefinition(position);
//            if (!(Tile == TileWall))
//            {
//                DirectionMovement(Directions.right);
//            }
//            else
//            {
//                position.x = position.x - 1;
//                position.y = position.y + 1;
//                FileTypeDefinition(position);
//                if (!(Tile == TileWall))
//                {
//                    DirectionMovement(Directions.up);
//                }
//                else
//                {
//                    //position.y = position.y - 2;
//                    DirectionMovement(Directions.down);
//                }
//            }
//        }
//        if (Direction == Directions.down)
//        {
//            position.y = position.y - 1;
//            FileTypeDefinition(position);
//            if (!(Tile == TileWall))
//            {
//                DirectionMovement(Directions.down);
//            }
//            else
//            {
//                position.y = position.y + 1;
//                position.x = position.x + 1;
//                FileTypeDefinition(position);
//                if (!(Tile == TileWall))
//                {
//                    DirectionMovement(Directions.right);
//                }
//                else
//                {
//                    //position.x = position.x - 2;
//                    DirectionMovement(Directions.left);
//                }
//            }
//        }
//        if (Direction == Directions.left)
//        {
//            position.x = position.x - 1;
//            FileTypeDefinition(position);
//            if (!(Tile == TileWall))
//            {
//                DirectionMovement(Directions.left);
//            }
//            else
//            {
//                position.x = position.x + 1;
//                position.y = position.y - 1;
//                FileTypeDefinition(position);
//                if (!(Tile == TileWall))
//                {
//                    DirectionMovement(Directions.down);
//                }
//                else 
//                {
//                    //position.y = position.y + 2;
//                    DirectionMovement(Directions.up);
//                }
//            }
//        }
//    }

//    private void quicklyChangeDirection()
//    {
//        FileTypeDefinition(TilePosition);
//        if (Tile == DirectionTileTop)
//        {
//            DirectionMovement(Directions.up);
//            CheckingPath(TilePosition);
//        } 
//        else if (Tile == DirectionTileRight)
//        {
//            DirectionMovement(Directions.right);
//            CheckingPath(TilePosition);
//        } 
//        else if (Tile == DirectionTileDown)
//        {
//            DirectionMovement(Directions.down);
//            CheckingPath(TilePosition);
//        } 
//        else if (Tile == DirectionTileLeft)
//        {
//            DirectionMovement(Directions.left);
//            CheckingPath(TilePosition);
//        }


//        PositionPlayer();
        
//        if (PlayerNewPosition == PlayerPosition)
//        {
//            CheckingPath(TilePosition);
//        }
        
//    }

//    private void AveragePositionTile()
//    {
//        PlayerNewPosition = map.WorldToCell(TilePosition);
//    }

//    private void ComparisonPositions()
//    {
//        PositionPlayer();
//        PlayerPosition = PlayerPosition;
//        if (PlayerNewPosition == PlayerPosition)
//        {
//            if (Direction == Directions.up)
//            {
//                PlayerNewPosition.y = PlayerNewPosition.y + 1;
//                //AveragePositionTile();

//            }
//            else if (Direction == Directions.right)
//            {
//                PlayerNewPosition.x = PlayerNewPosition.x + 1;
//                //AveragePositionTile();

//            }
//            else if (Direction == Directions.down)
//            {
//                PlayerNewPosition.y = PlayerNewPosition.y - 1;
//                //AveragePositionTile();

//            }
//            else if (Direction == Directions.left)
//            {
//                PlayerNewPosition.x = PlayerNewPosition.x - 1;
//                //AveragePositionTile();

//            }
//        }
//    }

//    void test()
//    {
//        PositionPlayer();

//    }

//    private void Update()
//    {
        
//        ComparisonPositions();
//        quicklyChangeDirection();
//    }
//    private void FixedUpdate()
//    {
//        if (Direction == Directions.up)
//        {
//            transform.position += new Vector3(0, speed, 0) * Time.deltaTime * speed;
//        }
//        if (Direction == Directions.down)
//        {
//            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime * speed;
//        }
//        if (Direction == Directions.left)
//        {
//            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime * speed;
//        }
//        if (Direction == Directions.right)
//        {
//            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * speed;
//        }
//    }
//}
