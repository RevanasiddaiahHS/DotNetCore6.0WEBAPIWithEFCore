using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SuperHeroController : ControllerBase
    {
        OrganizationContext orgctxt=new OrganizationContext();
        //private static List<SuperHero> heroes = new List<SuperHero>
        //    {
        //       new SuperHero
        //       {
        //           Id = 1,
        //           Name="Spider Man",
        //           FirstName="Peter",
        //           LastName="Parker",
        //           Place="New York City"
        //       },
        //       new SuperHero
        //       {
        //           Id=2,
        //           Name="Iron Man",
        //           FirstName="Tony",
        //           LastName="Stark",
        //           Place="Island"
        //       }
        //    };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            List<SuperHero> sup=orgctxt.superhero.ToList();
            return Ok(sup);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero request){
            orgctxt.superhero.Add(request);
            orgctxt.SaveChanges();
            List<SuperHero> sup = orgctxt.superhero.ToList();
            return Ok(sup);
         }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            //var hero=heroes.Find(x=>x.Id==id);
            var hero= orgctxt.superhero.Find(id);

            if (hero == null)
                return BadRequest("Hero Not found for this ID");
            return hero;
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = orgctxt.superhero.Find(request.Id);
            if (hero == null)
                return BadRequest("Hero Not found for this ID");
            //hero.Name = request.Name;
            //hero.FirstName = request.FirstName;
            //hero.LastName = request.LastName;
            //hero.Place = request.Place;
            //or
            orgctxt.Update<SuperHero>(hero);
            //We can follow both the update approches
            orgctxt.SaveChanges();
            List<SuperHero> sup = orgctxt.superhero.ToList();
            return Ok(sup);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = orgctxt.superhero.Find(id);
            if (hero == null)
                return BadRequest("Hero Not found for this ID");
            orgctxt.superhero.Remove(hero);
            orgctxt.SaveChanges();
            List<SuperHero> sup = orgctxt.superhero.ToList();
            return Ok(sup);
        }
    }
}
