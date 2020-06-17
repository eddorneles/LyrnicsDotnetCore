using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Business;
using LyrnicsDotnetCore.Data.Dto;

namespace LyrnicsDotnetCore.Controllers{

    [Route( "[controller]") ]
    public class SongsController : Controller {

        private ISongBusiness SongBusiness;

        public SongsController( ISongBusiness songBusiness ){
            this.SongBusiness = songBusiness;
        }//END constructor

        [HttpGet]
        public IActionResult Index(){
            IList<SongDto> songs = this.SongBusiness.FindAll();
            return Ok( songs );
        }//END Get()
        
        [HttpGet( "{id}" )]
        public IActionResult Get( int id ){
            SongDto song = this.SongBusiness.FindById( id );
            return Ok( song );
        }//END Get()

        [HttpPost]
        public IActionResult Post( [FromBody] SongDto song ){
            SongDto createdSong = this.SongBusiness.Create( song );
            return Ok( createdSong );
        }//END Post()

        [HttpPut("{id}")]
        public IActionResult Update( [FromRoute] int songId, [FromBody] SongDto song ){
            song.Id = songId;
            SongDto updatedSong = this.SongBusiness.Update( song );
            return Ok( updatedSong );
        }//END Post()

    }//END class
}//END namespace