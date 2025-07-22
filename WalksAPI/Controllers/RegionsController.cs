using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalksAPI.Data;
using WalksAPI.Models.Domain;
using WalksAPI.Models.Domain.DTOs;

namespace WalksAPI.Controllers
{
    // https://localhost:7091/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly WalksDbContext dbContext;

        //Constructor injection
        public RegionsController(WalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Create Action method


        // GET ALL REGIONS
        // GET: https://localhost:7091/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            // Get Data from Database - Domain models
            var regionDomain =  await dbContext.regions.ToListAsync();

            // Map Domain Models to DTOs (Data Transfer Objects)
            var regionDTOs = new List<RegionsDTO>();

            foreach (var regionsDomain in regionDomain)
            {
                regionDTOs.Add(new RegionsDTO()
                {
                    Id = regionsDomain.Id,
                    Code = regionsDomain.Code,
                    Name = regionsDomain.Name,
                    RegionImageUrl = regionsDomain.RegionImageUrl
                });

            }

            // Return DTOs
            return Ok(regionDTOs);
        }

        // GET BY ID
        // GET: https://localhost:7091/api/regions/{id}
        [HttpGet]
        [Route("{id:guid}")] // Optional, can be used to specify a different route
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            // Get Data from Database - Domain models
            var region = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var regionDTO = new RegionsDTO()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            // Return DTO back to client
            return Ok(regionDTO);
        }

        //POST(Create) : https://localhost:7091/api/regions
        [HttpPost]
        public  async Task<IActionResult> Create([FromBody] AddRegionRequestDTO requestDTO)
        {
            // Map DTO to Domain Model
            var regionDomain = new Regions
            {

                Code = requestDTO.Code,
                Name = requestDTO.Name,
                RegionImageUrl = requestDTO.RegionImageUrl
            };

            // Add Domain Model to Database
             await dbContext.regions.AddAsync(regionDomain);
             await dbContext.SaveChangesAsync();

            //Map Domain model back to DTO
            var region = new RegionsDTO()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDomain.Id }, regionDomain);


        }

        // PUT(UPDATE) : https://localhost:7091/api/regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO UpdaterequestDTO)
        {
            // Get the existing region from the database
            var regionDomain = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Update the properties  map DTO to Domain model
            regionDomain.Code = UpdaterequestDTO.Code;
            regionDomain.Name = UpdaterequestDTO.Name;
            regionDomain.RegionImageUrl = UpdaterequestDTO.RegionImageUrl;

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            // Map Domain model back to DTO
            var region = new RegionsDTO()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            return Ok(region);
        }

        //DELETE : https://localhost:7091/api/regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Get the existing region from the database
            var regionDomain = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            // Remove the region from the database
              dbContext.regions.Remove(regionDomain);    
          await  dbContext.SaveChangesAsync();

            // If you want to return a specific response after deletion, you can do so.
            // Map Domain Model back to DTO (optional)
            var regionDTO = new RegionsDTO()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };


            // Return NoContent status code
            return Ok(regionDTO);
        }
    }
}
