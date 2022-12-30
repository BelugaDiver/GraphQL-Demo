using GraphQL.Types;
using GraphQL_Demo.DataLayer.Model;

namespace GraphQL_Demo.GraphLayer.GraphTypes
{
    /// <summary>
    /// The StudentType class represents a graphql data model of a student.
    /// </summary>
    public class StudentType : ObjectGraphType<Student>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StudentType() : base()
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Email);
            Field(x => x.Age);
            Field(x => x.Courses);
        }
    }
}
