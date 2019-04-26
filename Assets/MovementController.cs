using UnityEngine;
using System.Collections;
public class MovementController : MonoBehaviour {
	public bool CanMove = true;
    public bool CanMoveForward = true;
	public bool CanMoveBack = true;
	public bool CanMoveLeft = true;
	public bool CanMoveRight = true;
	public bool CanMoveUp = true;
	public bool CanMoveDown = true;
	public float MovementSpeed = 100f;
	public float RotationSpeed = 100f;
	private bool canTranslate;
	void Start() {
		canTranslate = CanMoveForward || CanMoveBack || CanMoveRight || CanMoveLeft || CanMoveUp || CanMoveDown;
	}
	void Update() {
		
	}

	void FixedUpdate() {
		if( CanMove ) {
			UpdatePosition();
		}
	}
	void UpdatePosition() {
		// 移動の定義
		if( canTranslate ){
			// 座標を値で処理、
			int[] input = new int[ 6 ]; // Forward, Back, Left, Right, Up, Down
			if( CanMoveForward && Input.GetKey( KeyCode.UpArrow ) ) {
				input[ 0 ] = 1;
			} else if( CanMoveBack && Input.GetKey( KeyCode.DownArrow ) ) {
				input[ 1 ] = 1;
			}
			if( CanMoveLeft && Input.GetKey( KeyCode.A ) ) {
				input[ 2 ] = 1;
			} else if( CanMoveRight && Input.GetKey( KeyCode.D ) ) {
				input[ 3 ] = 1;
			}
			if( CanMoveUp && Input.GetKey( KeyCode.W ) ) {
				input[ 4 ] = 1;
			} else if( CanMoveDown && Input.GetKey( KeyCode.S ) ) {
				input[ 5 ] = 1;
			}
			int numInput = 0;
			for( int i = 0; i < 6; i++ ){
				numInput += input[ i ];
			}
			// 移動速度を定義
			float curSpeed = numInput > 0 ? MovementSpeed : 0;
			Vector3 AddPos = input[ 0 ] * Vector3.forward + input[ 2 ] * Vector3.left + input[ 4 ] * Vector3.up
				+ input[ 1 ] * Vector3.back + input[ 3 ] * Vector3.right + input[ 5 ] * Vector3.down;
			AddPos = GetComponent<Rigidbody>().rotation * AddPos;
			GetComponent<Rigidbody>().velocity = AddPos * ( Time.fixedDeltaTime * curSpeed );
		}
	}
}