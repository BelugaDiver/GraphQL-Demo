using GraphQL.Types;
using GraphQL_Demo.DataLayer.Model;

namespace GraphQL_Demo.GraphLayer.GraphTypes
{
    /// <summary>
    /// The StudentInputType class represents a graphql data model of a student for input.
    /// </summary>
    public class StudentInputType : InputObjectGraphType<Student>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StudentInputType() : base()
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
