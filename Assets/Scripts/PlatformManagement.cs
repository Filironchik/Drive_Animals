using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlatformManagement : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private TileBase
        DirectionTileTop, DirectionTileRight, DirectionTileDown, DirectionTileLeft, TileEarth, KlickTale;

    [SerializeField] private Vector3Int clickCelPosition;
    [SerializeField] private Camera Camera;
    [SerializeField] private Tilemap map;


   

    private void FileTypeDefinition(Vector3Int position)
    {
        KlickTale = map.GetTile(position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 ClickToWorldPoint = Camera.ScreenToWorldPoint(Input.mousePosition);
            clickCelPosition = (Vector3Int)map.WorldToCell(ClickToWorldPoint);
            FileTypeDefinition(clickCelPosition);
            if (KlickTale == TileEarth || KlickTale == DirectionTileTop || KlickTale == DirectionTileDown || KlickTale == DirectionTileRight || KlickTale == DirectionTileLeft)
            {

                map.SetTile(clickCelPosition, DirectionTileTop);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            if (eventData.delta.x > 0)
            {
                if (KlickTale == TileEarth || KlickTale == DirectionTileTop || KlickTale == DirectionTileDown || KlickTale == DirectionTileRight || KlickTale == DirectionTileLeft)
                {
                    map.SetTile(clickCelPosition, DirectionTileRight);
                }
            }
            else
            {
                if (KlickTale == TileEarth || KlickTale == DirectionTileTop || KlickTale == DirectionTileDown || KlickTale == DirectionTileRight || KlickTale == DirectionTileLeft)
                {
                    map.SetTile(clickCelPosition, DirectionTileLeft);
                }
            }
        }
        else
        {
            if (eventData.delta.y > 0)
            {
                if (KlickTale == TileEarth || KlickTale == DirectionTileTop || KlickTale == DirectionTileDown || KlickTale == DirectionTileRight || KlickTale == DirectionTileLeft)
                {
                    map.SetTile(clickCelPosition, DirectionTileTop);
                }
            }
            else
            {
                if (KlickTale == TileEarth || KlickTale == DirectionTileTop || KlickTale == DirectionTileDown || KlickTale == DirectionTileRight || KlickTale == DirectionTileLeft)
                {
                    map.SetTile(clickCelPosition, DirectionTileDown);
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData){}
}
