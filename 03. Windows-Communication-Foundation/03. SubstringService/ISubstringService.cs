namespace _03.SubstringService
{
    using System.Runtime.Serialization;
    using System.ServiceModel;

    [ServiceContract]
    public interface ISubstringService
    {
        [OperationContract]
        int GetOccurrencesCount(string substring, string text);
    }
}
