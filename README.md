# Helsinki City Bike App (work in progress)

# Project Background

This project is based on the [Solita Dev Academy pre-assignment](https://github.com/solita/dev-academy-2023-exercise) (I didn't apply for the position). The task was to create a user interface and backend service to display information about city bike trips in the metropolitan area in summer 2021.

# Implementation

I chose .NET Blazor Webassembly app technology for this task because I didn't have much experience with it. I wanted to review the learned material at the same time. I also hadn't independently completed a project this large in one go before. I have been involved in group projects where I had different responsibilities. At Savonia University of Applied Sciences, I completed one course on the .net topic, but the only task on that course was to pass the given tests from ten half-finished projects, not so much a production-related task.

# Database

SQLite was chosen as the project's database. Initially, I planned to use Mongo DB, but there was too much data for a free subscription, even after removing the requested parts before transferring the data to the server. While developing the program, I had to hardcode a limit on the amount of data retrieved, so Mongo DB might have worked better in the end. I take this as a learning experience. NOTE: The database is not included in the repository because its size is over 500mb. It can be downloaded from here (link coming later) and must be placed in the root of the server folder.

# Blazor webassembly

Blazor WebAssembly is a web application framework by Microsoft that enables developers to build interactive web applications using C# instead of JavaScript. It allows developers to create and run client-side web applications entirely in the browser, without the need for server-side code. This approach provides a more seamless experience for the user and enables better performance and security.

# Views

The project has five views (pages).

## Index.razor: 
Displays a greeting, information on whether the API is operational, and lists statistics on popular stations. This data works best when not limited by hardcoding.
![Screenshot](/Screenshots/index.png)

## Trips.razor:
Displays all trips (limited to 100). Trips can be filtered by search criteria.
![Screenshot](/Screenshots/trips.png)

## TripsDetails.razor:
Displays the selected trip's information.
![Screenshot](/Screenshots/tripsDetails.png)

## Stations.razor:
Displays all stations. Due to the "few" stations, it is not limited, but automatic filtering is set to 150 trips. The user can change this if desired.
![Screenshot](/Screenshots/stations.png)

## StationDetails.razor: 
Displays the selected station's information.
![Screenshot](/Screenshots/stationsDetails.png)

# TODO

- Tests
- Add more responsiveness
- Virtual pages for trips
- fix css issues with element sizes
- Add rest of the statics
- something special <3

# Graphics

- [Loading tier](https://giphy.com/stickers/gulo-gmx-25-LkQjHi1rULwOA1oFWU)
- [Custom icons](https://icons8.com/icon/set/popular/small)
- [Color palette](https://coolors.co/palettes/trending)
- [Background image](https://stock.adobe.com/fi/)
