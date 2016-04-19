using System.Collections.Generic;
using Hiking.Models;

namespace Hiking.Services
{
    public interface ISATrailsService
    {
        List<Trail> GetTrailsList();
        void AddTrail(Trail trail);

        Trail GetOneTrail(int id);
        void EditTrail(Trail trail);
    }
}