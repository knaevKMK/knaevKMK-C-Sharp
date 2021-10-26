

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

        public IQueryable<User> SortBy(SortBindDto sort)
        {
            var query = base.data.Set<User>().Where(u => u.Id != null);


            switch (sort.SortBy.ToLower())
            {
               
                case "id":
                    query = checkArrow(sort.Arrow.ToLower()) 
                        ? query.OrderByDescending(u => u.Id)
                        : query.OrderBy(u => u.Id); break;
                case "name":
                    query = checkArrow(sort.Arrow.ToLower()) ? query.OrderByDescending(u => u.FullName)
           : query.OrderBy(u => u.FullName); break;
                case "department":
                    query = checkArrow(sort.Arrow.ToLower()) ? query.OrderByDescending(u => u.Department.Name)
      : query.OrderBy(u => u.Department.Name); break;
                case "education":
                    query = checkArrow(sort.Arrow.ToLower()) ? query.OrderByDescending(u => u.Education)
      : query.OrderBy(u => u.Education); break;
                case "score":
                    query = checkArrow(sort.Arrow.ToLower()) ? query.OrderByDescending(u => u.Score)
          : query.OrderBy(u => u.Score); break;
                case "birthyear":
                    query = checkArrow(sort.Arrow.ToLower()) ? query.OrderByDescending(u => u.BirthDate.Year)
      : query.OrderBy(u => u.BirthDate.Year); break;
            }

                    return query;
        }

        private bool checkArrow(string sort)
        {
            return sort.Equals("desc");
        }
    }
 }

