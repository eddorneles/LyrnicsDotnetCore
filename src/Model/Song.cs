

namespace LyrnicsDotnetCore.Model {

    public class Song {
        public long? Id {get;set;}
        public string Title {get;set;}
        public string Code {get;set;}
        public long? BandId{get;set;}
        public Band Band {get;set;}

    }//END class

}//END namespace