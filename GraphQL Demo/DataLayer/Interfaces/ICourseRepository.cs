using GraphQL_Demo.DataLayer.Model;

namespace GraphQL_Demo.DataLayer.Interfaces
{
    /// <summary>
    /// The ICourseRepository describes a component capable of managing and delivering courses.
    /// </summary>
    public interface ICourseRepository : IObjectRepository<Course>
    {
    }
}
