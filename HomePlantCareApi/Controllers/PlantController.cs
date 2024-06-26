using HomePlantCareApi.Extensions;
using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomePlantCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository plantRepository;

        public PlantController(IPlantRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantDto>>> GetPlant()
        {
            try
            {
                var plants = await this.plantRepository.GetPlants();

                if (plants == null || !plants.Any())
                {
                    return NotFound();
                }
                else
                {
                    var plantDtos = plants.ConvertToPlantDto();
                    return Ok(plantDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
