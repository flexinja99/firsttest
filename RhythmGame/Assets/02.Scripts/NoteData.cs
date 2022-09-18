using UnityEngine; // using UnityEngine: ����Ƽ ������ ����Ѵٴ¶�

[System.Serializable] // Serializable :  Ŭ���� �Ǵ� ����ü�� ����ȭ �Ҽ������� ��Ÿ����.
public class NoteData
{
    public KeyCode keyCode; // KeyCode :  Ű������ Ű �ĺ��ڸ� �Ҵ��� ���� Ÿ��
    public float time;      // Time : �� �������� �����ϴµ� �ɸ� �ð�
    public float speedScale; // SpeedScale : ??

    public NoteData(KeyCode keyCode, float time, float speedScale)
    {
        this.keyCode = keyCode;
        this.time = time;
        this.speedScale = speedScale;
    }
}
