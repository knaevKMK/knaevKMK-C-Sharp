

namespace evnServer.Data.Repositories
{
    using evnServer.Model.Binding;
    using evnServer.Model.Entity;
    using System.Linq;
    using System.Reflection;
    public class UserRepository : Repository<User>, IUserRepository
    {
        
        public UserRepository(ApplicationDbContext data) : base(data)
        {
        }

        public IQueryable<User> Sort(FilterDto sort)
        {
            var query = base.data.Set<User>().Where(u => u.Id != null);
            PropertyInfo[] properties = typeof(FilterDto).GetProperties();
            foreach (var field in properties)
            {
                var _value = field.GetValue(sort);
                if (_value == null)
                {
                    continue;
                }

                switch (field.Name)
                {
                    //sort
                    case "IdSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Id)
                 : query.OrderBy(u => u.Id); break;
                    case "NameSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.FullName)
               : query.OrderBy(u => u.FullName); break;
                    case "DeprtmentSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Department)
          : query.OrderBy(u => u.Department); break;
                    case "EdicationSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.Education)
          : query.OrderBy(u => u.Education); break;
                    case "ScoreSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => (int)u.Score)
              : query.OrderBy(u => (int)u.Score); break;
                    case "BirthYearSort":
                        query = (byte)_value == (byte)1 ? query.OrderByDescending(u => u.BirthDate.Year)
          : query.OrderBy(u => u.BirthDate.Year); break;


                    // filter
                    case "Name": query = query.Where(u => u.FullName.Contains(sort.Name)); break;
                    case "Department": query = query.Where(u => u.Department.Name.Equals(sort.Department)); break;
                    case "Education": query = query.Where(u => u.Education.Contains(sort.Education)); break;
                    case "Score":
                        query =
                  sort.ArrowScore == null
                  ? query.Where(u => u.Score == (int)_value)
                  : sort.ArrowScore == 0
                                      ? query.Where(u => u.Score < sort.Score)
                                      : query.Where(u => u.Score > sort.Score); break;
                    case "BirthYaer":
                        query =
           sort.ArrowBirth == null
            ? query.Where(u => u.BirthDate.Year == (int)_value)
            : sort.ArrowBirth == 0 ? query.Where(u => u.BirthDate.Year < sort.BirthYaer)
                                    : query.Where(u => u.BirthDate.Year > sort.BirthYaer); break;


                }

            }
            return query;
        }
    }
 }

