using MovieCatalogue.Shared;
using System.Collections.Generic;

namespace MovieCatalogue.Api.Models
{
    public interface IJobCategoryRepository
    {
        IEnumerable<JobCategory> GetAllJobCategories();
        JobCategory GetJobCategoryById(int jobCategoryId);
    }
}