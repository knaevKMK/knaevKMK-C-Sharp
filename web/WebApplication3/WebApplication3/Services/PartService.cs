using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Repositories;
using WebApplication3.Views.ImoprtDto;

namespace WebApplication3.Services
{
    public class PartService : IPartService
    {
        private readonly SupplierRepository supplierRepository;
        private readonly PartRepository PartRepository;
        //   private readonly IMapper mapper;

        public PartService(
            PartRepository PartRepository
            , SupplierRepository suppler
            //,IMapper mapper
            )
        {
            this.PartRepository = PartRepository;
            this.supplierRepository = suppler;
            //     this.mapper = mapper;
        }



        public bool IsImported()
        {
            return !PartRepository.IsEmpty();
        }
        public PartDto AddPart(PartDto carDto)
        {

            //ToDo
            throw new NotImplementedException();



        }

        public ICollection<PartDto> AllParts()
        {


            //ToDo
            throw new NotImplementedException();
        }

        public PartDto DeletePart(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public PartDto GetPartById(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public PartDto Update(PartDto PartDto)
        {
            //ToDo
            throw new NotImplementedException();
        }




        public void ImportFromJson()
        {

            ICollection<PartDto> partDtos = JsonConvert.DeserializeObject<ICollection<PartDto>>(File.ReadAllText("./Data/ImportFromFile/parts.json"));

            foreach (var partDto in partDtos)
            {
                try
                {
                    Part part = new Part()
                    {
                        Name = partDto.name,
                        Prce = partDto.price,
                        Quantty = partDto.quantity,
                        
                    };
                    Supplier supplier = supplierRepository.GetById(partDto.SupplierId);
                    if (supplier==null)
                    {
                        continue;
                    }
                    part.Supplier = supplier;
                    PartRepository.Add(part);
                }
                catch (Exception) { continue; }
            }


        }

    }
}
