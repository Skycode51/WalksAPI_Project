using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTOs;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{
    //  /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) 
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

       

        //Create walk 
        //Post: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
              // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walks>(addWalksRequestDto);
            
            await walkRepository.CreateAsync(walkDomainModel);
            //Map Domain model to DTO

            return Ok(mapper.Map<WalksDTO>(walkDomainModel));

        }


        // Get all walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get all walks from the repository
            var walksDomainModel = await walkRepository.GetAllAsync();

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<WalksDTO>>(walksDomainModel));
        }

        // Get walk by Id
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            // Get walk by Id from the repository
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            // Check if walk exists
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalksDTO>(walkDomainModel));
        }

        // Update walk by Id
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalksRequestDto)
        {
            // Get walk by Id from the repository
            var walkDomainModel = mapper.Map<Walks>(updateWalksRequestDto);

          walkDomainModel =  await walkRepository.UpdateAsync(id, walkDomainModel);

            // Check if walk exists
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalksDTO>(walkDomainModel));
        }


        // Delete walk by Id
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Get walk by Id from the repository
            var walkDomainModel = await walkRepository.DeleteAsync(id);

            // Check if walk exists
            if (walkDomainModel == null)
            {
                return NotFound();
            }

           
            // Return NoContent status
            return Ok(mapper.Map<WalksDTO>(walkDomainModel));
        }
    }
}
