using System.Collections.Generic;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Services
{
    public interface ISupplerServce
    {
        SupplierDto Add(SupplierDto supplierDto);
        ICollection<SupplierDto> All();
        SupplierDto Delete(int id);
        SupplierDto GetById(int id);
        void ImportFromJson();
        bool IsImported();
        SupplierDto Update(SupplierDto supplierDto);
    }
}