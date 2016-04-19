using System.Collections.Generic;
using Hiking.Models;

namespace Hiking.Services
{
    public interface ISATrailsService
    {
        List<Trail> GetTrailsList();
    }
}