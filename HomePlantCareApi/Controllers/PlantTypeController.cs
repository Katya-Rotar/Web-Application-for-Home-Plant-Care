using HomePlantCareApi.Extensions;
using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomePlantCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantTypeController : ControllerBase
    {
        private readonly IPlantTypeRepository plantRepository;

        public PlantTypeController(IPlantTypeRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantTypeDto>>> GetPlantType()
        {
            try
            {
                var plantTypes = await this.plantRepository.GetPlantTypes();

                if (plantTypes == null || !plantTypes.Any())
                {
                    return NotFound();
                }
                else
                {
                    var plantDtos = plantTypes.ConvertToPlantTypeDto();
                    return Ok(plantDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantTypeDto>> GetById(int id)
        {
            try
            {
                var plantTypeId = await this.plantRepository.GetPlantTypeById(id);
                if (plantTypeId == null)
                {
                    return NotFound();
                }
                else
                {
                    var plantTypeIdDtos = plantTypeId.ConvertToPlantTypeIdDto();
                    return Ok(plantTypeIdDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
