using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour
{
	Vector3 rotatePoint = Vector3.zero;  //回転の中心
	Vector3 rotateAxis = Vector3.zero;   //回転軸
	float cubeAngle = 0f;                //回転角度

	float cubeSizeHalf;                  //キューブの大きさの半分
	bool isRotate = false;               //回転中に立つフラグ。回転中は入力を受け付けない



	void Start()
	{
		cubeSizeHalf = transform.localScale.x / 2f;
	}
	

		void Update()
	{
		//回転中は入力を受け付けない
		if (isRotate)
			return;

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			
			rotatePoint = transform.position + new Vector3(cubeSizeHalf, -cubeSizeHalf, 0f);
			rotateAxis = new Vector3(0, 0, -1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			
			rotatePoint = transform.position + new Vector3(-cubeSizeHalf, -cubeSizeHalf, 0f);
			rotateAxis = new Vector3(0, 0, 1);
			
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, cubeSizeHalf);
			rotateAxis = new Vector3(1, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			rotatePoint = transform.position + new Vector3(0f, -cubeSizeHalf, -cubeSizeHalf);
			rotateAxis = new Vector3(-1, 0, 0);
		}
		// 入力がない時はコルーチンを呼び出さないようにする
		if (rotatePoint == Vector3.zero)
			return;
		StartCoroutine(MoveCube());
	}


	IEnumerator MoveCube()
	{
		//回転中のフラグを立てる
		isRotate = true;

		//回転処理
		float sumAngle = 0f; //angleの合計を保存
		while (sumAngle < 90f)
		{
			cubeAngle = 0.5f; //ここを変えると回転速度が変わる
			sumAngle += cubeAngle;

			// 90度以上回転しないように値を制限
			if (sumAngle > 90f)
			{
				cubeAngle -= sumAngle - 90f;
			}
			transform.RotateAround(rotatePoint, rotateAxis, cubeAngle);

			yield return null;
		}

		//回転中のフラグを倒す
		isRotate = false;
		rotatePoint = Vector3.zero;
		rotateAxis = Vector3.zero;

		yield break;
	}


	bool ObjDic(Vector3 DirVec)
    {
		RaycastHit hit;

		Physics.Raycast(transform.position, DirVec, out hit);
		Debug.DrawRay(transform.position, DirVec);
			
		if(hit.distance <= 0.8)
        {
			return true;
        }

		return false;
	}
}