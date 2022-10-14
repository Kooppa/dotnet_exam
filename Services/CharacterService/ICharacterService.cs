using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_true.Dtos.Character;

namespace rpg_true.Services.CharacterService
{
    public interface ICharacterService
    {   
        Task <ServiceResponse<List<GetCharacterDto>>> GetAllCharacter();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacterDto);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}