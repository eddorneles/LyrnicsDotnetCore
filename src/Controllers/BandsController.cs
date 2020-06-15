using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using LyrnicsDotnetCore.Services;
using LyrnicsDotnetCore.Model;


namespace LyrnicsDotnetCore.Services{

    [Route( "/[controller]") ]
    public class BandsController : Controller {

        private IBandService bandService;

        public BandsController( IBandService bandService ){
            this.bandService = bandService;
        }//END constructor

        [HttpGet]
        public IActionResult Get(){
            return Ok();
        }//END Get()

        [HttpGet("{id}")]
        public IActionResult Get( int id ){
            return Ok();
        }//END Get()

        [HttpPost]
        public IActionResult Post( [FromBody] Band band ){
            return Ok( band );
        }

    }//END class
}//END namespace