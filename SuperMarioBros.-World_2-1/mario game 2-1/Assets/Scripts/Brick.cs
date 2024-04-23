using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	// Biến đánh dấu xem gạch đã bị va chạm chưa
	public bool hit;
	// Biến đếm để di chuyển gạch sau khi bị va chạm
	private int count;

	 // Âm thanh khi gạch bị va chạm
    public AudioClip bumpSFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	// Hàm được gọi mỗi frame
	
/*Trong ngữ cảnh của trò chơi và đồ họa máy tính, "frame" là một khung hình trong chuỗi các khung hình liên tiếp tạo ra một cảnh động.
Mỗi khung hình đại diện cho một trạng thái của trò chơi hoặc của cảnh đang được hiển thị, 
và khi các khung hình này được hiển thị một cách nhanh chóng và liên tục, 
chúng tạo ra ấn tượng của chuyển động cho người xem.

Trong Unity, hàm Update được gọi mỗi frame, tức là mỗi lần một khung hình mới được hiển thị trên màn hình.
Các công việc được thực hiện trong hàm Update thường liên quan đến việc cập nhật trạng thái của trò chơi,
xử lý input của người chơi và thực hiện các tính toán khác liên quan đến cơ chế chuyển động, va chạm và hiển thị đồ họa. 
Hàm Update được sử dụng để di chuyển gạch khi nó đã bị va chạm.*/
	void Update () {
		// Kiểm tra nếu gạch đã bị va chạm
		if (hit) {
			// Nếu còn đang cần di chuyển lên
			if (count > 0) 
			{
				// Di chuyển gạch lên một khoảng cố định
				transform.Translate (Vector3.up * Time.fixedDeltaTime * 2);
				count--;
			} 
			// Nếu đã di chuyển đủ lên và cần đi xuống
			else if (count <=0 && count > -3) 
			{
				transform.Translate (Vector3.down * Time.fixedDeltaTime * 2);
				count--;
			} 
			else 
			{
				// Đặt trạng thái va chạm là false để chuẩn bị cho lần va chạm tiếp theo
                hit = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	 // Kiểm tra nếu collider va chạm nằm dưới gạch và là người chơi
	{
		if (c.collider.bounds.max.y < transform.position.y && c.collider.tag == "Player") {
			// Đặt biến đếm là 3 để bắt đầu di chuyển gạch
			count = 3;
			hit = true;
			// Phát âm thanh va chạm
            SoundManager.instance.playSFX(bumpSFX, false);
		}
	}
}
