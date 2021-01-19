using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]

    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService _userProfileService, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._userProfileService = _userProfileService;
        }


        [HttpGet]
        [Route("GetAllUserProfile")]
        public async Task<IActionResult> GetAllUserProfile()
        {
            return Ok(await _userProfileService.GellAllUserProfileAsync());
        }

        [HttpGet]
        [Route("GetUserProfileByName")]
        public async Task<IActionResult> GetUserProfileByName(string name)
        {
            return Ok(await _userProfileService.FindUserProfileByNameAsync(name));
        }

        [HttpGet]
        [Route("GetUserProfileById")]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            return Ok(await _userProfileService.FindUserProfileByIdAsync(id));
        }

        [HttpGet]
        [Route("SearchByFilters")]


        [HttpPut]
        [Route("EditUserProfile")]
        public async Task<IActionResult> EditUserProfile(UserProfileDTO userProfileDTO)
        {
            return Ok(await _userProfileService.UpdateUserProfileAsync(userProfileDTO));
        }

        [HttpGet]
        [Route("GetUserProfileByApplicationUserId")]
        public async Task<IActionResult> GetUserProfileByApplicationUserId(string userId)
        {
            return Ok(await _userProfileService.GetUserProfileByApplicationUserId(userId));
        }
    }
}
