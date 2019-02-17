# WorkoutTRackerMonolith

## Requirements
* Node JS 8+
* .NET Core 2.2 SDK
* Angular CLI
* Docker


## Development
1. Start the Postgres database with Docker command `docker run --name workoutdb -e POSTGRES_DB=workoutdb -e POSTGRES_USER=kingswole -e POSTGRES_PASSWORD=kingswole -p 5432:5432 -d postgres`
2. Run migrations (CD to project folder and run `dotnet ef database update`
3. Restore client package requirements. CD into ClientApp and run `yarn` or `npm i`
4. Start the client with `ng serve`
5. Run the .NET Core app