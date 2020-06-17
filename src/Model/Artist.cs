using System.Collections.Generic;

namespace LyrnicsDotnetCore.Model {

    public class Artist : BaseEntity {
        public string Name {get;set;}
        public string Code {get;set;}
        public ICollection<Song> Songs {get;set;}

    }//END class

}//END namespace