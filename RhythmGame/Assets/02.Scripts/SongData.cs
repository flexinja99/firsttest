using System.Collections.Generic;//   using System.Collections : ���׸� �÷����� ������ ������ �Ϲ�ȭ�Ͽ� ����ϱ� ������ �÷��ǿ� ���� ������ ������ �����ϴ�.
                                 //���׸� �÷����� List<T>, Dictionary<T> , Queue<T>, Stack<T> ���� Ŭ������ �ֽ��ϴ�.

[System.Serializable] //[System.Serializable] : [Serializable]�� Ŭ���� �Ǵ� ����ü�� ����ȭ �Ҽ� ������ ��Ÿ����.
public class SongData
{
    public string videoName;
    public List<NoteData> notes;

    public SongData()
    {
        notes = new List<NoteData>();   //List : ����Ʈ�� �迭�� ������ ������ �Ѵ�. List<�ڷ���> ������ ���·� �����ϸ�, ��ü�̹Ƿ� new�����ڸ� �� ������Ѵ�.
    }
}
