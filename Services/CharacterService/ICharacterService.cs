using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg_true.Services.CharacterService
{
    public interface ICharacterService
    {   
        List<Character> GetAllCharacter();
        Character GetCharacterById(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}