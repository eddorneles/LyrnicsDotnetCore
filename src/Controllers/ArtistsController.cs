using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Controllers{

    [Route( "[controller]") ]
    public class ArtistsController : Controller {

        private readonly IArtistBusiness ArtistBusiness;

        public ArtistsController( IArtistBusiness artistBusiness ){
            this.ArtistBusiness = artistBusiness;
        }//END constructor

        [HttpGet]
        public IActionResult Index(){
            IList<Artist> artists = this.ArtistBusiness.FindAll();
            return Ok( artists );
        }//END Get()
        
        [HttpGet( "{id}" )]
        public IActionResult Get( int id ){
            Artist artist = this.ArtistBusiness.FindById( id );
            return Ok( artist );
        }//END Get()

        [HttpPost]
        public IActionResult Post( [FromBody] Artist artist ){
            Artist createdArtist = this.ArtistBusiness.Create( artist );
            return Ok( createdArtist );
        }//END Post()

        [HttpPut("{id}")]
        public IActionResult Update( [FromRoute] int artistId, [FromBody] Artist artist ){
            artist.Id = artistId;
            Artist updatedArtist = this.ArtistBusiness.Update( artist );
            return Ok( updatedArtist );
        }//END Post()

    }//END class
}//END namespace