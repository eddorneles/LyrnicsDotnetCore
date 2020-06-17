using System.Collections.Generic;

namespace LyrnicsDotnetCore.Data.Converters {

    public interface IParser<O,D> {
        D Parse( O origin );
        List<D> ParseList( List<O> origin);
    }//END interface
}


