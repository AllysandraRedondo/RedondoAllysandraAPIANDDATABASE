using Microsoft.AspNetCore.Mvc;
using BUSINESSLOGICdb;
using MODELSdb;
using System.Collections.Generic;


namespace OwnerAPIController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerAPIController : ControllerBase
    {

        private readonly VerifyingUser veruser;
        private readonly AnimeProcess aniproc;

        public OwnerAPIController(VerifyingUser verifyingUser, AnimeProcess animeProcess)
        {
            veruser = verifyingUser;
            aniproc = animeProcess;
        }

        [HttpGet]
        public IEnumerable<OwnerContent> GetAllUsers()
        {
            return veruser.GetAllUsers();
        }

        [HttpGet]
        public IEnumerable<AnimeContent> GetAllAnime()
        {
            return aniproc.GetAllAnime();
        }

        [HttpPost]
        public ActionResult<OwnerContent> Login([FromBody] OwnerContent ownerContent)
        {
            var user = veruser.VerifysUser(ownerContent.username, ownerContent.password);
                if (user != null)
                {
                    return Ok(user);
                }
                return Unauthorized();
        }

        [HttpPost]
        public ActionResult<int> AddAnime([FromBody] AnimeContent animeContent)
        {

            var r = aniproc.AddAnime(animeContent);
            return Ok(r);
        }

        [HttpDelete]
        public ActionResult<int> RemoveAnime(string title)
        {
            var result = aniproc.RemoveAnime(title);
            return Ok(result);

        }

        [HttpGet]
        public IEnumerable<AnimeContent> SearchAnime([FromQuery] string keyword)
        {

            return aniproc.SearchAnime(keyword);
        }
    }
}
