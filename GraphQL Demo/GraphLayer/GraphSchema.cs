using GraphQL.Types;
using GraphQL_Demo.DataLayer.Interfaces;

namespace GraphQL_Demo.GraphLayer
{
    /// <summary>
    /// The GraphSchema class defines the schema/entry point for all graph queries.
    /// Only one schema can be applied at a time.
    /// </summary>
    public class GraphSchema : Schema
    {
        /// <summary>
        /// Constructor that allows for dependency injection of the student repository and the course repository
        /// </summary>
        /// <param name="studentRepository">Student repository that manages students.</param>
        /// <param name="courseRepository">Course repository that manages courses.</param>
        public GraphSchema(IStudentRepository studentRepository, ICourseRepository courseRepository) 
        { 
            Query = new GraphQuery(studentRepository, courseRepository);
        }
    }
}
