using HomePlantCareApi.Extensions;
using HomePlantCareApi.Repositories.Contract;
using HomePlantCareModels.Dtos;
using Microsoft.AspNetCore.Mvc;
using Web_Application_for_Home_Plant_Care.Models;

namespace HomePlantCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository plantRepository;
        private readonly IReminderRepository reminderRepository;
        private readonly IPlantTypeRepository plantTypeRepository;

        public PlantController(IPlantRepository plantRepository, IReminderRepository reminderRepository, IPlantTypeRepository plantTypeRepository)
        {
            this.plantRepository = plantRepository;
            this.reminderRepository = reminderRepository;
            this.plantTypeRepository = plantTypeRepository;
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
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PlantDto>> GetById(int id)
        {
            try
            {
                var plantId = await this.plantRepository.GetPlantById(id);
                if (plantId == null)
                {
                   return NotFound();
                }
                else
                {
                    var plantIdDtos = plantId.ConvertToPlantIdDto();
                    return Ok(plantIdDtos);
                }

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddPlant(CreatePlantDto plantDto)
        {
            if (plantDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var plant = plantDto.ConvertToNewPlant();
                await this.plantRepository.AddPlant(plant);

                var createdPlantDto = plant.ConvertToPlantIdDto();

                // Отримати тип рослини для частоти поливу та пересадки
                var plantType = await this.plantTypeRepository.GetPlantTypeById(plant.PlantTypeID);

                if (plantType == null)
                {
                    return NotFound($"PlantType with ID {plant.PlantTypeID} not found.");
                }

                if (plant.DateLastWatering == null)
                {
                    return BadRequest("DateLastWatering cannot be null.");
                }

                if (plant.DateLastTransplant == null)
                {
                    return BadRequest("DateLastTransplant cannot be null.");
                }

                // Створити нагадування про полив
                var wateringReminder = new Reminder
                {
                    PlantID = plant.PlantID,
                    ReminderDate = plant.DateLastWatering.AddDays(plantType.WateringFrequency),
                    ReminderType = "Полив"
                };
                await this.reminderRepository.AddReminder(wateringReminder);

                // Створити нагадування про пересадку
                var transplantReminder = new Reminder
                {
                    PlantID = plant.PlantID,
                    ReminderDate = plant.DateLastTransplant.AddDays(plantType.TransplantFrequency),
                    ReminderType = "Пересадка"
                };
                await this.reminderRepository.AddReminder(transplantReminder);

                return CreatedAtAction(nameof(GetById), new { id = plant.PlantID }, createdPlantDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePlant(int id, CreatePlantDto plantDto)
        {
            try
            {
                var existingPlant = await this.plantRepository.GetPlantById(id);
                if (existingPlant == null)
                {
                    return NotFound($"Plant with ID {id} not found.");
                }

                existingPlant.PlantName = plantDto.PlantName;
                existingPlant.PlantTypeID = plantDto.PlantTypeID;
                existingPlant.PlantDescription = plantDto.PlantDescription;
                existingPlant.DateLastWatering = plantDto.DateLastWatering;
                existingPlant.DateLastTransplant = plantDto.DateLastTransplant;

                await this.plantRepository.UpdatePlant(existingPlant);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlant(int id)
        {
            try
            {
                var plant = await this.plantRepository.GetPlantById(id);
                if (plant == null)
                {
                    return NotFound($"Plant with ID {id} not found.");
                }

                await this.plantRepository.DeletePlant(plant);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
