using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetPoke()
        {
            var url = "https://pokeapi.co/api/v2/pokemon-species/413";

            using ( HttpClient _http =  new HttpClient() )
            {
                HttpResponseMessage response = await _http.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                
                return Ok(responseBody);

            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetPokeByName(string name)
        {
            var url = "https://pokeapi.co/api/v2/pokemon-species/";

            using (HttpClient _http = new HttpClient())
            {
                HttpResponseMessage response = await _http.GetAsync(url+"/"+name);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();


                return Ok(responseBody);

            }
        }

    }
}
