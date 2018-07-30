using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneesAroundListInfo> GetShyneesAroundList(ShyneeCoordinates shyneeCoordinates);

        Shynee GetShynee(Guid id);
    }
}
