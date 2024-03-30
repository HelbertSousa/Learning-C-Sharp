using Microsoft.EntityFrameworkCore;
using MinimalCrud.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Hello Cruel World!!", () => "Hello Cruel World");

app.MapGet("/Student", async (ApDbContext dbContext) =>
{
    return await dbContext.Students.ToListAsync();
});

app.MapGet("/Student/{id}", async (ApDbContext dbContext, Guid id) =>
{
    var student = await dbContext.Students.FindAsync(id);
    if (student == null)
    {
        return Results.NotFound("The student couldn't be found.");
    }
    return Results.Ok(student);
});

app.MapPost("/Student", async (ApDbContext dbContext, MinimalCrud.Model.StudentModel student) =>
{
    dbContext.Students.Add(student);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/students/{student.Id}", student);
});

app.MapPut("/Student", async (ApDbContext dbContext, MinimalCrud.Model.StudentModel student) =>
{
    var editStudent = await dbContext.Students.AsNoTracking().FirstOrDefaultAsync(editStudent => editStudent.Id == student.Id);
    
    if (editStudent is null) return Results.BadRequest("You can't edit a missing student");

    dbContext.Entry(editStudent).CurrentValues.SetValues(student);

    dbContext.Students.Update(editStudent);
    
    await dbContext.SaveChangesAsync();
    return Results.Ok("Student Update");
});

app.MapDelete("/Student/{id}", async (ApDbContext dbContext, Guid id) =>
{
    var student = await dbContext.Students.FindAsync(id);
    if (student == null)
    {
        return Results.NotFound("The student couldn't be found.");
    }
    dbContext.Students.Remove(student);
    await dbContext.SaveChangesAsync();
    return Results.Ok("Student deleted");
});

app.Run();
