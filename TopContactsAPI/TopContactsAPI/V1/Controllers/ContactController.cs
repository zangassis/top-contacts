using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TopContactsAPI.Data;
using TopContactsAPI.Extensions;
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
            model.Id = ContactExtensions.GenerateNewId();

            var contact = _mapper.Map<Contact>(model);

            _repository.Create(contact);

            if (_repository.SaveChanges())
                return Created($"/api/contact/{model.Id}", _mapper.Map<ContactDto>(contact));
            else
                return BadRequest("Sorry, something went wrong when registering a new contact... :(");
        }

        /// <summary>
        /// Update a existent Contact
        /// </summary>
        /// <returns></returns>
        [HttpPut("Update")]
        public IActionResult Update(ContactDto model)
        {
            var contact = _repository.GetContactById(model.Id);

            if (contact is null)
                return BadRequest($"Sorry T_T, contact not found to id: {model.Id}");

            _mapper.Map(model, contact);

            _repository.Update(contact);

            if (_repository.SaveChanges())
                return Created($"/api/contact/{model.Id}", _mapper.Map<ContactDto>(contact));
            else
                return BadRequest("Sorry, something went wrong while updating a contact... :(");
        }

        /// <summary>
        /// Delete a existent Contact
        /// </summary>
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var contact = _repository.GetContactById(id);

            if (contact is null)
                return BadRequest($"Sorry T_T, contact not found to id: {id}");

            _repository.Delete(contact);

            if (_repository.SaveChanges())
                return Ok(contact);
            else
                return BadRequest("Sorry, something went wrong while updating a contact... :(");
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