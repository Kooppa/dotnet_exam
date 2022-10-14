using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using rpg_true.Dtos.Character;

namespace rpg_true.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character{ Id = 1, Name = "Killua"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id)+1;
            characters.Add(character);
            // characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            return new ServiceResponse<List<GetCharacterDto>> {
                Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList()
                };
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();

            try {
            Character character = characters.FirstOrDefault(c => c.Id == updateCharacter.Id);

            _mapper.Map(updateCharacter, character);
            // character.Name = updateCharacter.Name;
            // character.HitPoints = updateCharacter.HitPoints;
            // character.Strength = updateCharacter.Strength;
            // character.Defense = updateCharacter.Defense;
            // character.Intelligence = updateCharacter.Intelligence;
            // character.Class = updateCharacter.Class;

            response.Data = _mapper.Map<GetCharacterDto>(character);
            } 
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}