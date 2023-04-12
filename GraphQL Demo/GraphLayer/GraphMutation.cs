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
    public class GraphMutation : ObjectGraphType
    {
        private IStudentRepository _studentRepository;
        private ICourseRepository _courseRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public GraphMutation(IStudentRepository studentRepository, ICourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;

            SetupStudentMutations();
            SetupCourseMutations();
        }

        public void SetupStudentMutations()
        {
            Field<StudentType>("createStudent").Argument<NonNullGraphType<StudentInputType>>("student")
                .Resolve(context => _studentRepository.Add(context.GetArgument<Student>("student")));

            Field<StudentType>("updateStudent").Argument<NonNullGraphType<StudentInputType>>("student")
                .Resolve(context => _studentRepository.Update(context.GetArgument<Student>("student").Id, context.GetArgument<Student>("student")));
        }

        public void SetupCourseMutations()
        {
            Field<CourseType>("createCourse").Argument<NonNullGraphType<CourseInputType>>("course")
                .Resolve(context => _courseRepository.Add(context.GetArgument<Course>("course")));

            Field<CourseType>("updateCourse").Argument<NonNullGraphType<CourseInputType>>("course")
                .Resolve(context => _courseRepository.Update(context.GetArgument<Course>("course").Id, context.GetArgument<Course>("student")));
        }
    }
}
