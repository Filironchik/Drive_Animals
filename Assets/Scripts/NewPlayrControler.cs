using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlayerControler
{
    public enum Directions { up, right, down, left };

    public class NewPlayrControler : MonoBehaviour
    {
        private Vector3 Player, startPlPos, endPlPos;

        [SerializeField] private Directions direction;

        private float startPos, endPos;

        private Vector3Int tilePos;

        [SerializeField] private Tilemap map;
        [SerializeField] private TileBase tileWall;

        private TileBase tile;

        private void Start()
        {
            endPlPos = Player;
        }

        private void assignPositions(float start, float end, Directions dir)
        {
            if (dir == Directions.up || dir == Directions.down)
            {
                float y = Mathf.SmoothStep(start, end, Time.deltaTime / 5);

                transform.position = new Vector2(transform.position.x, y);
            }
            if (dir == Directions.right || dir == Directions.left)
            {
                float x = Mathf.SmoothStep(start, end, Time.deltaTime / 5);

                transform.position = new Vector2(x, transform.position.y);
            }
        }


        private void calculationPositions(Directions dir, Vector3Int pos)
        {
            Vector3 PlPos;
            startPlPos = endPlPos;
            PlPos = map.CellToWorld(pos);

            if (dir == Directions.up)
            {
                endPos = PlPos.y++;
                endPlPos.y = PlPos.y++;
            }
            else if (dir == Directions.down)
            {
                endPos = PlPos.y--;
                endPlPos.y = PlPos.y--;
            }
            else if (dir == Directions.right)
            {
                endPos = PlPos.x++;
                endPlPos.x = PlPos.x++;
            }
            else if (dir == Directions.left)
            {
                endPos = PlPos.x--;
                endPlPos.x = PlPos.x--;
            }
        }

        private void learnPositionTile(Vector3 pos)
        {
            tilePos = (Vector3Int)map.WorldToCell(pos);
        }

        private void FileTypeDefinition(Vector3Int position)
        {
            tile = map.GetTile(position);   
        }

        private void DirectionMovement(Directions direction)
        {
            this.direction = direction;
        }

        private void CheckingPath(Vector3Int pos)
        {
            if (direction == Directions.up)
            {
                pos.y = pos.y + 1;
                FileTypeDefinition(pos);
                if (!(tile == tileWall))
                {
                    DirectionMovement(Directions.up);
                }
                else
                {
                    pos.y = pos.y - 1;
                    pos.x = pos.x - 1;
                    FileTypeDefinition(pos);
                    if (!(tile == tileWall))
                    {
                        DirectionMovement(Directions.left);
                    }
                    else
                    {
                        DirectionMovement(Directions.right);
                    }
                }
            }
            if (direction == Directions.right)
            {
                pos.x = pos.x + 1;
                FileTypeDefinition(pos);
                if (!(tile == tileWall))
                {
                    DirectionMovement(Directions.right);
                }
                else
                {
                    pos.x = pos.x - 1;
                    pos.y = pos.y + 1;
                    FileTypeDefinition(pos);
                    if (!(tile == tileWall))
                    {
                        DirectionMovement(Directions.up);
                    }
                    else
                    {
                        //position.y = position.y - 2;
                        DirectionMovement(Directions.down);
                    }
                }
            }
            if (direction == Directions.down)
            {
                pos.y = pos.y - 1;
                FileTypeDefinition(pos);
                if (!(tile == tileWall))
                {
                    DirectionMovement(Directions.down);
                }
                else
                {
                    pos.y = pos.y + 1;
                    pos.x = pos.x + 1;
                    FileTypeDefinition(pos);
                    if (!(tile == tileWall))
                    {
                        DirectionMovement(Directions.right);
                    }
                    else
                    {
                        //position.x = position.x - 2;
                        DirectionMovement(Directions.left);
                    }
                }
            }
            if (direction == Directions.left)
            {
                pos.x = pos.x - 1;
                FileTypeDefinition(pos);
                if (!(tile == tileWall))
                {
                    DirectionMovement(Directions.left);
                }
                else
                {
                    pos.x = pos.x + 1;
                    pos.y = pos.y - 1;
                    FileTypeDefinition(pos);
                    if (!(tile == tileWall))
                    {
                        DirectionMovement(Directions.down);
                    }
                    else
                    {
                        //position.y = position.y + 2;
                        DirectionMovement(Directions.up);
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            if (Player == endPlPos)
            {
                learnPositionTile(Player);
                CheckingPath(tilePos);
                calculationPositions(direction, tilePos);

            }
            //assignPositions(startPos, endPos, direction);

            if (direction == Directions.up || direction == Directions.down)
            {
                float y = Mathf.Lerp(startPos, endPos, Time.time);

                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
            if (direction == Directions.right || direction == Directions.left)
            {
                float x = Mathf.Lerp(startPos, endPos, Time.time);

                transform.position = new Vector3(x, transform.position.y, transform.position.z);
            }
        }


    }

}
