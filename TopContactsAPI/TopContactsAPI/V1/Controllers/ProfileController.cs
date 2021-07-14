using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopContactsAPI.Data;

namespace TopContactsAPI.V1.Controllers
{
    /// <summary>
    /// Profile Controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IRepository _repository;

        private readonly IMapper _mapper;

        /// <summary>
        ///
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public ProfileController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}