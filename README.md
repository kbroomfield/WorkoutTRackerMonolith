# WorkoutTRackerMonolith

## Requirements
* Node JS 8+
* .NET Core 2.2 SDK
* Angular CLI
* Docker


## Development
1. Start the Postgres database with Docker command `docker run --name workoutdb -e POSTGRES_DB=workoutdb -e POSTGRES_USER=kingswole -e POSTGRES_PASSWORD=kingswole -p 6543:5432 -d postgres`
2. Restore client package requirements. CD into ClientApp and run `yarn` or `npm i`
3. Start the client with `ng serve`
4. Run the .NET Core app with the default launch settings
5. Navigate to `https://localhost:5001` and enjoy

## Production
1. Update the WorkoutTRackerMonolith.csproj file to include production references for a SPA app.
2. Create a dockerfile for .NET project
3. In the the outer directory create a docker-compose.yml file, add postgres with relevant env variables, add the WorkoutTRacker image and make it depend on the postgres image
4. ....
5. Enjoy your production app, thanks for doing all the work!