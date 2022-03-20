using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayercontroler : MonoBehaviour
{
    [SerializeField] private float x, y, z;

	//Цель (пункт Б)
	public Transform target;

	//Стартовая позиция (ось Z)
	private float _startPos;
	//Конечная позиция (ось Z)
	private float _endPos;
	// Use this for initialization
	void Start()
	{
		//Запоминаем начальную и конечную позиции
		_startPos = transform.position.y;
		_endPos = target.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		//Новая позиция по оси Z
		float _y = Mathf.Lerp(_startPos, _endPos, Time.time/5);
		//Устанавливаем новую позицию
		transform.position = new Vector2(transform.position.x, _y);
	}


}
