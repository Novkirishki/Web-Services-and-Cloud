namespace _01.DayOfWeekService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
