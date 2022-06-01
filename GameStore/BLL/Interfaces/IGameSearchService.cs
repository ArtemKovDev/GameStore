using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IGameSearchService
    {
        IEnumerable<GameDto> GetGamesByName(string name);

        IEnumerable<GameDto> GetGamesByGenre(int[] genreIds);
    }
}
