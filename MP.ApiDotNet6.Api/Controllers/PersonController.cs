using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Application.DTOs.Person;
using MP.ApiDotNet6.Application.Services.Interfaces;
using MP.ApiDotNet6.Domain.Authentication;
using MP.ApiDotNet6.Domain.FiltersDb;

namespace MP.ApiDotNet6.Api.Controllers
{
    
    [Route("api/[controller]")]    
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private List<string> _permissionNeeded = new List<string>() {"admin"};
        private readonly ICurrentUser _currentUser;
        private readonly List<string> _permissionUser;
        public PersonController(IPersonService personService, ICurrentUser currentUser)
        {
            _personService = personService;
            _currentUser = currentUser;
            _permissionUser = _currentUser.Permissions.Split(",").ToList();
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PersonDTO personDTO)
        {
            _permissionNeeded.Add("CadastraPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();

            var result = await _personService.CreateAsync(personDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAsync()
        {
            _permissionNeeded.Add("BuscaPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();

            var result = await _personService.GetAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("paged")]
        public async Task<IActionResult> GetPagedAsync([FromQuery] PersonFilterDb pageRequest)
        {
            _permissionNeeded.Add("BuscaPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();

            var result = await _personService.GetPaged(pageRequest);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetIdAsync(int id)
        {
            _permissionNeeded.Add("BuscaPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();

            var result = await _personService.GetByIdAsync(id);
            if (result.IsSuccess)   
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
        {
            _permissionNeeded.Add("EditaPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();
                
            var result = await _personService.UpdateAsync(personDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            _permissionNeeded.Add("DeletaPessoa");
            if(!ValidPermission(_permissionUser,_permissionNeeded))
                return Forbidden();

            var result = await _personService.RemoveAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

