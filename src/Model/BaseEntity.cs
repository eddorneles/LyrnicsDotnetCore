using System.Runtime.Serialization;


namespace LyrnicsDotnetCore.Model{

    [DataContract]
    public class BaseEntity{
        public long? Id {get;set;}
    }
}