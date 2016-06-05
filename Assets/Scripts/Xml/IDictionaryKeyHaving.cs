namespace Lim.Xml
{
    /// <summary>
    /// 딕셔너리의 Key 로 사용될 수 있는 멤버를 갖는 오브젝트
    /// </summary>
    public interface IDictionaryKeyHaving<T>
    {
        T DictionaryKey { get; }
    }
}