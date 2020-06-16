using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using LyrnicsDotnetCore.Repository;
using LyrnicsDotnetCore.Services;
using LyrnicsDotnetCore.Model;

namespace LyrnicsDotnetCore.Controllers{

    [Route( "[controller]") ]
    public class BandsController : Controller {

        private IBandService BandService;
        private readonly IBandRepository BandRepository;

        public BandsController( IBandRepository bandRepository ){
            //this.bandService = bandService;
            this.BandRepository = bandRepository;
        }//END constructor

        [HttpGet]
        public IActionResult Index(){
            IList<Band> bands = this.BandRepository.FindAll();
            return Ok( bands );
        }//END Get()
        
        [HttpGet( "{id}" )]
        public IActionResult Get( int id ){
            Band band = this.BandRepository.FindById( id );
            return Ok( band );
        }//END Get()

        [HttpPost]
        public IActionResult Post( [FromBody] Band band ){
            Band createdBand = this.BandRepository.Create( band );
            return Ok( createdBand );
        }//END Post()

        [HttpPut("{id}")]
        public IActionResult Update( [FromRoute] int bandId, [FromBody] Band band ){
            band.Id = bandId;
            Band updatedBand = this.BandRepository.Update( band );
            return Ok( updatedBand );
        }//END Post()

    }//END class
}//END namespace