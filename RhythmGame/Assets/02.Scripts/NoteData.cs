using UnityEngine; // using UnityEngine: 유니티 엔진을 사용한다는뜻

[System.Serializable] // Serializable :  클래스 또는 구조체를 직렬화 할수있음을 나타낸다.
public class NoteData
{
    public KeyCode keyCode; // KeyCode :  키보드의 키 식별자를 할당해 놓은 타입
    public float time;      // Time : 한 프레임을 진행하는데 걸린 시간
    public float speedScale; // SpeedScale : ??

    public NoteData(KeyCode keyCode, float time, float speedScale)
    {
        this.keyCode = keyCode;
        this.time = time;
        this.speedScale = speedScale;
    }
}
