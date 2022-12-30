using GraphQL.Types;
using GraphQL_Demo.DataLayer.Model;

namespace GraphQL_Demo.GraphLayer.GraphTypes
{
    /// <summary>
    /// The CourseType class represents a graphql data model of a course.
    /// </summary>
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType() : base()
        {
            Field(x => x.Id);
            Field(x => x.CourseName);
        }
    }
}
