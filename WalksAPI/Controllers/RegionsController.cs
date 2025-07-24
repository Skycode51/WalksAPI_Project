using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTOs;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{
    // https://localhost:7091/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        //Constructor injection
        public RegionsController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper )
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //Create Action method


        // GET ALL REGIONS
        // GET: https://localhost:7091/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            // Get Data from Database - Domain models
            var regionDomain =  await regionRepository.GetAllAsync();

            // using AutoMapper to map Domain Models to DTOs
            // Return DTOs
            return Ok(mapper.Map<List<RegionsDTO>>(regionDomain));
        }

        // GET BY ID
        // GET: https://localhost:7091/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")] // Optional, can be used to specify a different route
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            // Get Data from Database - Domain models
            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO using AutoMApper
            return Ok(mapper.Map<RegionsDTO>(region));
        }

        //POST(Create) : https://localhost:7091/api/regions
        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] AddRegionRequestDTO requestDTO)
        {
            // Map DTO to Domain Model  using Mapper
            var regionDomain = mapper.Map<Regions>(requestDTO);

            // Add Domain Model to Database
            regionDomain = await regionRepository.CreateAsync(regionDomain);

            //Map Domain model back to DTO
            var region = mapper.Map<RegionsDTO>(regionDomain);

            return CreatedAtAction(nameof(GetById), new { id = regionDomain.Id }, regionDomain);


        }

        // PUT(UPDATE) : https://localhost:7091/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO UpdaterequestDTO)
        {

            //Map DTO to Domain Model
            var regionDomain = mapper.Map<Regions>(UpdaterequestDTO);

            // Get the existing region from the database
            regionDomain = await regionRepository.UpdateAsync(id, regionDomain);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Domain model back to DTO
            return Ok(mapper.Map<RegionsDTO>(regionDomain));
        }

        //DELETE : https://localhost:7091/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Get the existing region from the database
            var regionDomain = await regionRepository.DeleteAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // If you want to return a specific response after deletion, you can do so.
            // Map Domain Model back to DTO using AutoMapper
            return Ok(mapper.Map<RegionsDTO>(regionDomain));
        }
    }
}
