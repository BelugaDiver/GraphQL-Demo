using GraphQL;
using GraphQL.Types;
using GraphQL_Demo;
using GraphQL_Demo.DataLayer.Interfaces;
using GraphQL_Demo.DataLayer.Repositories;
using GraphQL_Demo.GraphLayer;

var builder = WebApplication.CreateBuilder(args);

// Inject dependencies necessary for the graph schema.
builder.Services.AddSingleton(
    provider => StudentSingletonRepository.GetSingleton(SampleData.GetStudents())
);

builder.Services.AddSingleton(
    provider => CourseSingletonRepository.GetSingleton(SampleData.GetCourses())
);

builder.Services.AddScoped<IStudentRepository, StudentSingletonRepository>(
    provider => provider.GetRequiredService<StudentSingletonRepository>()
);

builder.Services.AddScoped<ICourseRepository, CourseSingletonRepository>(
    provider => provider.GetRequiredService<CourseSingletonRepository>()
);

builder.Services.AddScoped<ISchema, GraphSchema>(
    provider => new GraphSchema(
        provider.GetRequiredService<IStudentRepository>(),
        provider.GetRequiredService<ICourseRepository>()
    )
 );

builder.Services.AddSingleton(
    provider => new GraphQuery(
        provider.GetRequiredService<IStudentRepository>(),
        provider.GetRequiredService<ICourseRepository>()
    )
);

// Automatically generate the graphql schema.
builder.Services.AddGraphQL(
    b => b
        .AddAutoSchema<ISchema>() // schema
        .AddSystemTextJson()
).AddLogging(c => c.AddConsole()); // serializer

var app = builder.Build();

app.UseGraphQL("/graphql");
app.UseGraphQLGraphiQL("/", 
    new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions
    {
        GraphQLEndPoint = "/graphql",
        SubscriptionsEndPoint = "/graphql"
    }
);

app.Run();
