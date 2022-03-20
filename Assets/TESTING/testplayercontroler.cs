using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayercontroler : MonoBehaviour
{
    [SerializeField] private float x, y, z;

	//���� (����� �)
	public Transform target;

	//��������� ������� (��� Z)
	private float _startPos;
	//�������� ������� (��� Z)
	private float _endPos;
	// Use this for initialization
	void Start()
	{
		//���������� ��������� � �������� �������
		_startPos = transform.position.y;
		_endPos = target.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		//����� ������� �� ��� Z
		float _y = Mathf.Lerp(_startPos, _endPos, Time.time/5);
		//������������� ����� �������
		transform.position = new Vector2(transform.position.x, _y);
	}


}
