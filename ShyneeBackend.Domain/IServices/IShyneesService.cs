using ShyneeBackend.Domain.DTOs;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneesAroundListInfo> GetShyneesAroundList();
    }
}
