

namespace LyrnicsDotnetCore.Model {

    public class Song : BaseEntity{
        public string Title {get;set;}
        public string Code {get;set;}
        public long? ArtistId{get;set;}
        public Artist Artist {get;set;}

    }//END class

}//END namespace