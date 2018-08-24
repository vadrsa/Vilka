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

        private RegionQuestionManager questionManager;
        
        public RegionController(UserManager<User> userManager, RegionQuestionManager reigonQuestionManager)
        {
            questionManager = reigonQuestionManager;
            _userManager = userManager;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        
        [Route("question")]
        [Authorize]
        public async Task<ActionResult<RegionQuestionInfo>> GetNextQuestion()
        {
            User user = await GetCurrentUserAsync();
            return questionManager.GetNext(user.Id);
        }

        [Route("answer")]
        [HttpPost]
        [Authorize]
        public async Task<bool> Post([FromBody] RegionHistoryItem answer)
        {
            User user = await GetCurrentUserAsync();
            answer.UserID = user.Id;
            answer.AnsweredOn = DateTime.Now;
            questionManager.AnswerQuestion(answer);
            return true;
        }
        
    }
}
