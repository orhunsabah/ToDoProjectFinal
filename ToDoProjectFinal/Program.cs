using ToDoProjectFinal.Controllers;
using ToDoProjectFinal.Data.SubToDoData;
using ToDoProjectFinal.Data.ToDoData;
using ToDoProjectFinal.Data.UserData;
using ToDoProjectFinal.Data.Utils;
using ToDoProjectFinal.Services.SubToDoServices;
using ToDoProjectFinal.Services.ToDoServices;
using ToDoProjectFinal.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



var connectionString = "Server = localhost; Database = TodoFinal; Trusted_Connection=True;";

builder.Services.AddSingleton<IProjectDbConnection>(s => new ProjectDbConnection(connectionString));


//User
builder.Services.AddSingleton<IGetAllUsersServiceRequest, GetAllUsersServiceRequest>();
builder.Services.AddSingleton<IGetAllUsersDataRequest, GetAllUsersDataRequest>();
builder.Services.AddSingleton<IGetUserByIdServiceRequest, GetUserByIdServiceRequest>();
builder.Services.AddSingleton<IGetUserByIdDataRequest, GetUserByIdDataRequest>();
builder.Services.AddSingleton<IDeleteUserByIdServiceRequest, DeleteUserByIdServiceRequest>();
builder.Services.AddSingleton<IDeleteUserByIdDataRequest, DeleteUserByIdDataRequest>();
builder.Services.AddSingleton<IInsertUserDataRequest, InsertUserDataRequest>();
builder.Services.AddSingleton<IInsertUserServiceRequest, InsertUserServiceRequest>();
builder.Services.AddSingleton<IUpdateUserByIdDataRequest, UpdateUserByIdDataRequest>();
builder.Services.AddSingleton<IUpdateUserByIdServiceRequest, UpdateUserByIdServiceRequest>();

//ToDo
builder.Services.AddSingleton<IGetAllToDosDataRequest, GetAllToDosDataRequest>();
builder.Services.AddSingleton<IGetAllToDosServiceRequest, GetAllToDosServiceRequest>();
builder.Services.AddSingleton<IGetToDoByIdServiceRequest, GetToDoByIdServiceRequest>();
builder.Services.AddSingleton<IGetToDoByIdDataRequest, GetToDoByIdDataRequest>();
builder.Services.AddSingleton<IDeleteToDoByIdDataRequest, DeleteToDoByIdDataRequest>();
builder.Services.AddSingleton<IDeleteToDoByIdServiceRequest, DeleteToDoByIdServiceRequest>(); 
builder.Services.AddSingleton<IInsertToDoDataRequest, InsertToDoDataRequest>();
builder.Services.AddSingleton<IInsertToDoServiceRequest, InsertToDoServiceRequest>();
builder.Services.AddSingleton<IUpdateToDoByIdDataRequest, UpdateToDoByIdDataRequest>();
builder.Services.AddSingleton<IUpdateToDoByIdServiceRequest, UpdateToDoByIdServiceRequest>();
builder.Services.AddSingleton<IGetProgressOfToDoByIdDataRequest, GetProgressOfToDoByIdDataRequest>();
builder.Services.AddSingleton<IGetProgressOfToDoByIdServiceRequest, GetProgressOfToDoByIdServiceRequest>();
builder.Services.AddSingleton<IChangeProgressOfToDoDataRequest, ChangeProgressOfToDoDataRequest>();
builder.Services.AddSingleton<ISwitchToDoDoneDataRequest, SwitchToDoDoneDataRequest>();

//SubToDo
builder.Services.AddSingleton<IGetAllSubToDosDataRequest, GetAllSubToDosDataRequest>();
builder.Services.AddSingleton<IGetAllSubToDosServiceRequest, GetAllSubToDosServiceRequest>();
builder.Services.AddSingleton<IGetSubToDoByIdDataRequest, GetSubToDoByIdDataRequest>();
builder.Services.AddSingleton<IGetSubToDoByIdServiceRequest, GetSubToDoByIdServiceRequest>();
builder.Services.AddSingleton<IDeleteSubToDoByIdDataRequest, DeleteSubToDoByIdDataRequest>();
builder.Services.AddSingleton<IDeleteSubToDoByIdServiceRequest, DeleteSubToDoByIdServiceRequest>();
builder.Services.AddSingleton<IInsertSubToDoDataRequest, InsertSubToDoDataRequest>();  
builder.Services.AddSingleton<IInsertSubToDoServiceRequest, InsertSubToDoServiceRequest>();
builder.Services.AddSingleton<IGetSumOfDoneSubToDosByToDoIdServiceRequest, GetSumOfDoneSubToDosByToDoIdServiceRequest>();
builder.Services.AddSingleton<IGetSumOfDoneSubToDosByToDoIdDataRequest, GetSumOfDoneSubToDosByToDoIdDataRequest>();
builder.Services.AddSingleton<IGetEffectPercentageOfSubToDoBySubToDoIdDataRequest, GetEffectPercentageOfSubToDoBySubToDoIdDataRequest>();
builder.Services.AddSingleton<IGetEffectPercentageOfSubToDoBySubToDoIdServiceRequest, GetEffectPercentageOfSubToDoBySubToDoIdServiceRequest>();
builder.Services.AddSingleton<IDeleteAllSubToDosByToDoIdServiceRequest, DeleteAllSubToDosByToDoIdServiceRequest>();
builder.Services.AddSingleton<IDeleteAllSubToDosByToDoIdDataRequest, DeleteAllSubToDosByToDoIdDataRequest>();
builder.Services.AddSingleton<IGetCountOfSubToDosByToDoIdDataRequest, GetCountOfSubToDosByToDoIdDataRequest>();
builder.Services.AddSingleton<IGetCountOfSubToDosByToDoIdServiceRequest, GetCountOfSubToDosByToDoIdServiceRequest>();
builder.Services.AddSingleton<IGetToDoIdBySubToDoIdDataRequest, GetToDoIdBySubToDoIdDataRequest>();
builder.Services.AddSingleton<ISwitchSubToDoDoneDataRequest, SwitchSubToDoDoneDataRequest>();
builder.Services.AddSingleton<ISwitchSubToDoDoneServiceRequest, SwitchSubToDoDoneServiceRequest>();

builder.Services.AddSingleton<ToDoController>();
builder.Services.AddSingleton<SubToDoController>();
builder.Services.AddSingleton<UserController>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
