using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopContactsAPI.Data;
using TopContactsAPI.Model;
using TopContactsAPI.V1.Dto;

namespace TopContactsAPI.V1.Controllers
{
    /// <summary>
    /// Contact Controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ContactController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new Contact
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public IActionResult Create(ContactDto model)
        {
            var contact = _mapper.Map<Contact>(model);

            _repository.Create(contact);

            if (_repository.SaveChanges())
                return Created($"/api/contact/{model.Id}", _mapper.Map<ContactDto>(contact));
            else
                return BadRequest("Sorry, Something went wrong when registering a new contact... :(");
        }

        /// <summary>
        /// Method responsible for returning all contacts by Profile Id.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllContactsByProfileId")]
        public async Task<IActionResult> GetAllContactsByProfileId(Guid profileId)
        {
            var contacts = await _repository.GetAllContactsByProfileIdAsync(profileId);

            if (contacts is null)
                return BadRequest("No contacts found for your profile, try adding one, it's free ;D");

            var contactsResult = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return Ok(contactsResult);
        }
    }
}