using HomePlantCareApi.Extensions;
using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomePlantCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantCareController : ControllerBase
    {
        private readonly IPlantCareRepository plantRepository;

        public PlantCareController(IPlantCareRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantCareDto>>> GetPlantCare()
        {
            try
            {
                var plants = await this.plantRepository.GetPlantsCare();

                if (plants == null || !plants.Any())
                {
                    return NotFound();
                }
                else
                {
                    var plantDtos = plants.ConvertToPlantCareDto();
                    return Ok(plantDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlantCareDto>> GetById(int id)
        {
            try
            {
                var plantId = await this.plantRepository.GetPlantCareById(id);
                if (plantId == null)
                {
                    return NotFound();
                }
                else
                {
                    var plantIdDtos = plantId.ConvertToPlantCareIdDto();
                    return Ok(plantIdDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPlantCare(PlantCareDto plantDto)
        {
            try
            {
                var plant = plantDto.ConvertToNewPlantCare();
                await this.plantRepository.AddPlantCare(plant);

                var createdPlantDto = plant.ConvertToPlantCareIdDto();

                return CreatedAtAction(nameof(GetById), new { id = plant.CareID }, createdPlantDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlantCare(int id, PlantCareDto plantDto)
        {
            try
            {
                var existingPlant = await this.plantRepository.GetPlantCareById(id);
                if (existingPlant == null)
                {
                    return NotFound($"Plant with ID {id} not found.");
                }

                existingPlant.CareID = plantDto.CareID;
                existingPlant.PlantID = plantDto.PlantID;
                existingPlant.CareDate = plantDto.CareDate;
                existingPlant.CareType = plantDto.CareType;

                await this.plantRepository.UpdatePlantCare(existingPlant);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlantCare(int id)
        {
            try
            {
                var plant = await this.plantRepository.GetPlantCareById(id);
                if (plant == null)
                {
                    return NotFound($"Plant with ID {id} not found.");
                }

                await this.plantRepository.DeletePlantCare(plant);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
