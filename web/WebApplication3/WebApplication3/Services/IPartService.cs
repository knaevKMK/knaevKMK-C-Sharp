using System.Collections.Generic;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Services
{
    public interface IPartService
    {
        PartDto AddPart(PartDto carDto);
        ICollection<PartDto> AllParts();
        PartDto DeletePart(int id);
        PartDto GetPartById(int id);
        void ImportFromJson();
        bool IsImported();
        PartDto Update(PartDto PartDto);
    }
}