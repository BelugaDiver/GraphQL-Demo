using GraphQL;
using GraphQL.Types;
using GraphQL_Demo.DataLayer.Interfaces;
using GraphQL_Demo.DataLayer.Model;
using GraphQL_Demo.GraphLayer.GraphTypes;

namespace GraphQL_Demo.GraphLayer
{
    /// <summary>
    /// The GraphQuery class defines graphql queries and their resolvers.
    /// </summary>
    public class GraphQuery : ObjectGraphType
    {
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public GraphQuery(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;

            SetupStudentQueries();
            SetupCourseQueries();
        }

        /// <summary>
        /// Sets up gql queries that can be used to retrieve courses and students with different characteristics
        /// </summary>
        public void SetupStudentQueries()
        {
            Field<ListGraphType<StudentType>>("students").Argument<StudentInputType>("student").Description("Gets a list of students.")
                .Resolve(context => _studentRepository.Get(context.GetArgument<Student>("student")));

            Field<StudentType>("student").Argument<IdGraphType>("id").Description("Gets a single student.")
                .Resolve(context => _studentRepository.Get(context.GetArgument<string>("id")));
        }

        public void SetupCourseQueries()
        {
            Field<ListGraphType<CourseType>>("courses").Argument<CourseInputType>("course").Description("Gets a list of courses.")
                .Resolve(context => _courseRepository.Get(context.GetArgument<Course>("course")));

            Field<CourseType>("course").Argument<IdGraphType>("id").Description("Gets a single course.")
                .Resolve(context => _courseRepository.Get(context.GetArgument<string>("id")));
        }
    }
}
