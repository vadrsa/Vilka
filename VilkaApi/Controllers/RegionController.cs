using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VilkaApi.BusinessLogic.Regions;
using BusinessEntities;
using VilkaApi.ResourceAccess.Regions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VilkaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public RegionController(UserManager<User> userManager){
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> Get()
        {
            return RegionRepository.Instance.SelectAll();
        }

        [Route("question")]
        [Authorize]
        public async Task<ActionResult<RegionQuestionInfo>> GetNextQuestion()
        {
            User user = await GetCurrentUserAsync();
            return new RegionQuestionManager().GetNext(user.Id);
        }

        [Route("answer")]
        [HttpPost]
        [Authorize]
        public async void Post([FromBody] RegionHistoryItem answer)
        {
            User user = await GetCurrentUserAsync();
            answer.UserID = user.Id;
            new RegionQuestionManager().AnswerQuestion(answer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
