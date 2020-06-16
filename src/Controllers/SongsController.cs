using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Controllers{

    [Route( "[controller]") ]
    public class SongsController : Controller {

        private ISongBusiness SongBusiness;
        private ISongRepository SongRepository;

        public SongsController( ISongRepository bandRepository ){
            //this.bandBusiness = bandBusiness;
            this.SongRepository = bandRepository;
        }//END constructor

        [HttpGet]
        public IActionResult Index(){
            IList<Song> bands = this.SongRepository.FindAll();
            return Ok( bands );
        }//END Get()
        
        [HttpGet( "{id}" )]
        public IActionResult Get( int id ){
            Song band = this.SongRepository.FindById( id );
            return Ok( band );
        }//END Get()

        [HttpPost]
        public IActionResult Post( [FromBody] Song band ){
            Song createdSong = this.SongRepository.Create( band );
            return Ok( createdSong );
        }//END Post()

        [HttpPut("{id}")]
        public IActionResult Update( [FromRoute] int bandId, [FromBody] Song band ){
            band.Id = bandId;
            Song updatedSong = this.SongRepository.Update( band );
            return Ok( updatedSong );
        }//END Post()

    }//END class
}//END namespace