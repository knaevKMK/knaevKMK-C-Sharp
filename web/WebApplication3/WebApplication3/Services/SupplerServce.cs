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
    public class SupplerServce : ISupplerServce
    {

        private readonly SupplierRepository SupplierRepository;
        public SupplerServce(
            SupplierRepository SupplierRepository
            //,IMapper mapper
            )
        {
            this.SupplierRepository = SupplierRepository;
            //     this.mapper = mapper;
        }



        public bool IsImported()
        {
            return !SupplierRepository.IsEmpty();
        }
        public SupplierDto Add(SupplierDto supplierDto)
        {

            Supplier suppler = map(supplierDto);


            SupplierRepository.Add(suppler);

            return supplierDto;
        }

        public ICollection<SupplierDto> All()
        {


            //ToDo
            throw new NotImplementedException();
        }

        public SupplierDto Delete(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public SupplierDto GetById(int id)
        {
            //ToDo
            throw new NotImplementedException();
        }

        public SupplierDto Update(SupplierDto supplierDto)
        {
            //ToDo
            throw new NotImplementedException();
        }




        public void ImportFromJson()
        {

            ICollection<SupplierDto> supplierDtos = JsonConvert.DeserializeObject<ICollection<SupplierDto>>(File.ReadAllText("./Data/ImportFromFile/suppliers.json"));

            Console.WriteLine();
            foreach (var supplierDto in supplierDtos)
            {
                try
                {
                    Add(supplierDto);

                }
                catch (Exception)
                {

                    continue;
                }


            }


        }

        private Supplier map(SupplierDto supplierDto)
        {
            return new Supplier()
            {
                Name = supplierDto.name,
                IsImporter = supplierDto.isImporter
            };
        }
    }
}
