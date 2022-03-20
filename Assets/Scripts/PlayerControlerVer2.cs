using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public enum Directions { up, right, down, left, stop };
public enum Motions { move, stop };
public class PlayerControlerVer2 : MonoBehaviour
{
    [SerializeField] private Directions Direction;
    [SerializeField] private Motions motion;

    [SerializeField] private float speed;

    //[SerializeField] Collider2D trUp, trDown, trLeft, trRight;
    [SerializeField] Vector3 oldPos, newPos;

    [SerializeField] private GameObject Players;
    [SerializeField] private Vector3 PlayerPosition, PlayerNewPosition;

    [SerializeField] private TileBase TileWall, tileDirections;
    [SerializeField] private TileBase Tile;

    [SerializeField] private Vector3Int TilePosition, TileNewPosition;
    [SerializeField] private Tilemap map;

    [SerializeField] private Rigidbody2D rb;

    public float posi;


    
    private void DirectionMovement(Directions direction)
    {
        this.Direction = direction;
    }


    //узнаём мировые и тайловые координаты игрока
    private void PositionPlayer()
    {
        PlayerPosition = Players.transform.position;
        TilePosition = (Vector3Int)map.WorldToCell(PlayerPosition);
    }

    //узнаём на каком тайле находится игрок
    private void FileTypeDefinition(Vector3Int position)
    {
        Tile = map.GetTile(position);
    }


    private void FixedUpdate()
    {
        if (motion == Motions.move)
        {
            if (Direction == Directions.up)
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime * speed;
                //rb.velocity = new Vector3(0, speed, 0) * speed;
            }
            if (Direction == Directions.down)
            {
                transform.position += new Vector3(0, -speed, 0) * Time.deltaTime * speed;
                //rb.velocity = new Vector3(0, -speed, 0) * speed;
            }
            if (Direction == Directions.left)
            {
                transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime * speed;
                //rb.velocity = new Vector3(-speed, 0, 0) * speed;
            }
            if (Direction == Directions.right)
            {
                transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * speed;
                //rb.velocity = new Vector3(speed, 0, 0) * speed;
            }
        }
    }

    private void CheckingPath(Vector3Int position)
    {
        if (Direction == Directions.up)
        {
            Motion(Directions.up);


            position.y = position.y + 1;
            FileTypeDefinition(position);
            if (!(Tile == TileWall))
            {
                DirectionMovement(Directions.up);
                motion = Motions.move;
                Debug.Log("Движение вверх");
            }
            else
            {
                position.y = position.y - 1;
                position.x = position.x - 1;
                FileTypeDefinition(position);
                if (!(Tile == TileWall))
                {
                    DirectionMovement(Directions.left);
                    Debug.Log("Движение влево");
                    motion = Motions.move;
                }
                else
                {
                    //position.x = position.x + 2;
                    DirectionMovement(Directions.right);
                    Debug.Log("Движение вправо");
                    motion = Motions.move;
                }

            }
        }
        if (Direction == Directions.right)
        {
            Motion(Directions.right);

            position.x = position.x + 1;
            FileTypeDefinition(position);
            if (!(Tile == TileWall))
            {
                DirectionMovement(Directions.right);
                motion = Motions.move;
            }
            else
            {
                position.x = position.x - 1;
                position.y = position.y + 1;
                FileTypeDefinition(position);
                if (!(Tile == TileWall))
                {
                    DirectionMovement(Directions.up);
                    motion = Motions.move;
                }
                else
                {
                    //position.y = position.y - 2;
                    DirectionMovement(Directions.down);
                    motion = Motions.move;
                }
            }
        }
        if (Direction == Directions.down)
        {
            Motion(Directions.down);
            
            position.y = position.y - 1;
            FileTypeDefinition(position);
            if (!(Tile == TileWall))
            {
                DirectionMovement(Directions.down);
                motion = Motions.move;
            }
            else
            {
                position.y = position.y + 1;
                position.x = position.x + 1;
                FileTypeDefinition(position);
                if (!(Tile == TileWall))
                {
                    DirectionMovement(Directions.right);
                    motion = Motions.move;
                }
                else
                {
                    //position.x = position.x - 2;
                    DirectionMovement(Directions.left);
                    motion = Motions.move;
                }
            }
        }
        if (Direction == Directions.left)
        {
            Motion(Directions.left);

            position.x = position.x - 1;
            FileTypeDefinition(position);
            if (!(Tile == TileWall))
            {
                DirectionMovement(Directions.left);
                motion = Motions.move;
            }
            else
            {
                position.x = position.x + 1;
                position.y = position.y - 1;
                FileTypeDefinition(position);
                if (!(Tile == TileWall))
                {
                    DirectionMovement(Directions.down);
                    motion = Motions.move;
                }
                else
                {
                    //position.y = position.y + 2;
                    DirectionMovement(Directions.up);
                    motion = Motions.move;
                }
            }
        }
    }

    private void Motion(Directions dir)
    {
        if (dir == Directions.up)
        {
            Debug.Log("Стена вверху");
            transform.position = transform.position - new Vector3(0, posi, 0);
        }
        else if (dir == Directions.down)
        {
            transform.position = transform.position + new Vector3(0, posi, 0);
        }
        else if (dir == Directions.right)
        {

            transform.position = transform.position + new Vector3(posi, 0, 0);
        }
        else if (dir == Directions.left)
        {
            transform.position = transform.position - new Vector3(posi, 0, 0);
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        motion = Motions.stop;
        Debug.Log("Стена");
        PositionPlayer();

       
        CheckingPath(TilePosition);

        
    }


}
