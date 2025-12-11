# Video Game Catalogue System

This project is a simple **full-stack CRUD application** built with:

- **ASP.NET Core ASP.NET Core 10.0,** (REST API + SQL Server LocalDB)
- **Angular 21** (Standalone components, Signals, Template-driven forms)
- **Bootstrap 5.3** 

---

# Features

### **Backend (ASP.NET Core)**
- REST API with CRUD endpoints for `Game`
- SQL Server LocalDB persistence
- EF Core migrations + seeded data
- Validation and safe API usage
- CORS configured for Angular dev environment

### **Frontend (Angular)**
- Standalone components
- Angular Signals for state
- Template-driven validation
- Reusable `<app-game-form>`
- Pages:
  - Games List
  - Create Game
  - Edit Game
- Bootstrap-styled UI

---

# ⚙️ Backend Setup (ASP.NET Core)

## 1. Ensure LocalDB is installed

```
sqllocaldb i
sqllocaldb start MSSQLLocalDB
```

---

## 2. Install EF Core CLI (if not installed)

```
dotnet tool install --global dotnet-ef
```

---

## 3. Run the EF Core migration

```
cd Newton.VideoGameCatalogue.Server
dotnet ef database update
```

This will:

- Create the `VideoGameCatalogue` database  
- Create the `Games` table  
- Insert seeded game data  

---

## 4. Run the backend

```
dotnet run
```

API will start on:

```
https://localhost:7241/api/games
```

---

# Frontend Setup (Angular)

## 1. Install dependencies

```
cd newton.videogamecatalogue.client
npm install
```

---

## 2. Configure API URL  
Location:

```
client/src/environments/environment.ts
```

Example:

```
export const environment = {
  apiUrl: 'https://localhost:7241/api'
};
```

---

## 3. Start Angular dev server

```
ng serve
```

Frontend will run at:

```
http://localhost:4200
```

---

# UI Overview

### Games Page
- Displays list of all games  
- Edit/Delete buttons  
- “Add New Game” button  

### Create Game Page
- Uses `<app-game-form>`  
- Validated template-driven form  
- On submit → calls POST API  

### Edit Game Page
- Loads game by route param  
- Prefills form via `@Input()`  
- On submit → calls PUT API  

---

# API Endpoints

### **GET** /api/games  
Returns all games.

### **GET** /api/games/{id}  
Returns a single game.

### **POST** /api/games  
Creates a new game.

### **PUT** /api/games/{id}  
Updates an existing game.

### **DELETE** /api/games/{id}  
Deletes a game.

Please see /swagger/index.html while the backend server is running.

---

# Running Both Apps Together

Backend:

```
cd Newton.VideoGameCatalogue.Server
dotnet run
```

Frontend:

```
cd client
ng serve
```

Open:

```
http://localhost:4200
```