using GraphQL.Types;
using GraphQL_Demo.DataLayer.Model;

namespace GraphQL_Demo.GraphLayer.GraphTypes
{
    /// <summary>
    /// The CourseInputType class represents a graphql data model of a course used for input.
    /// </summary>
    public class CourseInputType : InputObjectGraphType<Course>
    {
        public CourseInputType() : base()
        {
            Field(x => x.Id);
            Field(x => x.CourseName);
        }
    }
}
